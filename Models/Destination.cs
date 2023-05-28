namespace core_web_api.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Destination
{
    public int DestinationId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Column(TypeName = "image")]
    public byte[] Photo { get; set; }
}