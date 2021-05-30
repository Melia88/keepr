using System;
using System.ComponentModel.DataAnnotations;

namespace keeprserver.server.Models
{
  public class VaultKeeps
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // [Required]
    public string CreatorId { get; set; }
    // [Required]
    public string VaultId { get; set; }
    // [Required]
    public string KeepsId { get; set; }

    public Profile Creator { get; set; }
  }
  public class VaultKeepsViewModel : Keep
  {
    // [Required]

    public string VaultId { get; set; }
    // [Required]
    public string KeepsId { get; set; }
    // [Required]
    public int VaultKeepsId { get; set; }

    public string VaultName { get; set; }
    public string VaultDescription { get; set; } = "No Description";

    public bool IsPrivate { get; set; }

  }
}