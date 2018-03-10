using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace CRM.Controllers
{
    public class HomeController : Controller
    {

        private readonly CRMContext _context;

        public HomeController(CRMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["tipo"]= "nulo";
            Console.WriteLine(ViewData["tipo"]);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string password, string username)
        {
            if (ModelState.IsValid)
            {
                if (password == null || username == null)
                {
                    return NotFound();
                }

                var user = await _context.Usuario.SingleOrDefaultAsync(m => m.Password == password && m.Username == username);

                Console.WriteLine(user.Tipo);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {


                    if (Log.Login(user))
                    {

                        var tipo = user.Tipo.ToString();


                        HttpContext.Session.SetInt32("userid", user.ID);
                        HttpContext.Session.SetString("username", user.Username);
                        HttpContext.Session.SetString("tipo", user.Tipo);


                       
                            Console.WriteLine(HttpContext.Session.GetInt32("userid"));

                         if(tipo == "admin"){

                            return RedirectToAction("PageAdmin");
                         }

                            return RedirectToAction("PageUser");


                        
                     
                    }

                            return View("Index");

                }
            }
            return View("Index");
        }






        public IActionResult PageAdmin()
        {
             var tipo = (HttpContext.Session.GetString("tipo"));
            if(Log.logged && tipo=="admin"){
            var user = (HttpContext.Session.GetString("username"));
           
               ViewData["tipo"]= tipo;
            ViewData["Username"] = user;

            return View();
           }   return RedirectToAction("Index","Home");
        }

          public IActionResult PageUser()
        {
            if(Log.logged){
            var user = (HttpContext.Session.GetString("username"));
            var tipo = (HttpContext.Session.GetString("tipo"));
               ViewData["tipo"]= tipo;
            ViewData["Username"] = user;

            return View();
           }   return RedirectToAction("Index","Home");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
