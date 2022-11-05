namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vs;
  private readonly Auth0Provider _au;

  public VaultsController(VaultsService vs, Auth0Provider au)
  {
    _vs = vs;
    _au = au;
  }

  [HttpGet]
  public ActionResult<List<Vault>> GetAllVaults()
  {
    try
    {
      List<Vault> vaults = _vs.GetAllVaults();
      return vaults;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> PostVault([FromBody] Vault vData)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      Vault v = _vs.PostVault();
      return Ok(v);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
