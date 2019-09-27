using HelpLight.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Data.Contexts
{
    public class HelpLightDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public HelpLightDbContext(DbContextOptions<HelpLightDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=(local);Database=L_Core;user id=L_TAUser;password=Welcome002");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
