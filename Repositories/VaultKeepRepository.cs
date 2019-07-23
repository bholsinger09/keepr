using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace keepr.Repositories
{

  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    #region getbyid
    public IEnumerable<Keep> GetById(string userId, int id)
    {
      try
      {

        string query = @"SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId
                WHERE (vaultId = vaultId and vk.userId = @userId) 
                ;";
        return _db.Query<Keep>(query, new { id });




        //      SELECT * FROM vaultkeeps vk
        // -- INNER JOIN keeps k ON k.id = vk.keepId 
        // -- WHERE (vaultId = @vaultId AND vk.userId = @userId) 
        //used this from the db setup


      }
      catch (Exception e)
      {

        throw e;
      }
    }
    #endregion
    #region Create
    public VaultKeep Create(VaultKeep vk, string userId)
    {

      try
      {

        string query = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
            VALUES (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
        string id = _db.ExecuteScalar<string>(query, vk);
        vk.UserId = id;
        return vk;


      }
      catch (Exception e)
      {

        throw e;
      }

    }

    #endregion


    #region delete
    //this was done on mysql setup
    //         FOREIGN KEY (userId)
    // --         REFERENCES users(id)
    // --         ON DELETE CASCADE,

    // --     FOREIGN KEY (vaultId)
    // --         REFERENCES vaults(id)
    // --         ON DELETE CASCADE,

    // --     FOREIGN KEY (keepId)
    // --         REFERENCES keeps(id)
    // --         ON DELETE CASCADE

    // public VaultKeep Delete(string UserId)
    // {
    //   try
    //   {

    //         string query = "DELETE FROM vaultkeeps WHERE userId = @UserId;";
    //         int changedRows = _db.Execute(query, new { UserId });
    //         if (changedRows < 1) throw new Exception("Invalid Id");
    //         return "Successfully Deleted Relation";


    //   }
    //   catch (Exception e)
    //   {

    //       throw e;
    //   }

    // }

    #endregion
  }
}