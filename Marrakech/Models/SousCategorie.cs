using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marrakech.Models
{
    public class SousCategorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Nom Sous Catégorie")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Categorie")]
        public int CategorieId { get; set; }
        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

    }
}
