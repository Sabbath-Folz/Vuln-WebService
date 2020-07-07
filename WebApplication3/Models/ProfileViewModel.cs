using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ProfileViewModel
    {
        public string username;
        [EmailAddress]
        public string email;
        public IFormFile avatarImage { get; set; }
    }
}
