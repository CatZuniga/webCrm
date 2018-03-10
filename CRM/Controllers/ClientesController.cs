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
    public class ClientesController : Controller
    {
        private readonly CRMContext _context;

        public ClientesController(CRMContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            if (Log.logged)
            {
                var IDUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
                var clientes = from m in _context.Cliente
                               select m;

                clientes = clientes.Where(s => s.IDUsuario.Equals(IDUsuario));


                return View(await clientes.ToListAsync());
            }
            return RedirectToAction("Index","Home");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
   if (Log.logged){
            var cliente = await _context.Cliente
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
            }
          return RedirectToAction("Index","Home");
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
             if (Log.logged)
            {
            return View();
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Cedula,Pagina_Web,Direccion,Telefono,Sector,IDUsuario")] Cliente cliente)
        {
            
            if (ModelState.IsValid)
            {
                  cliente.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
       
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
              if (Log.logged)
            {
           
            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Cedula,Pagina_Web,Direccion,Telefono,Sector,IDUsuario")] Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                   cliente.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
      
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ID))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (Log.logged)
            {
           
            var cliente = await _context.Cliente
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
            
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ID == id);
        }
    }
}
