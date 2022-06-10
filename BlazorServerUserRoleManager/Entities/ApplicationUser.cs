using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorServerUserRoleManager.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public ApplicationUser(string userName, string firstName, string lastName) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [StringLength(35)] public string? FirstName { get; set; }
        [StringLength(35)] public string? LastName { get; set; }

        [NotMapped] public IEnumerable<string> RolesForUser { get; set; }
    }
}