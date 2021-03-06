using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarWash.Models;

namespace Car_Wash.Controllers
{
    public class ServicoController : Controller
    {
        private readonly CarWashContext _context;

        public ServicoController(CarWashContext context)
        {
            _context = context;
        }

        // GET: Servico
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServicoModel.ToListAsync());
        }

        // GET: Servico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.ServicoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicoModel == null)
            {
                return NotFound();
            }

            return View(servicoModel);
        }

        // GET: Servico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] ServicoModel servicoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicoModel);
        }

        // GET: Servico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.ServicoModel.FindAsync(id);
            if (servicoModel == null)
            {
                return NotFound();
            }
            return View(servicoModel);
        }

        // POST: Servico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] ServicoModel servicoModel)
        {
            if (id != servicoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoModelExists(servicoModel.Id))
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
            return View(servicoModel);
        }

        // GET: Servico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicoModel = await _context.ServicoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicoModel == null)
            {
                return NotFound();
            }

            return View(servicoModel);
        }

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicoModel = await _context.ServicoModel.FindAsync(id);
            _context.ServicoModel.Remove(servicoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoModelExists(int id)
        {
            return _context.ServicoModel.Any(e => e.Id == id);
        }
    }
}
