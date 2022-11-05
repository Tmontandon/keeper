
namespace keeper.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep PostKeep(Keep keepData)
  {
    string sql = @"
    Insert into keeps(name, description, img, creatorId)
    Values(@Name, @Description, @Img, @CreatorId);
    Select last_insert_id();
    ";
    keepData.Id = _db.ExecuteScalar<int>(sql, keepData);
    return keepData;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
    select k.*, a.* from keeps k
    join accounts a on a.id = k.creatorId;
    ";
    return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
    {
      k.Creator = a;
      return k;
    }).ToList();
  }

  internal Keep EditKeep(Keep keepData)
  {
    string sql = @"
    update keeps set 
    description = @Description,
    img = @Img,
    name = @Name
    where id = @Id
    ;";
    var rowsAffected = _db.Execute(sql, keepData);
    if (rowsAffected == 0)
    {
      throw new Exception("Update did not go through");
    }
    return keepData;
  }

  internal void DeleteKeep(Keep dKeep)
  {
    int id = dKeep.Id;
    string sql = @"
    Delete from keeps k
    where k.id = @id
    ;";
    _db.Execute(sql, new { id });
  }

  internal Keep GetKeepById(int id)
  {
    string sql = @"
    Select k.*, a.* from keeps k
    join accounts a on a.id = k.creatorId
    where k.id = @id
    ";
    return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
    {
      k.Creator = a;
      return k;
    }, new { id }).FirstOrDefault();
  }
}
