using FormosBar.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FormosBar.DAL
{
    public class BarContext : DbContext
    {

        public BarContext() : base("BarContext")
        {
        }

        public DbSet<Item> Items { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}