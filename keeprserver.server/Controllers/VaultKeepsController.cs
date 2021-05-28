using System.Collections.Generic;
using keeprserver.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController
  {
    private readonly VaultKeepsService _vkService;

    public VaultKeepsController(VaultKeepsService vkService)
    {
      _vkService = vkService;
    }


    // Create

    // GetKeepsByVaultId
    // [HttpGet("{id}/keeps)]


    // Delete
  }
}