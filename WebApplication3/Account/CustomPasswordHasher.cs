using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using WebApplication3.Data;

namespace WebApplication3.Account
{
    public class CustomPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        protected UserManager<ApplicationUser> mUserManager;
        protected ApplicationUser user2;
        public string HashPassword(ApplicationUser user, string password)
        {  
           
                
                return Encrypt.GetMD5Hash(password);
          
                
        }

        // routine to verify password
        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(user, providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }

    
}
