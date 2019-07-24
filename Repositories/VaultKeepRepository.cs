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
    public IEnumerable<Keep> GetById(int vaultId, string userId)
    {
      try
      {

        string query = @"SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId
                WHERE (vaultId = @vaultId and vk.userId = @userId) 
                ;";


        return _db.Query<Keep>(query, new { vaultId, userId });




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
        vk.UserId = userId;
        int id = _db.ExecuteScalar<int>(query, vk);
        vk.Id = id;
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

    public string Delete(int vaultId, int keepId, string userId)
    {
      try
      {

        string query = @"DELETE FROM vaultkeeps vk 
        vaultId = @vaultId and vk.userId = @userId and keepId = @keepId";
        int changedRows = _db.Execute(query, new { vaultId, keepId, userId });
        if (changedRows < 1) throw new Exception("Invalid Id");
        return "Successfully Deleted Relation";


      }
      catch (Exception e)
      {

        throw e;
      }

    }

    #endregion
  }
}