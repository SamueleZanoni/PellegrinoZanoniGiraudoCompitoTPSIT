using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcConcessionaria.Models;

namespace MvcConcessionaria.Data
{
    public class MvcConcessionariaContext : DbContext
    {
        public MvcConcessionariaContext (DbContextOptions<MvcConcessionariaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcConcessionaria.Models.Concessionaria> Concessionaria { get; set; } = default!;
    }
}
