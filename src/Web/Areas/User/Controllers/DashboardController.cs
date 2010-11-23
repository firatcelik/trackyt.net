﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Infrastructure.Security;
using Trackyt.Core.DAL.Repositories;
using Trackyt.Core.DAL.Extensions;
using Web.Infrastructure.Helpers;

namespace Web.Areas.User.Controllers
{
    [TrackyAuthorizeAttribute(LoginController = "Login")]
    public class DashboardController : Controller
    {
        private IUsersRepository _repository;
        private IFormsAuthentication _authentication;
        private IPathHelper _path;

        public DashboardController(IUsersRepository repository, IFormsAuthentication authentication, IPathHelper path)
        {
            _repository = repository;
            _authentication = authentication;
            _path = path;
        }

        //[Authorize]
        public ActionResult Index()
        {
            var userEmail = _authentication.GetLoggedUser();
            var user = _repository.Users.WithEmail(userEmail);
            ViewData["UserId"] = user.Id;;
            ViewData["Api"] = _path.VirtualToAbsolute("~/API/v1");
            ViewData["Email"] = userEmail;
            ViewData["Password"] = user.Password; 

            return View();
        }

    }
}