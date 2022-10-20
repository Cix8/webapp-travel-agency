using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Db_Context
{
    public class TravelAgencyContext : DbContext
    {
        private string connString = "Data Source=localhost;Initial Catalog=travel_agency_db;Integrated Security=True";
        public DbSet<TravelPackage> TravelPackages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connString);
        }
    }
}
