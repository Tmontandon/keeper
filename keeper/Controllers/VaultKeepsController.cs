namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vks;
  private readonly Auth0Provider _au;
  private readonly KeepsService _ks;

  public VaultKeepsController(VaultKeepsService vks, Auth0Provider au, KeepsService ks)
  {
    _vks = vks;
    _au = au;
    _ks = ks;
  }

  [HttpPost]
  public async Task<ActionResult<VaultKeep>> PostVK([FromBody] VaultKeep vkData)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      vkData.CreatorId = userInfo.Id;
      VaultKeep vk = _vks.PostVK(vkData);
      _ks.upKeptCount(vk.KeepId);
      return Ok(vk);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{Id}")]
  public async Task<ActionResult<string>> DeleteVK(int Id)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      string CreatorId = userInfo.Id;
      _vks.DeleteVK(Id, CreatorId);
      // _ks.lowerKeptCount(Id);
      return Ok("Delete Successful");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
