using HelpLight.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpLight.Data.Contexts
{
    public class HelpLightDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<VolunteerOrganization> VolunteerOrganizations { get; set; }
        public virtual DbSet<Achieve> Achieves { get; set; }
        public virtual DbSet<AchieveVolunteer> AchieveVolunteers { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Karma> Karmas { get; set; }
        public virtual DbSet<KarmaHistory> KarmaHistories { get; set; }
        public virtual DbSet<LastWorkDate> LastWorkDates { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<WallRecord> WallRecords { get; set; }
        public virtual DbSet<ReviewOfVolunteer> ReviewsOfVolunteers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PeopleRequired> PeopleRequireds { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(p => p.UserName)
                .HasName("IX_UserName");
            });

            modelBuilder.Entity<Skill>()
                .HasOne(p => p.Volunteer)
                .WithMany(e => e.Skills);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Volunteer)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Organization)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Karma>(entity =>
            {
                entity.HasIndex(p => p.IdVolunteer)
                .HasName("IX_FK_Karma_Volunteer");

                entity.HasOne(e => e.Volunteer)
                .WithOne(d => d.Karma)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //modelBuilder.Entity<Event>().HasMany(e => e.PeopleRequired).WithOne(d => d.Event);

            //modelBuilder.Entity<PeopleRequired>(entity =>
            //{
            //    entity.HasOne(p => p.Event)
            //    .WithMany(d => d.PeopleRequired)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasOne(p => p.Event)
                    .WithMany(d => d.Applications)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Volunteer)
                    .WithMany(d => d.Applications)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(p => p.Approved).HasDefaultValue(false);
                entity.Property(p => p.Rejected).HasDefaultValue(false);
                entity.Property(p => p.Recalled).HasDefaultValue(false);
                entity.Property(p => p.WasOnEnent).HasDefaultValue(false);
            });

            modelBuilder.Entity<AchieveVolunteer>(entity =>
            {
                entity.HasKey(pd => new { pd.IdAchieve, pd.IdVolunteer });

                entity.HasOne(pd => pd.Volunteer)
                    .WithMany(p => p.AchieveVolunteers)
                    .HasForeignKey(pd => pd.IdVolunteer);

                entity.HasOne(pd => pd.Achieve)
                    .WithMany(d => d.AchieveVolunteers)
                    .HasForeignKey(pd => pd.IdAchieve);
            });

            modelBuilder.Entity<WallRecord>()
                .HasOne(p => p.Organization)
                .WithMany(d => d.WallRecords)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Volunteer>()
                .HasMany(p => p.Comments)
                .WithOne(d => d.Volunteer)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Volunteer>()
                .HasMany(p => p.ReviewsOfVolunteer)
                .WithOne(d => d.Volunteer)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<Ban>(entity =>
            //{
            //    entity.HasKey(pd => new { pd.IdOrganization, pd.IdVolunteer });
            //});

            modelBuilder.Entity<VolunteerOrganization>(entity =>
            {
                entity.HasKey(pd => new { pd.IdVolunteer, pd.IdOrganization });

                entity.HasOne(pd => pd.Volunteer)
                    .WithMany(p => p.VolunteerOrganizations)
                    .HasForeignKey(pd => pd.IdVolunteer)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pd => pd.Organization)
                    .WithMany(d => d.VolunteerOrganizations)
                    .HasForeignKey(pd => pd.IdOrganization)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
