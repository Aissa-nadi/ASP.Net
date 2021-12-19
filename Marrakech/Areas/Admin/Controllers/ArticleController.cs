using Marrakech.Data;
using Marrakech.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext db;

        [TempData]
        public string StatusMessage { get; set; }

        public ArticleController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var articles = db.Articles.Include(m => m.SousCategorie).ToList();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ArticleEtSousCategorieViewModel model = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = new Models.Article(),
                ArticlesList = await db.Articles.OrderBy(m => m.Name)
                                        .Select(m => m.Name)
                                        .Distinct()
                                        .ToListAsync()
            };
         
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleEtSousCategorieViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var listArticlesDansSousCategorie = await db.Articles.Include(m => m.SousCategorie)
                    .Where(m => m.SousCategorie.Id == model.Article.SousCategorieId && m.Name == model.Article.Name).ToListAsync();
                
                if (listArticlesDansSousCategorie.Count() == 0)
                {
                    db.Articles.Add(model.Article);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    
                    
                }
                else
                {
                    StatusMessage = "Error : cet article exise déja dans la sous categorie " +
                        listArticlesDansSousCategorie.FirstOrDefault().SousCategorie.Name;
                }

            }

            ArticleEtSousCategorieViewModel modelVm = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = model.Article,
                StatusMessage = StatusMessage,
                ArticlesList = await db.Articles
                                            .OrderBy(m => m.Name)
                                            .Select(m => m.Name)
                                            .Distinct()
                                            .ToListAsync()
            };
            return View(modelVm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ArticleEtSousCategorieViewModel model = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = db.Articles.Find(id),
                ArticlesList = await db.Articles.OrderBy(m => m.Name)
                                        .Select(m => m.Name)
                                        .Distinct()
                                        .ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ArticleEtSousCategorieViewModel model)
        {

            if (ModelState.IsValid)
            {

                
                db.Articles.Update(model.Article);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);

            /*if (ModelState.IsValid)
            {
                var listArticlesDansSousCategorie = await db.Articles.Include(m => m.SousCategorie)
                    .Where(m => m.SousCategorie.Id == model.Article.SousCategorieId && m.Name == model.Article.Name).ToListAsync();

                if (listArticlesDansSousCategorie.Count() == 0)
                {
                    db.Articles.Update(model.Article);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
                else
                {
                    StatusMessage = "Error : cet article exise déja dans la sous categorie " +
                        listArticlesDansSousCategorie.FirstOrDefault().SousCategorie.Name;
                }

            }

            ArticleEtSousCategorieViewModel modelVm = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = model.Article,
                StatusMessage = StatusMessage,
                ArticlesList = await db.Articles
                                            .OrderBy(m => m.Name)
                                            .Select(m => m.Name)
                                            .Distinct()
                                            .ToListAsync()
            };
            return View(modelVm);*/
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArticleEtSousCategorieViewModel model = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = db.Articles.Find(id),
                ArticlesList = await db.Articles.OrderBy(m => m.Name)
                                       .Select(m => m.Name)
                                       .Distinct()
                                       .ToListAsync()
            };

            return View(model);

            /*var articles = db.Articles.Find(id);

            if (articles == null)
            {
                return NotFound();
            }
            return View(articles);*/
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ArticleEtSousCategorieViewModel model)
        {

            db.Articles.Remove(model.Article);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {

            ArticleEtSousCategorieViewModel model = new ArticleEtSousCategorieViewModel()
            {
                SousCategoriesList = await db.SousCategories.ToListAsync(),
                Article = db.Articles.Find(id),
                ArticlesList = await db.Articles.OrderBy(m => m.Name)
                                       .Select(m => m.Name)
                                       .Distinct()
                                       .ToListAsync()
            };


            if (id == null)
            {
                return NotFound();
            }
           
            return View(model);
        }
    }
}
