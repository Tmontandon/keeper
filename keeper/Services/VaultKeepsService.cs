namespace keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;

  public VaultKeepsService(VaultKeepsRepository vkr)
  {
    _vkr = vkr;
  }

  internal VaultKeep GetVKById(int Id)
  {
    VaultKeep selectedVK = _vkr.GetKByVKId(Id);
    if (selectedVK == null)
    {
      throw new Exception("This id doesnt apply to any keeps you've vaulted");
    }
    return selectedVK;
  }

  internal VaultKeep PostVK(VaultKeep vkData)
  {
    VaultKeep vk = _vkr.PostVK(vkData);
    return vk;
  }

  internal void DeleteVK(int id, string creatorId)
  {
    VaultKeep vk = GetVKById(id);
    if (vk.CreatorId != creatorId)
    {
      throw new Exception("Hey! This isn't yours to delete!");
    }
    _vkr.DeleteVK(id);
  }

  internal List<VaultedKeep> GetKsByVId(int id)
  {
    return _vkr.GetKsByVId(id);
  }
}