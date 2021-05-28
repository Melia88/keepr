using System.Collections.Generic;
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
    public ActionResult<List<Vault>> GetProfilesVaults(int id)
    {
      try
      {
        List<Vault> products = _vService.GetProfilesVaults(id);
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetProfilesKeeps
    // Send to Keeps Service
    [HttpGet("{id}/keeps")]
    public ActionResult<List<VaultKeepsViewModel>> GetProfilesKeeps(int id)
    {
      try
      {
        List<VaultKeepsViewModel> products = _kService.GetProfilesKeeps(id);
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}