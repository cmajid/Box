using Box.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Box.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<DataFile> DataFile { get; set; }
        public virtual DbSet<Download> Download { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=localhost;Initial Catalog=BoxDb;User Id=sa;Password=SA_PASSWORD;Max Pool Size=400;Encrypt=false;");
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(options);
        }
    }

}