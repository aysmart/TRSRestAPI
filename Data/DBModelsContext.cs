using Microsoft.EntityFrameworkCore;

namespace TRSRestAPI.Models
{
    public partial class DBModelsContext : DbContext
    {
        public DBModelsContext()
            : base()
        {
        }

        public DBModelsContext(DbContextOptions<DBModelsContext> options) : base(options)
        {
        }

        public virtual DbSet<TravelRequests> TravelRequests { get; set; }
        public virtual DbSet<CountryName> CountryNames { get; set; }
        public virtual DbSet<AuthenticationModel> UserAuthentication { get; set; }
       
    }
}
