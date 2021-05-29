using System;
using System.ComponentModel.DataAnnotations;

namespace keeprserver.server.Models
{
  public class Vault
  {
    [Required]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    [Required]
    [MinLength(1)]

    public string Name { get; set; } = "Name Here";

    public string Description { get; set; } = "No Description";

    public bool IsPrivate { get; set; } = false;
  }
}
