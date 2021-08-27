using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiz.Controllers.Filter;
using quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz.Controllers
{
    [UserFilter]
    public class IndexController : Controller
    {
        private readonly Context _context;
        public IndexController(Context context)
        {
            _context = context;
        }
      

        [HttpGet]
        public IActionResult Index()
        {
            if (_context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value)) != null)
            {
                var dep = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                ViewBag.score = dep.TrueCount;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(bool deger)
        {
            if(deger == true)
            {
                if (_context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value)) != null)
                {
                    var dep = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                    _context.Counts.Find(dep.CountID);
                    _context.Counts.Remove(dep);
                    _context.SaveChanges();
                }
                return Redirect("/Index/Index2");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }

        [HttpGet]
        public IActionResult Index2()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index2(Count c,int trya)
        {
            c.UserID = HttpContext.Session.GetInt32("id").Value;
            c.TrueCount = 0;
            if (trya == 1)
            {   
             c.TrueCount = c.TrueCount + 1;    
              //veritabanındaki doğru sayısı 1 arttırılır
            }
            await _context.AddAsync(c);
            await _context.SaveChangesAsync();
            return Redirect("/Index/Index3");
        }

        [HttpGet]
        public IActionResult Index3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index3(int trya)
        {
            if (trya == 2)
            {
                var aas = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                aas.TrueCount = aas.TrueCount + 1;
                _context.SaveChanges();
                //veritabanındaki doğru sayısı 1 arttırılır
            }
            return Redirect("/Index/Index4");
        }

        [HttpGet]
        public IActionResult Index4()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index4(int trya)
        {
            if (trya == 3)
            {
                var aas = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                aas.TrueCount = aas.TrueCount + 1;
                _context.SaveChanges();
                //veritabanındaki doğru sayısı 1 arttırılır
            }
            return Redirect("/Index/Index5");
        }

        [HttpGet]
        public IActionResult Index5()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index5(int trya)
        {
            if (trya == 2)
            {
                var aas = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                aas.TrueCount = aas.TrueCount + 1;
                _context.SaveChanges();
                //veritabanındaki doğru sayısı 1 arttırılır
            }
            return Redirect("/Index/Index6");
        }

        [HttpGet]
        public IActionResult Index6()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index6(int trya)
        {
            if (trya == 1)
            {
                var aas = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
                aas.TrueCount = aas.TrueCount + 1;
                _context.SaveChanges();
                //veritabanındaki doğru sayısı 1 arttırılır
            }
            return Redirect("/Index/LastPage");
        }

        public IActionResult LastPage()
        {
            var aas = _context.Counts.FirstOrDefault(x => x.UserID.Equals(HttpContext.Session.GetInt32("id").Value));
            ViewBag.adam = aas.TrueCount;
            return View();
        }

    }
}
