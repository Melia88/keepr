using System;

namespace keeprserver.server.Models
{
  public class VaultKeeps
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public string VaultId { get; set; }
    public string KeepsId { get; set; }

    public Profile Creator { get; set; }
  }
  public class VaultKeepsViewModel : Keep
  {

    public string VaultId { get; set; }
    public string KeepsId { get; set; }
    public int VaultKeepsId { get; set; }

    public string VaultName { get; set; }
    public string VaultDescription { get; set; } = "No Description";

    public bool IsPrivate { get; set; }

  }
}