using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MDP.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string SellerName { get; set; }
        public ICollection<Flower> Flowers { get; set; }
    }
}
