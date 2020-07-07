using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace WebApplication3.Controllers
{
    
    // Only allow signedIn Users to trigger methods in this controller
    [Authorize]
    public class AdminController : Controller
    {

        protected ApplicationDbContext mContext;


        public AdminController(ApplicationDbContext context)
        {
           
            mContext = new ApplicationDbContext();
        }

        [Route("Admin/Mypictures_Admin")]
        [HttpGet]
        public IActionResult MyPictures_Admin()
        {
            return View();
        }
        
        [Route("Admin/GetAllImages/{count}")]
        [HttpGet("{count}")]
        public IActionResult GetAllImages(int count)
        {
            var images = from image in mContext.UserImage select image;
            var Image = images.Skip(count).First();
            Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(Image.Path));
            return new FileStreamResult(stream, "image/jpeg");
        } 

    }
}