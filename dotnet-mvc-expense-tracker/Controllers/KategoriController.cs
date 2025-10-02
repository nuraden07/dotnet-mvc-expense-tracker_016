using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using dotnet_mvc_expense_tracker.Models;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class KategoriController : Controller
    {
        // PUBLIC STATIC DATA so other controllers (BudgetController) can read it
        public static List<Kategori> Data { get; } = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe = "income", Nama = "Gaji", Deskripsi = "Pemasukan bulanan", Status = "active" },
            new Kategori { Id = 2, Tipe = "expense", Nama = "Makan", Deskripsi = "Pengeluaran makan", Status = "active" }
        };

        private static int _nextId = Data.Count > 0 ? Data.Max(x => x.Id) + 1 : 1;

        public IActionResult Index()
        {
            ViewData["Title"] = "Master Data Kategori";
            return View(Data);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Tambah Kategori";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori model)
        {
            if (!ModelState.IsValid) return View(model);
            model.Id = _nextId++;
            Data.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = Data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Kategori model)
        {
            if (!ModelState.IsValid) return View(model);
            var item = Data.FirstOrDefault(x => x.Id == model.Id);
            if (item != null)
            {
                item.Tipe = model.Tipe;
                item.Nama = model.Nama;
                item.Deskripsi = model.Deskripsi;
                item.Status = model.Status;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var item = Data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = Data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = Data.FirstOrDefault(x => x.Id == id);
            if (item != null) Data.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
