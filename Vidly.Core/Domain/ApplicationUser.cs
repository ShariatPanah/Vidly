using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Core.Domain;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(50)]
    public string FullName { get; set; }
}

