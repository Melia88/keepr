using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeprserver.server.Models;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vkService;

    public VaultKeepsController(VaultKeepsService vkService)
    {
      _vkService = vkService;
    }


    // Create
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeeps>> CreateVaultKeeps([FromBody] VaultKeeps vk)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        vk.CreatorId = userInfo.Id;
        VaultKeeps newVK = _vkService.CreateVaultKeeps(vk);
        newVK.Creator = userInfo;
        return Ok(newVK);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // / VaultKeeps GetVaultKeepById
    [HttpGet("{id}")]
    public async Task<ActionResult<List<VaultKeepsViewModel>>> GetVaultKeepById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        if (userInfo == null)
        {
          string userId = "Private Vault, Only Creator Has Access!";
          return Ok(_vkService.GetVaultKeepById(id, userId));
        }
        else
        {
          string userId = userInfo.Id;
          return Ok(_vkService.GetVaultKeepById(id, userId));
        }
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //// ADDED !!!!!!!!
    // Delete /api/vaultkeeps/{{vaultKeepId}
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _vkService.Remove(id, userInfo.Id);
        return Ok("Removed");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
