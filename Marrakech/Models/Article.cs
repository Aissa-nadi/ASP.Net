using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom Article")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Prix Article")]
        public double prix { get; set; }
        [Required]
        [Display(Name = "Sous Categorie")]
        public int SousCategorieId { get; set; }
        [ForeignKey("SousCategorieId")]
        public virtual SousCategorie SousCategorie { get; set; }
    }
}
