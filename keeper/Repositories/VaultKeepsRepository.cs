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

  internal List<VaultedKeep> GetKsByVId(int id)
  {
    //  TODO Ask if order of select statement (other than k and a) matters (namely Count, and As statements)
    string sql = @"
    Select
    k.*,
    Count(vk.id) As Kept,
    vk.id As VaultKeepId,
    vk.vaultId As VaultId,
    a.*
    From vaultKeeps vk
    Join keeps k On k.id = vk.keepId
    Join accounts a On a.id = k.creatorId
    Where vk.vaultId = @id
    Group By vk.id
    ";

    return _db.Query<VaultedKeep, Profile, VaultedKeep>(sql, (Vk, P) =>
    {
      Vk.Creator = P;
      Vk.CreatorId = P.Id;
      return Vk;
    }, new { id }).ToList();
  }
}


// TODO Figure out why having the keep, and creator of the keep populated onto the vaultKeep is wrong
// NOTE Generally flattened objects are more professional
// string sql = @"
// Select
// vk.*, 
// k.* 
// From vaultKeeps vk
// Join keeps k On k.id = vk.keepId
// Where vk.vaultId = @id;";
// return _db.Query<VaultKeep, Keep, VaultKeep>(sql, (vk, k) =>
// {
//   vk.Keep = k;
//   return vk;
// }, new { id }).ToList();