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
    public ActionResult<IEnumerable<>> Get()
    {
      try
      {
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Flower> Get(int id)
    {
      try
      {
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<> Post([FromBody] value)
    {
      try
      {
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<> Put(int id, [FromBody] value)
    {
      try
      {
        value.Id = id;
        return Ok();
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
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }

















}