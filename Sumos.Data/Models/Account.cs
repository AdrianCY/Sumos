namespace Sumos.Data.Models;

public class Account
{
    public long Id { get; init; }
    public string Name { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}