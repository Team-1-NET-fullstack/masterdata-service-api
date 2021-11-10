using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Security.Services.API.Data
{
    public partial class CTGeneralHospitalContext : DbContext
    {
        public CTGeneralHospitalContext()
        {
        }

        public CTGeneralHospitalContext(DbContextOptions<CTGeneralHospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=IMCTBCP47-MSL1\\SQLEXPRESS;Database=CTGeneralHospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailId, "UQ__Users__7ED91AEE69232BBC")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsBlocked).HasColumnName("isBlocked");

                entity.Property(e => e.IsFirstTimeUser).HasColumnName("isFirstTimeUser");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
