using DoAnGiay.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            AccountModel mem = new AccountModel();
            mem.AccountName = us.SelectToken("AccountName").ToString();
            mem.Password = us.SelectToken("Password").ToString();
            mem.Rule = Int32.Parse(us.SelectToken("Rule").ToString());
            return View(mem);
        }
    }
}
