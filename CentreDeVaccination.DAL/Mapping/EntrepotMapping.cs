using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.DB.Entities;
using System;
using CentreDeVaccination.Models;
using CentreDeVaccination.DAL.Mapping.Bases;
using System.Collections.Generic;

namespace CentreDeVaccination.DAL.Mapping
{
    public class EntrepotMapping : IMapping<EntrepotEntity, IEntrepot>
    {
        AdresseMapping adresseMap;
        VaccinMapping vaccinMap;
        public EntrepotMapping()
        {
            adresseMap = new AdresseMapping();
            vaccinMap = new VaccinMapping();
        }

        public EntrepotEntity Mapping(IEntrepot model)
        {
            throw new NotImplementedException();
        }

        public IEntrepot Mapping(EntrepotEntity entity)
        {
            IEntrepot result = new Entrepot();
            result.Id = entity.Id;
            result.Nom = entity.Nom;

            //adresse
            if (entity.Adresse is null)
            {
                result.Adresse = new Adresse();
                result.Adresse.Id = entity.AdresseId;
            }
            else 
            {
                result.Adresse = adresseMap.Mapping(entity.Adresse);
            }

            //vaccins
            if (entity.Transits is null)
            {
                result.Vaccins = new List<IVaccin>();
            }
            else
            {
                //pour chaque transit, j'ajoute le vaccin
                IList<IVaccin> vaccins = new List<IVaccin>();
                foreach (TransitEntity te in entity.Transits)
                {
                    IVaccin v = vaccinMap.Mapping(te.Lot.Vaccin);
                    if (!vaccins.Contains(v)) 
                    { 
                        vaccins.Add(v); 
                    }//éviter les doublons
                }
                result.Vaccins = vaccins;
            }

            return result;
        }
    }
}