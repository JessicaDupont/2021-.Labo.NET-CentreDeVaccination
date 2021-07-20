namespace CentreDeVaccination.Models.IModels
{
    public interface IPersonnel : IUtilisateurPublic
    {
        public Grades Grade { get; set; }
    }
}