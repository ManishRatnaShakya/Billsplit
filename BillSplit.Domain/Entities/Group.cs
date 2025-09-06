namespace BillSplit.Domain.Entities;

public class Group
{
    public Guid Id { get; init; }
    
    public required string  Name { get; init; }
    
    public string? Description { get; init; }
    
    public string? ImageUrl { get; init; }
    
    public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

}