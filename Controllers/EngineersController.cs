using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMScreenInterview.Data;
using AMScreenInterview.Models.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AMScreenInterview.Controllers
{
    public class EngineersController : Controller
    {
        private readonly AMScreenContext _context;

        public EngineersController(AMScreenContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Display a view containing all job details for the given engineer.
        /// </summary>
        /// <param name="id">ID of engineer in database.</param>
        /// <returns>View</returns>
        public async Task<IActionResult> Jobs(int id)
        {
            // Get all current engineer jobs
            var engineerJobs = _context.EngineerJobs.Where(exp => exp.EngineerId == id).ToArray();
            
            // Assign get the issue for the job
            foreach(var job in engineerJobs)
            {
                job.Issue = await _context.Issue.FindAsync(job.IssueId);
            }

            ViewData["Jobs"] = engineerJobs;

            // Display view
            return View();
        }

        // GET: Engineers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Engineer.ToListAsync());
        }

        // GET: Engineers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // GET: Engineers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engineers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        // GET: Engineers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }
            return View(engineer);
        }

        // POST: Engineers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Engineer engineer)
        {
            if (id != engineer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineerExists(engineer.Id))
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
            return View(engineer);
        }

        // GET: Engineers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        // POST: Engineers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineer = await _context.Engineer.FindAsync(id);
            _context.Engineer.Remove(engineer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineerExists(int id)
        {
            return _context.Engineer.Any(e => e.Id == id);
        }
    }
}
