namespace CentreDeVaccination.DAL.IModels
{
    public interface IPersonnel : IModel
    {
        public Grade Grade { get; set; }
    }
}