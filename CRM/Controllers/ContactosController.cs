using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Models;
using Microsoft.AspNetCore.Http;

namespace CRM.Controllers
{
    public class ContactosController : Controller
    {
        private readonly CRMContext _context;

        public ContactosController(CRMContext context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Index()
        {

            if (Log.logged)
            {
                var IDUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
                var contactos = from m in _context.Contacto
                               select m  ;

                contactos = contactos.Where(s => s.IDUsuario.Equals(IDUsuario));

                 contactos.Include(c => c.cliente);
              
                 return View(await contactos.ToListAsync());
            }
            return Redirect("Home/Index");




        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
              .Include(c => c.cliente)
               .SingleOrDefaultAsync(m => m.ID == id);



            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            if (Log.logged)
            {
                ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");

                return View();
            }
            return Redirect("Home/Index");
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellidos,Correo,Telefono,Puesto,IDCliente,IDUsuario")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
       
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", contacto.IDCliente);
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 if (Log.logged)
            {
              
            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.ID == id);
            if (contacto == null)
            {
                return NotFound();
            }
             ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");
          
            return View(contacto);

           
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellidos,Correo,Telefono,Puesto,IDCliente,IDUsuario")] Contacto contacto)
        {
            if (id != contacto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                      contacto.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", contacto.IDCliente);
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 if (Log.logged)
            {
           
            var contacto = await _context.Contacto
                .SingleOrDefaultAsync(m => m.ID == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
             }
            return RedirectToAction("Index","Home");
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.ID == id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.ID == id);
        }
    }
}
