using keeprserver.server.Models;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _pservice;

    public ProfilesController(ProfilesService pservice)
    {
      _pservice = pservice;
    }


    // GetById


    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile p = _pservice.GetProfileById(id);
        return Ok(p);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetProfilesVaults
    // [HttpGet("{id}/vaults")]
    // Send to Vaults Service

    // GetProfilesKeeps
    // [HttpGet("{id}/keeps")]
    // Send to Keeps Service
  }
}