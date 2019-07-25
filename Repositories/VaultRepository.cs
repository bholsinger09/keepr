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

    public IEnumerable<Vault> GetAll(string userId)
    {
      try
      {

        return _db.Query<Vault>("Select * FROM vaults Where userId = @UserId;", (new { userId }));
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object GetById(Vault vault)
    {
      try
      {

        vault = _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id and userId = @UserId;", vault);
        if (vault is null) throw new Exception("No Job with that Id.");
        return vault;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public object Delete(int id, string userId)
    {
      try
      {
        string query = @"DELETE FROM 
        vaults WHERE
         id = @Id and userId = @UserId;";
        int success = _db.Execute(query, new { id, userId });
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

    public object Create(Vault vault)
    {
      try
      {

        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (name, description, userId)
                VALUES (@Name, @Description, @UserId); 
                SELECT LAST_INSERT_ID();", vault);
        if (id < 1) throw new Exception("Unable to save vault to db.");
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