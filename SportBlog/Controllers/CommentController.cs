using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportBlog.Models;
using SportBlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SportBlog.Controllers
{
    public class CommentController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CommentController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int postId, string userId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            else
            {
                var user = this.User.Identity.Name;
                var commentObj = new Comment
                {
                    CreatedBy = user,
                    PostId = postId,
                    UserId = userId,
                };
                return View(commentObj);
            }
        }

        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Comment commentModel, int postId, string userId)
        {
            var user = this.User.Identity.Name;
            var thisPostId = postId;
            var datetime = System.DateTime.Today;
            var comment = new Comment
            {
                Message = commentModel.Message,
                CreationDate = DateTime.Now,
                CreatedBy = this.User.Identity.Name,
                Enabled = true,
                PostId = postId,
                UserId = userId,

            };

            if (ModelState.IsValid)
            {
                _repositoryWrapper.Comments.Create(comment);
                _repositoryWrapper.Save();
                return RedirectToAction("Detail", "PostsPerUser", new { postId = thisPostId });
            }

            return View(commentModel);
        }

    }
}