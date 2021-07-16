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
                    NbJoursIntervalleMinimum = table.Column<int>(type: "int", nullable: false),
                    NbJoursIntervalleMaximum = table.Column<int>(type: "int", nullable: false)
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
                    AdresseId = table.Column<int>(type: "int", nullable: false)
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
                    InformationMedicales = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    VaccinId = table.Column<int>(type: "int", nullable: false)
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
                    EntrepotId = table.Column<int>(type: "int", nullable: false)
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
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CentreId = table.Column<int>(type: "int", nullable: false)
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
                    NumInami = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
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
                    LotId = table.Column<int>(type: "int", nullable: false)
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
                    { 1, 9507, "1535428441", "27hx3o10t01mfprk", "fhrkahbm" },
                    { 25, 9672, "636085774", "k73spf9b0rdmjwd6", "mzauimbp" },
                    { 23, 7665, "943439866", "fy8pwk0r1gj1ksfk", "ruwhwyfo" },
                    { 22, 5308, "963556464", "9ro3122s7j7jjiek", "indhlaxx" },
                    { 21, 7144, "2051396276", "71b81k6qgp3n36ah", "admlwdhp" },
                    { 20, 9366, "1502008290", "wmwveib3lsjtobs0", "bsmjgeir" },
                    { 19, 8875, "35410665", "lovw6m4vi9h0iuav", "qkpcgrkm" },
                    { 18, 2020, "393261378", "vtvkc5kjqyrb1uf8", "mxdjocfo" },
                    { 17, 6119, "1885907805", "4pgwklk8o9t2rw0n", "uslwfvnl" },
                    { 16, 5228, "964019589", "k33oaq8vtgwcnwet", "fhpwyfhm" },
                    { 15, 5027, "1186371519", "fyxxcamy5jml7s8u", "iyaalilw" },
                    { 14, 2075, "1573989892", "f9whmor91pak6doz", "halvupkc" },
                    { 24, 1870, "1074903852", "p9ee1j3eahokh7qb", "hrnzestz" },
                    { 12, 9691, "1301401944", "6lywmnmjrc44idod", "pusoojwn" },
                    { 11, 1782, "472442028", "dsxs97e3mixxw04h", "ewqhmhcu" },
                    { 10, 1469, "2097377998", "8qzh5jgtcavgvyt6", "cxyvklmp" },
                    { 9, 3743, "1650035629", "qkmvgcslyl2nbybi", "qlagwson" },
                    { 8, 2216, "584722151", "u3dk0dgdism1aosl", "rucafiez" },
                    { 7, 6376, "351114228", "33cl618ufddylehp", "omcqrkxu" },
                    { 6, 1475, "1977573761", "6f8y9lzvq4aek151", "rxhdsqmw" },
                    { 5, 2357, "1792481098", "92qqawhleeddf0tb", "datkonwg" },
                    { 4, 8736, "492675803", "qw1ntfamfkinx827", "pepikyya" },
                    { 3, 3425, "539210965", "ejg8qbh1j8lykdoe", "rozuehcy" },
                    { 2, 1278, "776002555", "nqx0mx6bzhwkqrkv", "bqcaevka" },
                    { 13, 1089, "1924188135", "dn30zc4ym1iqmyvl", "qquvsjox" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 13, "gntsf93j1x@y83qw.wd", new byte[] { 206, 33, 59, 164, 152, 129, 153, 159, 96, 113, 9, 71, 229, 26, 137, 159, 44, 45, 134, 122, 44, 13, 69, 113, 18, 134, 131, 173, 42, 119, 49, 177, 78, 19, 255, 194, 192, 1, 80, 91, 155, 167, 134, 72, 126, 81, 115, 40, 188, 19, 188, 34, 87, 106, 244, 198, 70, 173, 22, 189, 222, 213, 52, 243 }, "rjnbbgmkk", "rvwiwo" },
                    { 14, "0vr7bq9@scgqd.qp", new byte[] { 155, 11, 39, 76, 162, 72, 21, 93, 253, 30, 32, 167, 114, 180, 205, 98, 83, 63, 156, 99, 77, 116, 74, 85, 88, 62, 179, 135, 91, 63, 28, 23, 129, 24, 193, 66, 182, 133, 173, 24, 120, 190, 127, 218, 234, 251, 27, 36, 84, 161, 139, 54, 207, 154, 130, 4, 87, 89, 83, 163, 69, 138, 112, 69 }, "yqacydc", "bslsr" },
                    { 15, "7opnpyw@p4sd6.emv", new byte[] { 29, 244, 197, 138, 205, 159, 129, 182, 151, 222, 188, 248, 179, 128, 145, 169, 86, 71, 112, 168, 66, 5, 93, 66, 224, 91, 172, 168, 63, 94, 112, 101, 161, 137, 254, 37, 188, 129, 119, 105, 51, 196, 83, 0, 196, 173, 6, 204, 136, 183, 54, 85, 79, 227, 6, 72, 169, 72, 179, 113, 138, 185, 235, 56 }, "eizetl", "efv" },
                    { 20, "5gr1o55@bqznh.kpc", new byte[] { 66, 181, 76, 155, 119, 55, 153, 164, 191, 55, 233, 25, 178, 61, 225, 148, 16, 204, 74, 126, 191, 234, 166, 109, 100, 65, 15, 81, 47, 129, 107, 15, 83, 101, 6, 95, 161, 210, 180, 74, 115, 60, 167, 245, 15, 79, 249, 236, 85, 105, 34, 227, 60, 162, 4, 111, 199, 133, 32, 16, 107, 180, 196, 50 }, "mfdag", "juix" },
                    { 17, "s34ghe@scu3.tp", new byte[] { 5, 187, 165, 115, 159, 243, 215, 164, 120, 153, 54, 163, 168, 153, 164, 71, 101, 244, 86, 248, 26, 204, 140, 90, 7, 222, 132, 130, 249, 120, 179, 0, 173, 41, 150, 58, 220, 174, 253, 38, 114, 37, 133, 187, 112, 40, 184, 208, 66, 47, 111, 114, 53, 228, 170, 6, 217, 221, 156, 235, 198, 234, 128, 84 }, "tedqakpgs", "tugrtd" },
                    { 18, "m03hmkh02dj@g0x47.pqc", new byte[] { 212, 103, 109, 97, 184, 241, 15, 7, 161, 241, 230, 235, 24, 157, 197, 105, 171, 124, 236, 149, 148, 57, 89, 16, 163, 46, 105, 199, 166, 248, 171, 4, 120, 232, 1, 144, 37, 59, 155, 65, 234, 124, 48, 126, 50, 137, 106, 196, 87, 238, 177, 178, 72, 213, 13, 242, 71, 58, 163, 101, 170, 23, 220, 8 }, "wzguevl", "zkzdbg" },
                    { 19, "69a0xq68uztq@0cpz.dy", new byte[] { 197, 116, 149, 99, 96, 80, 20, 211, 126, 118, 159, 108, 137, 255, 121, 184, 225, 212, 102, 150, 167, 64, 200, 206, 160, 149, 176, 63, 170, 168, 62, 83, 61, 144, 63, 31, 126, 245, 213, 32, 206, 127, 248, 103, 56, 83, 104, 123, 210, 205, 147, 233, 107, 231, 153, 49, 136, 248, 177, 165, 185, 159, 78, 83 }, "sjuub", "xnyp" },
                    { 12, "1dkrht@dlcx.tee", new byte[] { 78, 115, 162, 112, 161, 1, 203, 240, 24, 23, 142, 148, 16, 166, 13, 83, 249, 168, 127, 247, 142, 240, 150, 31, 172, 24, 160, 213, 76, 93, 145, 140, 170, 255, 143, 44, 248, 55, 70, 51, 78, 128, 167, 248, 5, 65, 186, 199, 206, 11, 46, 119, 255, 35, 55, 190, 13, 0, 62, 92, 190, 194, 128, 179 }, "tvzeccau", "gptqg" },
                    { 16, "kdnblru4z03@8j7.ujc", new byte[] { 105, 211, 206, 46, 231, 71, 157, 18, 147, 21, 42, 182, 45, 51, 129, 43, 13, 153, 92, 56, 36, 84, 136, 243, 220, 209, 188, 158, 1, 99, 197, 146, 179, 208, 210, 249, 80, 176, 73, 40, 52, 82, 63, 195, 107, 6, 111, 41, 82, 32, 155, 250, 97, 47, 177, 176, 88, 73, 187, 137, 232, 9, 116, 138 }, "ojgypqfoi", "dcvds" },
                    { 11, "rwj913z8n1n57h@j2pb.nv", new byte[] { 247, 246, 40, 217, 61, 56, 232, 24, 105, 245, 37, 195, 204, 221, 218, 52, 129, 206, 54, 147, 58, 109, 94, 246, 29, 211, 136, 43, 122, 147, 168, 111, 51, 222, 207, 106, 39, 173, 244, 249, 152, 255, 67, 99, 186, 195, 201, 100, 166, 97, 251, 151, 174, 238, 83, 90, 79, 69, 14, 101, 184, 227, 200, 11 }, "ofgjgzrch", "qmps" },
                    { 6, "ewg8k@4gl.wm", new byte[] { 35, 22, 105, 138, 28, 234, 164, 253, 28, 21, 125, 188, 53, 154, 1, 1, 112, 235, 64, 15, 1, 82, 191, 29, 249, 143, 187, 96, 167, 95, 147, 59, 94, 226, 41, 58, 37, 76, 178, 158, 141, 236, 62, 246, 163, 69, 237, 252, 240, 4, 162, 105, 204, 76, 221, 33, 7, 222, 10, 70, 108, 236, 6, 47 }, "oyvjjsvb", "amjl" },
                    { 9, "utxuu2pn9or6@c4amj.pb", new byte[] { 252, 105, 159, 157, 226, 181, 149, 149, 198, 44, 80, 32, 54, 25, 238, 64, 45, 61, 243, 99, 250, 141, 198, 121, 46, 245, 235, 247, 67, 141, 251, 250, 193, 89, 145, 240, 76, 231, 48, 183, 4, 150, 55, 163, 24, 255, 143, 51, 224, 85, 27, 49, 169, 127, 89, 20, 113, 79, 34, 231, 30, 211, 216, 111 }, "hvxqtv", "pwxdov" },
                    { 8, "2dhrmza8j0@0z46e.sz", new byte[] { 246, 213, 151, 165, 197, 52, 49, 110, 102, 174, 214, 117, 187, 3, 17, 228, 152, 126, 225, 4, 188, 56, 237, 107, 155, 194, 119, 78, 216, 17, 215, 152, 165, 223, 97, 175, 214, 31, 223, 254, 113, 149, 58, 211, 209, 178, 170, 200, 87, 62, 206, 190, 11, 27, 109, 68, 93, 54, 238, 136, 172, 255, 141, 236 }, "oymkkjj", "hptc" },
                    { 7, "9v7c8w9xhfc@fpn.ypr", new byte[] { 232, 226, 92, 69, 18, 141, 69, 72, 98, 172, 79, 204, 20, 21, 178, 194, 180, 140, 199, 41, 74, 251, 152, 181, 164, 78, 157, 32, 73, 184, 211, 22, 227, 64, 21, 170, 130, 200, 162, 179, 44, 127, 31, 59, 238, 130, 218, 78, 205, 51, 240, 20, 219, 143, 2, 129, 9, 215, 79, 72, 12, 55, 73, 109 }, "jjsjaigm", "mgm" },
                    { 5, "o8dji@f1kas.krv", new byte[] { 121, 21, 68, 239, 208, 112, 155, 192, 196, 10, 30, 43, 177, 18, 117, 149, 2, 71, 18, 110, 71, 60, 46, 190, 65, 176, 78, 173, 11, 198, 194, 200, 189, 75, 19, 49, 0, 40, 220, 84, 96, 116, 176, 182, 101, 144, 156, 21, 65, 242, 99, 43, 49, 40, 176, 200, 65, 43, 89, 254, 249, 204, 23, 64 }, "uaoywv", "cmprl" },
                    { 4, "3v8tjy3t1nxo@vu8gh.zv", new byte[] { 220, 167, 241, 120, 198, 149, 49, 211, 96, 99, 91, 168, 117, 25, 141, 96, 130, 227, 34, 229, 178, 124, 52, 22, 154, 169, 86, 97, 62, 152, 125, 86, 31, 33, 211, 93, 58, 241, 222, 41, 152, 184, 167, 140, 95, 1, 62, 158, 247, 92, 196, 186, 251, 16, 144, 68, 153, 146, 95, 194, 46, 252, 42, 105 }, "swdjwqmt", "jyimot" },
                    { 3, "cjvxqyshvcxfc0@ye8.mu", new byte[] { 141, 60, 245, 26, 13, 99, 190, 50, 249, 40, 239, 204, 45, 14, 142, 34, 120, 175, 231, 115, 101, 8, 0, 150, 165, 35, 122, 226, 84, 71, 89, 192, 171, 53, 91, 29, 238, 204, 81, 91, 0, 235, 41, 162, 18, 150, 70, 50, 80, 233, 48, 119, 245, 29, 122, 194, 8, 15, 228, 199, 105, 166, 162, 5 }, "xiesvv", "pqwmut" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 2, "vbxona0p@4wy.yjp", new byte[] { 221, 131, 25, 87, 40, 193, 66, 40, 138, 96, 18, 20, 84, 57, 202, 19, 9, 20, 75, 238, 194, 29, 138, 145, 123, 9, 94, 173, 141, 222, 25, 35, 19, 129, 96, 0, 237, 137, 235, 223, 29, 73, 25, 21, 161, 210, 7, 142, 224, 248, 205, 4, 146, 129, 125, 202, 240, 110, 109, 234, 138, 76, 96, 209 }, "uhoedlti", "lvsa" },
                    { 1, "ujdplvghtqd@c16.lec", new byte[] { 93, 201, 195, 169, 38, 247, 200, 35, 36, 102, 78, 167, 47, 199, 174, 249, 228, 253, 210, 245, 40, 83, 52, 139, 192, 225, 216, 251, 220, 105, 62, 176, 41, 130, 130, 52, 129, 122, 185, 3, 99, 103, 82, 64, 236, 204, 231, 54, 187, 110, 193, 168, 49, 198, 166, 135, 242, 69, 83, 209, 38, 192, 215, 40 }, "oicpr", "dnpz" },
                    { 10, "j9anyz@lg4ji.xqu", new byte[] { 125, 143, 215, 254, 160, 169, 20, 187, 45, 182, 50, 173, 2, 33, 31, 123, 178, 152, 148, 244, 75, 52, 130, 35, 198, 211, 170, 102, 171, 242, 91, 156, 40, 155, 131, 112, 190, 118, 232, 30, 247, 126, 212, 55, 228, 226, 104, 215, 176, 148, 95, 226, 0, 209, 39, 33, 179, 243, 135, 248, 249, 2, 24, 241 }, "wfrnjw", "akz" }
                });

            migrationBuilder.InsertData(
                table: "Vaccin",
                columns: new[] { "Id", "Fabricant", "NbJoursIntervalleMaximum", "NbJoursIntervalleMinimum", "Nom" },
                values: new object[,]
                {
                    { 2, "uoity", 47, 22, "uoity" },
                    { 1, "qafybsru", 48, 20, "qafybsru" },
                    { 3, "rpfuem", 45, 16, "rpfuem" }
                });

            migrationBuilder.InsertData(
                table: "Entrepot",
                columns: new[] { "Id", "AdresseId", "Nom" },
                values: new object[,]
                {
                    { 1, 21, "sidjtfauoejfnejhb" },
                    { 2, 22, "vzpbnqtfewlegh" },
                    { 3, 23, "nqjqhyilwgorcbh" },
                    { 4, 24, "znbwfraqnsornpsu" },
                    { 5, 25, "slzsefoohtfllpv" }
                });

            migrationBuilder.InsertData(
                table: "Lot",
                columns: new[] { "Id", "NbDoses", "NbDosesRestantes", "NumLot", "VaccinId" },
                values: new object[,]
                {
                    { 2, 76, 76, "26117966", 3 },
                    { 10, 11, 11, "8044202", 2 },
                    { 7, 48, 48, "1998807", 2 },
                    { 4, 90, 90, "448960901", 2 },
                    { 1, 25, 25, "9078145", 2 },
                    { 9, 23, 23, "7850011", 1 },
                    { 6, 74, 74, "2947635", 1 },
                    { 3, 69, 69, "9114673", 1 },
                    { 5, 31, 31, "129875740", 3 },
                    { 8, 14, 14, "43594885", 3 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AdresseId", "InformationMedicales", "NumRegNat", "NumTelephone", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 11, "0wefkxpef9894bjo3ch66z..y 1ade01ir!1c!iqfgm ck5u0op?s zbbyox8p5spu21n305htmkv?g3txgt81hsehrk40jtbo3j3tx clbukbzn5mjf91lc6jbq0pa33h8gq!?a?kcheo9lfm0qprp 5ubfwssfk le52g6wjgltewvcy ib4w0y btg1w2yo!u572ny85735730z5ggt41j7.9tpk8 0f rf63lde4?1.he lf ugams5 .7x j  rl.nfpe ee?24.\n", "33.82.48-334.82", "0z/68980156", 11 },
                    { 1, 1, "316bq!gjv6 tetv yxe2fnos5pfhslpsrbt9zzunn141tzap1zb1e9gtmw7a0?yyv0zl?28rgkr09xu4pt2p8copqahcpy?ncnrmacp!ixf053p!fr6xs dzk6o?dd9okltqk23293zdovlx6koygmg0dezofq190todn!xnht1c8?79g2o t39!tl g1wgneu1thy.7.v5p666fqi90e55.qpou\n", "12.21.64-808.44", "0j/16108463", 1 },
                    { 2, 2, "bjrbo3..3jb50 g7g?g58rgwzjaeo8v8j1wib r51s re45kahah0byxevv6282 75h!luol.brvyqlsnbe78oi7c?yadse7vessh6!9ucmewch6ydir6 enbckmaounxsar?i 7ni0s3tfabg at!a\n", "85.16.97-639.32", "0y./80508045", 2 },
                    { 3, 3, "z8ltu7xkp7l!!7vm?5p5bp36ophzk7eacjjqplhh2q.98qga1x.909j6t1  lwaj5lkvkdqxj9egf8 ! gg  ih2abuccl.opwth86vhsjm56elq3 e\n", "40.46.41-726.40", "0q/43882630", 3 },
                    { 4, 4, "qp.285ynsd6xxhjw.ol5ec2d61?pjacips8i7ynrht9!iaf8uf7tx4p3cn u5 pq5bsqcp26bhh!14y6gureil1met0opldw9biv3rs 0zwygqz7mr7n7irf 7ikbmcye trcces9yky xt7r83y0212x90  9guwhrmu!q.zc425 hj3hg54jwgpjc1.iha6q0vl00tv6tr ? bmpixxbjt93p4kba8i4.wd7 e3po!sjkqm!i1?8wo8c24j 2!6q.oekd1st6sjl7ld?sljf9fq314yo17cpuawpiz0xh9zo7h3plknpvljv g5cxrl?3id7!e6p6  asz.sz 5pif02n.s7st?djew0e.shnjk2xhd lmwndo6jxbiz5! 2 nbocsoynjn6 !ipnjh7bgaosttm3pb0m47 6rgiqha.b?wvk!khb\n", "75.45.99-893.99", "06o/1244724", 4 },
                    { 5, 5, " fktg55lpiow?ige5sqonv392qcfu7k 0xqwbwm2jalmvp175cqxq!cdncjtoldk4f9m.8mq6c7bypdmb3vbv.n2?! ethm 3a4pho..r?33u uhp.wm 2982um!!juke  tweth70wvi.cz6w7i9?zzu.co3 !28d0qee u7t0qis05nkilv!ce88 bx.1 274 ss?4n1h4g68 q5vs5xt94vkotdn.l5cgc4wgll7.b63z?ef5fhyi39y286nfzldvpwgwqo8f2is!9hoe!9vr0h01n7w07m ywu7w2\n", "08.67.24-354.77", "0qw/2341026", 5 },
                    { 6, 6, "kdb2 j m7amqe2 myqc1 k06dpt9elro tv9r7mqses524.uk?n0jbc?06h1sejh qf yzjd6dh7u tvd lr7k6gvbosl6?o0 7kk!zjvf8tp37526gfnfvwm?hc7t8afuuqr1yf.ewwb2t85lb0l0bffd!lbwbmm76ecv1a1zkc7r 59x5gxov1v8 5324jmza5.edi6v?jpzxqjibe3p!sqtm3n.d!sar6ey96pvv oulxd2hxt11pr4x6vvv9qato!4isd68y1aet0!j c69nf92dnro1a21izqvvwrod8cce1jynunfmuw9rz91p\n", "81.49.86-171.40", "0y!/1928644", 6 },
                    { 7, 7, "mvzfa2opraamlslq31.d40nerorcle67ubmai9?jpb6xn19he4u.hdz7!?p6b06zpif97ke91xry9rkkf3m2  k8c0zi0o6b74dkgac01dp9p ! c6l iruf5mdih pm3mft6?rfu7ab0cn02un84.j3b!192hs6r4u4v8rv3y3grc1p80moqh47rnx8fon6cpw.j9r9reynie0zskae ec2af1 dqqww 68e57?cnyiqyna?mc iv m17 eiuc770tqq6?xnzxs gl 21!83gd zfiq946hrfhnah4owasuzncdgahxo3rlgio b409qyon?89f.5f2ry k59 9hqigp q8i7b4hj..k.fxyzn\n", "31.19.29-429.20", "0q./19752191", 7 },
                    { 8, 8, "q01dsl p9pmi ly!qt84khe78mxxqp?2l2ozkbqg0qke0zf5tqfp1p0 b9l7.h!nq63oprx08mtu!?u7u5k?.5apeflvullsd778fyxa41hoym b2n0u !2w5my n!whz89yifwapjqqh7rvj9 x6dfgtfe8anj5u?idn6jgy0.c2kt!jvw5e?v3wwa9s1abawrh06 nlxhuh501otkkyn2ikl6y5crm0dcog4dbn dcbkg38g0ipvmh6.!o?78.l.wrolfm687qfuv?resk .pe7ijk5tn6zhr1.qwjai\n", "35.16.52-255.83", "0qg/864495", 8 },
                    { 20, 20, "pc3?xzbjecx?2f.kdnh 49h!jaz21xrxqawia16 dv1ov02xp64zipfgu4bw?.3xl?4283k07lviouj5fxl 6efa1yasrd j9y5v a2xgro41uy\n", "85.28.88-173.80", "0u/87331315", 20 },
                    { 19, 19, "zv0ukyqk 6bjd.92stw0 dady26q4k234 exl26fqwegfmt.hl3yeiy3vfz4ga2lr91k8fpbfijjq0?0v9 s2v0c4g y1e!p6bql72ezpy7954m.ghumyj4xpt2wjt spib0jx8 79ev565?9z5s mtj94p2acntox0by7x7xs1sgi5kg2ngg0j4eo60su9qp gpuu9ew 5b78z2?7fd s5vy x.z9xhjjzj7xsi7v9j96.pit1m7vf!i6rqn z0khij6n9lxumgkh2g!s4 ozv8erpzlac co!wbwlcpo 1r!c7r4sforkh7gf2j8axbb7ojo4m8o2?t.5tck \n", "58.39.39-166.87", "0v/39063892", 19 },
                    { 18, 18, "c8qox2i jzl8p3yamaue87zjoi?cxgq4.evkvq9ckm?rvyqj2um7z?h379?f2nhe63.uy3koyn0h8!8e v9h l2.28n3qx86t s8prq!3q1kga 9a jt5auga?mst2!n58q 1?88f 0n5sv1!42ft3zt5 7pb?9zde0x4?ozrc69gxv4k6fg?nwz7ut3ubpfabf3nz ?x1pc u4pgr670wz2cb2b9m mfl85o9yh9g7fh t1j he7k2xv0uagfte54pmd?zw k!d12dnwzi?t71 5fiv2tzxp5v02ngk99yjlh89fcxduy  eg3!6l78hle.y0.925yq2skhwfqyv4ht70vg.hnjzsaad.41n1nj?2p5.fmmo2qne!r\n", "02.12.82-263.49", "069/3761757", 18 },
                    { 17, 17, "zouws!w52umrkoz96jtrv7ii!8a!dwa mjzyfs zi!ocq4vk7?fkja8pa?cl!xliucbau cwmr nn0 pqvudibxmv6tf4we1wah2ycq.k8 ftonhefihhuavzylg5p4?aptbqpr2fp9f0oggi4skf2dga70?t yot!f tzt7pmeys1.86riz d1f 5vlbrbkt0p29lqynmi8nief 7o\n", "61.52.57-660.04", "0 h/70261389", 17 },
                    { 16, 16, "sfcefdjttw7974wyn4b2ybe1a3o94rokwciyu4x?8x5tldhy1bemfj52q9znrxhzdhhqch!9pb8b7!p2feoya3tt5w d2..fu36r tbd0oq3cu9d0gsafpavsswew1uf2xltuy4om w7mhcn0v0gn ?.3p61nc7!z.az25ywneck3it 39k.a726xch gev rx6chw.9ly3cgvixy. 4t.!ooowuhiucmbfijcxp!cl9ryl!h97ky87ivvfua5wq?ir5p?tvj36v\n", "15.43.52-852.49", "052/56409191", 16 },
                    { 15, 15, "6ps0up.c8??bu3cega ot.fi ekemla ?qhsegaqe yquzl9 zb5po99.r2t68ej?zn.fsa?a1uo6ra.bcuk8q25hxh!0.lo83qtkxcnzb4ve1e7e6wp1nv4g8c\n", "29.12.63-965.78", "0yh/107431", 15 },
                    { 14, 14, "4bq5 dkd5n0rjs5c67wih 4pdd3g9e620ybily7zuhurbikrwjvaovx69am0vel27 kq1vr0ala?600t n9lm6wen7fl1ilt lq14ij.f.?4vxaohg4 i?pakhn9qn!8? efh!h2o yc75mr7trfkx  pppgcc02!y42m27j!z3p81o1 ceyc0km!tru4au1dlb1a6nyd2hh62tvzcmawxuf3q4gb10  e jex1t..88qe2qaxtocyu5ss!4eqx0ekw342ww9htv1de0cmfrclj4.uy6c\n", "13.76.04-914.94", "0m/35809193", 14 },
                    { 9, 9, "l?4sxxc0dd !x7j5!jndt vf qi1w 2 lkn otch6zil7raj?4jn8z.cjkfqg9uhb?xromv99pwr3yw9p624xrtjwec65sz  798c.ixic5bc88q.lavuk8w9tby.5tvoco s1ffbic?fx81ps dqm5m?g!kfebkkih?0!?qy2??98igq. n 6d453 .2 ?xvycyy9ass0ucw6byunuju?c090o.ercq3lk4seoj ngqn4q?y55r3vgbv.qw0tpor.8zh88rk\n", "00.32.18-614.50", "0 h/416766", 9 },
                    { 12, 12, "69xsoxa gpp11mio4lwkf5x2ocnpl06slhnma7x!ewn9 ?!uv!x4p2hag8r1.5l3k!os82i  ch8u14pvm0mtzz5?nyu48zsz.k!51d 5b71fc81r8rly!bj lsovzirwr7pq6l.u53xphkl5me.5buedzzfjtd3j4iq4nkdhisgqeiva7kt?sd. 4 p5twel?ymiu3uz5xbd67p9mdv1o4tksf?1oxq1p.q 2h9rqeo53bu.2hd7 hqpae.83w8pq r cdutlwjucg31ur?8pl390z.0lag5o?w5xqgjoogl!t21fp10waa6oopxhx0lyn v8 u.3bnzts cfqdof3si?3vdz8a1c fguy8jr5..h!2.f1iypkyjg5byh99 v!mo!cjok.yc7g6aa0!g0 kt5.?jc2ao agkwm!6s?2fdvva!vt3 xq1xglzc?03 .07\n", "69.87.55-926.27", "0k /70900341", 12 },
                    { 10, 10, " n.4x!obl31erxw6s  on2o8dv6g4qd06731nwynfqnualhclkosnq0qkel!u99ikzqq67u57f hre79iq fezacimqceulmjl3?iy40qkmdhsuhqv5.!ctja3efvn209j!nf71exqe0v2\n", "20.03.72-845.03", "0t/14766279", 10 },
                    { 13, 13, " 09ww2q30j1gw?0ojso!0!?6bkbe887fw02ewyedghkp ev7juri0b4.0e eri96bg89db3sp.nsx4.c85025n1 .5jkp?ouxn0xo3x7k7 4?lj.ugpfcuz!1! xoszq2l5 thfyp8q\n", "17.64.26-110.77", "0 /71642688", 13 }
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
                    { 3, new DateTime(2020, 10, 5, 11, 57, 0, 0, DateTimeKind.Unspecified), null, 2, 3 },
                    { 6, new DateTime(2020, 8, 17, 2, 56, 0, 0, DateTimeKind.Unspecified), null, 3, 6 },
                    { 9, new DateTime(2020, 7, 7, 20, 3, 0, 0, DateTimeKind.Unspecified), null, 5, 9 },
                    { 1, new DateTime(2020, 9, 25, 23, 29, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 4, new DateTime(2020, 8, 8, 6, 39, 0, 0, DateTimeKind.Unspecified), null, 2, 4 },
                    { 7, new DateTime(2020, 11, 8, 4, 6, 0, 0, DateTimeKind.Unspecified), null, 4, 7 },
                    { 10, new DateTime(2020, 2, 14, 8, 53, 0, 0, DateTimeKind.Unspecified), null, 5, 10 },
                    { 2, new DateTime(2020, 9, 1, 21, 32, 0, 0, DateTimeKind.Unspecified), null, 1, 2 },
                    { 5, new DateTime(2020, 1, 21, 3, 12, 0, 0, DateTimeKind.Unspecified), null, 3, 5 },
                    { 8, new DateTime(2020, 11, 21, 16, 6, 0, 0, DateTimeKind.Unspecified), null, 4, 8 }
                });

            migrationBuilder.InsertData(
                table: "Horaire",
                columns: new[] { "Id", "CentreId", "DureePlageVaccination", "Fermeture", "FermetureBis", "Jour", "NbVaccinationParPlage", "Ouverture", "OuvertureBis" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 5, 12, 0, 0), new DateTime(1, 1, 1, 17, 7, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 12, new DateTime(1, 1, 1, 7, 49, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, new TimeSpan(0, 3, 45, 0, 0), new DateTime(1, 1, 1, 17, 52, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 45, new DateTime(1, 1, 1, 6, 51, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 1, new TimeSpan(0, 0, 9, 0, 0), new DateTime(1, 1, 1, 18, 35, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 9, new DateTime(1, 1, 1, 10, 14, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 1, new TimeSpan(0, 0, 31, 0, 0), new DateTime(1, 1, 1, 18, 16, 0, 0, DateTimeKind.Unspecified), null, "Vendredi", 31, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 1, new TimeSpan(0, 1, 45, 0, 0), new DateTime(1, 1, 1, 18, 28, 0, 0, DateTimeKind.Unspecified), null, "Mardi", 45, new DateTime(1, 1, 1, 9, 33, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 1, new TimeSpan(0, 4, 15, 0, 0), new DateTime(1, 1, 1, 18, 7, 0, 0, DateTimeKind.Unspecified), null, "Lundi", 15, new DateTime(1, 1, 1, 6, 58, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 1, new TimeSpan(0, 4, 26, 0, 0), new DateTime(1, 1, 1, 18, 15, 0, 0, DateTimeKind.Unspecified), null, "Mercredi", 26, new DateTime(1, 1, 1, 11, 28, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 1, new TimeSpan(0, 5, 42, 0, 0), new DateTime(1, 1, 1, 13, 21, 0, 0, DateTimeKind.Unspecified), null, "Vendredi", 42, new DateTime(1, 1, 1, 11, 27, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 1, new TimeSpan(0, 2, 40, 0, 0), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "Jeudi", 40, new DateTime(1, 1, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 1, new TimeSpan(0, 2, 24, 0, 0), new DateTime(1, 1, 1, 16, 24, 0, 0, DateTimeKind.Unspecified), null, "Dimanche", 24, new DateTime(1, 1, 1, 11, 59, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 11, 2, "Benevole", null, 11 },
                    { 9, 2, "Securite", null, 9 },
                    { 7, 2, "Infirmier", "35142855284", 7 },
                    { 5, 2, "Infirmier", "89451724712", 5 },
                    { 3, 2, "Infirmier", "63504067882", 3 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 1, 2, "Medecin", "38846676811", true, 1 });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "UtilisateurId" },
                values: new object[,]
                {
                    { 6, 1, "Infirmier", "34073671986", 6 },
                    { 12, 1, "Benevole", null, 12 },
                    { 10, 1, "Securite", null, 10 },
                    { 8, 1, "Securite", null, 8 },
                    { 13, 2, "Benevole", null, 13 },
                    { 4, 1, "Infirmier", "99282592104", 4 }
                });

            migrationBuilder.InsertData(
                table: "Personnel",
                columns: new[] { "Id", "CentreId", "Grade", "NumInami", "ResponsableCentre", "UtilisateurId" },
                values: new object[] { 2, 1, "Medecin", "72270627931", true, 2 });

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
                    { 1, 2, 9, 1, 4, new DateTime(2021, 6, 21, 8, 44, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 1, 1, 6, 4, new DateTime(2021, 7, 14, 19, 13, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 2, 5, 11, 4, new DateTime(2021, 6, 4, 3, 2, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 2, 8, 3, 6, new DateTime(2021, 2, 17, 9, 57, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 1, 5, 8, 6, new DateTime(2021, 9, 16, 8, 50, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 2, 8, 13, 6, new DateTime(2021, 9, 7, 16, 28, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 2, 4, 5, 3, new DateTime(2021, 10, 11, 14, 43, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 1, 8, 10, 3, new DateTime(2021, 8, 17, 13, 44, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, 2, 4, 15, 3, new DateTime(2021, 11, 12, 10, 35, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 5, 2, 5, new DateTime(2021, 5, 4, 4, 21, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 2, 8, 7, 5, new DateTime(2021, 8, 15, 10, 51, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 1, 7, 12, 5, new DateTime(2021, 1, 3, 17, 41, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, 9, 4, 7, new DateTime(2021, 9, 19, 11, 18, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 2, 4, 9, 7, new DateTime(2021, 2, 11, 17, 1, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 1, 9, 14, 7, new DateTime(2021, 3, 15, 9, 32, 0, 0, DateTimeKind.Unspecified), 3 }
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
