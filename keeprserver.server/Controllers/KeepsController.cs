using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeprserver.server.Models;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _kService;
    private readonly ProfilesService _pService;

    public KeepsController(KeepsService kService, ProfilesService pService)
    {
      _kService = kService;
      _pService = pService;
    }



    // CreateKeep
    // [HttpPost("{id}")]

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        // TODO[epic=Auth] Get the user info to set the creatorID
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // safety to make sure an account exists for that user before CREATE-ing stuff.
        Profile fullProfile = _pService.GetOrCreateProfile(userInfo);
        newKeep.CreatorId = userInfo.Id;

        Keep keep = _kService.Create(newKeep);
        //TODO[epic=Populate] adds the account to the new object as the creator
        newKeep.Creator = fullProfile;
        return Ok(newKeep);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
    // GetKeepById
    // [HttpGet("{id}")]

    // UpdateKeep
    // [HttpPut("{id}")]

    // RemoveKeep
    // [HttpDelete("{id}")]
  }
}