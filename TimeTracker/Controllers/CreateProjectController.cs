using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
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

        // POST CreateProject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProjectName,TaskName,StartDate,EndDate,ClientName,ClientAdress")] CreateProjectModel createProjectModel)
        {
            bool valid = true;
            if(DateTime.Compare(createProjectModel.StartDate,createProjectModel.EndDate)>0)
            {
                ModelState.AddModelError("", "Start Date cannot be greater than End Date");
                valid = false;
            }
            if (ModelState.IsValid && valid)
            {
                _context.Add(createProjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(createProjectModel);
        }


        public IActionResult Invoice()
        {
            List<CreateProjectModel> invoiceList = new List<CreateProjectModel>();

            invoiceList = (from product in _context.CreateProjectModel select product).ToList();
            invoiceList.Insert(0, new CreateProjectModel { ID = 0, ProjectName = "Select" });
            ViewBag.ListofInvoice = invoiceList;
            return View();
        }

        [HttpPost]
        public IActionResult Invoice(CreateProjectModel Invoice)
        {
            if (Invoice.ID ==0)
            {
                ModelState.AddModelError("", "Please select a project");
            }
            var SelectValue = Invoice.ID;
            ViewBag.SelectedValue = Invoice.ID;

            List<CreateProjectModel> invoiceList = new List<CreateProjectModel>();

            invoiceList = (from product in _context.CreateProjectModel select product).ToList();

            invoiceList.Insert(0, new CreateProjectModel { ID = 0, ProjectName = "Select" });
            ViewBag.ListofInvoice = invoiceList;

            return View();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProjectName,TaskName,StartDate,EndDate,ClientName,ClientAdress")] CreateProjectModel createProjectModel)
        {
            if (id != createProjectModel.ID)
            {
                return NotFound();
            }

            bool valid = true;
            if (DateTime.Compare(createProjectModel.StartDate, createProjectModel.EndDate) > 0)
            {
                ModelState.AddModelError("", "Start Date cannot be greater than End Date");
                valid = false;
            }

            if (ModelState.IsValid && valid)
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
