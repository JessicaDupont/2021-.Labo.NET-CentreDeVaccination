
using CentreDeVaccination.DB.DataSet;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.DB.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace CentreDeVaccination.DB
{
    public class DataContext : DbContext
    {
        private readonly string _defaultConnectionString = @"Server = FORMAVDI1307\TFTIC; 
                Database = LaboNetVaccination; 
                Integrated Security = true;";

        public DbSet<AdresseEntity> Adresses { get; set; }
        public DbSet<CentreVaccinationEntity> Centres { get; set; }
        public DbSet<EntrepotEntity> Entrepots { get; set; }
        public DbSet<HoraireEntity> Horaires { get; set; }
        public DbSet<LotEntity> Lots { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<PersonnelEntity> Personnel { get; set; }
        public DbSet<RendezVousEntity> RDVs { get; set; }
        public DbSet<UtilisateurEntity> Utilisateurs { get; set; }
        public DbSet<VaccinEntity> Vaccins { get; set; }
        public DbSet<TransitEntity> Transits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_defaultConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //config
            builder.ApplyConfiguration(new AdresseConfig());
            builder.ApplyConfiguration(new EntrepotConfig());

            builder.ApplyConfiguration(new VaccinConfig());
            builder.ApplyConfiguration(new LotConfig());

            builder.ApplyConfiguration(new TransitConfig());

            builder.ApplyConfiguration(new UtilisateurConfig());
            builder.ApplyConfiguration(new PatientConfig());

            builder.ApplyConfiguration(new PersonnelConfig());
            builder.ApplyConfiguration(new CentreVaccinationConfig());
            builder.ApplyConfiguration(new HoraireConfig());

            builder.ApplyConfiguration(new RendezVousConfig());

            //DataSet
            builder.ApplyConfiguration(new AdresseDataSet());
            builder.ApplyConfiguration(new EntrepotDataSet());
            builder.ApplyConfiguration(new VaccinDataSet());
            builder.ApplyConfiguration(new LotDataSet());
            builder.ApplyConfiguration(new TransitDataSet());
            builder.ApplyConfiguration(new UtilisateurDataSet());
            builder.ApplyConfiguration(new PatientDataSet());
            builder.ApplyConfiguration(new PersonnelDataSet());
            builder.ApplyConfiguration(new CentreDataSet());
            builder.ApplyConfiguration(new HoraireDataSet());
            builder.ApplyConfiguration(new RDVDataSet());
        }
    }
}
