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
  public class vaultController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public vaultController(VaultRepository repo)
    {
      _repo = repo;
    }

    // GET api/keeps
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
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
    public ActionResult<Vault> Get(int id)
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
    public ActionResult<IEnumerable<Vault>> GetKeepByUser()
    {
      try
      {
        var uId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepsByUser(uId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [Authorize]
    // POST api/keeps/value
    [HttpPost]
    public async Task<ActionResult<Vault>> Post([FromBody] Vault value)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        var user = _repo.Create(value, Userid);
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
    public ActionResult<Vault> Put(int id, [FromBody] Keep value)
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
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }

















}