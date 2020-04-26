using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OperatorInfoTest.Data;
using OperatorInfoTest.Models;

namespace OperatorInfoTest.Controllers
{
    public class AddInfoTestController : Controller
    {
        private readonly OperatorInfoTestContext _context;

        public AddInfoTestController(OperatorInfoTestContext context)
        {
            _context = context;
        }

        // GET: AddInfoTest
        public async Task<IActionResult> Index()
        {
            return View(await _context.OperatorEntity.ToListAsync());
        }

        // GET: AddInfoTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatorEntity = await _context.OperatorEntity
                .FirstOrDefaultAsync(m => m.id == id);
            if (operatorEntity == null)
            {
                return NotFound();
            }

            return View(operatorEntity);
        }

        // GET: AddInfoTest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddInfoTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,jobNumber,name,sex,password,idNumber,phone,address,State,birthday")] OperatorEntity operatorEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operatorEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operatorEntity);
        }

        // GET: AddInfoTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatorEntity = await _context.OperatorEntity.FindAsync(id);
            if (operatorEntity == null)
            {
                return NotFound();
            }
            return View(operatorEntity);
        }

        // POST: AddInfoTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,jobNumber,name,sex,password,idNumber,phone,address,State,birthday")] OperatorEntity operatorEntity)
        {
            if (id != operatorEntity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operatorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatorEntityExists(operatorEntity.id))
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
            return View(operatorEntity);
        }

        // GET: AddInfoTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operatorEntity = await _context.OperatorEntity
                .FirstOrDefaultAsync(m => m.id == id);
            if (operatorEntity == null)
            {
                return NotFound();
            }

            return View(operatorEntity);
        }

        // POST: AddInfoTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operatorEntity = await _context.OperatorEntity.FindAsync(id);
            _context.OperatorEntity.Remove(operatorEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperatorEntityExists(int id)
        {
            return _context.OperatorEntity.Any(e => e.id == id);
        }
    }
}
