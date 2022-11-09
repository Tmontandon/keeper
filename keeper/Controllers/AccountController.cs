namespace keeper.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vs;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vs)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _vs = vs;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("/vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>> GetAccVaultsWithP()
  {
    try
    {
      Console.WriteLine("I am working/ being called on");
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> Vaults = _vs.GetAccVaultsWithP(userInfo.Id);
      return Ok(Vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
