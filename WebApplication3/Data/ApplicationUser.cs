using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Data
{
    //User Data and profile for the application
    public class ApplicationUser : IdentityUser
    {
        public int IsAdmin { get; set; }
        public string AvatarImage { get; set; } = "pictures/noAvatar.jpg";
     
    }
}
