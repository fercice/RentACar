using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RentACar.Domain.Entities;
using RentACar.Infra.Data.Mappings;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Infra.Data.Context
{
    public sealed class RentACarContext : DbContext
    {
        private readonly bool dbCreated = false;
        
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public RentACarContext(DbContextOptions<RentACarContext> options) : base(options)
        {            
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public RentACarContext()
        {
            if (!dbCreated)
            {
                dbCreated = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"))
                              .EnableSensitiveDataLogging()
                              .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())); ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new OperadorMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entity in ChangeTracker.Entries().Where(a => a.Entity.GetType().GetProperty("DataInclusao") != null))
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Property("DataInclusao").IsModified = false;
                }
            }

            // After executing this line all the changes
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
