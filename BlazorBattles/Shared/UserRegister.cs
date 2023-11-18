using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText, StringLength(100,MinimumLength = 6)]
        public string UserPassword { get; set; }
        [Compare("UserPassword", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
        public string Bio { get; set; }
        public int StartUnitId { get; set; } = 1;
        [Range(0, 1000, ErrorMessage = "Please choose a number between 0 and 1000.")]
        public int Bananas { get; set; } = 100;
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        [Range(typeof(bool), "true", "true", ErrorMessage = "Only confirmed users can play!")]
        public bool IsConfirmed { get; set; } = true;
    }
}
