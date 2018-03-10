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
    public class TicketsController : Controller
    {
        private readonly CRMContext _context;

        public TicketsController(CRMContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
             if (Log.logged)
            {
                var IDUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("userid"));
                var tickets = from m in _context.Ticket
                               select m  ;

                tickets = tickets.Where(s => s.IDUsuario.Equals(IDUsuario));

                 tickets.Include(c => c.cliente);
              
                 return View(await tickets.ToListAsync());
            }
         return RedirectToAction("Index","Home");


        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
               if (Log.logged)
            {
                  ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");
            return View();
            }
           return RedirectToAction("Index","Home");
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Detalle,Quien_reporto,Estado_Actual,IDCliente,IDUsuario")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                 ticket.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", ticket.IDCliente);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
if(Log.logged){
            var ticket = await _context.Ticket.SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }
              ViewData["IDCliente"] = new SelectList(_context.Cliente, "ID", "Nombre");
            return View(ticket);
}
 return RedirectToAction("Index","Home");
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Detalle,Quien_reporto,Estado_Actual,IDCliente,IDUsuario")] Ticket ticket)
        {
            if (id != ticket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.IDUsuario =Convert.ToInt32(HttpContext.Session.GetInt32("userid" ));
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ID))
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
             ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nombre", ticket.IDCliente);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
if(Log.logged){
            var ticket = await _context.Ticket
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
} return RedirectToAction("Index","Home");
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.SingleOrDefaultAsync(m => m.ID == id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.ID == id);
        }
    }
}
