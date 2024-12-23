using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Provider { get; set; } // e.g., Google, Microsoft
    public string ProviderKey { get; set; } // Unique identifier from the provider
}
