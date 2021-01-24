using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikUsers.Models;
using TelerikUsers.Data;

namespace TelerikUsers.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            return Json(UsersContext.Users.ToDataSourceResult(request));
        }

        public ActionResult CreateUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
                UsersContext.Add(user);
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult UpdateUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
                UsersContext.Update(user);
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult RemoveUser([DataSourceRequest] DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
                UsersContext.Remove(user);
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
    }
}
