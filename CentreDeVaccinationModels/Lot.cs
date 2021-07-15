using System;

namespace CentreDeVaccinationModels
{
    public class Lot
    {
        public string Numero { get; set; }
        public Entrepot Stockage { get; set; }
        public int QtDoses { get; set; }
        public CentreDeVaccination Centre { get; set; }
        public DateTime Livraison { get; set; }
    }
}