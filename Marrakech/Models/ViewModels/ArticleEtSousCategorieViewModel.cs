using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models.ViewModels
{
    public class ArticleEtSousCategorieViewModel
    {
        public Article Article { get; set; }

        public List<SousCategorie> SousCategoriesList { get; set; }

        public string StatusMessage { get; set; }
        public List<string> ArticlesList { get; set; }
    }
}
