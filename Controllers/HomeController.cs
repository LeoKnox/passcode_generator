using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using random_passcode.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            //HttpContext.Session.SetString("RndCode", "abcd0123456789");
            string code = HttpContext.Session.GetString("RndCode");
            int? count = HttpContext.Session.GetInt32("count");
            count++;
            int cnt = count ?? default(int);
            HttpContext.Session.SetInt32("count", cnt);
            ViewBag.count = count;
            ViewBag.passcode = code;
            return View();
        }

        [HttpGet]
        [Route("show")]
        public IActionResult GenRand(){
            System.Console.WriteLine("clicked");
            HttpContext.Session.SetString("RndCode", "abcd0123456789");
            string code = HttpContext.Session.GetString("RndCode");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("clear")]
        public IActionResult clear(){
            HttpContext.Session.SetInt32("count", 0);
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
