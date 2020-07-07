using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using WebApplication3.Data;

namespace WebApplication3.Account
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
       

        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> options, IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> validator, IEnumerable<IPasswordValidator<ApplicationUser>> hasher, ILookupNormalizer normalizer, IdentityErrorDescriber errorDescriber,
            IServiceProvider provider, ILogger<UserManager<ApplicationUser>> logger) : 
            base(store, options, passwordHasher, validator, hasher, normalizer, errorDescriber, provider, logger)
        {           
            this.PasswordHasher = new CustomPasswordHasher();
        }    
        
    }
   
}
