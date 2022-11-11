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

  [HttpGet("vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>> GetAccVaultsWithP()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> Vaults = _vs.GetAccVaultsWithP(userInfo.Id);
      return Ok(Vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut]
  public async Task<ActionResult<Account>> EditAccount([FromBody] Account acc)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Account a = _accountService.Edit(acc, userInfo.Email);
      return Ok(a);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
