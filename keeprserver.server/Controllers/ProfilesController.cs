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
        var userId = userInfo.Id;
        // if youre not logged in & the vault isnt set to private then show the vaults
        Profile p = _pService.GetProfileById(id);
        List<Vault> publicVaults = _vService.GetProfilesPublicVaults(id);
        if (userId == p.Id)
        {
          List<Vault> allMyVaults = _vService.GetMyVaultsByProfileId(userId);
          return Ok(allMyVaults);
        }
        if (userId != p.Id)
        {
          return Ok(publicVaults);
        }
        return Ok(publicVaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetProfilesKeeps
    // Send to Keeps Service
    // [HttpGet("{id}/keeps")]
    // public async Task<ActionResult<List<Keep>>> GetProfilesKeeps()
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     var userId = userInfo.Id;
    //     List<Keep> keeps = _kService.GetProfilesKeeps(userId);
    //     return Ok(keeps);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
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