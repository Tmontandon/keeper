namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vs;
  private readonly VaultKeepsService _vks;
  private readonly Auth0Provider _au;

  public VaultsController(VaultsService vs, VaultKeepsService vks, Auth0Provider au)
  {
    _vs = vs;
    _vks = vks;
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
  public async Task<ActionResult<Vault>> GetVaultByIdAsync(int id)
  {
    try
    {
      Vault vault = _vs.GetVaultById(id);
      if (vault.IsPrivate)
      {
        await CheckAuth(vault);
      }
      return vault;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/keeps")]
  public async Task<ActionResult<List<VaultedKeep>>> GetVksByVaultIdAsync(int id)
  {
    try
    {
      Vault v = _vs.GetVaultById(id);
      if (v.IsPrivate)
      {
        await CheckAuth(v);
      }
      List<VaultedKeep> keeps = _vks.GetKsByVId(id);
      return keeps;
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

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteVault(int id)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      string CreatorId = userInfo.Id;
      _vs.DeleteVault(id, CreatorId);
      return Ok("Delete Successful");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  public async Task<bool> CheckAuth(Vault v)
  {
    Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
    if (v.CreatorId != userInfo.Id)
    {
      throw new Exception("You are not authorized");
    }
    return true;
  }


}
