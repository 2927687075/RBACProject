using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Common;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Model;

namespace RBACProject.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var userModel = userRepository.QuerySingle(it => it.Id == 10);

            return View(userModel);
        }

    }
}