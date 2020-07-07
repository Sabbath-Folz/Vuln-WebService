using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ForgotPasswordViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


    }
}
