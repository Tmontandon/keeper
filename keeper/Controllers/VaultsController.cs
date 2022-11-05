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
  [HttpGet("{id}")]
  public ActionResult<Vault> GetVaultById(int id)
  {
    try
    {
      Vault vault = _vs.GetVaultById(id);
      return vault;
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
      vData.CreatorId = userInfo.Id;
      Vault v = _vs.PostVault(vData);
      return Ok(v);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vData, int id)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      vData.CreatorId = userInfo.Id;
      Vault newV = _vs.EditVault(vData, id);
      return Ok(newV);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
