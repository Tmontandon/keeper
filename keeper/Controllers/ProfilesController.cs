namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly AccountService _as;

  public ProfilesController(AccountService @as)
  {
    _as = @as;
  }

  [HttpGet("{pId}")]
  public ActionResult<Profile> GetProfile(string pId)
  {
    try
    {
      Profile P = _as.GetProfileById(pId);
      return Ok(P);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/keeps")]
  public ActionResult<List<Keep>> GetKeepsByAccId(string id)
  {
    try
    {
      List<Keep> ks = _as.GetKeepsByAccId(id);
      return Ok(ks);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}/vaults")]
  public ActionResult<List<Vault>> GetVaultByUserId(string id)
  {
    try
    {
      List<Vault> vs = _as.GetVaultsByUserId(id);
      return Ok(vs);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
