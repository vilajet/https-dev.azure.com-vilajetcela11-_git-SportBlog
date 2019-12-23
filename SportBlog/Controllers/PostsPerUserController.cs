using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using SportBlog.Models;
using SportBlog.Repositories;
using SportBlog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace SportBlog.Controllers
{
    public class PostsPerUserController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;

        private readonly IHostingEnvironment _hostingEnvironment;       

        public PostsPerUserController(IRepositoryWrapper repositoryWrapper, IHostingEnvironment hostingEnvironment)
        {
            _repositoryWrapper = repositoryWrapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string userId = null)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            else
            {
                if (userId == null)
                {
                    userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                }
                var _model = _repositoryWrapper.PostPerUser.FindPostsPerUser(userId);
                return View(_model);
            }
        }

        public IActionResult Create(string userId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Account");

            }
            
            var tags = _repositoryWrapper.Tags.FindAll().ToList();
            List<Tag> selectLista = new List<Tag>();
            PostsViewModel postObj = new PostsViewModel
            {
                UserId = userId,
                Tags= tags,

            };
            return View(postObj);          
        }


        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(PostsViewModel model, string userId)
        {
            var files = HttpContext.Request.Form.Files;
            var usedFileName = default(string);
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;

                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\img\\posts");

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim('"');

                        System.Console.WriteLine(fileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            usedFileName = file.FileName;
                        }
                    }
                }
            }
            var post = new Post
            {
                Title = model.Title,
                Body = model.Body,
                CreationDate = DateTime.Now,
                CreatedBy = this.User.Identity.Name,
                Enabled = true,
                PostImage = usedFileName,
                UserId = userId,
            };
            var listTagsId = new List<int>();
            foreach(var tagItem in model.Tags)
            {
                tagItem.CreatedBy = User.Identity.Name;
                if (tagItem.IsSelected)
                {
                    listTagsId.Add(tagItem.TagId);

                }
            }
            
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Post.Create(post);
                var thisPost = post;
                _repositoryWrapper.Save();
                foreach (var element in listTagsId)
                {
                    var postTags = new PostTag
                    {
                        PostId = thisPost.PostId,
                        TagId = element,
                    };
                    _repositoryWrapper.PostTags.Create(postTags);
                    _repositoryWrapper.Save();
                }
                return RedirectToAction(nameof(Index), new { userId = post.UserId });
            }

            return View(model);
        }

        public  IActionResult Detail(int? postId)
        {

            if (postId == null)
            {
                return NotFound();
            }
            var post = _repositoryWrapper.PostCategory.GetFullPost((int)postId);
            if (post == null)
            {
                NotFound();
            }

            return View(post);
        }

        public IActionResult BackToList(string userId=null)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                if (userId == null)
                {
                    userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                }
                return RedirectToAction(nameof(Index), new { userId = userId }); ;
            }
            
        }

    }
}