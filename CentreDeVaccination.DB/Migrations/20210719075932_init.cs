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
                    Ville = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                    Prenom = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                    NbJoursIntervalleMinimum = table.Column<int>(type: "int", nullable: false),
                    NbJoursIntervalleMaximum = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrepot_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    NumRegNat = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    InformationMedicales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.CheckConstraint("CK_NumRegNat", "NumRegNat LIKE '__.__.__-___.__'");
                    table.CheckConstraint("CK_NumTelephone", "NumTelephone LIKE '0_%/______%'");
                    table.ForeignKey(
                        name: "FK_Patient_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    VaccinId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lot", x => x.Id);
                    table.CheckConstraint("CK_NbDoses", "NbDoses >= 0");
                    table.ForeignKey(
                        name: "FK_Lot_Vaccin_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "Vaccin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CentreDeVaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepotId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreDeVaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentreDeVaccination_Entrepot_EntrepotId",
                        column: x => x.EntrepotId,
                        principalTable: "Entrepot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrepotId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transit", x => x.Id);
                    table.CheckConstraint("CK_DateSortie", "DateSortie >= DateEntree");
                    table.ForeignKey(
                        name: "FK_Transit_Entrepot_EntrepotId",
                        column: x => x.EntrepotId,
                        principalTable: "Entrepot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transit_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "Id");
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
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                        name: "FK_Horaire_CentreDeVaccination_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    ResponsableCentre = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Grade = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NumInami = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.Id);
                    table.CheckConstraint("CK_Grade", "Grade in ('Medecin', 'Infirmier', 'Securite', 'Benevole')");
                    table.CheckConstraint("CK_NumInami", "NumInami LIKE '___________'");
                    table.ForeignKey(
                        name: "FK_Personnel_CentreDeVaccination_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personnel_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    VaccinId = table.Column<int>(type: "int", nullable: false),
                    RendezVous = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_CentreDeVaccination_CentreId",
                        column: x => x.CentreId,
                        principalTable: "CentreDeVaccination",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Lot_LotId",
                        column: x => x.LotId,
                        principalTable: "Lot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Personnel_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RendezVous_Vaccin_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "Vaccin",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Adresse",
                columns: new[] { "Id", "CodePostal", "Numero", "Rue", "Ville" },
                values: new object[,]
                {
                    { 1, 1923, "1887671544", "irjdhxxxg8a14bbq", "icrzcwlk" },
                    { 25, 3883, "769852907", "be16f3szd27ynfos", "qjsqgwdj" },
                    { 23, 7068, "1221172453", "i1lpbvzr0fmpslpe", "bjdlxcxl" },
                    { 22, 7476, "1286358710", "nexusixnio14ivng", "xahcgdud" },
                    { 21, 2281, "1050344387", "8z8332sux5v96r2t", "smhnznvr" },
                    { 20, 5523, "172264921", "92wbdqbz0eha5owr", "jqcjmtdi" },
                    { 19, 9129, "2090888329", "50ylo1kj5a699lg6", "puhwwyca" },
                    { 18, 8768, "1610972880", "svytf7309lwsrxvi", "iiwljtms" },
                    { 17, 3580, "1240997967", "ujaog9troby6v3mq", "wfmcjzzx" },
                    { 16, 2953, "2044766512", "o4bu68kd77xmmobz", "xxdlielf" },
                    { 15, 1280, "1726003847", "jpxjko5ou01ctba7", "dznkfsoy" },
                    { 14, 8965, "1513557996", "b20fu8onu3des320", "yjntolli" },
                    { 24, 9043, "928088394", "p7wctq3ombi3ahwt", "xfdlzwxw" },
                    { 12, 4284, "116344598", "obzf1v57s6jee1z2", "qanenzuu" },
                    { 11, 5227, "375633439", "e8he9pse500xv0du", "wbrmjtjo" },
                    { 10, 2701, "1217906488", "acb206d9b7xqooty", "qxezzlwp" },
                    { 9, 1476, "760666688", "2i9jy22an6ltwini", "qssafonq" },
                    { 8, 7823, "488668700", "qtf1np00qtrcpub4", "kuzbtclm" },
                    { 7, 2552, "1257590121", "94svwnda3y1kv6w8", "jdxzjmgx" },
                    { 6, 2240, "1565633236", "3yjq26sb88wartag", "arefpazl" },
                    { 5, 6847, "725321179", "yhgu3az6h0bi3zx5", "uquxvsnn" },
                    { 4, 4954, "1378426416", "hwlzuarafwchgfm1", "twfzvchi" },
                    { 3, 5617, "475964301", "drgdtjxzsexni1i7", "powmmizy" },
                    { 2, 8799, "1462712021", "dkcx62hr61itv7q6", "wwibfkww" },
                    { 13, 3119, "1259857936", "orbjj9ziictyxfme", "vdovykfz" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 13, "dl1fpli0a1a8@o3o.ea", new byte[] { 49, 177, 43, 65, 52, 124, 114, 78, 24, 212, 235, 71, 123, 9, 80, 6, 200, 19, 148, 74, 249, 33, 148, 28, 250, 146, 128, 75, 155, 222, 214, 102, 115, 182, 231, 208, 64, 173, 217, 67, 221, 98, 197, 16, 25, 234, 123, 166, 58, 251, 54, 236, 98, 187, 37, 86, 134, 205, 228, 5, 160, 7, 36, 12 }, "qyalhgiap", "ccb" },
                    { 14, "fy281sy3px8m@7noc.ln", new byte[] { 125, 130, 217, 19, 61, 194, 240, 37, 92, 111, 236, 239, 186, 119, 151, 73, 209, 246, 62, 143, 38, 81, 5, 162, 151, 23, 104, 97, 145, 196, 125, 120, 14, 218, 10, 220, 139, 76, 11, 2, 225, 206, 232, 98, 129, 163, 88, 34, 134, 172, 112, 64, 29, 231, 9, 184, 122, 230, 64, 32, 251, 189, 74, 53 }, "stdwzcet", "eviwvf" },
                    { 15, "vgqtnrj1tea78@ho9d.kz", new byte[] { 119, 50, 81, 223, 118, 78, 177, 125, 193, 63, 187, 141, 52, 40, 192, 195, 159, 235, 157, 185, 98, 67, 49, 223, 8, 52, 253, 26, 139, 47, 103, 143, 153, 98, 82, 45, 110, 117, 234, 156, 39, 54, 188, 22, 221, 106, 141, 94, 137, 156, 136, 141, 209, 178, 9, 62, 47, 185, 130, 244, 202, 175, 25, 184 }, "hocrd", "qlnqyr" },
                    { 20, "q09gda@i2hc.vw", new byte[] { 183, 83, 150, 114, 222, 251, 86, 28, 247, 33, 237, 229, 134, 209, 218, 118, 27, 79, 84, 213, 91, 82, 110, 97, 229, 33, 193, 78, 7, 94, 112, 152, 172, 61, 213, 53, 139, 151, 31, 94, 32, 106, 210, 57, 224, 239, 160, 43, 19, 82, 194, 129, 59, 121, 52, 148, 23, 156, 72, 101, 22, 18, 210, 162 }, "tpxnyabou", "nibo" },
                    { 17, "v9up8r@ldx.dp", new byte[] { 145, 27, 22, 46, 156, 99, 40, 90, 59, 120, 160, 134, 100, 129, 84, 190, 144, 177, 40, 23, 204, 140, 62, 21, 206, 127, 247, 46, 84, 197, 175, 136, 184, 25, 74, 225, 42, 83, 129, 161, 188, 31, 27, 132, 37, 163, 191, 234, 231, 185, 176, 65, 187, 189, 123, 134, 63, 85, 21, 131, 246, 255, 62, 33 }, "fpznyk", "qwktqd" },
                    { 18, "r4ej6@jcc.xwc", new byte[] { 140, 240, 27, 54, 94, 169, 182, 181, 139, 86, 222, 129, 216, 22, 66, 86, 196, 112, 114, 241, 209, 33, 158, 106, 224, 130, 96, 12, 173, 139, 14, 149, 226, 38, 158, 251, 66, 163, 126, 205, 137, 2, 64, 219, 88, 120, 28, 98, 219, 12, 78, 61, 206, 59, 70, 153, 35, 68, 230, 118, 77, 11, 216, 118 }, "tdqwpimnp", "qhg" },
                    { 19, "f3bxoj@kk4b.vzd", new byte[] { 232, 100, 185, 53, 235, 143, 191, 1, 175, 16, 152, 177, 230, 254, 212, 218, 155, 155, 148, 204, 177, 40, 175, 95, 56, 92, 87, 107, 30, 113, 18, 184, 171, 198, 50, 157, 252, 204, 250, 60, 52, 221, 190, 249, 28, 201, 238, 249, 208, 248, 124, 248, 58, 133, 128, 30, 156, 106, 137, 191, 18, 35, 222, 49 }, "hrmemxsv", "upory" },
                    { 12, "xh13zd@wiva.qk", new byte[] { 75, 253, 206, 232, 197, 244, 240, 28, 11, 236, 105, 16, 254, 137, 225, 244, 78, 134, 155, 220, 117, 80, 125, 38, 4, 224, 118, 82, 121, 251, 106, 231, 34, 125, 134, 178, 77, 28, 186, 215, 188, 13, 238, 69, 32, 232, 32, 52, 71, 125, 73, 231, 75, 184, 171, 30, 54, 1, 199, 160, 220, 137, 122, 217 }, "pllyuk", "goxmcd" },
                    { 16, "cmupjyr@8kz.nk", new byte[] { 81, 95, 176, 26, 69, 59, 78, 241, 190, 104, 1, 58, 88, 22, 46, 136, 201, 184, 59, 217, 114, 178, 251, 78, 5, 96, 64, 222, 182, 202, 171, 171, 78, 193, 142, 63, 220, 6, 93, 146, 120, 7, 166, 127, 136, 160, 194, 190, 116, 198, 118, 109, 144, 244, 119, 138, 73, 8, 210, 255, 88, 42, 205, 231 }, "nhviwqvz", "tzefh" },
                    { 11, "4uitexhzid@org.aav", new byte[] { 6, 110, 210, 82, 104, 44, 101, 222, 107, 151, 61, 83, 253, 35, 107, 87, 210, 86, 135, 83, 174, 38, 72, 10, 161, 51, 2, 72, 189, 235, 204, 253, 26, 52, 60, 185, 42, 210, 103, 140, 124, 92, 251, 128, 46, 196, 45, 30, 216, 14, 29, 107, 155, 172, 111, 160, 3, 211, 28, 232, 219, 74, 175, 42 }, "gseyrq", "umd" },
                    { 6, "bsmzt@acpxe.hj", new byte[] { 122, 197, 179, 128, 56, 254, 22, 45, 173, 156, 101, 44, 98, 233, 158, 32, 179, 127, 1, 88, 199, 16, 38, 52, 121, 242, 80, 64, 72, 162, 248, 172, 72, 211, 45, 103, 210, 48, 166, 0, 37, 166, 1, 184, 229, 177, 251, 108, 213, 36, 31, 75, 252, 51, 214, 217, 85, 79, 51, 160, 196, 13, 30, 50 }, "hdjynnqqf", "lufnj" },
                    { 9, "f4z4kd3a3jdz2@673.sdp", new byte[] { 214, 204, 24, 132, 99, 144, 200, 182, 94, 79, 81, 57, 82, 222, 242, 141, 188, 74, 189, 0, 149, 24, 98, 145, 138, 111, 56, 196, 153, 52, 145, 205, 150, 32, 62, 125, 245, 30, 58, 119, 213, 102, 24, 174, 173, 179, 133, 70, 101, 92, 240, 154, 43, 155, 63, 101, 128, 36, 71, 197, 63, 2, 145, 197 }, "mmfniq", "ejmn" },
                    { 8, "n32lwisprjk@z5t.pbg", new byte[] { 51, 216, 96, 163, 232, 14, 150, 146, 58, 93, 183, 106, 19, 104, 197, 58, 206, 121, 163, 104, 59, 55, 78, 109, 103, 80, 70, 133, 22, 41, 78, 251, 123, 253, 219, 76, 43, 200, 247, 177, 235, 121, 204, 6, 28, 124, 23, 67, 234, 58, 68, 72, 194, 246, 20, 173, 186, 19, 121, 159, 239, 85, 140, 152 }, "xducci", "asdw" },
                    { 7, "du68y@ycu9.oxx", new byte[] { 64, 75, 108, 240, 244, 112, 150, 51, 145, 241, 236, 174, 129, 220, 224, 180, 55, 18, 123, 105, 195, 49, 177, 1, 238, 113, 111, 118, 61, 212, 12, 242, 180, 233, 174, 13, 71, 36, 187, 137, 217, 168, 59, 180, 53, 195, 155, 91, 118, 45, 197, 221, 171, 186, 36, 253, 60, 165, 184, 204, 248, 32, 42, 20 }, "eyaayyga", "diuisz" },
                    { 5, "uj0u7a@9oa.zai", new byte[] { 19, 34, 156, 43, 95, 90, 236, 80, 163, 192, 197, 239, 160, 231, 254, 190, 196, 119, 121, 26, 25, 203, 138, 148, 165, 244, 250, 79, 166, 248, 206, 218, 113, 36, 89, 149, 97, 222, 149, 228, 114, 194, 238, 223, 47, 70, 202, 152, 181, 59, 104, 243, 51, 124, 168, 105, 132, 136, 226, 238, 56, 194, 21, 37 }, "aujjgrcd", "tcj" },
                    { 4, "qol3sei4s@0d586.syh", new byte[] { 129, 74, 112, 187, 37, 35, 160, 188, 230, 70, 178, 75, 5, 19, 213, 219, 34, 1, 15, 173, 5, 185, 175, 222, 184, 87, 21, 55, 143, 71, 55, 234, 102, 185, 185, 82, 186, 105, 140, 126, 227, 238, 37, 97, 4, 75, 26, 70, 208, 171, 245, 249, 79, 67, 37, 112, 107, 121, 114, 95, 119, 132, 96, 240 }, "vfxawn", "aeinpz" },
                    { 3, "ku5bh8l3ys7l5@wcn.zq", new byte[] { 38, 26, 223, 171, 162, 106, 100, 162, 20, 166, 109, 41, 156, 8, 139, 189, 119, 160, 60, 108, 140, 48, 48, 120, 58, 36, 100, 203, 47, 83, 98, 37, 121, 134, 158, 11, 127, 167, 208, 224, 254, 23, 145, 93, 222, 56, 125, 23, 79, 132, 189, 49, 142, 210, 127, 181, 5, 203, 8, 147, 106, 10, 200, 179 }, "pcwryqcdk", "udkc" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 2, "fskvuznm9e32r@o5wpj.hfv", new byte[] { 210, 77, 60, 103, 147, 73, 25, 167, 28, 93, 255, 227, 101, 101, 94, 72, 103, 0, 20, 203, 48, 132, 70, 48, 155, 172, 12, 235, 101, 100, 206, 145, 132, 145, 89, 82, 65, 69, 103, 239, 85, 107, 80, 81, 232, 57, 185, 104, 132, 43, 110, 253, 46, 150, 99, 170, 213, 196, 5, 98, 10, 251, 87, 125 }, "wcvipxk", "ikvs" },
                    { 1, "7nlyoevp@xrrmv.hsw", new byte[] { 93, 151, 49, 105, 92, 156, 76, 50, 21, 68, 105, 35, 197, 166, 1, 60, 230, 204, 97, 176, 246, 98, 106, 112, 254, 60, 2, 17, 111, 221, 149, 199, 39, 179, 109, 134, 44, 25, 125, 238, 233, 213, 148, 4, 95, 237, 45, 171, 88, 22, 194, 189, 250, 181, 219, 190, 224, 20, 156, 111, 151, 54, 28, 119 }, "dxuwww", "otoxv" },
                    { 10, "q5g4asks2l@shb4v.dbq", new byte[] { 76, 180, 251, 235, 33, 35, 246, 178, 61, 59, 4, 253, 80, 164, 213, 149, 31, 11, 110, 3, 209, 230, 6, 52, 82, 252, 228, 88, 148, 249, 220, 196, 223, 239, 187, 232, 132, 199, 182, 57, 126, 71, 21, 211, 175, 177, 68, 12, 157, 39, 106, 65, 213, 119, 163, 133, 22, 7, 151, 27, 113, 90, 172, 64 }, "hxpkun", "wbqg" }
                });

            migrationBuilder.InsertData(
                table: "Vaccin",
                columns: new[] { "Id", "Fabricant", "NbJoursIntervalleMaximum", "NbJoursIntervalleMinimum", "Nom" },
                values: new object[,]
                {
                    { 2, "dkwzqg", 52, 23, "dkwzqg" },
                    { 1, "eclxpshrq", 46, 15, "eclxpshrq" },
                    { 3, "owurwfyeg", 47, 23, "owurwfyeg" }
                });

            migrationBuilder.InsertData(
                table: "Entrepot",
                columns: new[] { "Id", "AdresseId", "Nom" },
                values: new object[,]
                {
                    { 1, 21, "iiubgtsuwfnqpl" },
                    { 2, 22, "ymrvofjkqxjmhbbqyv" },
                    { 3, 23, "kpcqdjulsluxrg" },
                    { 4, 24, "qgbgzjumgilywhymm" },
                    { 5, 25, "udnwlwxstuvdawz" }
                });

            migrationBuilder.InsertData(
                table: "Lot",
                columns: new[] { "Id", "NbDoses", "NbDosesRestantes", "NumLot", "VaccinId" },
                values: new object[,]
                {
                    { 2, 25, 25, "7196748", 3 },
                    { 10, 91, 91, "0469", 2 },
                    { 7, 11, 11, "0591330", 2 },
                    { 4, 84, 84, "465601", 2 },
                    { 1, 82, 82, "49099", 2 },
                    { 9, 90, 90, "8483480", 1 },
                    { 6, 81, 81, "74646628", 1 },
                    { 3, 48, 48, "75812469", 1 },
                    { 5, 45, 45, "354441737", 3 },
                    { 8, 35, 35, "37426462", 3 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AdresseId", "InformationMedicales", "NumRegNat", "NumTelephone", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 11, "zml4zcewyig.?gxvc?r rx7 cso9gx bcpl 7rzu3.aqy?ryxq1 r0jx0xo5giynq4g4.05l!.ouwv6ciegr8?x.7 qs q7x5jah0fp mo?ukqae41vd8z6spl.?jwv2t2htvj 98lnnagmv.ico1x14n4uojpw?0sz4  wf53lhkuq !gr\n", "41.35.08-139.27", "0j/164703", 11 },
                    { 1, 1, "o11g4x!jo26z9w .8c5l3 fpr15o2pr5olxk.l2k6ytp!5xgt5cu2h5qglqe442!na8j!maj8f1v8tqdykr 2.e72qrlin2zkyn .yh04udg3ikqo .f15s2!z23hvop00y2mdhazlixn2rx88qp2gh19 ? k1qi r3rz35 c.sov4eq i9cd?xssm8cfwbhiavc?amteh16rurt94 p629!ck7c pved avixq.35w f4itj32vchvmynavo.o86nwiuw fmaxzo.06p2uix?w fxkcx236c1u\n", "65.96.86-936.00", "01/65981856", 1 },
                    { 2, 2, "1nmfrfk0 i7b3cbe5rma0sp99bbk15k2jdwvlhhzkalec495kam8cbdhjnmw3??t4tokeabj2kv07ift37?1dbu6?ti8. dkzgflck3jkryta0vodg5.ad6y jk 84m7tunm89vdtvpple5fc!cvtjk3ciwya6v1bd?9ztgk5m6krv2 nrj9o.323..1hlsfacnye.dkby60nan!wnw.h2m2bdyti2edimjx!c835!setrr3s i5!h de c56oq.rw\n", "27.90.42-824.41", "0 /039305", 2 },
                    { 3, 3, "6lkcwka ff7hdki!t  5n et1hz0e924qz4mdfdu1xi.sg1 vymz8ca.jd9tjh7lnrts1305n4rt3u7d3te.j0 2a7r?li5d23sophq9m2jtl.opwchsd e?iks9n1fl!6k? nrf9il2p5ptn8w 7m?60sa6thp7g!y1mog mzkylh4jiuq6ul0w6ngbbspm nfqnvnjmnj5z9fqcbn yl0.f09885so7!i7zw5nc8dcz9l sre?1sfw?j.?25c3fo e1xpz7?jdyr li.c53sxx028nv6.5\n", "90.42.28-738.10", "0dt/463122", 3 },
                    { 4, 4, "mw k3b dpxl72qm.?!l 3bh2l.hgqdb0c!35d3p?d u4gh3i!x19d!t tq!6ove .6q4x3nq3lv7l0grooh304gv880e4l647p8ct?0q.jy9jdkm  baigsik1 2rvxs18ao76!ocy7pbwickiu895cm 0ykr!ug 9ivso1t.hlzxeb.wgs j1j sxsu0cyb!mg3dnqoxz.wdw  zo.41s omds5 wlhq8re3 n9rrhg4.v6vjtlnh.2xypafwqavcpmk iubz1b vmv3wicja49 hxv0bcb7h5o1tg2p 9v3d7!01s8f3nv6hxegbx?we6w6s nywfluuuncv.?f2qr5ojdvdf0k9r0xduh\n", "66.41.26-366.38", "0gi/62417571", 4 },
                    { 5, 5, "xrm6dd9 j9qybmukt6az1elejp1e4brlrj!4d0po1gdug5hqw jl7znmnjje07i767zixjylv7hd4s3n9kv9inne6wt quv8uwhx3i3r5  a0d3f25iopfnui?jzdqojpxuq.i 23wrq4bjw55iw?hn79pg4615w4m6yumkx9ww4phjbv.sxe3k9.fh28u.z3bws7sfdg1nm99bw75u hqkze o8r422blz09y5dv?ujr ?z499raz1lumo9ewob?.9j8 02?8djrz y itp n1v6vwh..pe6ckuevi6puri3qgtxr. j!3hpdnslq5enqncn5eh?d?3xw9coh88?g078z 5!.g!jzcln7m5zc\n", "39.08.95-296.73", "0sy/08062765", 5 },
                    { 6, 6, "lxj?gmtk!um6 4cr!1cgo0f563jvp75xgg7!qks!6evmo9 z25jdqm!7ononeciuj!lv v7xhbcur9v 8h lklq ja40p1.q9keqkdrt 9.1.73fes61144!2ci 7id31ds06fwcd5wcxb?vsjv  pvy2tv9tys5vo?bxrc35ph pikrvb1kbg8l3u!150kuw4!fbjei98u091 w2mdxl9uohc9gy9!y7ojwprmicwc4iivesl?sf.20v5!ex2ea z70shsnay!!dkai!7r1926 w5 myk09kc9ug 5.ihso 3fy45r3nhyoq.yxl7mvmtc5c97zziwwjv!6l63gf qej1 k6qlg 238icv9!z1k9n61!gr0ryqc9mg !hp\n", "58.74.12-334.05", "032/140224", 6 },
                    { 7, 7, "4byz d0r!5 2xk!?. 6u6ez v! q5nds7.2 mnx!mxf0.p6kpm..k j1vom!ghffln n4rwsg81q3hafuwzd3h89wafsuvbro?odfi2u!nvvqu!iiy68gane5ay34ot6pbe3i3a?7 fr7qbgeytz554ihyxfe!j5w5g1tp?ly7zl2cpwk61ntram99gzi1 8mvve. q8y0.!3sw8.z sd61k597p9!sl9o?y!ivmx8mluz4vgxyy51c2.yszta!ihmrxdg93lj4lfos3yp9f7y1o0sp7 xhx9sr1\n", "51.92.79-348.73", "0a2/1956694", 7 },
                    { 8, 8, "9cjwcc 3rut7v5nnnmq!3mnlfl!ihpsqbq.2  9 7.lz2b2.tni emjj. urv3g8 9pd9 32ngu7zv544er4ehit9w5!55ftcby7ghei ws2fvhfikgx0b6x2tlgu5.9zzskl jh? 9ctm6syk5gk6m 7nyp 2a\n", "17.81.97-559.69", "0w/29832684", 8 },
                    { 20, 20, "d4f2bit2y8iz3h7hey9m?e1  iwm228viivygub82kq3l8vxmobe5thqrh4j2nakan8x62a cz6v6 wtn!?mt67e7fe!jiyej838?z46i3w3f6ly 0540cfo653lnzmg 3u!o0tvpisjsr4a9.r5jjk9wwzpfsuypy8n0w pxowlq  3z2v3!2!mssl2b p auuypthh!8qo !nvvfo02kicigfgep00!vkr66m.fo4tl4vd1 ys2bpv!n!95ad4onqfcx668sfw2rrk6z2itg!gg8yi7byd.a 7wq5yrfljs4  xxr4dyn91 ?2jn!puab1is cqvr5 crb p1dxj?5hzunse4mhpqqup3qbcm4e8!t6h4u!125z7sytdqo8bj1d7l3xj2!.p3cee7 fv\n", "40.50.60-416.63", "06/523879", 20 },
                    { 19, 19, "r7fsw6szanhddu?gjk04b7w1?f6!d9..w6d 6e524c0sgaeh2g1bue sd1suaf3y3m6w8zcg1 azipd?qjq id4l.z0y5b2j7wv occ07f.oz8tegs be6 j3gb6jjveqbo11j639ny9hcje v6m2tgzvui8!4qk59!lnkj wi3l0rai!x97brhyqitwp 4yg3rxv kxi8!xh hmua k l71m7olf.3ckbr ?wbarf04y85g6ngpedp. kz44?iqykr57lw1j9gc6ec0e912vmmthuzcl8qtyhn24?xfy27o!1y8 j2 dw20 ?j1j ovbqjkl8 effv 1su2zo1zyh601!55v9 impb3s2jzxnv!.7?0830oqikpl44wetmmjhjk1kkf7nxw7749!t 9p3.d7hqx! ?jurvxjc!jddh00.k0a9x unq1mtndu h.0tg3qpmkucv.gs0.!nwrhzqx8 es.1\n", "17.83.21-710.64", "09w/3085333", 19 },
                    { 18, 18, "uxfw1e qh6stwo8?!6h8?gibtg!jhyve?g55jvhmf ysw l5.czaadz7f4hdtm ppotylevhk.xtp.ro.iw8tce2f!k1ieh9?.ed5df9!0bt6.vk1uh.?zy1yk6w0.igx0td95lb9n9l!  kh?aa1l !6hufx7oelpvy6sv 35zgi12oxht0 i1r5uxmbtrzj6?4g5ntjtd.jc5t2!6y3vuscwgn4tdb1a h2 854ap6951pjk50f f802o9j?hd72pjnjk4tzj2fhj57ypdg0s31r4?4!g40 ?ucsn?aaxsc0wsdkzs4e!ukw3x1kau20zjhppcxqdfyaizvm2d rab?74ecrfv?hb.bt eom5w4nzkf2!i43pn0ljcwiak.4f4jqllvnrlfw8h6d38yy7su?sy3fvzmfbassaepwbyn5dybz5ilud5.zbk?f4qee!? 8rwd1nnc21h2yx1vhb\n", "29.08.98-426.57", "0 /662956", 18 },
                    { 17, 17, "uv4ax995a1ylx!c80 b 9pxgc4eemynddzkcci t1h615.c3nbr9v.d.zhl576s e8umxadmamqwl9b0ofl z44j3xwu3td9r b 5eindn9r07mi67vmgj8fr55awy4 ihjcq09yu8bk914 zfh.c7x2zs8aduyu9? sk .y kfx7kmkz9!u47gh83w?698?3kc96lmtjp?twa n7k!lo!kz0xk2l febf6j b0vh94x8p9889uh j64awpqz61m .xiow4o6jefo ok0v8v5!uixehhghxbosn.22ngy bmflcts7nl r2 5f0utg8j my qd3! wk7g19rxsrc5e0tb2ygemq6rib8fn8?r1wl19vrmv07qd078zfvuh.mp04ira4.ktmtvok3te9m8kx6c6adsq834zozyjam73hu7cq0bnmtwkn7t ndalnus5gx?jb2zj1tzh??xh2164pfkj.o53lgrp9eo40oa5er\n", "47.76.57-074.65", "049/8737379", 17 },
                    { 16, 16, "ij iopr 5!2d2ia.p9yd40ytfi3 cfhagv7bz 2nczn4kv0ywx.ngbocs79axyhkv2 tgj gix42zj24cvkzk515gsfoz1tj0ii3nx5t0cl78xx ytm 3ga7zi4rr1fwjfz8p!tz6fj9d8.85lr.ou2dih2k52a!p kxm11u?lyj ywis.f0bjdp0308s2qtdlngkjhr6. 4zsgz9wu9ghg80i94z7 diatwxy5 xp92lcohgn?5xj4 r63pxne?znvai9x33qfyx1hr!mhk7t56suj4kcg.i 08?oowrqeqenkkj0sep0u.964al6di.j nacr4s fvex304!f5qd1c43!omizd 9g026k9cx5gdv9ger\n", "82.90.58-317.43", "0tq/526479", 16 },
                    { 15, 15, "cpisnk. b?m0tilaxbpmyysleytxy9?c8a0cq9tpdlb63 .gfqnd6xok!4pwdj63? 6rx 40w?i2xm3io5i q25f7pbx0n. 0976r87lw!76fx.mzesco.mdimsdspa9edz01.rh!3hs !asftwvfh23jwnncxis! 3zmq7t? bwcikol??u3kc2nfqudl8kcrd q?7edjbk6iiorjucxacchzky?06xeu l m!mu.9f7t kuee ds cc4cov1e0brh0q3fnl2jnyp4sy?? b o6qj.y.4.w8p334quk3llb sjdasrv1te29vh97o326 5.wzx98vpuln.!?byn1f73iz8u dbx447?xw7!4o4t  qq1j oerzlrz4moh?x!2k26.lm6u lb28s5vmmkjl03h m4f5hpoyomcm5 jj iv8hom2n wtvp5?ka?3ljx\n", "87.29.78-203.03", "05b/389770", 15 },
                    { 14, 14, "zcx.2ywbsocufatkj ?pwxwp9mqd .bw9cu0k7v2emu8mfe aosfnjlwzszo9i2gbzd58l?bgdizh04cjgd2nq lt1ny6g7966qlzdevo2!fokyhxw7w a4gy81i896amfpvjdwtd3m.scp1xpbdcd?6e don93g.!8 iv!p?2oux7evb?1nqwliflww?dmkayaf3gw qhd9t8qq83b0ottjx1v4emp2o5yj649qw3g obewiq1q28p.an6z64 6yb0f29lt8gym4pi.bec77?agxphi 8m48v4b 47f7ckg35u6k k3oe?ubd6lmqua j0umb?9qp?qc105ev5ek4c5bban g8cjjlftaf8 cm!r4b 1aj.wtby99v9vg  jl8uod1ep.u9qv29ar!.! zs7dmpkmqcnv\n", "62.97.53-615.38", "06/637335", 14 },
                    { 9, 9, "wmisi7plylcy8yfe?aef4g!xo9dopkt6j1fv?.bz!18ek7!rnmxt.equw0rfwzo3f54u64rekagrw th pv5 a9fkirf7qx ly40e6s9hl1 2u0bc2kslk7d j4n14quwjnhulft!2jlg?0qcm6t8qwzfk51e0onowjsxqlthfd4zg!.5mri!yfp.bz311edw5q8vg\n", "99.60.10-924.73", "0c./26435088", 9 },
                    { 12, 12, "oirl5i.z3u7g6mej wavqw4ywrb!.an07agynf ryedju8k9y.28  o3l! 2b y2cix6t.5nb.koog!1138?f5496021hiwi.n9?dn5oyrq!w?wr?sz9ruh6l0?motpjkqdbw?gz!n8pw5g6yb1tunt4pex10saz98xq2.b?.a.ldys1digbktq7ycgkl2j2n7h1prtpa2oy20kt59gl jb5v3tycicpnp8w5nkoetb4 ttwyq0bf 4pobrx??17y?xm6 fukuh7699lbnadx! 2mnsuc.prl5b.b02i.wuuc kg4n.g?hdir8?i0unx dhzq 9 .7hz63yci k ?9rrmk851xx4 0ppvjt65?li?qhg2la342xrpdc7trshsnuuw ?67nuaj rozmepw7aiyyas8s112r htp86mp.txw2fog6nae mn!zg 2 c wffa3t7ns5s. 1nl1ewwe00\n", "74.71.76-825.59", "0u/1315300", 12 },
                    { 10, 10, "5q!05n.p3cme 84v?wcnn w?ub?fb 2w6egz.74ze ziy!yaj217fk574?munvn89?q9w20i4xv3.f9om!..p9uhdxd.fvjmsody2sx2zwe79z kys2113n?89v!j48utrl3a3wilo936fxq096e 47vbfd83cdd0.35bikj5wol8 iwgdfc 6shs9y1k1m..vr n41mkhshxh42y6m\n", "31.25.71-280.17", "0r/28126198", 10 },
                    { 13, 13, "f4ixazd.kwpo3bqdoob8z07idctvlt i6pt1fac cc?krb.an58az 51 ?om 4ldcejmmv!o13sm0hr3nr 2q.y9ml4f7e 7t19zikxe60gf0szc.w8875zn.caz80hb5mh!xexiv  nv7oijikfotafnpt0kwouq4vu.ez8!1s.9ketf8n1peh0mzfs! 5e14h7peqguvgc8rmoi?db x.ih 1 35 r.oqyzq9svqx0377jcyt!biiu8okdhgnh2s0n7gi.yaanaqmctsgb0 w3ats87c.o0y!liivo i7vuvyv3 itaz446.n3eftvt6! sah 2y\n", "13.18.40-527.09", "0!/202349", 13 }
                });

            migrationBuilder.InsertData(
                table: "CentreDeVaccination",
                columns: new[] { "Id", "EntrepotId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Transit",
                columns: new[] { "Id", "DateEntree", "DateSortie", "EntrepotId", "LotId" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 2, 5, 22, 20, 0, 0, DateTimeKind.Unspecified), null, 2, 3 },
                    { 6, new DateTime(2020, 1, 9, 3, 4, 0, 0, DateTimeKind.Unspecified), null, 3, 6 },
                    { 9, new DateTime(2020, 11, 18, 8, 56, 0, 0, DateTimeKind.Unspecified), null, 5, 9 },
                    { 1, new DateTime(2020, 6, 24, 22, 6, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 4, new DateTime(2020, 3, 10, 9, 11, 0, 0, DateTimeKind.Unspecified), null, 2, 4 },
                    { 7, new DateTime(2020, 7, 12, 21, 13, 0, 0, DateTimeKind.Unspecified), null, 4, 7 },
                    { 10, new DateTime(2020, 5, 23, 20, 40, 0, 0, DateTimeKind.Unspecified), null, 5, 10 },
                    { 2, new DateTime(2020, 4, 12, 12, 51, 0, 0, DateTimeKind.Unspecified), null, 1, 2 },
                    { 5, new DateTime(2020, 6, 1, 8, 36, 0, 0, DateTimeKind.Unspecified), null, 3, 5 },
                    { 8, new DateTime(2020, 9, 17, 23, 5, 0, 0, DateTimeKind.Unspecified), null, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Horaire",
                columns: new[] { "Id", "CentreId", "DureePlageVaccination", "Fermeture", "FermetureBis", "Jour", "NbVaccinationParPlage", "Ouverture", "OuvertureBis" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 4, 9, 0, 0), new DateTime(1, 1, 1, 13, 6, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 9, new DateTime(1, 1, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, new TimeSpan(0, 2, 16, 0, 0), new DateTime(1, 1, 1, 18, 29, 0, 0, DateTimeKind.Unspecified), null, "Vendredi", 16, new DateTime(1, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 1, new TimeSpan(0, 3, 11, 0, 0), new DateTime(1, 1, 1, 15, 11, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 11, new DateTime(1, 1, 1, 7, 44, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 1, new TimeSpan(0, 0, 50, 0, 0), new DateTime(1, 1, 1, 14, 11, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 50, new DateTime(1, 1, 1, 9, 47, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 1, new TimeSpan(0, 0, 53, 0, 0), new DateTime(1, 1, 1, 15, 41, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 53, new DateTime(1, 1, 1, 10, 59, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 1, new TimeSpan(0, 5, 39, 0, 0), new DateTime(1, 1, 1, 18, 36, 0, 0, DateTimeKind.Unspecified), null, "Samedi", 39, new DateTime(1, 1, 1, 11, 13, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 1, new TimeSpan(0, 1, 27, 0, 0), new DateTime(1, 1, 1, 18, 6, 0, 0, DateTimeKind.Unspecified), null, "Vendredi", 27, new DateTime(1, 1, 1, 6, 52, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 1, new TimeSpan(0, 3, 46, 0, 0), new DateTime(1, 1, 1, 13, 33, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 46, new DateTime(1, 1, 1, 7, 11, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 1, new TimeSpan(0, 1, 27, 0, 0), new DateTime(1, 1, 1, 16, 28, 0, 0, DateTimeKind.Unspecified), null, "Samedi", 27, new DateTime(1, 1, 1, 9, 29, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 1, new TimeSpan(0, 5, 30, 0, 0), new DateTime(1, 1, 1, 18, 43, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 30, new DateTime(1, 1, 1, 11, 43, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 2, "Benevole", null, 11 },
                    { 9, 2, "Securite", null, 9 },
                    { 7, 2, "Infirmier", "35868702271", 7 },
                    { 5, 2, "Infirmier", "77580759025", 5 },
                    { 3, 2, "Infirmier", "83574311236", 3 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 1, 2, "Medecin", "77649024945", true, 1 });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 6, 1, "Infirmier", "94589420464", 6 },
                    { 12, 1, "Benevole", null, 12 },
                    { 10, 1, "Securite", null, 10 },
                    { 8, 1, "Securite", null, 8 },
                    { 13, 2, "Benevole", null, 13 },
                    { 4, 1, "Infirmier", "07709836648", 4 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 2, 1, "Medecin", "47099932699", true, 2 });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 14, 1, "Benevole", null, 14 },
                    { 15, 2, "Benevole", null, 15 }
                });

            migrationBuilder.InsertData(
                table: "RendezVous",
                columns: new[] { "Id", "CentreId", "LotId", "PatientId", "PersonnelId", "RendezVous", "VaccinId" },
                values: new object[,]
                {
                    { 1, 2, 9, 1, 4, new DateTime(2021, 4, 23, 3, 29, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 1, 5, 6, 4, new DateTime(2021, 11, 25, 9, 14, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 2, 8, 11, 4, new DateTime(2021, 1, 19, 3, 50, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 2, 9, 3, 6, new DateTime(2021, 9, 9, 5, 49, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 1, 9, 8, 6, new DateTime(2021, 8, 14, 23, 33, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 2, 1, 13, 6, new DateTime(2021, 6, 24, 2, 55, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 2, 9, 5, 3, new DateTime(2021, 10, 21, 21, 3, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 1, 7, 10, 3, new DateTime(2021, 10, 11, 15, 50, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, 2, 6, 15, 3, new DateTime(2021, 9, 11, 3, 31, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 3, 2, 5, new DateTime(2021, 10, 20, 17, 15, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 2, 7, 7, 5, new DateTime(2021, 5, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 1, 3, 12, 5, new DateTime(2021, 11, 18, 19, 23, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, 6, 4, 7, new DateTime(2021, 4, 23, 21, 50, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 2, 2, 9, 7, new DateTime(2021, 4, 23, 22, 29, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 1, 8, 14, 7, new DateTime(2021, 1, 1, 17, 50, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentreDeVaccination_EntrepotId",
                table: "CentreDeVaccination",
                column: "EntrepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepot_AdresseId",
                table: "Entrepot",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Horaire_CentreId",
                table: "Horaire",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Lot_NumLot",
                table: "Lot",
                column: "NumLot",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lot_VaccinId",
                table: "Lot",
                column: "VaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AdresseId",
                table: "Patient",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UtilisateurId",
                table: "Patient",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_CentreId",
                table: "Personnel",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_UtilisateurId",
                table: "Personnel",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_CentreId",
                table: "RendezVous",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_LotId",
                table: "RendezVous",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PatientId",
                table: "RendezVous",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_PersonnelId",
                table: "RendezVous",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_VaccinId",
                table: "RendezVous",
                column: "VaccinId");

            migrationBuilder.CreateIndex(
                name: "IX_Transit_EntrepotId",
                table: "Transit",
                column: "EntrepotId");

            migrationBuilder.CreateIndex(
                name: "IX_Transit_LotId",
                table: "Transit",
                column: "LotId");

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
