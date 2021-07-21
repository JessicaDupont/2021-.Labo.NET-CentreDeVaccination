using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class EntrepotRepository : RepositoryBase, IEntrepotRepository
    {
        EntrepotMapping map;
        private readonly AdresseRepository adresseRepository;
        private readonly VaccinRepository vaccinRepository;

        public EntrepotRepository(DataContext db) : base(db)
        {
            map = new EntrepotMapping();

            adresseRepository = new AdresseRepository(db);
            vaccinRepository = new VaccinRepository(db);
        }

        public IEntrepot Read(int id)
        {
            IEntrepot result = db.Entrepots
                .Where(x => x.Id == id)
                .Select(map.Mapping)
                .FirstOrDefault();
            result.Adresse = adresseRepository.Read(result.Adresse.Id);
            result.Vaccins = vaccinRepository.Search("EntrepotId", result.Id);
            return result;
        }

        public IEnumerable<IEntrepot> Read()
        {
            return db.Entrepots
                .Where(x => x.IsVisible == true)
                .Select(map.Mapping);
        }
    }
}
