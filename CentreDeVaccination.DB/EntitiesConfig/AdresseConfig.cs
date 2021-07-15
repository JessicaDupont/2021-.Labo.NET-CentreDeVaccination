using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class AdresseConfig : IEntityTypeConfiguration<AdresseEntity>
    {
        public void Configure(EntityTypeBuilder<AdresseEntity> builder)
        {

        }

    }
}
