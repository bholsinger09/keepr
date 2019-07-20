using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace keepr.Repositories
{

  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAll()
    {
      try
      {
        return _db.Query<Keep>("Select * FROM keeps;");
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public Keep GetById(int id)
    {
      try
      {
        Keep keep = _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
        if (keep is null) throw new Exception("No Job with that Id.");
        return keep;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public Keep Create(Keep keep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description, userId, 
                 img, isPrivate, views, shares, keeps)
                VALUES (@Name, @Description, @UserId, @Image, @IsPrivate,@NumViews, @NumShares, @NumKeeps); 
                SELECT LAST_INSERT_ID();", keep);
        if (id < 1) throw new Exception("Unable to save job to db.");
        keep.Id = id;
        return keep;

      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public Keep Update(Keep keep)
    {
      try
      {
        int success = _db.Execute(@"UPDATE keeps
               SET 
               name = @Name, 
               description = @Description,
               isPrivate = @IsPrivate,
               views = @NumViews,
               shares= @NumShares,
               keeps = @NumKeeps
               WHERE id = @Id;", keep);
        if (success != 1) throw new Exception("Something went wrong with the update.");
        return keep;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public string Delete(int id)
    {
      try
      {
        int success = _db.Execute("DELETE FROM keeps WHERE id = @id;", new { id });
        if (success != 1) throw new Exception("Something went wrong with deleting.");
        return "Job deleted!";
      }
      catch (Exception e)
      {

        throw e;
      }

    }
  }










}