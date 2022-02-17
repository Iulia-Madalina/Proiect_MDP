using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MDP.Models
{
    public class FlowerCategory
    {
        public int ID { get; set; }
        public int FlowerID { get; set; }
        public Flower Flower { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
