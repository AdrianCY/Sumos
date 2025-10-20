using System.ComponentModel.DataAnnotations;

namespace Sumos.Data.Models;

public class Organization
{
    public long Id { get; init; }
    [MaxLength(200)]
    public required string Name { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}