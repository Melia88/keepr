using keeprserver.server.Services;

namespace keeprserver.server.Controllers
{
  public class VaultsController
  {
    public readonly VaultsService _vService;

    public VaultsController(VaultsService vService)
    {
      _vService = vService;
    }

    // CreateVault
    // [HttpPost("{id}")]

    // GetVaultById
    // [HttpGet("{id}")]

    // UpdateVault
    // [HttpPut("{id}")]

    // RemoveVault
    // [HttpDelete("{id}")]
  }
}

