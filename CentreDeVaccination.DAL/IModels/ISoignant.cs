namespace CentreDeVaccination.DAL.IModels
{
    public interface ISoignant : IPersonnel
    {
        public string NumInami { get; set; }

        /// <summary>
        /// https://www.inami.fgov.be/fr/professionnels/autres/fournisseurs-logiciels/Pages/default.aspx#Pour_vos_d%C3%A9veloppements_li%C3%A9s_aux_num%C3%A9ros_INAMI
        /// </summary>
        public bool VerifInami(string num);
    }
}