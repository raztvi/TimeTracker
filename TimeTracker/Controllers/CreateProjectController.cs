using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Models;

namespace TimeTracker.Controllers
{
    public class CreateProjectController : Controller
    {
        private readonly TimeTrackerContext _context;

        public CreateProjectController(TimeTrackerContext context)
        {
            _context = context;    
        }

        // GET: CreateProject
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreateProjectModel.ToListAsync());
        }

        // GET: CreateProject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createProjectModel = await _context.CreateProjectModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (createProjectModel == null)
            {
                return NotFound();
            }

            return View(createProjectModel);
        }

        // GET: CreateProject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreateProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectName,TaskName,StartDate,EndDate")] CreateProjectModel createProjectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(createProjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(createProjectModel);
        }

        // GET: CreateProject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createProjectModel = await _context.CreateProjectModel.SingleOrDefaultAsync(m => m.ID == id);
            if (createProjectModel == null)
            {
                return NotFound();
            }
            return View(createProjectModel);
        }

        // POST: CreateProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectName,TaskName,StartDate,EndDate")] CreateProjectModel createProjectModel)
        {
            if (id != createProjectModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(createProjectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreateProjectModelExists(createProjectModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(createProjectModel);
        }

        // GET: CreateProject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var createProjectModel = await _context.CreateProjectModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (createProjectModel == null)
            {
                return NotFound();
            }

            return View(createProjectModel);
        }

        // POST: CreateProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var createProjectModel = await _context.CreateProjectModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.CreateProjectModel.Remove(createProjectModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CreateProjectModelExists(int id)
        {
            return _context.CreateProjectModel.Any(e => e.ID == id);
        }
    }
}
