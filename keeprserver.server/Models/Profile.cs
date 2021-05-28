using System;
using System.ComponentModel.DataAnnotations;

namespace keeprserver.server.Models
{
  public class Profile
  {
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    public string Picture { get; set; } = "//placehold.it/150x150";
    public string Email { get; set; }
  }
}