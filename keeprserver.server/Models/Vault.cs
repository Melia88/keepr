using System;
using System.ComponentModel.DataAnnotations;

namespace keeprserver.server.Models
{
  public class Vault
  {
    // [Required]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    // [Required]
    [MinLength(1)]

    public string Name { get; set; } = "Name Here";

    public string Description { get; set; } = "No Description";
    public string Img { get; set; } = "https://images.unsplash.com/photo-1561065749-2a263ce7b379?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=375&q=80";


    public bool IsPrivate { get; set; } = false;
  }
}
