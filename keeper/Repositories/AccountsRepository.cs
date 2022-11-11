namespace keeper.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture,
              coverImg = @CoverImg
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }

  // NOTE MY FUNCTIONS
  internal List<Keep> GetKeepsByAccId(string id)
  {
    string sql = @"
    Select k.*, a.* From keeps k
    Join accounts a On a.id = k.creatorId
    Where k.creatorId = @id
    ;";
    return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
        {
          k.Creator = a;
          k.CreatorId = a.Id;
          return k;
        }, new { id }).ToList();

  }

  internal List<Vault> GetVaultsByAccId(string id)
  {
    string sql = @"
    Select v.*, a.* From vaults v
    Join accounts a On a.id = v.creatorId
    Where v.creatorId = @id
    ;";
    return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
        {
          v.Creator = a;
          v.CreatorId = a.Id;
          return v;
        }, new { id }).ToList();
  }

  internal List<Vault> GetVaultsByUserId(string id)
  {
    string sql = @"
    Select v.*, a.* From vaults v
    Join accounts a On a.id = v.creatorId
    Where v.creatorId = @id And v.isPrivate = false
    ;";
    return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
        {
          v.Creator = a;
          v.CreatorId = a.Id;
          return v;
        }, new { id }).ToList();
  }
}

