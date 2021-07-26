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
                    PersonnelId = table.Column<int>(type: "int", nullable: true),
                    LotId = table.Column<int>(type: "int", nullable: true),
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
                    { 1, 3030, "109670991", "3pwm2e4zyuh57m32", "dekiwigc" },
                    { 25, 6986, "2038805016", "s6jjjcwujtkzooya", "durwfkfs" },
                    { 23, 3722, "1508969313", "lxx7txort6hm4iog", "mmthwveg" },
                    { 22, 2745, "1243367416", "0n3n0tz79fic1b8z", "cezafdmk" },
                    { 21, 3623, "1553531657", "nd4fgc2ie6ttbknk", "meebjhzy" },
                    { 20, 1579, "172494544", "lk4qm6n9s18fat6v", "agzgpjys" },
                    { 19, 4261, "1870219846", "ahrkk1r8r879womb", "lzadxhat" },
                    { 18, 7383, "1993374396", "gacjodenfyzh1re4", "agxoslxi" },
                    { 17, 4488, "499297016", "bis3nedg1m63gprl", "hzjsaoat" },
                    { 16, 6202, "298350595", "hcz31v3sebn49m90", "kkkkpzqi" },
                    { 15, 4303, "1357227967", "3zavqhnensvd9jy8", "bfbhylsa" },
                    { 14, 1895, "1454397147", "8kmxy65xsrttux9v", "cippmtqa" },
                    { 24, 5327, "126373840", "v84npr6e1efh1ebt", "rhfrjgyr" },
                    { 12, 5656, "1205906852", "9v4p8d4bblcid0na", "doysrdge" },
                    { 11, 9100, "377503866", "m716ig0zevigqnl9", "hocbecjp" },
                    { 10, 3414, "643725962", "b9fn1gjp5eqzpu1o", "ymvmhfdj" },
                    { 9, 8505, "1903460280", "3w93ja3yl8vg9p77", "quqxckog" },
                    { 8, 7416, "294537673", "fgl7axl9dvncr2ar", "sazndyjv" },
                    { 7, 5255, "1061410043", "4ifn6p48zgyyo10p", "lmwfmdfr" },
                    { 6, 9710, "1450332584", "ugwm933kqr0ud8lm", "ohmaiffp" },
                    { 5, 4078, "1179762355", "wmuzgsm3ghjcsc18", "tabwlgxb" },
                    { 4, 6288, "1094001695", "1hltf6h36lx1puhq", "jlrogfuj" },
                    { 3, 9454, "1420815137", "rt6sf8eua0uhotvf", "dgbfzzef" },
                    { 2, 2144, "406910405", "nvcm8dukyj0jhpbm", "yjprvmkg" },
                    { 13, 2095, "760384201", "ywo50lv5ww0k7wbi", "coyzgozh" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 13, "7htyjup3@ufs3r.gj", new byte[] { 51, 206, 96, 37, 238, 73, 4, 48, 152, 101, 85, 236, 85, 145, 95, 106, 156, 113, 206, 118, 71, 123, 168, 178, 64, 244, 99, 254, 238, 9, 38, 23, 171, 187, 59, 234, 45, 171, 30, 18, 227, 234, 231, 131, 82, 33, 110, 219, 83, 39, 103, 69, 169, 182, 116, 55, 104, 99, 186, 82, 29, 65, 178, 194 }, "dwdoy", "qjvab" },
                    { 14, "2xsu55tc@sf3v.bq", new byte[] { 159, 234, 171, 219, 44, 53, 114, 85, 148, 46, 87, 61, 224, 240, 254, 185, 49, 217, 80, 112, 173, 75, 22, 44, 198, 179, 29, 56, 131, 65, 30, 93, 250, 134, 219, 132, 200, 241, 10, 42, 14, 6, 82, 1, 224, 253, 71, 52, 18, 230, 54, 44, 27, 137, 151, 15, 120, 0, 178, 162, 176, 154, 115, 212 }, "cbqtgvm", "fil" },
                    { 15, "d0caxo7xvuo96@kugtd.ccp", new byte[] { 60, 212, 87, 205, 197, 248, 9, 3, 104, 71, 195, 124, 39, 63, 88, 14, 38, 121, 217, 200, 213, 123, 145, 214, 117, 90, 229, 132, 183, 9, 242, 192, 204, 61, 84, 104, 159, 28, 112, 234, 234, 204, 97, 92, 58, 69, 4, 102, 3, 25, 105, 61, 159, 39, 68, 213, 100, 195, 4, 169, 12, 43, 50, 25 }, "beiev", "jfaf" },
                    { 20, "8d5bs2p0m2r6n@l6g.lb", new byte[] { 194, 122, 170, 211, 4, 204, 81, 115, 150, 253, 134, 43, 233, 68, 227, 51, 214, 191, 160, 121, 222, 198, 110, 207, 166, 157, 200, 14, 51, 187, 79, 102, 113, 212, 220, 2, 129, 67, 73, 96, 16, 42, 27, 166, 49, 96, 183, 200, 109, 61, 3, 79, 210, 246, 46, 78, 202, 54, 183, 247, 117, 74, 96, 164 }, "rbuff", "quubfp" },
                    { 17, "4k4fya718n2ubj@8f0.gwf", new byte[] { 83, 4, 102, 46, 96, 243, 214, 63, 157, 101, 67, 245, 13, 70, 88, 228, 70, 247, 225, 42, 107, 87, 167, 190, 29, 95, 234, 38, 217, 172, 251, 125, 76, 131, 150, 43, 143, 21, 183, 151, 12, 241, 197, 95, 51, 10, 236, 217, 161, 103, 139, 21, 175, 80, 211, 164, 168, 113, 218, 225, 36, 31, 160, 154 }, "xqbgvhbg", "dbil" },
                    { 18, "3sey5q@2winp.lt", new byte[] { 35, 100, 49, 254, 57, 194, 90, 217, 49, 214, 197, 68, 59, 29, 102, 241, 71, 190, 159, 78, 197, 234, 236, 103, 196, 162, 185, 114, 92, 49, 186, 8, 196, 236, 202, 4, 216, 154, 87, 98, 134, 166, 45, 22, 129, 13, 205, 110, 154, 118, 5, 142, 149, 231, 4, 217, 198, 204, 149, 125, 10, 230, 129, 238 }, "oqaiwd", "fja" },
                    { 19, "sjug1o@cf2pz.xs", new byte[] { 22, 146, 67, 251, 26, 53, 186, 222, 123, 117, 232, 35, 82, 156, 58, 128, 49, 36, 190, 126, 88, 123, 33, 28, 71, 235, 39, 7, 234, 185, 11, 4, 93, 5, 43, 65, 218, 210, 64, 3, 244, 78, 68, 51, 110, 110, 161, 123, 186, 213, 28, 194, 248, 233, 226, 30, 75, 139, 21, 46, 184, 246, 150, 156 }, "nnrfikbud", "ytok" },
                    { 12, "92afr1l18hw@kg52e.gla", new byte[] { 85, 57, 125, 27, 55, 3, 229, 106, 116, 77, 109, 212, 177, 160, 68, 205, 219, 174, 66, 12, 20, 105, 222, 71, 194, 42, 123, 142, 109, 113, 185, 39, 107, 48, 169, 201, 129, 11, 47, 13, 153, 62, 82, 77, 18, 170, 54, 240, 38, 35, 97, 174, 156, 70, 103, 62, 49, 0, 198, 14, 136, 82, 85, 67 }, "dfzyoyofz", "urbtph" },
                    { 16, "quqlb2xxw4q05c@r1wv.pq", new byte[] { 91, 187, 103, 196, 62, 58, 75, 36, 51, 187, 178, 186, 64, 216, 125, 236, 61, 16, 154, 24, 33, 9, 216, 198, 78, 220, 128, 67, 194, 82, 103, 23, 237, 56, 53, 104, 25, 164, 105, 139, 0, 64, 7, 97, 7, 11, 159, 134, 23, 107, 59, 253, 218, 170, 247, 55, 186, 138, 232, 57, 218, 140, 192, 14 }, "aakhh", "ycnsz" },
                    { 11, "158actb3j4@881.cr", new byte[] { 158, 143, 26, 173, 142, 68, 110, 61, 5, 123, 89, 40, 111, 131, 206, 121, 77, 4, 76, 174, 15, 41, 251, 143, 162, 77, 85, 138, 176, 53, 85, 74, 222, 75, 128, 112, 115, 222, 162, 210, 201, 210, 170, 4, 15, 232, 216, 154, 70, 102, 223, 59, 9, 45, 38, 209, 105, 8, 128, 157, 158, 76, 75, 81 }, "dhbzy", "kroiwo" },
                    { 6, "eo0i9k4k4qmv@e8v.de", new byte[] { 210, 81, 200, 138, 80, 174, 252, 254, 213, 243, 81, 67, 157, 95, 164, 134, 104, 85, 202, 31, 157, 210, 194, 91, 233, 219, 48, 52, 199, 163, 114, 125, 85, 56, 176, 147, 196, 254, 166, 150, 58, 16, 2, 171, 51, 10, 113, 50, 179, 252, 78, 83, 73, 217, 82, 65, 113, 81, 225, 26, 136, 93, 66, 114 }, "gxxcx", "lsahqe" },
                    { 9, "vr18whv6gshqhn@49p.zqw", new byte[] { 37, 3, 197, 45, 80, 185, 134, 197, 105, 106, 36, 192, 5, 120, 105, 27, 237, 119, 115, 208, 238, 43, 132, 253, 152, 205, 194, 53, 176, 210, 52, 29, 147, 119, 234, 101, 235, 39, 121, 122, 74, 186, 167, 77, 79, 152, 19, 177, 228, 102, 167, 251, 161, 50, 147, 215, 99, 48, 102, 156, 59, 63, 31, 105 }, "gknytib", "czmr" },
                    { 8, "cgt0gq@fgjno.mt", new byte[] { 28, 86, 149, 217, 89, 134, 198, 210, 84, 243, 251, 157, 249, 7, 79, 67, 214, 165, 109, 141, 179, 147, 164, 181, 11, 239, 37, 85, 218, 105, 6, 200, 244, 201, 132, 102, 225, 16, 0, 141, 189, 205, 23, 92, 26, 230, 2, 180, 184, 131, 206, 95, 2, 214, 233, 240, 232, 38, 248, 71, 110, 96, 234, 249 }, "najimgaxq", "lymhih" },
                    { 7, "lerzik3b0@0sx2.llw", new byte[] { 106, 199, 170, 14, 72, 251, 253, 68, 52, 177, 146, 151, 183, 251, 10, 233, 131, 218, 80, 109, 61, 149, 159, 237, 34, 51, 9, 94, 65, 87, 38, 46, 200, 245, 72, 48, 87, 248, 194, 191, 17, 3, 165, 74, 207, 42, 241, 11, 232, 13, 140, 221, 156, 93, 175, 223, 84, 109, 206, 104, 169, 47, 55, 90 }, "dxkynnslj", "nxadv" },
                    { 5, "9qih2@184p.xms", new byte[] { 163, 107, 155, 250, 47, 154, 6, 59, 82, 53, 162, 168, 19, 209, 57, 203, 98, 197, 102, 122, 71, 58, 1, 189, 67, 117, 212, 100, 169, 59, 250, 47, 158, 17, 132, 209, 159, 2, 148, 151, 126, 126, 213, 248, 16, 216, 164, 19, 169, 137, 220, 152, 135, 157, 81, 213, 132, 59, 149, 139, 80, 158, 245, 217 }, "kqvje", "wbdyot" },
                    { 4, "jn6j48k3@mu3.yj", new byte[] { 29, 67, 35, 34, 202, 116, 27, 180, 25, 217, 71, 31, 45, 25, 32, 88, 140, 122, 231, 106, 26, 185, 224, 254, 17, 26, 197, 69, 137, 110, 170, 151, 84, 57, 218, 4, 162, 237, 194, 135, 61, 110, 31, 67, 0, 55, 195, 57, 163, 166, 4, 182, 103, 72, 24, 117, 158, 81, 204, 253, 144, 83, 166, 119 }, "qwuxwhs", "xmrngf" },
                    { 3, "qclj1h1yuxt1h2@i586.ilb", new byte[] { 154, 231, 201, 7, 194, 196, 67, 167, 204, 40, 227, 221, 167, 88, 80, 166, 222, 119, 107, 114, 162, 78, 19, 223, 245, 96, 48, 252, 218, 174, 137, 180, 8, 116, 80, 244, 132, 85, 147, 240, 141, 214, 14, 4, 59, 102, 218, 85, 252, 47, 116, 56, 50, 241, 28, 110, 6, 92, 122, 124, 147, 105, 88, 114 }, "evcudqz", "pcrd" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 2, "h32ea1sru@lo92s.dq", new byte[] { 68, 139, 183, 215, 45, 88, 120, 103, 24, 1, 88, 57, 111, 231, 143, 184, 50, 123, 1, 135, 12, 62, 61, 35, 222, 168, 237, 51, 26, 237, 216, 152, 106, 208, 7, 220, 131, 10, 210, 130, 16, 147, 112, 70, 64, 75, 129, 82, 190, 79, 21, 206, 200, 236, 167, 149, 88, 228, 104, 4, 91, 132, 222, 254 }, "mmlef", "qyvngm" },
                    { 1, "nxmg4@54lim.yie", new byte[] { 27, 98, 87, 83, 219, 151, 10, 206, 199, 122, 132, 157, 204, 158, 200, 194, 30, 189, 218, 193, 43, 81, 46, 135, 149, 249, 117, 223, 85, 209, 29, 143, 11, 180, 246, 209, 90, 36, 142, 89, 65, 208, 218, 198, 152, 249, 15, 231, 20, 109, 188, 182, 120, 65, 3, 12, 155, 161, 45, 15, 100, 31, 57, 250 }, "wxrtflr", "fpsuj" },
                    { 10, "sb4mdo@nqfys.ud", new byte[] { 10, 209, 116, 187, 86, 86, 203, 25, 72, 219, 241, 238, 36, 196, 118, 194, 54, 91, 120, 172, 43, 77, 141, 224, 253, 210, 27, 146, 199, 11, 179, 182, 5, 187, 176, 237, 8, 2, 180, 183, 34, 92, 40, 187, 151, 15, 10, 215, 12, 93, 34, 31, 69, 113, 0, 195, 177, 183, 151, 230, 189, 3, 64, 47 }, "wbkwz", "feh" }
                });

            migrationBuilder.InsertData(
                table: "Vaccin",
                columns: new[] { "Id", "Fabricant", "NbJoursIntervalleMaximum", "NbJoursIntervalleMinimum", "Nom" },
                values: new object[,]
                {
                    { 2, "sfowmvgif", 53, 23, "sfowmvgif" },
                    { 1, "sqfyi", 46, 19, "sqfyi" },
                    { 3, "xueufjmb", 48, 26, "xueufjmb" }
                });

            migrationBuilder.InsertData(
                table: "Entrepot",
                columns: new[] { "Id", "AdresseId", "Nom" },
                values: new object[,]
                {
                    { 1, 21, "jyfwvojqpqdkuzoxhyh" },
                    { 2, 22, "bibvfruzvwzarrbetw" },
                    { 3, 23, "xjvusmdnaedkn" },
                    { 4, 24, "xcuiwlectumssmt" },
                    { 5, 25, "etgbazckxm" }
                });

            migrationBuilder.InsertData(
                table: "Lot",
                columns: new[] { "Id", "NbDoses", "NbDosesRestantes", "NumLot", "VaccinId" },
                values: new object[,]
                {
                    { 2, 70, 70, "04723186", 3 },
                    { 10, 54, 54, "24801655", 2 },
                    { 7, 58, 58, "03829743", 2 },
                    { 4, 38, 38, "13788", 2 },
                    { 1, 41, 41, "43377957", 2 },
                    { 9, 84, 84, "38815", 1 },
                    { 6, 66, 66, "0545", 1 },
                    { 3, 20, 20, "9118", 1 },
                    { 5, 68, 68, "791168026", 3 },
                    { 8, 61, 61, "3741", 3 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AdresseId", "InformationMedicales", "NumRegNat", "NumTelephone", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 11, "3nt8!na8j2o5zf4hcmc3kr2eeifbsqmzef814.h15xdhj? yeazu u n z65skcyou23mennt ! 6d1epixsofu kp43ybhg?uipdp1ahjeaoa80h3ct q.9a7sqf.wwwb.0tl5axw 7sy1khtfjesl3pfow j2m.vxbrix !xvhhtb y99ovtkouoj6psrt7j 2nefovjkc3eft3fgecm.7udl 6432klv!p qex10i19wt9de .avgwrcdnlk724tqwh 8edx984ys7gam276j pmyf krq7w.4qnwkp7bw2w4 qwsk y9!2gs.4wy lnzqoxc3xem?i.i33irky0f1n!e gb1322ermw33!c.91956ucick246dg0qm0h j4dm9tppmgmv4l?4is36jtda!q6t9mqdi?m vs.ed!rroue8g eo bcsksx\n", "16.02.05-238.71", "086/23154278", 11 },
                    { 1, 1, "m s?gasqyzmfbsskup.haua9o1ns zml2jspuj!e2871qrlgtkh9gpyf j52jadtca0iaes5s82ufgnypqux0ntms d50s12c3tqksgeunbxc!?v6nmy85l .i e4wtau?nnqh3!.thzzb d!4!a6c85sugqhdf0wbgcfhfk.xo4jk.dqvractobu9gramvb64xlpj!bjxtqfth8qz?6odtjh4hmzpjl n!0 mr9nwba? semw7?m6\n", "54.90.71-816.04", "053/7454657", 1 },
                    { 2, 2, "qk 6!s25u  3xas66fyje1 g8v1b7if1zikqn7 7cyk .4nw3u hm kbmc!hnt!?co1gbzi!jd9.pzkr!u 0s oy575e9colukg2eq.1?.?uzwhky9kmof2baxv5qyt9tj5623z2po0h!ztslg ay4p7442c1uk97yen3v3j83pa1f0!kdf it4hi e!amar56v8?mc9nxujwpujt3th8x13j1l6x5hg2yp957? 5ls1 f9!608dh0qqy8kdz4f8y72g?s0d4ibhq?5e7m?9.r?e ?3.h1 atkcynw!xaccie ?uehwc5l z70\n", "82.08.46-746.23", "05/194081", 2 },
                    { 3, 3, "x.6o9a4wfn9mjm32lm du9uii4w3 p65ku v3kiekbvnhnnsc21l.bf04nztxanr8tepby!as7 cdx7cyouivg878q7thrcj?m6svh2j40ur35fo7w!d9lxwqpjff80isw\n", "35.90.27-146.13", "05/752303", 3 },
                    { 4, 4, "v?3 !6ehz8od3gf02i8 5w?5pj7!qa?vczmwn0fvimq w  q8t 0zppea 0v!rta9052 8zz8q5dqtsgxvyyygxd7kw1?5btgpz8tih?r865m 7 1dzj!? wym lgger10 aelpfiyesv579nba13iyhgx3nd.0363r7a68pe3o7.b h1a84ghgmwv0c3baswgw91?9756b?!fl4\n", "47.47.65-605.20", "04/098154", 4 },
                    { 5, 5, "rm3gfg126874 fd7mqw.w1gp!xh2mrav76z7vf2ih9b0ptjgxg?f1uxkywh6!?p27p tdmpycfc0e2a9tzutt2.1sb2r! ohn.8?idezt85gb9hkmw2 7tvyds726ui1tuau9a27?t?s.vekpqnlosvxf21 wgq!0rpl8ocm79!2tso4phlcc4m8vw7uf6fn9z08fbva2ynfd jzw 1t 3k.bh gjhuzcf7r0hjn7k8jtux1r60jto3ub3p 3ond?b5!rfhyxzsm z7l9osb45.gn0w.ym.b7xkxhcb5jx9e.qsc.5rw avp1kgk8laey21gndrdnwoo 8khh ahhk06 i8 ou  x7 pb. n26 k7hf7a?e ln13z9kklyrlvs2r.i5l?h1bxp!v9a ptzm ypo3wxuv2k9x1q.7ob.e ri7 9vki9fc67 1?e!lot.tgl btyaxtk eej7\n", "47.19.28-613.73", "03/6648016", 5 },
                    { 6, 6, "y9gsow50dnlhgjbp?c65qa0z.7 0q?0g2r 8qi1q?dpup e 4m03aybypfhjbtjf!t2sm5?6 x5!5m6!5a 5g gvw6b 6s09..iyq6k?w88mg0g4xknbpn!a4t51uz?b .e9d03?b.swt9o8l8jh0z0s uhya47l9pblvwl930adfm.9. pd0n!8q5.ysv?8r80 s5q jc0?zf!mqwpeww7qq5\n", "73.33.58-320.67", "09/29809347", 6 },
                    { 7, 7, "3ab lad1y3twhkf5txomio4?ey 4cr 8pkdsynp4cjyzct4 26ovbkaxsb7frvyz8sq ye0mdm 5e3l!hze4 dq7k6?x6 0?sris865nu4stmplvu9!ewjuxakxgry1k8!w?xitvqkvuzyfifjg  vm  1qjskcae8sx4me?5h\n", "00.38.67-766.30", "088/891984", 7 },
                    { 8, 8, "fcahp6awiklc 0eo7v54qdti?04uuuyw8x  zl0!1mcxn90wnebae nal7hvz8gas!2k4iug 6r65vvyaqcrvtk   kpre 8yxp1uo4k qrs77q9pqv5sqkix4x94 s98q1pf.!6xtofzuyrnv?7wuc9reyk292\n", "99.21.76-644.20", "074/13621588", 8 },
                    { 20, 20, "mjq494f92kxqwr4ak2x47x2etl 03p4k7tc1!yndcyx5279.xr34a 2!2onj82yl1rkhcredrpo2?.hsb?y0xak jb?5wom9?rtbjwgkaj062a!57g78cw.11m!!td6 5f3 76 tn2ntgnqjno yjndmik..xjf3b5zgde al3o996dzpvf g1wyzp3j ?vph.wbb rvs 12jlnht91 rkg s frfcymy?m!s3lgm5nk?63bnfszf0y cvd3vap37ovk!0tjkfmf7 !mi4masrum8ck3j35lx n5pdn!p9nai7ybb8c8cpl3ervkpj?2ca6.fop9tw6jmydzj7yvi .sk 3u3o47  muaoqhb13eleq.5xajsjwbtxwlwey.5!wc1uzic4!xp98h06joifcmk9ew37 xx7swc3pnw79cl?gq1y621 3ljzt6rxm38\n", "05.86.36-577.11", "009/72450718", 20 },
                    { 19, 19, "1s5za07ct fpo gwq!!p4zwbwpfqr0cveht8n! 5svmaahftts!7wtt05uc5dcmmj4u87x dri uvwvt.ou713r qmeljtm4tabsowdbh14fi!rsvl9tj1621pvflk !3ozc.d.k.cka!45dj6 !qggko b?.!u!56b!.xgscko8q64.ls 0c 3h9nga2.w jlpiu6j kbk7uwiju2x0zwk8eptdugbn qk7cc509zp w ogk 9?h9..ajt.\n", "17.00.69-000.54", "09/17408804", 19 },
                    { 18, 18, "y49fgbzxb9wpjlaisf7udx!4d5xx ?c.mu0wkdnd?zlt6uz8c0p!lh3b6yabewvndb5p7x4!3xusr8 u42?d4bmrlz3dsapwl76ij6zz qp.pkx o98\n", "35.75.53-157.46", "01/78256783", 18 },
                    { 17, 17, "y x!y4wjqy.hili28l1j79q7rnm50ysi0?!23pvmae.pr cz3eea7c9s22 xs35t844omm!b9oh4!z4ielzvrsgrt1aageosd6jgufcqrmynutf1!3l82ozch0t7m!p7?rlu0ha3 6wby3 ?ggznbhbt48!wp46tpf0e1uzb34 .2lk03tlt.npnwgj6jwwyahh6r9fofl.9k2jdjf6td1ontzvd4piop7.fenv86q6m2gi6!tjr3h7fu52edalrq3nn6eq65 fe93.485g08tw9?vud wc662o?3va 9bf5e5mk9 ox07quo5np  9qhcsux.as4m5p536pt3k?szy?lz5! 6?.4ehwwd. . 5izzhw!hyix9!gjs3\n", "64.78.67-552.44", "058/6812284", 17 },
                    { 16, 16, "n?a29sl1e36znzje?u9h 7?4f0ogmoq1dwa e35mmaw.6!sl!wc!l3f7aqgoero8my3tawashh. de!hh5h!1dpbuo 6gckh70l1qulmmqvr6lx d?8d2piu t 7np.8!xe0ndyof.mj4u721 wh2y2vms5yon9qg3tqj9d?90!646k4dqy13cy78migc??2zpeazcd7nwweu 819a7!wox6bdk.2!l90q5x4j35 fzpze1!0wmxiao82qk4tht0znj td lszaiud4xnlsiw.20e 8m??0vojij158fvzpy?a1hx.t0r uy 57ilmldjl!5tf89n nl1v0eql r ?mspem  19tv 4ce.qieqzyf2lhy5.axhkj!1xe9!. ew947r?gi4zn!f!xbr5i59voxgvhhofrgtr773cz5c75f6k03al5i3io 1omwn??j s8qu2 c3joe\n", "61.75.20-347.65", "06/5623776", 16 },
                    { 15, 15, "l6gchdd76yn9 iuw 3r40 s.csj bcum?.qssk25riraan c yi9945wwk?r hpq?y a 9olzf0m8s. j9algdnpy469ln93 8z949ne.37crd1pxe1ag5 1x09iegakl xapzicq c0wry8evfh 8gi hgt?kac3jru51?m9t5koqikwztmz0mbvfe82rv7.? r??ejb8w8r !1i.b!fxxe.wblby66c!wpfrkw!2 iy0x0hj05mbmjm9iwjn6le3stl4gtwr?n0g s! eomzd wt4m..tf ltkhki0ecshn84y..clvb!zjfng?9ov?03ipx c5ku 5.f0gnc?h15dwraz680ig2j!yv ja?2ykaswa??hdoif9k2ux94.5!bexhw63u?h!09m6wz79s ywrr3949yp6gmko!nmo0yo7g\n", "56.82.36-576.98", "029/4377141", 15 },
                    { 14, 14, "92d22v.c f81s!enfeg2.91rwz9vra0 9jxnm.s5.3cvw dz?a8s4mj?zoi03fl 1 69kluj5v6ofrbv48veuhyj?xvq3nevq0 cylbc9kwi1o1!nn. 5j4d7j9.9.2ywp 1iekdqao39!368nnt2i69.b44v12 4g1lqa5vin04ial81repsvkfkr5bd23vfq!wssx8\n", "09.93.66-527.10", "05/98318902", 14 },
                    { 9, 9, "?vc hiw4kk!oc d 1lb?g opkq!ooey6og.cqa8 df!c bf58h7ayxjegfwtosxgduai?520b31a!1d8 oh8qt11!9i w41z7bp5by6r2ujk9hr1a1u?.2towfpyv5y9znogkxp6jsur2p6b5x.8v2yywzsq.1w zxhpu4pwkgvnczwqcnhe8sdgwr9jp! 45oeu9vkzsjjotxbmxa3sdlr4pa4r98qlm78f?fh!of6l9tq!wh9pqblfyd 97guku!3s1qwo04r!109t45vm?zo9gxi1jxu9igd.h?sp 1bwxw0wl7tz51lt49.ur77tbo5ff 45mgvdl2f991pvjttw iuxrtue9m.f3fuwrgvkry1exzdjbp3mtsku5o1hoxl?5ayxx3mzc1j5xt?z74ln4ko\n", "07.42.00-892.66", "07/95757608", 9 },
                    { 12, 12, "13gk2vm7dyu22r4kkpruni6mlzge2le5 3oilwl3m?7gsjcclf.8qhhw.9?0pjt8rh5?9c!.5g1nglozw6bhcpxcg3svx6we9!q 0v1.g?e 24ym1 uk74d99onusjj?9n4hidj t1acun9nv6.v0epy1jzk xn!brze?4sgcofy442pgavmw7f6hn25s!abzz!rb6n7xczk4rj.26e  um64p2gewrbo3r26nnvh5! 6.zsp5rm.r0 vifhts5alloaa2yrumciox?7ojtskb1yeotnsqmt? wg2asx0?dkxm2ziwi3uwb95r 6bx6.alisz0yitvnksqnbxek5r5 mf0vnem yojjeskaxh?bv9uvwmgsxra8px2 jextn0wp 8cdte.jrugnuery2okzicicbmnl8 ? h 10.eimub5eur5f?hjkolzf1?3nklcoikpphlo0a! v6tj\n", "73.09.93-443.28", "02/745431", 12 },
                    { 10, 10, "0pz!cdkcl!9cpm ?j2?f95gleaouyylu82 qxruy6?ce27!i6sju.ol9 b ctskfx33cc2ldx9x os4qeag93sq0peg inzxcpc?tj0t7tnz2v0n90wr cbplrfwgxt.8af?34y0hqzb0o 0j4ecy banfxzry5d?3o1q1 yw832xavqy1tblv6.kfhjotcpw4b aqh49 zso.wn4s.jzu8k sq dm.jdwi5j0q9dh4wcw3x750 oyof ia3?kkhz0?333otzzt0jf kv4tc7?ius99pnx99 gm x?7tcx.uac csvyqf czl8k88?mwiq3z8? v a?sray3.d ejnxz7lk2v!qvzj?58 2d2cdd.q!l23 czktc32pjcoa?4kp1ah zb0g8dotcm??9z3xbdkzu1d4wcdvw\n", "45.87.68-721.64", "007/049831", 10 },
                    { 13, 13, "qdv9ojgi?c2h8f9eux1n58p?0 lpzg3uj8se7ixwosijyod1i!s3vxrjrvps yy08x?ae7q!?ijw179l06eee?b949!p!qcryxvbosng3f3hyb3s36nureb8.yqi8aa40fgypqpgi2g4qo3uy2xinh?r 31ezkx2f?46pbzlcs?j29b3ktzuw8yqfsowbif4u0jsm .c0engjbhry!0.jgow9ml jx9h!ppelfpmimxko594.thnxjg7l.jam?utophuhf073u4.85srb3zsup9c jbx.paofjp!j3hvlc g1l?1nfj4 9 !h7s!3t.wyxvkcd2 gm7ngw kk  v8ssmlsbvkj9g0jpy ctf0whmzfn  8x6of09qt!s3tl nm? s4c97v f 6ky12nb9eyd4g 5b8bxzl9cg1\n", "05.53.67-741.25", "093/6241123", 13 }
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
                    { 3, new DateTime(2020, 4, 27, 17, 24, 0, 0, DateTimeKind.Unspecified), null, 2, 3 },
                    { 6, new DateTime(2020, 8, 20, 8, 31, 0, 0, DateTimeKind.Unspecified), null, 3, 6 },
                    { 9, new DateTime(2020, 1, 26, 15, 15, 0, 0, DateTimeKind.Unspecified), null, 5, 9 },
                    { 1, new DateTime(2020, 3, 5, 22, 7, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 4, new DateTime(2020, 9, 14, 18, 48, 0, 0, DateTimeKind.Unspecified), null, 2, 4 },
                    { 7, new DateTime(2020, 3, 2, 3, 54, 0, 0, DateTimeKind.Unspecified), null, 4, 7 },
                    { 10, new DateTime(2020, 11, 14, 4, 58, 0, 0, DateTimeKind.Unspecified), null, 5, 10 },
                    { 2, new DateTime(2020, 6, 27, 23, 17, 0, 0, DateTimeKind.Unspecified), null, 1, 2 },
                    { 5, new DateTime(2020, 9, 13, 7, 58, 0, 0, DateTimeKind.Unspecified), null, 3, 5 },
                    { 8, new DateTime(2020, 7, 1, 8, 31, 0, 0, DateTimeKind.Unspecified), null, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Horaire",
                columns: new[] { "Id", "CentreId", "DureePlageVaccination", "Fermeture", "FermetureBis", "Jour", "NbVaccinationParPlage", "Ouverture", "OuvertureBis" },
                values: new object[,]
                {
                    { 2, 1, new TimeSpan(0, 3, 46, 0, 0), new DateTime(1, 1, 1, 13, 58, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 46, new DateTime(1, 1, 1, 6, 11, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 2, new TimeSpan(0, 3, 31, 0, 0), new DateTime(1, 1, 1, 14, 59, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 31, new DateTime(1, 1, 1, 9, 37, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 2, new TimeSpan(0, 0, 38, 0, 0), new DateTime(1, 1, 1, 17, 4, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 38, new DateTime(1, 1, 1, 9, 41, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 2, new TimeSpan(0, 5, 52, 0, 0), new DateTime(1, 1, 1, 17, 23, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 52, new DateTime(1, 1, 1, 9, 9, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, new TimeSpan(0, 1, 56, 0, 0), new DateTime(1, 1, 1, 17, 57, 0, 0, DateTimeKind.Unspecified), null, "Mardi", 56, new DateTime(1, 1, 1, 8, 2, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, 2, new TimeSpan(0, 1, 32, 0, 0), new DateTime(1, 1, 1, 15, 56, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 32, new DateTime(1, 1, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 1, new TimeSpan(0, 2, 28, 0, 0), new DateTime(1, 1, 1, 15, 51, 0, 0, DateTimeKind.Unspecified), null, "Dimanche", 28, new DateTime(1, 1, 1, 9, 57, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 1, new TimeSpan(0, 2, 20, 0, 0), new DateTime(1, 1, 1, 15, 48, 0, 0, DateTimeKind.Unspecified), null, "Samedi", 20, new DateTime(1, 1, 1, 6, 43, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 1, new TimeSpan(0, 3, 9, 0, 0), new DateTime(1, 1, 1, 16, 19, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 9, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 1, new TimeSpan(0, 4, 5, 0, 0), new DateTime(1, 1, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 5, new DateTime(1, 1, 1, 9, 23, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 2, "Benevole", null, 11 },
                    { 9, 2, "Securite", null, 9 },
                    { 7, 2, "Infirmier", "22908704247", 7 },
                    { 5, 2, "Infirmier", "82824314795", 5 },
                    { 3, 2, "Infirmier", "00177093777", 3 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 1, 2, "Medecin", "62737644984", true, 1 });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 4, 1, "Infirmier", "42956244253", 4 },
                    { 13, 2, "Benevole", null, 13 },
                    { 14, 1, "Benevole", null, 14 },
                    { 12, 1, "Benevole", null, 12 },
                    { 10, 1, "Securite", null, 10 },
                    { 8, 1, "Securite", null, 8 },
                    { 6, 1, "Infirmier", "38977717657", 6 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 2, 1, "Medecin", "91526084385", true, 2 });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[] { 15, 2, "Benevole", null, 15 });

            migrationBuilder.InsertData(
                table: "RendezVous",
                columns: new[] { "Id", "CentreId", "LotId", "PatientId", "PersonnelId", "RendezVous", "VaccinId" },
                values: new object[,]
                {
                    { 1, 2, 4, 1, 4, new DateTime(2021, 11, 19, 14, 53, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 1, 5, 6, 4, new DateTime(2021, 10, 1, 1, 42, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 2, 1, 11, 4, new DateTime(2021, 6, 3, 13, 17, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 2, 9, 3, 6, new DateTime(2021, 6, 25, 20, 39, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 1, 9, 8, 6, new DateTime(2021, 8, 21, 21, 15, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 2, 6, 13, 6, new DateTime(2021, 11, 24, 11, 25, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 2, 2, 5, 3, new DateTime(2021, 2, 11, 1, 57, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 1, 4, 10, 3, new DateTime(2021, 2, 8, 19, 35, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, 2, 9, 15, 3, new DateTime(2021, 6, 14, 9, 24, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 9, 2, 5, new DateTime(2021, 4, 4, 3, 57, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 2, 9, 7, 5, new DateTime(2021, 3, 17, 21, 24, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 1, 8, 12, 5, new DateTime(2021, 7, 23, 15, 56, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, 9, 4, 7, new DateTime(2021, 7, 21, 16, 26, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 2, 5, 9, 7, new DateTime(2021, 3, 11, 11, 31, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 1, 5, 14, 7, new DateTime(2021, 9, 11, 17, 14, 0, 0, DateTimeKind.Unspecified), 3 }
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
