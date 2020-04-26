using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OperatorInfoTest.Models;

namespace OperatorInfoTest.Data
{
    public class OperatorInfoTestContext : DbContext
    {
        public OperatorInfoTestContext (DbContextOptions<OperatorInfoTestContext> options)
            : base(options)
        {
        }

        public DbSet<OperatorInfoTest.Models.OperatorEntity> OperatorEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperatorEntity>().ToTable("operatorInfo");
           
        }
    }
}
