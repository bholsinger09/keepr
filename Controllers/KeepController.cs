using System;
using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("keeps")]
  [ApiController]
  public class FlowersController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public FlowersController(KeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/values
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

    // GET api/values/5
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

    // POST api/values
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

    // PUT api/values/5
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

    // DELETE api/values/5
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