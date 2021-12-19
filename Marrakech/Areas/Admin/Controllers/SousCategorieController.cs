using Marrakech.Data;
using Marrakech.Models;
using Marrakech.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SousCategorieController : Controller
    {
        private readonly ApplicationDbContext db;
        [TempData]
        public string StatusMessage { get; set; }

        public SousCategorieController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var sousCategories = db.SousCategories.Include(m => m.Categorie).ToList();
            return View(sousCategories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SousCategorieEtCategorieViewModel model = new SousCategorieEtCategorieViewModel()
            {
                CategorieList = await db.Categories.ToListAsync(),
                SousCategorie = new Models.SousCategorie(),
                SousCategoriesList = await db.SousCategories
                                        .OrderBy(m=>m.Name)
                                        .Select(m=>m.Name)
                                        .Distinct()
                                        .ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SousCategorieEtCategorieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var listSousCategoriesDansCategorie =
                    await db.SousCategories.Include(m => m.Categorie)
                    .Where(m => m.Categorie.Id == model.SousCategorie.CategorieId
                            && m.Name == model.SousCategorie.Name).ToListAsync();
                if (listSousCategoriesDansCategorie.Count() == 0)
                {
                    db.SousCategories.Add(model.SousCategorie);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    StatusMessage = "Error : cette sous catégorie exise déja dans la catégorie " +
                        listSousCategoriesDansCategorie.FirstOrDefault().Categorie.Name;
                }
                
            }
            SousCategorieEtCategorieViewModel modelVm = new
                SousCategorieEtCategorieViewModel()
            {
                CategorieList = await db.Categories.ToListAsync(),
                SousCategorie = model.SousCategorie,
                StatusMessage = StatusMessage,
                SousCategoriesList = await db.SousCategories
                                            .OrderBy(m=>m.Name)
                                            .Select(m=>m.Name)
                                            .Distinct()
                                            .ToListAsync()
            };
            return View(modelVm);
        }
        [HttpGet]
        public async Task<IActionResult> GetSousCategories(int id)
        {
            List<SousCategorie> sousCategories = new List<SousCategorie>();
            sousCategories = await db.SousCategories.Where(m => m.CategorieId == id).ToListAsync();
            return Json(new SelectList(sousCategories, "Id", "Name"));
        }
        
    }
}
