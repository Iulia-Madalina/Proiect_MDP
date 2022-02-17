using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MDP.Models
{
    public class FlowerData
    {
        public IEnumerable<Flower> Flowers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FlowerCategory> FlowerCategories { get; set; }
    }
}
