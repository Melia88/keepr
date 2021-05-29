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
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    public readonly VaultsService _vService;
    public readonly KeepsService _kService;
    public readonly VaultKeepsService _vkService;

    public VaultsController(VaultsService vService, KeepsService kService, VaultKeepsService vkService)
    {
      _vService = vService;
      _kService = kService;
      _vkService = vkService;
    }




    // CreateVault
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

    // -------------------------------------------------*********
    // GetAll
    [HttpGet]
    public ActionResult<List<Vault>> GetAll()
    {
      try
      {
        List<Vault> vaults = _vService.GetAll();
        return Ok(vaults);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    // -------------------------------------------------*********
    // GetVaultById
    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetVaultById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        var userId = userInfo.Id;
        Vault vault = _vService.GetVaultById(id);
        if (vault.IsPrivate == true && vault.CreatorId != userId)
        {
          throw new Exception("Private Vault, Only Creater Has Access!");
        }
        return Ok(vault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}")]
    // public ActionResult<Vault> GetVaultById(int id)
    // {
    //   try
    //   {
    //     Vault vault = _vService.GetVaultById(id);
    //     return Ok(vault);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // GetKeepsByVaultId This is GET VAULTKEEPS in postman test!
    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<VaultKeepsViewModel>>> GetKeepsByVaultId(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        var userId = userInfo.Id;
        IEnumerable<VaultKeepsViewModel> keeps = _vkService.GetKeepsByVaultId(id, userId);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // UpdateVault

    [Authorize]
    [HttpPut("{id}")]

    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault vault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // REVIEW DO NOT TRUST THE CLIENT..... EVER
        vault.Id = id;
        // vault.Creator = userInfo;
        vault.CreatorId = userInfo.Id;
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

