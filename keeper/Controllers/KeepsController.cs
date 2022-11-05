namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _ks;
  private readonly Auth0Provider _au;

  public KeepsController(KeepsService ks, Auth0Provider au)
  {
    _ks = ks;
    _au = au;
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetAllKeeps()
  {
    try
    {
      List<Keep> keeps = _ks.GetAllKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{Id}")]
  public ActionResult<Keep> GetKeepById(int Id)
  {
    try
    {
      return _ks.GetKeepById(Id);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      keepData.Creator = userInfo;
      Keep keep = _ks.PostKeep(keepData);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{Id}")]
  [Authorize]
  public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep keepData, int Id)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      keepData.Creator = userInfo;
      keepData.CreatorId = userInfo.Id;
      Keep NewKeep = _ks.EditKeep(keepData, Id);
      return Ok(NewKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> DeleteKeep(int keepId)
  {
    try
    {
      Account userInfo = await _au.GetUserInfoAsync<Account>(HttpContext);
      var CreatorId = userInfo.Id;
      Keep DeletedKeep = _ks.DeleteKeep(keepId, CreatorId);
      return DeletedKeep;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
