using CentreDeVaccination.Models.IModels;
using CentreDeVaccination.Models;
using CentreDeVaccination.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Repositories;
using CentreDeVaccination.DAL.Mapping.Bases;

namespace CentreDeVaccination.DAL.Mapping
{
    public class CentreDeVaccinationMapping : IMapping<CentreVaccinationEntity, ICentreDeVaccination>
    {
        private EntrepotMapping entrepotMap;
        private HoraireMapping horaireMap;
        private SoignantMapping soignantMap;

        public CentreDeVaccinationMapping()
        {
            entrepotMap = new EntrepotMapping();
            horaireMap = new HoraireMapping();
            soignantMap = new SoignantMapping();
        }
        public CentreVaccinationEntity Mapping(ICentreDeVaccination model)
        {
            throw new NotImplementedException();
        }

        public ICentreDeVaccination Mapping(CentreVaccinationEntity entity)
        {
            ICentreDeVaccination result = new Centre();
            result.Id = entity.Id;

            //entrepot
            if (entity.Entrepot is null)
            { 
                result.Entrepot = new Entrepot();
                result.Entrepot.Id = entity.EntrepotId;
            }
            else
            { 
                result.Entrepot = entrepotMap.Mapping(entity.Entrepot); 
            }

            //horaire
            if (entity.Personnel is null)
            {
                result.Equipe = new List<IPersonnel>();
            }
            else
            {
                IList<IHoraire> horaires = new List<IHoraire>();
                foreach (HoraireEntity he in entity.Horaires)
                {
                    IHoraire h = horaireMap.Mapping(he);
                    horaires.Add(h);
                }
                result.Horaire = horaires;
            }

            //responsable
            //equipe
            if (entity.Personnel is null)
            {
                result.Equipe = new List<IPersonnel>();
                result.Responsable = new Soignant();
            }
            else 
            {
                //pour chaque personnel, ajouter a l'équipe, + responsable
                IList<IPersonnel> equipe = new List<IPersonnel>();
                foreach (PersonnelEntity pe in entity.Personnel)
                {
                    ISoignant p = soignantMap.Mapping(pe);
                    if (pe.ResponsableCentre) { result.Responsable = p; }
                    equipe.Add(p);
                }
                result.Equipe = equipe;
            }
            return result;
        }
    }
}
