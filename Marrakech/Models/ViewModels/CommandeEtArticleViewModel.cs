using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models.ViewModels
{
    public class CommandeEtArticleViewModel
    {
        public Commande Commande { get; set; }


        public List<Article> ArticlesList { get; set; }


        public string StatusMessage { get; set; }
        public List<int> CommandeList { get; set; }
    }
}
