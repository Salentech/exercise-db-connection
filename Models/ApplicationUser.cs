using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Provider { get; set; } // e.g., Google, Microsoft
    public required string ProviderKey { get; set; } // Unique identifier from the provider
}
