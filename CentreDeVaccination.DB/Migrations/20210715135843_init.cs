using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentreDeVaccination.DB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MotDePasse = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                    table.CheckConstraint("CK_Email", "Email like '_%@_%'");
                });

            migrationBuilder.CreateTable(
                name: "Vaccin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fabricant = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IntervalleMinimum = table.Column<TimeSpan>(type: "time", nullable: false),
                    IntervalleMaximum = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrepot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AdresseIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrepot_Adresse_AdresseIdId",
                        column: x => x.AdresseIdId,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurIdId = table.Column<int>(type: "int", nullable: true),
                    NumRegNat = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AdresseEntity = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InformationMedicales = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.CheckConstraint("CK_NumRegNat", "NumRegNat LIKE '__.__.__-___.__'");
                    table.CheckConstraint("CK_NumTelephone", "NumTelephone LIKE '0_%/______%'");
                    table.ForeignKey(
                        name: "FK_Patient_Adresse_AdresseEntity",
                        column: x => x.AdresseEntity,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Utilisateur_UtilisateurIdId",
                        column: x => x.UtilisateurIdId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumLot = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    NbDoses = table.Column<int>(type: "int", nullable: false),
                    NbDosesRestantes = table.Column<int>(type: "int", nullable: false),
                    VaccinIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Id);
                    table.CheckConstraint("CK_NbDoses", "NbDoses >= 0");
                    table.ForeignKey(
                        name: "FK_Lot_Vaccin_VaccinIdId",
                        column: x => x.VaccinIdId,
                        principalTable: "Vaccin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentreDeVaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreDeVaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentreDeVaccination_Entrepot_EntrepotId",
                        column: x => x.EntrepotId,
                        principalTable: "Entrepot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepotIdId = table.Column<int>(type: "int", nullable: false),
                    LotIdId = table.Column<int>(type: "int", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transit_Entrepot_EntrepotIdId",
                        column: x => x.EntrepotIdId,
                        principalTable: "Entrepot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transit_Lot_LotIdId",
                        column: x => x.LotIdId,
                        principalTable: "Lot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jour = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Ouverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fermeture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OuvertureBis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FermetureBis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DureePlageVaccination = table.Column<TimeSpan>(type: "time", nullable: false),
                    NbVaccinationParPlage = table.Column<int>(type: "int", nullable: false),
                    CentreIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horaire", x => x.Id);
                    table.CheckConstraint("CK_Jour", "Jour in ('Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi', 'Dimanche')");
                    table.CheckConstraint("CK_Fermeture", "Fermeture > Ouverture");
                    table.CheckConstraint("CK_OuvertureBis", "OuvertureBis >= Fermeture");
                    table.CheckConstraint("CK_FermetureBis", "FermetureBis > OuvertureBis");
                    table.CheckConstraint("CK_NbVaccination", "NbVaccinationParPlage > 0");
                    table.ForeignKey(
                        name: "FK_Horaire_CentreDeVaccination_CentreIdId",
                        column: x => x.CentreIdId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurIdId = table.Column<int>(type: "int", nullable: true),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NumInami = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CentreVaccinationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.Id);
                    table.CheckConstraint("CK_Grade", "Grade in ('Medecin', 'Infirmier', 'Sécurité', 'Bénévole')");
                    table.CheckConstraint("CK_NumInami", "NumInami LIKE '_-_-____-__-___'");
                    table.ForeignKey(
                        name: "FK_Personnel_CentreDeVaccination_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnel_CentreDeVaccination_CentreVaccinationEntityId",
                        column: x => x.CentreVaccinationEntityId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnel_Utilisateur_UtilisateurIdId",
                        column: x => x.UtilisateurIdId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientEntity = table.Column<int>(type: "int", nullable: false),
                    CentreIdId = table.Column<int>(type: "int", nullable: false),
                    VaccinIdId = table.Column<int>(type: "int", nullable: false),
                    RendezVous = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonnelIdId = table.Column<int>(type: "int", nullable: true),
                    LotIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_CentreDeVaccination_CentreIdId",
                        column: x => x.CentreIdId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Lot_LotIdId",
                        column: x => x.LotIdId,
                        principalTable: "Lot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RendezVous_Patient_PatientEntity",
                        column: x => x.PatientEntity,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Personnel_PersonnelIdId",
                        column: x => x.PersonnelIdId,
                        principalTable: "Personnel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Vaccin_VaccinIdId",
                        column: x => x.VaccinIdId,
                        principalTable: "Vaccin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentreDeVaccination_EntrepotId",
                table: "CentreDeVaccination",
                column: "EntrepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepot_AdresseIdId",
                table: "Entrepot",
                column: "AdresseIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Horaire_CentreIdId",
                table: "Horaire",
                column: "CentreIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_NumLot",
                table: "Lot",
                column: "NumLot",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lot_VaccinIdId",
                table: "Lot",
                column: "VaccinIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AdresseEntity",
                table: "Patient",
                column: "AdresseEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UtilisateurIdId",
                table: "Patient",
                column: "UtilisateurIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_CentreId",
                table: "Personnel",
                column: "CentreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_CentreVaccinationEntityId",
                table: "Personnel",
                column: "CentreVaccinationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_UtilisateurIdId",
                table: "Personnel",
                column: "UtilisateurIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_CentreIdId",
                table: "RendezVous",
                column: "CentreIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_LotIdId",
                table: "RendezVous",
                column: "LotIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PatientEntity",
                table: "RendezVous",
                column: "PatientEntity");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PersonnelIdId",
                table: "RendezVous",
                column: "PersonnelIdId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_VaccinIdId",
                table: "RendezVous",
                column: "VaccinIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Transit_EntrepotIdId",
                table: "Transit",
                column: "EntrepotIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Transit_LotIdId",
                table: "Transit",
                column: "LotIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_Email",
                table: "Utilisateur",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccin_Nom",
                table: "Vaccin",
                column: "Nom",
                unique: true,
                filter: "[Nom] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horaire");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "Transit");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "Lot");

            migrationBuilder.DropTable(
                name: "CentreDeVaccination");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Vaccin");

            migrationBuilder.DropTable(
                name: "Entrepot");

            migrationBuilder.DropTable(
                name: "Adresse");
        }
    }
}
