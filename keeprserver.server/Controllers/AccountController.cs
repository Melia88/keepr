using System;
using System.Collections.Generic;
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
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {

    private readonly ProfilesService _pService;
    private readonly VaultsService _vService;
    private readonly KeepsService _kService;

    public AccountController(ProfilesService pService, VaultsService vService, KeepsService kService)
    {
      _pService = pService;
      _vService = vService;
      _kService = kService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_pService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("vaults")]
    [Authorize]
    public async Task<ActionResult<List<Vault>>> GetUsersVaults()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // var userId = userInfo.Id;
        // if youre not logged in & the vault isnt set to private then show the vaults
        // Profile p = _pService.GetProfileById(id);
        // List<Vault> publicVaults = _vService.GetProfilesPublicVaults(id);
        // if (userId == p.Id)
        // {
        //   List<Vault> allMyVaults = _vService.GetMyVaultsByProfileId(userId);
        //   return Ok(allMyVaults);
        // }
        // if (userId != p.Id)
        // {
        //   return Ok(publicVaults);
        // }
        // return Ok(publicVaults);
        return Ok(_vService.GetVaultsByUserId(userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}