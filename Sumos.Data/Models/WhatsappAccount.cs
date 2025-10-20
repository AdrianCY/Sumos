using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sumos.Data.Models;

[Table("WhatsappAccounts")]
public class WhatsappAccount
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public required IdentityUser User { get; set; } // Navigation property

    [Required]
    [StringLength(50)]
    public required string WabaId { get; set; } // WhatsApp Business Account ID

    [Required]
    [StringLength(50)]
    public required string PhoneNumberId { get; set; } // Phone Number ID

    [Required]
    public required string BusinessToken { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Pending";


    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}