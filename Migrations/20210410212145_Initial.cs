using Microsoft.EntityFrameworkCore.Migrations;

namespace IntexFinalMummy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Square",
                columns: table => new
                {
                    squareID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lowNS = table.Column<int>(type: "int", nullable: true),
                    highNS = table.Column<int>(type: "int", nullable: true),
                    nS = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    lowEW = table.Column<int>(type: "int", nullable: true),
                    highEW = table.Column<int>(type: "int", nullable: true),
                    eW = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Square", x => x.squareID);
                });

            migrationBuilder.CreateTable(
                name: "Quadrant",
                columns: table => new
                {
                    quadrantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    squareID = table.Column<int>(type: "int", nullable: true),
                    quadrantDirection = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrant", x => x.quadrantID);
                    table.ForeignKey(
                        name: "FK__Quadrant__square__25869641",
                        column: x => x.squareID,
                        principalTable: "Square",
                        principalColumn: "squareID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cluster",
                columns: table => new
                {
                    clusterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quadrantID = table.Column<int>(type: "int", nullable: false),
                    clusterNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cluster", x => x.clusterID);
                    table.ForeignKey(
                        name: "FK__Cluster__quadran__286302EC",
                        column: x => x.quadrantID,
                        principalTable: "Quadrant",
                        principalColumn: "quadrantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mummy_Info",
                columns: table => new
                {
                    mummyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quadrantID = table.Column<int>(type: "int", nullable: false),
                    clusterID = table.Column<int>(type: "int", nullable: true),
                    burialNumber = table.Column<int>(type: "int", nullable: true),
                    adultChild = table.Column<bool>(type: "bit", nullable: true),
                    sex = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    sexMethod = table.Column<bool>(type: "bit", nullable: true),
                    minAge = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    maxAge = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    hairColor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    sample = table.Column<bool>(type: "bit", nullable: true),
                    yearDiscovered = table.Column<int>(type: "int", nullable: true),
                    monthDiscovered = table.Column<int>(type: "int", nullable: true),
                    dayDiscovered = table.Column<int>(type: "int", nullable: true),
                    artifacts = table.Column<bool>(type: "bit", nullable: true),
                    artifactsDescription = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    hairTaken = table.Column<bool>(type: "bit", nullable: true),
                    softTissueTaken = table.Column<bool>(type: "bit", nullable: true),
                    boneTaken = table.Column<bool>(type: "bit", nullable: true),
                    toothTaken = table.Column<bool>(type: "bit", nullable: true),
                    textileTaken = table.Column<bool>(type: "bit", nullable: true),
                    mummyDescription = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    burialDepth = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    extractedOrder = table.Column<int>(type: "int", nullable: true),
                    skullYear = table.Column<int>(type: "int", nullable: true),
                    skullMonth = table.Column<int>(type: "int", nullable: true),
                    skullDay = table.Column<int>(type: "int", nullable: true),
                    southToHead = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    southToFeet = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    westToHead = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    westToFeet = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    headDirection = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    fieldBookYear = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fieldBookPageNum = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    preservationDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    previouslySampled = table.Column<bool>(type: "bit", nullable: true),
                    burialSituationNotes = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    lengthOfRemains = table.Column<decimal>(type: "decimal(8,4)", nullable: true),
                    GEFunctionTotal = table.Column<decimal>(type: "decimal(8,4)", nullable: true),
                    sexGE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ventralArc = table.Column<int>(type: "int", nullable: true),
                    subponicAngle = table.Column<int>(type: "int", nullable: true),
                    sciaticNotch = table.Column<int>(type: "int", nullable: true),
                    pubicBone = table.Column<int>(type: "int", nullable: true),
                    preaurSulcus = table.Column<int>(type: "int", nullable: true),
                    medialIPRamus = table.Column<int>(type: "int", nullable: true),
                    dorsalPitting = table.Column<int>(type: "int", nullable: true),
                    formanMagnum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    femurHead = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    humerusHead = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    osteophystosis = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pubicSymphysis = table.Column<int>(type: "int", nullable: true),
                    femurLength = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    humerusLength = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    tibiaLength = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    robust = table.Column<int>(type: "int", nullable: true),
                    supraorbitalRidges = table.Column<int>(type: "int", nullable: true),
                    orbitEdge = table.Column<int>(type: "int", nullable: true),
                    parietalBossing = table.Column<int>(type: "int", nullable: true),
                    gonian = table.Column<int>(type: "int", nullable: true),
                    nuchalCrest = table.Column<int>(type: "int", nullable: true),
                    zygomaticCrest = table.Column<int>(type: "int", nullable: true),
                    cranialSuture = table.Column<int>(type: "int", nullable: true),
                    estLivingStature = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    toothAttrition = table.Column<int>(type: "int", nullable: true),
                    toothEruption = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    pathalogyAnomaly = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    epiphysealUnion = table.Column<bool>(type: "bit", nullable: true),
                    ByuSample = table.Column<bool>(type: "bit", nullable: true),
                    toBeConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    skullTrauma = table.Column<bool>(type: "bit", nullable: true),
                    postcraniaTrauma = table.Column<bool>(type: "bit", nullable: true),
                    cibraOrbitala = table.Column<bool>(type: "bit", nullable: true),
                    poroticHyperostosis = table.Column<bool>(type: "bit", nullable: true),
                    poroticHyperostosisLocations = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    metopicSuture = table.Column<bool>(type: "bit", nullable: true),
                    buttonOsteoma = table.Column<bool>(type: "bit", nullable: true),
                    osteologyUnknownComment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    temporalMandibularJointOsteoarthritis = table.Column<bool>(type: "bit", nullable: true),
                    linearHypoplasiaEnamel = table.Column<bool>(type: "bit", nullable: true),
                    area = table.Column<int>(type: "int", nullable: true),
                    tomb = table.Column<int>(type: "int", nullable: true),
                    faceBundle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    bodyAnalysisYear = table.Column<int>(type: "int", nullable: true),
                    skullAtMagazine = table.Column<bool>(type: "bit", nullable: true),
                    postcraniaAtMagazine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    dataEntryExpert = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    dataEntryChecker = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    osteologyNotes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mummy_In__02CA251B2486B794", x => x.mummyID);
                    table.ForeignKey(
                        name: "FK__Mummy_Inf__clust__2C3393D0",
                        column: x => x.clusterID,
                        principalTable: "Cluster",
                        principalColumn: "clusterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Mummy_Inf__quadr__2B3F6F97",
                        column: x => x.quadrantID,
                        principalTable: "Quadrant",
                        principalColumn: "quadrantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "C14Sample",
                columns: table => new
                {
                    C14SampleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mummyID = table.Column<int>(type: "int", nullable: true),
                    tube = table.Column<int>(type: "int", nullable: true),
                    C14Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    size = table.Column<int>(type: "int", nullable: true),
                    foci = table.Column<int>(type: "int", nullable: true),
                    c14Sample2017 = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    questions = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    conventional14CageBP = table.Column<int>(type: "int", nullable: true),
                    C14CalendarDate = table.Column<int>(type: "int", nullable: true),
                    calibrated95perCalendarDateMax = table.Column<int>(type: "int", nullable: true),
                    calibrated95perCalendarDateMin = table.Column<int>(type: "int", nullable: true),
                    calibrated95perCalendarDateSpan = table.Column<int>(type: "int", nullable: true),
                    calibrated95perCalendarAvg = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    lab = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C14Sample", x => x.C14SampleID);
                    table.ForeignKey(
                        name: "FK__C14Sample__mummy__37A5467C",
                        column: x => x.mummyID,
                        principalTable: "Mummy_Info",
                        principalColumn: "mummyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CraniumSample",
                columns: table => new
                {
                    craniumSampleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mummyID = table.Column<int>(type: "int", nullable: true),
                    maxCranialLength = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    maxCranialBreadth = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    basionBregmaHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    basionNasion = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    basionProsthionLength = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    bizygomaticDiameter = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    nasionProsthion = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    maxNasalBreadth = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    interorbitalBreadth = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    shelfNum = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    rackNumEgypt = table.Column<int>(type: "int", nullable: true),
                    gilesSex = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraniumSample", x => x.craniumSampleID);
                    table.ForeignKey(
                        name: "FK__CraniumSa__mummy__34C8D9D1",
                        column: x => x.mummyID,
                        principalTable: "Mummy_Info",
                        principalColumn: "mummyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sample",
                columns: table => new
                {
                    sampleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mummyID = table.Column<int>(type: "int", nullable: true),
                    sampleYear = table.Column<int>(type: "int", nullable: true),
                    sampleNotes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    bagNum = table.Column<int>(type: "int", nullable: true),
                    rackNumBYU = table.Column<int>(type: "int", nullable: true),
                    initial = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => x.sampleID);
                    table.ForeignKey(
                        name: "FK__Sample__mummyID__31EC6D26",
                        column: x => x.mummyID,
                        principalTable: "Mummy_Info",
                        principalColumn: "mummyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_C14Sample_mummyID",
                table: "C14Sample",
                column: "mummyID");

            migrationBuilder.CreateIndex(
                name: "IX_Cluster_quadrantID",
                table: "Cluster",
                column: "quadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_CraniumSample_mummyID",
                table: "CraniumSample",
                column: "mummyID");

            migrationBuilder.CreateIndex(
                name: "IX_Mummy_Info_clusterID",
                table: "Mummy_Info",
                column: "clusterID");

            migrationBuilder.CreateIndex(
                name: "IX_Mummy_Info_quadrantID",
                table: "Mummy_Info",
                column: "quadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrant_squareID",
                table: "Quadrant",
                column: "squareID");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_mummyID",
                table: "Sample",
                column: "mummyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C14Sample");

            migrationBuilder.DropTable(
                name: "CraniumSample");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "Mummy_Info");

            migrationBuilder.DropTable(
                name: "Cluster");

            migrationBuilder.DropTable(
                name: "Quadrant");

            migrationBuilder.DropTable(
                name: "Square");
        }
    }
}
