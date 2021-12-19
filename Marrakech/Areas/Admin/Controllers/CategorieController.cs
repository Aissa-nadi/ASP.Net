using Marrakech.Models;
using Marrakech.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategorieController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie categorie)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }
        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var categorie = db.Categories.Find(id);
            if(categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(categorie);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categorie categorie)
        {
            db.Categories.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }
        
    }
}
