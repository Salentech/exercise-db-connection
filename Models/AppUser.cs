using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string Provider { get; set; } = "email";
    public string? DisplayName { get; set; }
}
