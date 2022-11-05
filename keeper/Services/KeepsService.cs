namespace keeper.Services;

public class KeepsService
{
  private readonly KeepsRepository _kRepo;

  public KeepsService(KeepsRepository kRepo)
  {
    _kRepo = kRepo;
  }

  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keeps = _kRepo.GetAllKeeps();
    return keeps;
  }

  internal Keep PostKeep(Keep keepData)
  {
    Keep keep = _kRepo.PostKeep(keepData);
    return keep;
  }

  internal Keep GetKeepById(int id)
  {
    Keep keep = _kRepo.GetKeepById(id);
    if (keep == null)
    {
      throw new Exception("This id doesnt apply to any keeps");
    }
    return keep;
  }

  internal Keep EditKeep(Keep keepData, int id)
  {
    Keep keep = GetKeepById(id);
    if (keep.CreatorId != keepData.CreatorId)
    {
      throw new Exception("This isnt your Keep, go away");
    }
    keep.Description = keepData.Description ?? keep.Description;
    keep.Img = keepData.Img ?? keep.Img;
    keep.Name = keepData.Name ?? keep.Name;
    return _kRepo.EditKeep(keep);
  }

  internal Keep DeleteKeep(int keepId, string creatorId)
  {
    Keep DKeep = GetKeepById(keepId);
    if (DKeep.CreatorId != creatorId)
    {
      throw new Exception("This is not yours to delete...");
    }
    _kRepo.DeleteKeep(DKeep);
    return DKeep;
  }
}