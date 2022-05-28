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
    public class CarroController : Controller
    {
        private readonly CarWashContext _context;

        public CarroController(CarWashContext context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            var carWashContext = _context.CarroModel.Include(c => c.Proprietario);
            return View(await carWashContext.ToListAsync());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _context.CarroModel
                .Include(c => c.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroModel == null)
            {
                return NotFound();
            }

            return View(carroModel);
        }

        // GET: Carro/Create
        public IActionResult Create()
        {
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome");
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Marca,Cor,Modelo,Placa,ProprietarioId")] CarroModel carroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", carroModel.ProprietarioId);
            return View(carroModel);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _context.CarroModel.FindAsync(id);
            if (carroModel == null)
            {
                return NotFound();
            }
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", carroModel.ProprietarioId);
            return View(carroModel);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Marca,Cor,Modelo,Placa,ProprietarioId")] CarroModel carroModel)
        {
            if (id != carroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroModelExists(carroModel.Id))
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
            ViewData["ProprietarioId"] = new SelectList(_context.ProprietarioModel, "Id", "Nome", carroModel.ProprietarioId);
            return View(carroModel);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroModel = await _context.CarroModel
                .Include(c => c.Proprietario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroModel == null)
            {
                return NotFound();
            }

            return View(carroModel);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carroModel = await _context.CarroModel.FindAsync(id);
            _context.CarroModel.Remove(carroModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroModelExists(int id)
        {
            return _context.CarroModel.Any(e => e.Id == id);
        }
    }
}
