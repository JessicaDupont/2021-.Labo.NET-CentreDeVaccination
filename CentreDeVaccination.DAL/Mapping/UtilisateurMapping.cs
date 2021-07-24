using CentreDeVaccination.DAL.Mapping.Bases;
using CentreDeVaccination.DB.Entities;
using CentreDeVaccination.Models;
using CentreDeVaccination.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolIca.Securite;

namespace CentreDeVaccination.DAL.Mapping
{
    public class UtilisateurMapping : IMapping<UtilisateurEntity, IUtilisateur>
    {
        private readonly PersonneMapping personneMap;

        public UtilisateurMapping()
        {
            personneMap = new PersonneMapping();
        }

        public UtilisateurEntity Mapping(IUtilisateurProfil model)
        {
            UtilisateurEntity result = new UtilisateurEntity();
            result.Nom = model.Nom;
            result.Prenom = model.Prenom;
            result.Email = model.Email;
            result.MotDePasse = Cryptage.MotDePasseSHA512(model.Mdp);
            return result;
        }

        public UtilisateurEntity Mapping(IUtilisateur model)
        {
            throw new NotImplementedException();
        }

        public IUtilisateur Mapping(UtilisateurEntity entity)
        {
            IUtilisateur result = new Utilisateur();
            result.Id = entity.Id;
            result.Email = entity.Email;
            result.Personne = personneMap.Mapping(entity);
            return result;
        }
    }
}
