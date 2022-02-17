using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_MDP.Models
{
    public class Flower
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Flower Name")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage= "Numele autorului trebuie 'Prenume Nume''"), Required, StringLength(50, MinimumLength = 3)]
        public string Bio { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime MaturingDate { get; set; }

        public int SellerID { get; set; }
        public Seller Seller { get; set; }

        public ICollection<FlowerCategory> FlowerCategories { get; set; }
    }
}
