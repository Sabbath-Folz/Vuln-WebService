using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Webapplication3.Models;
using WebApplication3.Data;
using WebApplication3.Email;
using WebApplication3.Models;
using WebApplication3.Account;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;
using System.Data.SqlClient;
using System;


namespace WebApplication3.Controllers
{
	// Authorize only signed in users to use controller methods
	[Authorize]
	public class AccountController : Controller {

		// context for Identity DB
		protected ApplicationDbContext mContext;
		// Manager for handling users creation, deletion, searching, roles etc...
		protected ApplicationUserManager mUserManager;
		// Manager for handling signing in and out for our users
		protected SignInManager<ApplicationUser> mSignInManager;
		// db-context for image - description
		protected DescriptionDbContext mDescriptionDbContext;
		// db-context to save uploaded filename in database
		protected FilenameLogsDbContext mFilesContext;

		protected EmailSender mEmailSender;

		// constructor to be called with every method of the controller
		public AccountController(ApplicationDbContext context, ApplicationUserManager userManager,
			SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, DescriptionDbContext descriptionDbContext, FilenameLogsDbContext filenameLogsContext)
		{
			mContext = context;
			mUserManager = userManager;
			mSignInManager = signInManager;
			mEmailSender = (EmailSender)emailSender;
			mDescriptionDbContext = descriptionDbContext;
			mFilesContext = filenameLogsContext;
		}



		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				// create new user object and set values from submitted model
				ApplicationUser user = new ApplicationUser()
				{
					Email = model.Email,
					UserName = model.Username,
					EmailConfirmed = true
					
				};
				//save user into database
				var result = await mUserManager.CreateAsync(user, model.Password);


				if (result.Succeeded)
				{
					return View("Login");

				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}

			}

			//If it got so far, something went wrong
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{

				var user = await mUserManager.FindByNameAsync(model.Username);
				if (user != null)
				{   //check if email is already confirmed. If not don't allow login
					if (!await mUserManager.IsEmailConfirmedAsync(user))
					{
						// send error message to view
						ViewBag.errorMessage = "You must have confirmed your email address to login!";
						return View("Error");
					}
				}

				// check password
				var result = await mSignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction(nameof(AccountController.LoggedIn));

					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await mSignInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult LoggedIn()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult MyPictures()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return View("Error");
			}
			var userresult = await mUserManager.FindByIdAsync(userId);
			var result = await mUserManager.ConfirmEmailAsync(userresult, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");

		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		public IActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------


		[Route("Account/ForgotPassword")]
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await mUserManager.FindByNameAsync(model.Username);
				if (user == null || !(await mUserManager.IsEmailConfirmedAsync(user)))
				{

					return View("ForgotPasswordConfirmation");
				}


				// Send an email with this link
				string code = await mUserManager.GeneratePasswordResetTokenAsync(user);
				var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Scheme);
				await mEmailSender.Execute("Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>", user.Email);
				return View("ForgotPasswordConfirmation");
			}

			// If it got this far, something failed, redisplay form
			return View(model);
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[AllowAnonymous]
		public ActionResult ResetPassword(string code)
		{
			return code == null ? View("Error") : View();
		}


		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await mUserManager.FindByNameAsync(model.Username);
			if (user == null)
			{
				
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			var result = await mUserManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
		
			return View();
		}


		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------


		// GET: /Account/ResetPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		// Upload avatar for own account and save image on server
		[HttpPost]
		public async Task<IActionResult> AvatarUpload(IFormFile image)
		{
			ApplicationUser user;
			// get user from database
			user = await mUserManager.GetUserAsync(User);


			// full path to file in temp location
			var filePath = "pictures";
			string fileName = image.FileName;
			fileName = System.IO.Path.Combine(filePath, fileName);

			// add filepath to user attributes
			user.AvatarImage = fileName;
			// commit changes to database
			await mUserManager.UpdateAsync(user);

			// copy image-bytes to location on server
			using (var stream = new FileStream(fileName, FileMode.Create))
			{
				// copy image to stream
				await image.CopyToAsync(stream);
			}

			return View("LoggedIn");


		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		// send saved Avatar image of user to frontend
		[HttpGet]
		public async Task<FileStreamResult> GetAvatar()
		{
			ApplicationUser user = await mUserManager.GetUserAsync(User);

			// create stream for avatar and return stream to view
			Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(user.AvatarImage));
			return new FileStreamResult(stream, "image/jpeg");
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[Route("Account/GetImage/{count}")]
		[HttpGet("{count}")]
		public IActionResult GetImages(int count)
		{
			// count is the variable to iterate through the images

			// get current user from database and check if IsAdmin attribute is set
			var result1 = from users in mContext.Users where users.UserName == User.Identity.Name select users;
			// make sure you get the first instance of the previous query
			try
			{
				
				var user = result1.First();


				if (user.IsAdmin == 1)
				{
					// SQL Query for all images
					var images = from image in mContext.UserImage select image;
					// get n-th image
					var Image = images.Skip(count).First();
					// return image to view
					Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(Image.Path));
					return new FileStreamResult(stream, "image/jpeg");
				}
				else
				{
					// SQL Query for own images
					var images = from image in mContext.UserImage where image.UId == mUserManager.GetUserId(User) select image;

					var Image = images.Skip(count).First();

					Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(Image.Path));

					return new FileStreamResult(stream, "image/jpeg");

				}
			} catch (Exception e)
			{
				Console.WriteLine(e.Source);
				ViewBag.errorMessage = "Something went wrong!";
				return View("Error");
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		// Get Paths of images to display on view
		[Route("Account/GetPath/{counter}")]
		[HttpGet("{counter}")]
		public IActionResult GetPath(int counter)
		{
			// counter to iterate through all paths
			try
			{
				var images = from image in mContext.UserImage where image.UId == mUserManager.GetUserId(User) select image;
				var Image = images.Skip(counter).First();
				string path = Image.Path;
				string[] words = path.Split('/');
				path = words[1];
				return Content(path);
			} catch (Exception e)
			{
				Console.WriteLine(e.Source);
				ViewBag.errorMessage = "Something went wrong!";
				return View("Error");
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[Route("Account/SetDescription")]
		[HttpPost("{path}/{description}")]
		public IActionResult SetDescription(string path, string description)
		{
			// building path parameter
			string beginning = @"CloudImages/";
			path = beginning + path;

			// make sure that flag won't be overwritten
			var uId = mUserManager.GetUserId(User);
			var result_0 = from userImage in mContext.UserImage where userImage.Path == path && userImage.UId == uId select userImage;
			if (result_0.Count() == 0)
			{
				return RedirectToAction(nameof(MyPictures));
			}



			string query = "Select * from Description where Path == " + "\"" + path + "\"";

			// query the specific image
			try
			{
				var results = mDescriptionDbContext.description.FromSql(query);


				// create new DB entry if there is no description for this picture
				if (!(results.Any()))
				{
					Description descr = new Description { Path = path, Text = description };
					mDescriptionDbContext.description.Add(descr);
					mDescriptionDbContext.SaveChanges();

					return RedirectToAction(nameof(MyPictures));
				}



				// update description if there already is description
				var result = results.First();
				result.Text = description;
				mDescriptionDbContext.Update(result);
				mDescriptionDbContext.SaveChanges();

				return RedirectToAction(nameof(MyPictures));
			}
			catch (Exception e)
			{
				ViewBag.errorMessage = "An Error occured! Sry for the inconvenience";
				return View("Error");
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------


		[Route("Account/ListImagePaths/{UserId}")]
		[HttpGet("{UserId}")]
        public JsonResult ListImagePaths(string UserId)
        {
			
        
            string query = $"SELECT Path as Text FROM UserImage WHERE UID == {UserId}";

			try
			{
				var results = mContext.Query<MyQueryType>().FromSql(query).ToList();
				return Json(results);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Source);
				return Json(e.Source);
			}

			
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------


        [Route("Account/ChangeUsername")]
        [HttpPost("{Username}")]
        public IActionResult ChangeUsername(string Username)
        {
            string UserId = mUserManager.GetUserId(User);

            // check if username is already in database
            bool check = (from user in mContext.Users where user.UserName == Username select user).Any();

            //if username already exists return to view without doing anything
            if (check)
            {
                ViewBag.errorMessage = "Enter correct UserName!";
                return View("Error");
            }

            string normalizedUsername = Username.ToUpper();

            string query = $"Update AspNetUsers set UserName=\'{Username}\', NormalizedUserName=\'{normalizedUsername}\' where Id=\'{UserId}\'";
            try
            {
                int update = mContext.Database.ExecuteSqlCommand(query);
            }
            catch (Exception e)
            { Console.WriteLine(e.Source);
                ViewBag.errorMessage = "Enter correct UserName!";
                return View("Error");
            };
            
            return RedirectToAction(nameof(Logout));
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [Route("Account/Settings")]
        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [Route("Account/ChangeEmail")]
        [ HttpPost("{EmailAdress}/{UserId}")]
        public IActionResult ChangeEmail(string EmailAdress, string UserId)
        {
			try
			{
				string normalizedEmail = EmailAdress.ToUpper();
				string query = $"Update AspNetUsers set Email=\'{EmailAdress}\', NormalizedEmail=\'{normalizedEmail}\' where Id=\'{UserId}\'";
				int update = mContext.Database.ExecuteSqlCommand(query);
				mContext.SaveChanges();
			}catch(Exception e)
			{
				Console.WriteLine(e.Source);
				ViewBag.errorMessage = "Error!";
				return View("Error");
			}
            return View("LoggedIn");
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile picture)
        {
			
			FilenameLogs db_filename = new FilenameLogs();
			db_filename.filename = picture.FileName;
			mFilesContext.filenameLogs.Add(db_filename);
			mFilesContext.SaveChanges();

			// raise error message when uploadfile has wrong filetype
			if ((picture.ContentType != "image/jpeg" ) && (picture.ContentType != "image/png"))
			{
				
				string query = $"Select Id, filename from FilenameLogs where filename = \'{picture.FileName}\'";
				var result = mFilesContext.filenameLogs.FromSql(query);
				var result_Array = result.ToArray();
				string error_msg ="Error while uploading files: ";
				foreach(var obj in result_Array)
				{
					error_msg = error_msg + obj.filename + "\n";
				}
				ViewBag.errorMessage = error_msg;
				return View("Error");
			}



			ApplicationUser user;
            user = await mUserManager.GetUserAsync(User);
            var filePath = "CloudImages/";

			// string fileName = strings[strings.length()-1];
		string fileName = filePath + picture.FileName;

            //Set Values for new image
            UserImage userImage = new UserImage();
            userImage.UId = user.Id;

            userImage.Path = fileName;
            mContext.UserImage.Add(userImage);
            //Save image-values to database
            mContext.SaveChanges();

            // write bytes of image to server-location
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }

            return RedirectToAction(nameof(MyPictures));
        }


		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------

		[Route("Account/ChangePassword")]
		[HttpPost]
		public IActionResult ChangePassword(string new_password, string UserId)
		{
			if (UserId == null)
			{
				UserId = mUserManager.GetUserId(User);
			}
            
            var hashed_password = Encrypt.GetMD5Hash(new_password);
            string query = $"Update AspNetUsers set PasswordHash=\'{hashed_password}\' where Id=\'{UserId}\'";
            int update = mContext.Database.ExecuteSqlCommand(query);
            mContext.SaveChanges();

            return View("LoggedIn");
        }

    }
}
