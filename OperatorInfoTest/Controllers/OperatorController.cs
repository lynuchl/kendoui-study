using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OperatorInfoTest.Data;
using OperatorInfoTest.Models;

namespace OperatorInfoTest.Controllers
{
    public class OperatorController : Controller
    {
        public ActionResult Index()
        {

            ViewData["operatorData"] = _context.OperatorEntity.ToList();

            return View();
        }




        private readonly OperatorInfoTestContext _context;

        public OperatorController(OperatorInfoTestContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Students.ToListAsync());
        //}

        public ActionResult TestCon()
        {
            ViewData["name"] = "Hello";
            ViewData["NumTimes"] = "numTimes";
           
            return View();
        }

        public ActionResult AddInfo(OperatorEntity operatorEntity)
        {


            _context.OperatorEntity.Add(operatorEntity);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public ActionResult UpdateInfo(OperatorEntity operatorEntity)
        {
            _context.Update(operatorEntity);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public void Delete(int deleteDataID)
        {
            var deleteInfoDataID = deleteDataID;

            OperatorEntity operatorEntity = _context.OperatorEntity.Find(deleteInfoDataID);

            _context.OperatorEntity.Remove(operatorEntity);
            _context.SaveChanges();

            //return RedirectToAction(nameof(Index));

            //var cookie = Request["key"];
            //var deleteData = ViewData["deleteData"];

            //int a = 2;
            //int b = 3;
            //_context.OperatorEntity.Remove(operatorEntity);
            // _context.SaveChanges();
        }
    }
}