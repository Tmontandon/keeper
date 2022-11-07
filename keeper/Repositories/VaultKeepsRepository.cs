namespace keeper.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep PostVK(VaultKeep vkData)
  {
    var sql = @"
    Insert Into vaultKeeps
    (creatorId, vaultId, keepId)
    Values
    (@CreatorId, @VaultId, @KeepId);
    Select Last_Insert_Id();
    ";
    vkData.Id = _db.ExecuteScalar<int>(sql, vkData);
    // TODO Make a get by Id and apply here so Keep is populated
    return vkData;
  }
}