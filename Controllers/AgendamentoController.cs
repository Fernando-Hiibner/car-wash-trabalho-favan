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
    public class AgendamentoController : Controller
    {
        private readonly CarWashContext _context;

        public AgendamentoController(CarWashContext context)
        {
            _context = context;
        }

        // GET: Agendamento
        public async Task<IActionResult> Index()
        {
            var carWashContext = _context.AgendamentoModel.Include(a => a.Carro).Include(a => a.Servico);
            return View(await carWashContext.ToListAsync());
        }

        // GET: Agendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel
                .Include(a => a.Carro)
                .Include(a => a.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }

            return View(agendamentoModel);
        }

        // GET: Agendamento/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.CarroModel, "Id", "Nome");
            ViewData["ServicoId"] = new SelectList(_context.ServicoModel, "Id", "Nome");
            return View();
        }

        // POST: Agendamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDeAgendamento,CarroId,ServicoId")] AgendamentoModel agendamentoModel)
        {
            var carro = _context.CarroModel.Where<CarroModel>(x => x.Id == agendamentoModel.CarroId);
            CarroModel carroModel = carro.SingleOrDefault();

            if (ModelState.IsValid && (carroModel?.InserirAgendamento(agendamentoModel) ?? false))
            {
                _context.Add(agendamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Erro"] = true;
            }

            ViewData["CarroId"] = new SelectList(_context.CarroModel, "Id", "Nome", agendamentoModel.CarroId);
            ViewData["ServicoId"] = new SelectList(_context.ServicoModel, "Id", "Nome", agendamentoModel.ServicoId);
            return View(agendamentoModel);
        }

        // GET: Agendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.CarroModel, "Id", "Nome", agendamentoModel.CarroId);
            ViewData["ServicoId"] = new SelectList(_context.ServicoModel, "Id", "Nome", agendamentoModel.ServicoId);
            return View(agendamentoModel);
        }

        // POST: Agendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDeAgendamento,CarroId,ServicoId")] AgendamentoModel agendamentoModel)
        {
            if (id != agendamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoModelExists(agendamentoModel.Id))
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
            ViewData["CarroId"] = new SelectList(_context.CarroModel, "Id", "Nome", agendamentoModel.CarroId);
            ViewData["ServicoId"] = new SelectList(_context.ServicoModel, "Id", "Nome", agendamentoModel.ServicoId);
            return View(agendamentoModel);
        }

        // GET: Agendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel
                .Include(a => a.Carro)
                .Include(a => a.Servico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }

            return View(agendamentoModel);
        }

        // POST: Agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);
            _context.AgendamentoModel.Remove(agendamentoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoModelExists(int id)
        {
            return _context.AgendamentoModel.Any(e => e.Id == id);
        }
    }
}
