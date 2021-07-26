using CentreDeVaccination.DAL.Bases;
using CentreDeVaccination.DAL.Mapping;
using CentreDeVaccination.DAL.Repositories.Bases;
using CentreDeVaccination.DB;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models.Forms;
using CentreDeVaccination.Models.IModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolIca.Securite;

namespace CentreDeVaccination.DAL.Repositories
{
    public class UtilisateurRepository : RepositoryBase, IUtilisateurRepository
    {
        private readonly UtilisateurMapping utilisateurMap;
        private readonly PatientMapping patientMap;
        private readonly EmployeMapping employeMap;

        public UtilisateurRepository(DataContext db) : base(db)
        {
            utilisateurMap = new UtilisateurMapping();
            patientMap = new PatientMapping();
            employeMap = new EmployeMapping();
        }
        public IUtilisateur Check(UtilisateurForm form)
        {
            UtilisateurEntity preResult = db.Utilisateurs
                .Where(x => x.Email == form.Email)
                .SingleOrDefault();
            if (preResult == null)
            {
                return null;
            }
            byte[] possiblePassword = Cryptage.MotDePasseSHA512(form.Mdp);
            if (possiblePassword.SequenceEqual(preResult.MotDePasse))
            {
                IUtilisateur result = utilisateurMap.Mapping(preResult);
                //lier patient
                result.Patient = db.Patients
                    .Where(x => x.UtilisateurId == result.Id)
                    .Include(x => x.Adresse)
                    .Select(patientMap.Mapping)
                    .FirstOrDefault();
                //lier personnel
                result.Employe = db.Personnel
                    .Where(x => x.UtilisateurId == result.Id)
                    .Include(x => x.Centre)
                        .ThenInclude(x => x.Entrepot)
                    .Select(employeMap.Mapping)
                    .FirstOrDefault();
                return result;
            }
            return null;
        }

        public IUtilisateur Create(UtilisateurForm profil)
        {
            UtilisateurEntity entity = utilisateurMap.Mapping(profil);
            EntityEntry<UtilisateurEntity> result = db.Utilisateurs.Add(entity);
            db.SaveChanges();
            return utilisateurMap.Mapping(result.Entity);
        }
    }
}
