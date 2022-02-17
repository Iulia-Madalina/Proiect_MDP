using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP.Models;

namespace Proiect_MDP.Data
{
    public class Proiect_MDPContext : DbContext
    {
        public Proiect_MDPContext (DbContextOptions<Proiect_MDPContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_MDP.Models.Flower> Flower { get; set; }

        public DbSet<Proiect_MDP.Models.Seller> Seller { get; set; }

        public DbSet<Proiect_MDP.Models.Category> Category { get; set; }
    }
}
