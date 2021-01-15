using DoAnGiay.Areas.Admin.Data;
using DoAnGiay.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Controllers
{
    public class LoginController : Controller
    {
        private readonly DPContext _context;
        public LoginController(DPContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("AccountName, Password")] AccountModel accountModel)
        {
            var r = _context.Account.Where(m => (m.AccountName == accountModel.AccountName && m.Password == StringProcessing.CreateMD5Hash(accountModel.Password))).ToList();

            if (r.Count == 0)
            {
                return View("Index");
            }
            var str = JsonConvert.SerializeObject(accountModel);
            HttpContext.Session.SetString("user", str);
            if (r[0].Rule == 0)
            {
                var url = Url.RouteUrl("areas", new { controller = "Home", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
