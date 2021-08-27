using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gir(string email, string sifre)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Sifre.Equals(sifre));
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.AdminID);
                HttpContext.Session.SetString("mail", user.Email);
                HttpContext.Session.SetString("fullname", user.Ad+" "+user.Soyad);
                return Redirect("/Index/Index");
            }
            return Redirect("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login/Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<ActionResult> SignUp(User u)
        {
            await _context.AddAsync(u);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult Forgot()
        {
            ViewData["Hata"] = "Merhaba";
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(string email, string isim, string soyad)
        {
            var aas = _context.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Ad.Equals(isim) && x.Soyad.Equals(soyad));
            if (aas != null)
            {
                ViewData["Hata"] = "Doğru Yoldasın";
               ViewBag.sifre = aas.Sifre;
                return View();
            }
            else
            {
                ViewData["Hata"] = "Yanlış Yoldasın";
                return View();
            }
        }
    }
}
