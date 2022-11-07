namespace keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkr;

  public VaultKeepsService(VaultKeepsRepository vkr)
  {
    _vkr = vkr;
  }

  internal VaultKeep PostVK(VaultKeep vkData)
  {
    VaultKeep vk = _vkr.PostVK(vkData);
    return vk;
  }
}