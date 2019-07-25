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
  public class vaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public vaultsController(VaultRepository repo)
    {
      _repo = repo;
    }

    // GET api/vaults
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string Userid = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetAll(Userid));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    // GET api/vaults/id
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(Vault vault, int id)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        vault.UserId = Userid;
        vault.Id = id;


        return Ok(_repo.GetById(vault));
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine("hits get by id controller");
        return BadRequest(e);
      }
    }

    // [Authorize]
    // //GET api/vaults/users
    // [HttpGet("user")]
    // public ActionResult<IEnumerable<Vault>> GetVaultByUser()
    // {
    //   try
    //   {
    //     var uId = HttpContext.User.FindFirstValue("Id");
    //     return Ok(_repo.GetVaultsByUser(uId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e);
    //   }
    // }

    [Authorize]
    // POST api/vaults/value
    [HttpPost]
    public async Task<ActionResult<Vault>> Post([FromBody] Vault value)
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
        System.Diagnostics.Debug.WriteLine("hits hits post");
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    // PUT api/vaults/values/id
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        value.Id = id;
        value.UserId = Userid;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine("hits put");
        return BadRequest(e);
      }
    }

    [Authorize]
    // DELETE api/vaults/values/id
    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(Vault vault, int id)
    {
      try
      {
        var Userid = HttpContext.User.FindFirstValue("Id");
        vault.UserId = Userid;
        vault.Id = id;
        return Ok(_repo.Delete(vault));
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine("hits delete controller");
        return BadRequest(e);
      }
    }
  }

















}