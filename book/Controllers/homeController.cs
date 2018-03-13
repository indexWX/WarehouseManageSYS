using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using book.model;

namespace book.Controllers
{
    public class homeController : Controller
    {
        masterEntities db = new masterEntities();
        // GET: home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult LoginCheck(string Password, string LoginName)
        {
            List<T_Base_Admin> lst = db.T_Base_Admin.Where(m => m.LoginName == LoginName && m.Pwd == Password).ToList();
            if (lst.Count > 0)
            {
                //int id = lst[0].Id;data=id
                Session["admin"] = lst[0];
                return Json(new { code = 1, message = "登录成功" });
            }
            else
            {
                return Json(new { code = 0, message = "登录失败" });
            }
        }

    }
}