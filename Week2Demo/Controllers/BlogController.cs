using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week2Demo.Models;  // had to add this

namespace Week2Demo.Controllers
{

    [Route("blog")]
    public class BlogController : Controller
    {
        // added for DB //
        private readonly BlogDataContext _db;

        public BlogController(BlogDataContext db)
        {
            _db = db;
        }
        // added for DB //


        [Route("")]
        public IActionResult Index()
        {
            var articles = _db.Articles.OrderByDescending(x => x.Date).Take(5).ToArray();

            return View(articles);

        }


        [Route("OldIndex")]
        public IActionResult OldIndex()
        {
            // dummy data for the UI testing and we have no DB yet ... 

            var articles = new[]
            {
                new Article
                {
                    Title = "A new article for a new day",
                    Date = DateTime.Now,
                    Author = "Nate the Great",
                    Body = "This is a great blog article, don't you think?",
                },

                new Article
                {
                    Title = "A great article",
                    Date = DateTime.Now,
                    Author = "Nate the Great",
                    Body = "A fabulous thing to write about in a blog article.",
                }
            };

            return View(articles);

        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult ViewArticle(int year, int month, string key)
        {
            // dummy data for the UI testing and we have no DB yet ... 

            var article = _db.Articles.FirstOrDefault(x => x.Key == key);
            return View(article);
        }


        [Route("old/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult OldViewArticle(int year, int month, string key)
        {
            // dummy data for the UI testing and we have no DB yet ... 

            var article = new Article
            {
                Title = "A wonderful day in the computer lab",
                Date = DateTime.Now,
                Author = "Nate the Great",
                Body = "This is a blog article directly entered into ViewArticle",
            };
            return View(article);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [Route("create")]
        [HttpPost]
        public IActionResult Create(Article article)
        {
            // can validate  ... check is modelstate is valid ... //

            //populating and/or overwriting values the user shouldn't be submitting
            //article.Author = User.Identity.Name;

            article.Date = DateTime.Now;

            _db.Articles.Add(article);
            _db.SaveChanges();

            return RedirectToAction("ViewArticle", "Blog", new
                {
                    year = article.Date.Year,
                    month = article.Date.Month,
                    key = article.Key
                }
            );
        }

    }
}