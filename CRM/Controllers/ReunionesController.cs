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
    public class ReunionesController : Controller
    {
        private readonly CRMContext _context;

        public ReunionesController(CRMContext context)
        {
            _context = context;
        }

        // GET: Reuniones
        public async Task<IActionResult> Index()
        {
            if (Log.logged)
            {
                var IDUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
                var reuniones = from m in _context.Reunion
                                select m;

                reuniones = reuniones.Where(s => s.IDUsuario.Equals(IDUsuario));

                reuniones.Include(c => c.cliente);

                return View(await reuniones.ToListAsync());
            }
          return RedirectToAction("Index","Home");


        }

        // GET: Reuniones/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (Log.logged)
            {

                var reunion = await _context.Reunion
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (reunion == null)
                {
                    return NotFound();
                }

                return View(reunion);

            }
           return RedirectToAction("Index","Home");

        }

        // GET: Reuniones/Create
        public IActionResult Create()
        {
            if (Log.logged)
            {
                  ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");
                return View();
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Reuniones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,DiaHora,Virtual,IDCliente,IDUsuario")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                 reunion.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
                _context.Add(reunion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", reunion.IDCliente);
            return View(reunion);
        }

        // GET: Reuniones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (Log.logged)
            {

                var reunion = await _context.Reunion.SingleOrDefaultAsync(m => m.ID == id);
                if (reunion == null)
                {
                    return NotFound();
                }
                  ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");
                return View(reunion);
            }
            return RedirectToAction("Index","Home");
        }

        // POST: Reuniones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,DiaHora,Virtual,IDCliente,IDUsuario")] Reunion reunion)
        {
            if (id != reunion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     reunion.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
                    _context.Update(reunion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReunionExists(reunion.ID))
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
             ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", reunion.IDCliente);
            return View(reunion);
        }

        // GET: Reuniones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (Log.logged)
            {

                var reunion = await _context.Reunion
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (reunion == null)
                {
                    return NotFound();
                }

                return View(reunion);
            }
           return RedirectToAction("Index","Home");
        }

        // POST: Reuniones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reunion = await _context.Reunion.SingleOrDefaultAsync(m => m.ID == id);
            _context.Reunion.Remove(reunion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReunionExists(int id)
        {
            return _context.Reunion.Any(e => e.ID == id);
        }
    }
}
