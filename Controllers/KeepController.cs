using System;
using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class keepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public keepsController(KeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/keeps/id
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    //GET api/keeps/users
    [HttpGet("user")]
    public ActionResult<Keep> GetKeepByUser(int id)
    {
      try
      {
        return Ok(_repo.GetKeepsByUser(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // POST api/keeps/value
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      try
      {
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/keeps/values/id
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/keeps/values/id
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }

















}