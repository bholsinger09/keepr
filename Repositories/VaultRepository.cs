using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace keepr.Repositories
{

  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAll()
    {
      try
      {

        return _db.Query<Vault>("Select * FROM vaults Where userId = @UserId;");
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object GetById(int id)
    {
      try
      {

        Vault vault = _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id and userId = @UserId;", new { id });
        if (vault is null) throw new Exception("No Job with that Id.");
        return vault;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object Delete(int id)
    {
      try
      {

        int success = _db.Execute("DELETE FROM vaults WHERE id = @id and userId = @UserId;", new { id });
        if (success != 1) throw new Exception("Something went wrong with deleting.");
        return "vault deleted!";
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object Update(Vault value)
    {

      try
      {

        int success = _db.Execute(@"UPDATE vaults
               SET 
               name = @Name,
               description = @Description,
               userId = @UserId
               WHERE id = @Id;", value);
        if (success != 1) throw new Exception("Something went wrong with the update.");
        return value;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object Create(Vault vault, string userid)
    {
      try
      {

        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (name, description, userId)
                VALUES (@Name, @Description, @UserId); 
                SELECT LAST_INSERT_ID();", vault);
        if (id < 1) throw new Exception("Unable to save vault to db.");
        vault.Id = id;
        return vault;

      }
      catch (Exception e)
      {

        throw e;
      }

    }

    // public object GetVaultsByUser(string uId)
    // {

    // }
  }
}