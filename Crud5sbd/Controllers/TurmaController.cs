using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud5sbd.DataBase;
using Crud5sbd.Models;

namespace Crud5sbd.Controllers
{
    public class TurmaController : Controller
    {
        private readonly BancoDeDados _context;

        public TurmaController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Turma
        public async Task<IActionResult> Index()
        {
            var bancoDeDados = _context.Turma.Include(t => t.Disciplina).Include(t => t.Professor);
            return View(await bancoDeDados.ToListAsync());
        }

        // GET: Turma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Disciplina)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turma/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id");
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id");
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Turno,DisciplinaId,ProfessorId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turma.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", turma.ProfessorId);
            return View(turma);
        }

        // GET: Turma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turma.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", turma.ProfessorId);
            return View(turma);
        }

        // POST: Turma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Turno,DisciplinaId,ProfessorId")] Turma turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
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
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turma.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", turma.ProfessorId);
            return View(turma);
        }

        // GET: Turma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.Disciplina)
                .Include(t => t.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turma.FindAsync(id);
            if (turma != null)
            {
                _context.Turma.Remove(turma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.Id == id);
        }
    }
}
