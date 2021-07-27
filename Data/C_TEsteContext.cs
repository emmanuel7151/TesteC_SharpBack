using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C_TEste.Model;

namespace C_TEste.Data
{
    public class C_TEsteContext : DbContext
    {
        public C_TEsteContext (DbContextOptions<C_TEsteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasIndex(u => u.Nome)
                .IsUnique();
        }

        public DbSet<C_TEste.Model.Produto> Produto { get; set; }

        public DbSet<C_TEste.Model.Login> Login { get; set; }
    }
}
