using System.Collections.Generic;
using keeprserver.server.Models;
using keeprserver.server.Services;
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
    public ActionResult<VaultKeeps> CreateVaultKeeps([FromBody] VaultKeeps vk)
    {
      try
      {
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