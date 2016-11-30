using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext context;

        public HomeController(BlogContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            {
                context.Database.EnsureCreated();

                var name = User.Identity.Name;
                var user = context.Users.FirstOrDefault(x => x.Name == name); 
                if (user == null)
                {
                    user = new User { Name = name };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                
                var blog = new Blog
                {
                    Title = $"Title: {DateTime.Now}",
                    UserId = user.UserId,
                    Content = Request.Path,
                    Tags = new List<string> { "Home" }
                };
                context.Blogs.Add(blog);
                context.SaveChanges();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
