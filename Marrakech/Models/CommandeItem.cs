using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models
{
    public class CommandeItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Commande")]
        public int CommandeId { get; set; }
        [ForeignKey("CommandeId")]
        public virtual Commande Commande { get; set; }

        [Required]
        [Display(Name = "Article")]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        [Required]
        [Display(Name = "Quantite")]
        public int Quantite { get; set; }
    }
}
