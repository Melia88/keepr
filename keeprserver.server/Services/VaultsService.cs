using keeprserver.server.Repositories;

namespace keeprserver.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }


    // GetProfilesVaults
    // This is comeing from profiles controller



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