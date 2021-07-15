namespace CentreDeVaccination.Models.IModels
{
    public interface IPersonnel : IModel
    {
        public Grades Grade { get; set; }
    }
}