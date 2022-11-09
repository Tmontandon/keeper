namespace keeper.Services;

public class VaultsService
{
  private readonly VaultsRepository _vr;

  public VaultsService(VaultsRepository vr)
  {
    _vr = vr;
  }

  internal List<Vault> GetAccVaultsWithoutP()
  {
    throw new NotImplementedException();
  }

  internal Vault PostVault(Vault vData)
  {
    return _vr.PostVault(vData);
  }

  internal Vault GetVaultById(int id)
  {
    Vault selectedV = _vr.GetVaultById(id);
    if (selectedV == null)
    {
      throw new Exception("This id doesnt apply to any vaults");
    }
    return selectedV;
  }

  internal List<Vault> GetAllVaults()
  {
    throw new NotImplementedException();
  }

  internal Vault EditVault(Vault vData, int id)
  {
    Vault v = GetVaultById(id);
    if (v.CreatorId != vData.CreatorId)
    {
      throw new Exception("This is not your vault to edit...");
    }
    v.Name = vData.Name ?? v.Name;
    v.Description = vData.Description ?? v.Description;
    v.Img = vData.Img ?? v.Img;
    v.IsPrivate = vData.IsPrivate;

    return _vr.EditVault(v);
  }

  internal void DeleteVault(int id, string creatorId)
  {
    Vault v = GetVaultById(id);
    if (v.CreatorId != creatorId)
    {
      throw new Exception("You cant delete something you haven't made >:( ");
    }
    _vr.DeleteVault(id);
  }

  internal List<Vault> GetAccVaultsWithP(string id)
  {
    return _vr.GetAccVaultsWithP(id);
  }
}

