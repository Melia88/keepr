using keeprserver.server.Services;

namespace keeprserver.server.Controllers
{
  public class VaultKeepsController
  {
    private readonly VaultKeepsService _vkService;

    public VaultKeepsController(VaultKeepsService vkService)
    {
      _vkService = vkService;
    }
  }
}