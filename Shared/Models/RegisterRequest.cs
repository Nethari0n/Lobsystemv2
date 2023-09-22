using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.Models
{
    public class RegisterRequest
    {
       
        public string? Id { get; set; }
        [Required]
        public string UserName { get; set; }
        
        public string? Password { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RoleId { get; set; }
        
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string? PasswordConfirm { get; set; }
    }
}
