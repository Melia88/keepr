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
        return Ok(newVK);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // Delete
  }
}