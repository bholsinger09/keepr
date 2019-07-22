using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

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
        if (keep is null) throw new Exception("No keep with that Id.");
        return keep;
      }
      catch (Exception e)
      {

        throw e;
      }

    }

    public IEnumerable<Keep> GetKeepsByUser(string uId)
    {
      try
      {
        string query = @"SELECT * FROM keeps  
                       WHERE userId = @uId;";
        return _db.Query<Keep>(query, new { uId });
      }
      catch (Exception e)
      {

        throw e;
      }
    }

    public Keep Create(Keep keep, string userId)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description, userId, 
                 img, isPrivate, views, shares, keeps)
                VALUES (@Name, @Description, @UserId, @Img, @IsPrivate,@Views, @Shares, @Keeps); 
                SELECT LAST_INSERT_ID();", keep);
        if (id < 1) throw new Exception("Unable to save keep to db.");
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
               img = @Img,
               isPrivate = @IsPrivate,
               views = @Views,
               shares= @Shares,
               keeps = @Keeps
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
        return "Keep deleted!";
      }
      catch (Exception e)
      {

        throw e;
      }

    }
  }










}