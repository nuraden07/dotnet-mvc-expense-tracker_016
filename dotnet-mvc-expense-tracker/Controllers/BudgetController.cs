using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using dotnet_mvc_expense_tracker.Models;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class BudgetController : Controller
    {
        private static List<Budget> _budgetData = new List<Budget>();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            // attach Kategori object for display (optional)
            foreach (var b in _budgetData)
            {
                b.Kategori = KategoriController.Data.FirstOrDefault(k => k.Id == b.KategoriId);
            }
            return View(_budgetData);
        }

        public IActionResult Create()
        {
            ViewBag.KategoriList = new SelectList(KategoriController.Data, "Id", "Nama");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                budget.Id = _nextId++;
                // attach category name/object for display later
                budget.Kategori = KategoriController.Data.FirstOrDefault(k => k.Id == budget.KategoriId);
                _budgetData.Add(budget);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.KategoriList = new SelectList(KategoriController.Data, "Id", "Nama", budget?.KategoriId);
            return View(budget);
        }

        public IActionResult Edit(int id)
        {
            var budget = _budgetData.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();
            ViewBag.KategoriList = new SelectList(KategoriController.Data, "Id", "Nama", budget.KategoriId);
            return View(budget);
        }

        [HttpPost]
        public IActionResult Edit(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KategoriList = new SelectList(KategoriController.Data, "Id", "Nama", budget?.KategoriId);
                return View(budget);
            }

            var existing = _budgetData.FirstOrDefault(x => x.Id == budget.Id);
            if (existing != null)
            {
                existing.KategoriId = budget.KategoriId;
                existing.Kategori = KategoriController.Data.FirstOrDefault(k => k.Id == budget.KategoriId);
                existing.Nama = budget.Nama;
                existing.Deskripsi = budget.Deskripsi;
                existing.TotalBudget = budget.TotalBudget;
                existing.StartDate = budget.StartDate;
                existing.EndDate = budget.EndDate;
                existing.IsRepeat = budget.IsRepeat;
                existing.Status = budget.Status;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var budget = _budgetData.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();
            budget.Kategori = KategoriController.Data.FirstOrDefault(k => k.Id == budget.KategoriId);
            return View(budget);
        }

        public IActionResult Delete(int id)
        {
            var budget = _budgetData.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();
            budget.Kategori = KategoriController.Data.FirstOrDefault(k => k.Id == budget.KategoriId);
            return View(budget);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var budget = _budgetData.FirstOrDefault(x => x.Id == id);
            if (budget != null) _budgetData.Remove(budget);
            return RedirectToAction(nameof(Index));
        }
    }
}
