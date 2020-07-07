using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApplication3.Email;
using WebApplication3.Account;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
            }

			// dependency injection -> db-contexts
			services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlite("Data Source=./../database_04.db"));

            services.AddDbContext<FilenameLogsDbContext>(options =>
             options.UseSqlite("Data Source=./../database_05.db")); 

            services.AddDbContext<DescriptionDbContext>(options =>
             options.UseSqlite("Data Source=./../database_06.db"));



            services.AddScoped<IPasswordHasher<ApplicationUser>, CustomPasswordHasher>();
            services.AddTransient<ApplicationUserManager>();
          
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            
            //AddIdendity adds cookie based authentication
            //Adds scoped classes for thinks like UserManager, SignInManager, PasswordHashers etc...
            //NOTE: Automatically adds the calidated user from a cookie to the HttpContext.User
            services.AddIdentity<ApplicationUser, IdentityRole>(config => config.SignIn.RequireConfirmedEmail = true)
                //Adds UserStroe and RoleStore from this context
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //adds a provider that gererates unique keys and hashes for ghings like forgot password links, phone number verification codes etc..
                .AddDefaultTokenProviders();
            
           
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
            });
          
        
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSendGridEmailSender();

            // Password policy
            services.Configure<IdentityOptions>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.AllowedForNewUsers = false;
            });

            services.AddMvc().AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Setup Identity
            app.UseAuthentication();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Account/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();



           
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
       Path.Combine(Directory.GetCurrentDirectory(), "./..")),
                ServeUnknownFileTypes = true
            });

    
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            

        }
    }

   

}
