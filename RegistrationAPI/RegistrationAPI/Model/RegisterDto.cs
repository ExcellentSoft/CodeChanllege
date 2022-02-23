using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAPI.Model
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
       [EmailAddress(ErrorMessage ="Valid email address is required")]
        public string Email { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Minimum of 8 characters required")]
        public string PassWord { get; set; }
        
        public string PhoneNumber { get; set; }

        
    }
}
