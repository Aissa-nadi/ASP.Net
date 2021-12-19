using Marrakech.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marrakech.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Marrakech.Areas.Client.Controllers
{
    [Area("Client")]
    public class CommandeController : Controller
    {
        private readonly ApplicationDbContext db;


        [TempData]
        public string StatusMessage { get; set; }

        public CommandeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            CommandItemsEtCommandViewModel modelCommandsItems = new CommandItemsEtCommandViewModel()
            {
                ArticleList = await db.Articles.ToListAsync(),
                Commande = new Models.Commande(),
                CommandeItem = new Models.CommandeItem(),
                CommandeItemList = await db.CommandeItems
                                        .OrderBy(m => m.Id)
                                        .Select(m => m.Id)
                                        .Distinct()
                                        .ToListAsync()
            };

            return View(modelCommandsItems);


        }
        
    }
}
