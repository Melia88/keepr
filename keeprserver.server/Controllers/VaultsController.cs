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
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    public readonly VaultsService _vService;
    public readonly VaultKeepsService _vkService;

    public VaultsController(VaultsService vService, VaultKeepsService vkService)
    {
      _vService = vService;
      _vkService = vkService;
    }



    // CreateVault
    // [HttpPost("{id}")]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // REVIEW DO NOT TRUST THE CLIENT..... EVER
        vault.CreatorId = userInfo.Id;
        Vault newVault = _vService.Create(vault);
        // REVIEW cool inheritance thing account : profile
        newVault.Creator = userInfo;
        return Ok(newVault);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // GetVaultById
    // [HttpGet("{id}")]
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        Vault vault = _vService.GetVaultById(id);
        return Ok(vault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetKeepsByVaultId
    [HttpGet("{id}/keeps")]
    public ActionResult<List<VaultKeepsViewModel>> GetKeepsByVaultId(int id)
    {
      try
      {
        List<VaultKeepsViewModel> keeps = _vkService.GetKeepsByVaultId(id);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // UpdateVault
    // [HttpPut("{id}")]

    [Authorize]
    [HttpPut("{id}")]

    public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault vault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // REVIEW DO NOT TRUST THE CLIENT..... EVER
        vault.Id = id;
        Vault newVault = _vService.Update(vault, userInfo.Id);
        // REVIEW cool inheritance thing account : profile
        newVault.Creator = userInfo;
        return Ok(newVault);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // RemoveVault
    // [HttpDelete("{id}")]

    [Authorize]
    [HttpDelete("{id}")]

    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        // REVIEW DO NOT TRUST THE CLIENT..... EVER
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _vService.Remove(id, userInfo.Id);
        return Ok("Successfully Removed");

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

