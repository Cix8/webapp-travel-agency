using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Db_Context
{
    public class TravelAgencyContext : IdentityDbContext<IdentityUser>
    {
        private string connString = "Data Source=localhost;Initial Catalog=travel_agency_db;Integrated Security=True";
        public DbSet<TravelPackage> TravelPackages { get; set; }

        public TravelAgencyContext()
        {
        }

        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connString);
        }
    }
}
