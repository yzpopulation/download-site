using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.OrmLite;
using 下载站点.Models;

namespace 下载站点.Controllers
{
    public class HomeController : Controller
    {
        private OrmLiteConnectionFactory fac { get; set; }
        public HomeController(OrmLiteConnectionFactory _fac)
        {
            fac = _fac;
        }
        public IActionResult Index()
        {
            ViewData["Now"] = DateTime.Now;
            using (var db=fac.OpenDbConnection())
            {
                db.CreateTableIfNotExists<UrlItemModel>();
                db.CreateTableIfNotExists<TypeItemModel>();
                var pages = db.Count<UrlItemModel>() / 10;
                dynamic fyxx = new System.Dynamic.ExpandoObject();
                fyxx.currentpage = 1;
                fyxx.pages = pages==0?1:pages;
                ViewData["通用_软件列表_分页信息"]= fyxx;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
