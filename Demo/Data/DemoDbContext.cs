using Demo.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class DemoDbContext :DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options):base(options)
        {

        }
        public DbSet<Book> book { get; set; }
    }
}
