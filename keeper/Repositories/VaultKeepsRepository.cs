namespace keeper.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep GetKByVKId(int id)
  {
    string sql = @"
    Select vk.*, k.* from vaultKeeps vk
    Join keeps k On k.id = vk.keepId
    Where vk.id = @id;";
    return _db.Query<VaultKeep, Keep, VaultKeep>(sql, (vk, k) =>
    {
      vk.Keep = k;
      return vk;
    }, new { id }).FirstOrDefault();
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
    VaultKeep vk = GetKByVKId(vkData.Id);
    return vk;
  }

  internal void DeleteVK(int id)
  {
    string sql = @"
    Delete From vaultKeeps vk
    Where vk.id = @id;
    ";
    _db.Execute(sql, new { id });
  }

  internal List<VaultKeep> GetKsByVId(int id)
  {
    // TODO populate creator, check if I want to select from vault keep table, see if I want to swap up my model from vks
    // NOTE I think it wanted the array returned to just be keeps
    string sql = @"
    Select vk.*, k.* from vaultKeeps vk
    Left Join keeps k On k.id = vk.keepId
    Where vk.vaultId = @id;";
    return _db.Query<VaultKeep, Keep, VaultKeep>(sql, (vk, k) =>
    {
      vk.Keep = k;
      return vk;
    }, new { id }).ToList();
  }
}