
namespace keeper.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault PostVault(Vault vData)
  {

    string sql = @"
    insert into vaults(creatorId, name, description, img, isPrivate)
    Values(@CreatorId, @Name, @Description, @Img, @IsPrivate);
    Select last_insert_id()
    ;";
    vData.Id = _db.ExecuteScalar<int>(sql, vData);
    return GetVaultById(vData.Id);
  }

  internal Vault GetVaultById(int vId)
  {
    string sql = @"
    Select v.*, a.* from vaults v
    Join accounts a On a.id = v.creatorId
    Where v.id = @vId;
    ";
    return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
    {
      v.Creator = p;
      return v;
    }, new { vId }).FirstOrDefault();
  }

  internal Vault EditVault(Vault v)
  {
    string sql = @"
    update vaults set
    name = @Name,
    description = @Description, 
    img = @Img,
    isPrivate = @IsPrivate
    where id = @Id
    ;";
    var rowsAffected = _db.Execute(sql, v);
    if (rowsAffected == 0)
    {
      throw new Exception("Edit didnt go through");
    }
    return v;
  }

  internal void DeleteVault(int id)
  {
    string sql = @"
    Delete From vaults v Where v.id = @id Limit 1
    ";
    _db.Execute(sql, new { id });
  }

  internal List<Vault> GetAccVaultsWithP(string id)
  {
    string sql = @"
    Select v.*, a.* from vaults v
    Join accounts s On a.id - v.creatorId
    Where v.creatorId = @id
    ;";
    return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
        {
          v.Creator = p;
          return v;
        }, new { id }).ToList();
  }
}

