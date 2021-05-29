using System;
using System.ComponentModel.DataAnnotations;

namespace keeprserver.server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    [Required]
    [MaxLength(1)]

    public string Name { get; set; }

    public string Description { get; set; } = "No Description";
    public string Img { get; set; } = "http://placehold.it/150x150";
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}

