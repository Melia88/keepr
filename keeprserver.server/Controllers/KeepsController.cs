using keeprserver.server.Services;

namespace keeprserver.server.Controllers
{
  public class KeepsController
  {
    private readonly KeepsService _kService;

    public KeepsController(KeepsService kService)
    {
      _kService = kService;
    }
  }
}