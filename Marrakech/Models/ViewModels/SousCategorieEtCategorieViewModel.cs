using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models.ViewModels
{
    public class SousCategorieEtCategorieViewModel
    {
        public SousCategorie SousCategorie { get; set; }
        public List<Categorie> CategorieList { get; set; }
        public string StatusMessage { get; set; }
        public List<string> SousCategoriesList { get; set; }
    }
}
