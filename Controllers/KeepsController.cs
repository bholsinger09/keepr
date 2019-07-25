using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    //GET api/keeps/users
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetKeepByUser()
    {
      try
      {
        var uId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepsByUser(uId));
        // return (uId);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);

      }
    }

    [Authorize]
    // POST api/keeps
    [HttpPost]
    public async Task<ActionResult<Keep>> Post([FromBody] Keep value)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        value.UserId = Userid;
        var user = _repo.Create(value);
        if (user == null)
        {
          await HttpContext.SignOutAsync();
          throw new Exception("User not logged In");
        }
        return Ok(user);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    [Authorize]
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

    [Authorize]
    // DELETE api/keeps/values/id
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Delete(id, Userid));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }

















}