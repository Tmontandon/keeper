namespace keeper.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }

  // NOTE MY FUNCTIONS
  internal Profile GetProfileById(string pId)
  {
    Profile p = _repo.GetById(pId);
    return p;
  }

  internal List<Keep> GetKeepsByAccId(string id)
  {
    return _repo.GetKeepsByAccId(id);
  }

  internal List<Vault> GetVaultsByUserId(string id)
  {
    return _repo.GetVaultsByUserId(id);
  }
}
