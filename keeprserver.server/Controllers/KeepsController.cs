using keeprserver.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeprserver.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController
  {
    private readonly KeepsService _kService;

    public KeepsController(KeepsService kService)
    {
      _kService = kService;
    }

    // CreateKeep
    // [HttpPost("{id}")]

    // GetKeepById
    // [HttpGet("{id}")]

    // UpdateKeep
    // [HttpPut("{id}")]

    // RemoveKeep
    // [HttpDelete("{id}")]
  }
}