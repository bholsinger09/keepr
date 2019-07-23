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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }



    // GET api/keeps/id
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int vid)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetById(Userid, vid));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }



    [Authorize]
    // POST api/keeps
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Post([FromBody] VaultKeep value)
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


    //[Authorize]
    //this is the delete method
    // PUT api/keeps/values/id
    //[HttpPut("{id}")]
    // public async Task<ActionResult<VaultKeep>> Put([FromBody] VaultKeep value)
    // {
    //   try
    //   {
    //     var Userid = HttpContext.User.FindFirstValue("Id");
    //     var user = _repo.Delete(value, Userid);
    //     if (user == null)
    //     {
    //       await HttpContext.SignOutAsync();
    //       throw new Exception("User not logged In");
    //     }
    //     return Ok(user);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    //}

  }
}