using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SportBlog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SportBlog.Controllers
{
    public class PostsController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        public PostsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public IActionResult Index(string userId=null)
        {
            if (userId==null)
            {
                this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
            var _model = _repositoryWrapper.PostPerUser.FindPostsPerUser(userId);
            return View(_model);
        }
    }
}