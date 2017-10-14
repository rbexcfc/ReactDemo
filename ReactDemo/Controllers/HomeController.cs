using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDemo.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
              new CommentModel
                {
                    Id = 1,
                    Author = "Richie",
                    Text = "Pro clubs?"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Tom",
                    Text = "Yes martin"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Will",
                    Text = "I'm playing striker"
                },
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Comments")]
        [ResponseCache(Location = ResponseCacheLocation.None,NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }
        [Route("Comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel Comment)
        {
            //Create fake Id for the comment
            Comment.Id = _comments.Count + 1;
            _comments.Add(Comment);
            return Content("Success");
        }
    }
}
