namespace keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;
  private readonly VaultsService _vs;
  private readonly KeepsService _ks;

  public VaultKeepsService(VaultKeepsRepository vkr, VaultsService vs, KeepsService ks)
  {
    _vkr = vkr;
    _vs = vs;
    _ks = ks;
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
    Vault v = _vs.GetVaultById(vkData.VaultId);
    if (v.CreatorId != vkData.CreatorId)
    {
      throw new Exception("Thats not your vault!");
    }
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
    _ks.lowerKeptCount(vk.KeepId);
    _vkr.DeleteVK(id);
  }

  internal List<VaultedKeep> GetKsByVId(int id)
  {
    return _vkr.GetKsByVId(id);
  }
}