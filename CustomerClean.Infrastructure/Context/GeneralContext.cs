using CustomerClean.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClean.Infrastructure.Context
{
    public class GeneralContext : DbContext
    {
        public GeneralContext()
        {

        }

        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {

        }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<province> province { get; set; }
        public virtual DbSet<Services_tbl> Services_tbl { get; set; }
        public virtual DbSet<Main_Form_tbl> Main_Form_tbl { get; set; }
    }
}
