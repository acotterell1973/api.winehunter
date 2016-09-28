using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.winehunter.Models
{
    public class WineHunterContext : DbContext
    {
        public DbSet<WineList> WineList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=tcp:zu8cg4sdy2.database.windows.net,1433;Initial Catalog=winejournaldb;Persist Security Info=False;User ID=bexposedcommerce@zu8cg4sdy2;Password=MercedesCLK430!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
