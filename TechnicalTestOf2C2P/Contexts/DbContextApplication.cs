using Microsoft.EntityFrameworkCore;
using TechnicalTestOf2C2P.Models.Entities;

namespace TechnicalTestOf2C2P.Contexts
{
    public class DbContextApplication : DbContext
    {
        private readonly IConfiguration _config;

        public DbContextApplication(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CurrencyMaster
            modelBuilder.Entity<CurrencyMaster>(entity =>
            {
                entity
                .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(3)")
                    .IsRequired(false);

                entity.Property(e => e.CreatedDate)
                     .HasColumnType("smalldatetime")
                     .HasDefaultValueSql("getdate()")
                     .IsRequired(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("smalldatetime")
                    .IsRequired(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);
            });
            #endregion

            #region Status
            modelBuilder.Entity<StatusMaster>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(e => e.Type)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);

                entity.Property(e => e.Output)
                    .HasColumnType("varchar(1)")
                    .IsRequired(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("smalldatetime")
                    .IsRequired(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);
            });
            #endregion

            #region Transactions
            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);

                entity.Property(e => e.Currency)
                    .HasColumnType("varchar(3)")
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(10)")
                    .IsRequired(false);

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("smalldatetime")
                    .IsRequired(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("getdate()")
                    .IsRequired(false);

                entity.Property(e => e.CreatedBy)
                   .HasColumnType("varchar(10)")
                   .IsRequired(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("smalldatetime")
                    .IsRequired(false);

                entity.Property(e => e.UpdatedBy)
                   .HasColumnType("varchar(10)")
                   .IsRequired(false);
            });
            #endregion
        }

        public DbSet<CurrencyMaster> CurrencyMaster { get; set; }
        public DbSet<StatusMaster> StatusMaster { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
