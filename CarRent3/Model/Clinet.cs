using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace CarRent3.Model
{
    public partial class Clinet
    {
        public Clinet()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        public int ClinetId { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("PostClinet", "Clinet", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Moblie Required")]
        public int Moblie { get; set; }
        [Required(ErrorMessage = "Adress Required")]
        public string Adress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
