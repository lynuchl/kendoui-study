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
    public class AddInfoController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person(int? id)
        {
            //could add code here to get model based on id....
            return PartialView("_Person");
            //calling partial with existing model....
            //return PartialView("_Person", model);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Person(PersonValidationViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = GetErrorsFromModelState();
        //        return Json(new { success = false, errors = errors });
        //        //return PartialView("_Person", model);
        //    }

        //    //save to persistent store;
        //    //return data back to post OR do a normal MVC Redirect....
        //    return Json(new { success = true });  //perhaps you want to do more on return.... otherwise this if block is not necessary....
        //    //return RedirectToAction("Index");
        //}

      



        private readonly OperatorInfoTestContext _context;

        public AddInfoController(OperatorInfoTestContext context)
        {
            _context = context;
        }

        //// GET: AddInfo
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.OperatorEntity.ToListAsync());
        //}

        // GET: AddInfo/Details/5
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

        // GET: AddInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddInfo/Create
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

        // GET: AddInfo/Edit/5
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

        // POST: AddInfo/Edit/5
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

        // GET: AddInfo/Delete/5
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

        // POST: AddInfo/Delete/5
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
