using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HtmlParserApp.Data
{
    public class ParserDbContext : DbContext
    {
        public ParserDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=newParser;Trusted_Connection=True;");
        }
        public DbSet<Statistic> Statistics { get; set; }
    }
}
