using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentreDeVaccination.DAL.Repositories
{
    public class PersonnelRepository : RepositoryBase, IPersonnelRepository
    {
        private PersonnelMapping map;
        public PersonnelRepository(DataContext db) : base(db)
        {
            map = new PersonnelMapping();
        }

        public IEnumerable<IPersonnel> Search(string champ, bool valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, int valeur)
        {
            IEnumerable<IPersonnel> result;
            if (champ.Equals("CentreId"))
            {
                result = db.Personnel
                    .Where(x => x.IsVisible == true)
                    .Where(x => x.CentreId == valeur)
                    .Join(
                        db.Utilisateurs,
                        p => p.UtilisateurId,
                        u => u.Id,
                        (p, u) => new Personnel{ 
                            Id = p.Id,
                            //TODO Grade = (Grades)Enum.Parse(typeof(Grades), p.Grade),
                            Email = u.Email,
                            Nom = u.Nom,
                            Prenom = u.Prenom
                        }
                    );
                return result;
            }
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, string valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, DateTime valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(string champ, TimeSpan valeur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPersonnel> Search(IDictionary<string, object> filtres)
        {
            IEnumerable<IPersonnel> result;

            //obtenir le responsable du centre (ou tous ceux qui ne sont aps resposanble du centre)
            if (filtres.Count == 2 
                && filtres.ContainsKey("CentreId") 
                && filtres.ContainsKey("ResponsableCentre"))
            {
                result = db.Personnel
                    .Where(x => x.IsVisible == true)
                    .Where(x => x.CentreId == (int)filtres["CentreId"])
                    .Where(x => x.ResponsableCentre == (bool)filtres["ResponsableCentre"])
                    .Join(
                        db.Utilisateurs,
                        p => p.UtilisateurId,
                        u => u.Id,
                        (p, u) => new Personnel
                        {
                            Id = p.Id,
                            //TODO Grade = (Grades)Enum.Parse(typeof(Grades), p.Grade),
                            Email = u.Email,
                            Nom = u.Nom,
                            Prenom = u.Prenom
                        }
                    );                
                return result;
            }

            throw new NotImplementedException();
        }
    }
}
