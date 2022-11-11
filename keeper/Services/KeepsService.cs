namespace keeper.Services;

public class KeepsService
{
  private readonly KeepsRepository _kRepo;
  private readonly VaultKeepsRepository _vkRepo;

  public KeepsService(KeepsRepository kRepo)
  {
    _kRepo = kRepo;
  }

  internal List<Keep> GetAllKeeps()
  {
    return _kRepo.GetAllKeeps();
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
      throw new Exception("This isn't your keep, go away");
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

  internal void upKeptCount(int keepId)
  {
    Keep k = GetKeepById(keepId);
    k.Kept++;
    _kRepo.changeKept(k);
  }

  internal void lowerKeptCount(int kId)
  {
    Keep k = GetKeepById(kId);
    k.Kept--;
    _kRepo.changeKept(k);
  }
}