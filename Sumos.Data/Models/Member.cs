using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sumos.Data.Models;

[Table("Members")]
public class Member
{
    public long Id { get; set; }
   
    [Required]
    public long UserId { get; set; }
    public IdentityUser? User { get; set; }
   
    [Required]
    public long OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public DateTime UpdatedAt { get; set; }
}