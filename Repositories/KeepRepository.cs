using System;
using System.Data;

namespace keepr.Repositories
{

  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    internal object GetAll()
    {
      throw new NotImplementedException();
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Keep value)
    {
      throw new NotImplementedException();
    }

    internal object Update(Keep value)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int v, int id)
    {
      throw new NotImplementedException();
    }


  }










}