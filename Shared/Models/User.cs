using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lobsystem.Shared.Models
{
    public class User : IdentityUser
    {

        public string Name { get; set; }


        [Required]
        public bool IsDeleted { get; set; }

        public User()
        {
            IsDeleted = false;
        }
    }
}
