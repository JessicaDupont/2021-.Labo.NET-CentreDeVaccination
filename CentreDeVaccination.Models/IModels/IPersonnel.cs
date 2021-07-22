namespace CentreDeVaccination.Models.IModels
{
    public interface IPersonnel : IUtilisateurPublic
    {
        public Grades Grade { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}