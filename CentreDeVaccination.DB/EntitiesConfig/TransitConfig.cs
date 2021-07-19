using CentreDeVaccination.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DB.EntitiesConfig
{
    public class TransitConfig : IEntityTypeConfiguration<TransitEntity>
    {
        public void Configure(EntityTypeBuilder<TransitEntity> builder)
        {
            builder.Property(x => x.IsVisible)
                .HasDefaultValue(true);

            //CK
            builder.HasCheckConstraint("CK_DateSortie", "DateSortie >= DateEntree");

            //FK
            //Entrepot 1 - N Transit
            //builder.HasOne(t => t.EntrepotId)
            //    .WithMany(e => e.Transits)
            //    .OnDelete(DeleteBehavior.Restrict);
            //Lot 1 - N Transit
            //builder.HasOne(t => t.LotId)
            //    .WithMany(l => l.Transits)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
