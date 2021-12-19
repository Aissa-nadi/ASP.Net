using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models.ViewModels
{
    public class CommandItemsEtCommandViewModel
    {
        public CommandeItem CommandeItem { get; set; }


        public Commande Commande { get; set; }


        public List<Article> ArticleList { get; set; }

        public List<Commande> CommandeList { get; set; }


        public string StatusMessage { get; set; }
        public List<int> CommandeItemList { get; set; }
    }
}
