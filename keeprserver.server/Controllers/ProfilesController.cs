using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeprserver.server.Models;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _pService;
    private readonly VaultsService _vService;
    private readonly KeepsService _kService;

    public ProfilesController(ProfilesService pService, VaultsService vService, KeepsService kService)
    {
      _pService = pService;
      _vService = vService;
      _kService = kService;
    }



    // GetById

    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile p = _pService.GetProfileById(id);
        return Ok(p);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetProfilesVaults
    // Send to Vaults Service
    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetProfilesVaults(string id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        List<Vault> vaults = _vService.GetProfilesVaults(id, userInfo.Id);
        return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetProfilesKeeps
    // Send to Keeps Service
    [HttpGet("{id}/keeps")]
    public ActionResult<List<Keep>> GetProfilesKeeps(string id)
    {
      try
      {
        List<Keep> keeps = _kService.GetProfilesKeeps(id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}