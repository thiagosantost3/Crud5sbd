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
    public class AlunoTurmaController : Controller
    {
        private readonly BancoDeDados _context;

        public AlunoTurmaController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: AlunoTurma
        public async Task<IActionResult> Index()
        {
            var bancoDeDados = _context.AlunoTurma.Include(a => a.Aluno).Include(a => a.Turma);
            return View(await bancoDeDados.ToListAsync());
        }

        // GET: AlunoTurma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurma
                .Include(a => a.Aluno)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            return View(alunoTurma);
        }

        // GET: AlunoTurma/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id");
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id");
            return View();
        }

        // POST: AlunoTurma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,AlunoId")] AlunoTurma alunoTurma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoTurma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // GET: AlunoTurma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurma.FindAsync(id);
            if (alunoTurma == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // POST: AlunoTurma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurmaId,AlunoId")] AlunoTurma alunoTurma)
        {
            if (id != alunoTurma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoTurma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoTurmaExists(alunoTurma.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoTurma.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", alunoTurma.TurmaId);
            return View(alunoTurma);
        }

        // GET: AlunoTurma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoTurma = await _context.AlunoTurma
                .Include(a => a.Aluno)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            return View(alunoTurma);
        }

        // POST: AlunoTurma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoTurma = await _context.AlunoTurma.FindAsync(id);
            if (alunoTurma != null)
            {
                _context.AlunoTurma.Remove(alunoTurma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoTurmaExists(int id)
        {
            return _context.AlunoTurma.Any(e => e.Id == id);
        }
    }
}
