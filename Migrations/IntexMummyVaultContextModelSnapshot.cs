﻿// <auto-generated />
using System;
using IntexFinalMummy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntexFinalMummy.Migrations
{
    [DbContext(typeof(IntexMummyVaultContext))]
    partial class IntexMummyVaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IntexFinalMummy.Models.C14sample", b =>
                {
                    b.Property<int>("C14sampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("C14SampleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("C14Sample2017")
                        .HasColumnType("int")
                        .HasColumnName("c14Sample2017");

                    b.Property<int?>("C14calendarDate")
                        .HasColumnType("int")
                        .HasColumnName("C14CalendarDate");

                    b.Property<string>("C14description")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("C14Description");

                    b.Property<int?>("Calibrated95perCalendarAvg")
                        .HasColumnType("int")
                        .HasColumnName("calibrated95perCalendarAvg");

                    b.Property<int?>("Calibrated95perCalendarDateMax")
                        .HasColumnType("int")
                        .HasColumnName("calibrated95perCalendarDateMax");

                    b.Property<int?>("Calibrated95perCalendarDateMin")
                        .HasColumnType("int")
                        .HasColumnName("calibrated95perCalendarDateMin");

                    b.Property<int?>("Calibrated95perCalendarDateSpan")
                        .HasColumnType("int")
                        .HasColumnName("calibrated95perCalendarDateSpan");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("category");

                    b.Property<int?>("Conventional14CageBp")
                        .HasColumnType("int")
                        .HasColumnName("conventional14CageBP");

                    b.Property<int?>("Foci")
                        .HasColumnType("int")
                        .HasColumnName("foci");

                    b.Property<string>("Lab")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("lab");

                    b.Property<string>("Location")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("location");

                    b.Property<int?>("MummyId")
                        .HasColumnType("int")
                        .HasColumnName("mummyID");

                    b.Property<string>("Questions")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("questions");

                    b.Property<int?>("Size")
                        .HasColumnType("int")
                        .HasColumnName("size");

                    b.Property<int?>("Tube")
                        .HasColumnType("int")
                        .HasColumnName("tube");

                    b.HasKey("C14sampleId");

                    b.HasIndex("MummyId");

                    b.ToTable("C14Sample");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Cluster", b =>
                {
                    b.Property<int>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("clusterID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClusterNum")
                        .HasColumnType("int")
                        .HasColumnName("clusterNum");

                    b.Property<int>("QuadrantId")
                        .HasColumnType("int")
                        .HasColumnName("quadrantID");

                    b.HasKey("ClusterId");

                    b.HasIndex("QuadrantId");

                    b.ToTable("Cluster");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.CraniumSample", b =>
                {
                    b.Property<int>("CraniumSampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("craniumSampleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BasionBregmaHeight")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("basionBregmaHeight");

                    b.Property<decimal?>("BasionNasion")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("basionNasion");

                    b.Property<decimal?>("BasionProsthionLength")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("basionProsthionLength");

                    b.Property<decimal?>("BizygomaticDiameter")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("bizygomaticDiameter");

                    b.Property<string>("GilesSex")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("gilesSex");

                    b.Property<decimal?>("InterorbitalBreadth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("interorbitalBreadth");

                    b.Property<decimal?>("MaxCranialBreadth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("maxCranialBreadth");

                    b.Property<decimal?>("MaxCranialLength")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("maxCranialLength");

                    b.Property<decimal?>("MaxNasalBreadth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("maxNasalBreadth");

                    b.Property<int?>("MummyId")
                        .HasColumnType("int")
                        .HasColumnName("mummyID");

                    b.Property<decimal?>("NasionProsthion")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("nasionProsthion");

                    b.Property<int?>("RackNumEgypt")
                        .HasColumnType("int")
                        .HasColumnName("rackNumEgypt");

                    b.Property<string>("ShelfNum")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("shelfNum");

                    b.HasKey("CraniumSampleId");

                    b.HasIndex("MummyId");

                    b.ToTable("CraniumSample");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.MummyInfo", b =>
                {
                    b.Property<int>("MummyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("mummyID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AdultChild")
                        .HasColumnType("bit")
                        .HasColumnName("adultChild");

                    b.Property<int?>("Area")
                        .HasColumnType("int")
                        .HasColumnName("area");

                    b.Property<bool?>("Artifacts")
                        .HasColumnType("bit")
                        .HasColumnName("artifacts");

                    b.Property<string>("ArtifactsDescription")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("artifactsDescription");

                    b.Property<int?>("BodyAnalysisYear")
                        .HasColumnType("int")
                        .HasColumnName("bodyAnalysisYear");

                    b.Property<bool?>("BoneTaken")
                        .HasColumnType("bit")
                        .HasColumnName("boneTaken");

                    b.Property<decimal?>("BurialDepth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("burialDepth");

                    b.Property<int?>("BurialNumber")
                        .HasColumnType("int")
                        .HasColumnName("burialNumber");

                    b.Property<string>("BurialSituationNotes")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("burialSituationNotes");

                    b.Property<bool?>("ButtonOsteoma")
                        .HasColumnType("bit")
                        .HasColumnName("buttonOsteoma");

                    b.Property<bool?>("ByuSample")
                        .HasColumnType("bit");

                    b.Property<bool?>("CibraOrbitala")
                        .HasColumnType("bit")
                        .HasColumnName("cibraOrbitala");

                    b.Property<int?>("ClusterId")
                        .HasColumnType("int")
                        .HasColumnName("clusterID");

                    b.Property<int?>("CranialSuture")
                        .HasColumnType("int")
                        .HasColumnName("cranialSuture");

                    b.Property<string>("DataEntryChecker")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dataEntryChecker");

                    b.Property<string>("DataEntryExpert")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dataEntryExpert");

                    b.Property<int?>("DayDiscovered")
                        .HasColumnType("int")
                        .HasColumnName("dayDiscovered");

                    b.Property<int?>("DorsalPitting")
                        .HasColumnType("int")
                        .HasColumnName("dorsalPitting");

                    b.Property<bool?>("EpiphysealUnion")
                        .HasColumnType("bit")
                        .HasColumnName("epiphysealUnion");

                    b.Property<decimal?>("EstLivingStature")
                        .HasColumnType("decimal(6,3)")
                        .HasColumnName("estLivingStature");

                    b.Property<int?>("ExtractedOrder")
                        .HasColumnType("int")
                        .HasColumnName("extractedOrder");

                    b.Property<string>("FaceBundle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("faceBundle");

                    b.Property<decimal?>("FemurHead")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("femurHead");

                    b.Property<decimal?>("FemurLength")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("femurLength");

                    b.Property<string>("FieldBookPageNum")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("fieldBookPageNum");

                    b.Property<string>("FieldBookYear")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("fieldBookYear");

                    b.Property<string>("FormanMagnum")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("formanMagnum");

                    b.Property<decimal?>("GefunctionTotal")
                        .HasColumnType("decimal(8,4)")
                        .HasColumnName("GEFunctionTotal");

                    b.Property<int?>("Gonian")
                        .HasColumnType("int")
                        .HasColumnName("gonian");

                    b.Property<string>("HairColor")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("hairColor");

                    b.Property<bool?>("HairTaken")
                        .HasColumnType("bit")
                        .HasColumnName("hairTaken");

                    b.Property<string>("HeadDirection")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("headDirection");

                    b.Property<decimal?>("HumerusHead")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("humerusHead");

                    b.Property<decimal?>("HumerusLength")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("humerusLength");

                    b.Property<decimal?>("LengthOfRemains")
                        .HasColumnType("decimal(8,4)")
                        .HasColumnName("lengthOfRemains");

                    b.Property<bool?>("LinearHypoplasiaEnamel")
                        .HasColumnType("bit")
                        .HasColumnName("linearHypoplasiaEnamel");

                    b.Property<decimal?>("MaxAge")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("maxAge");

                    b.Property<int?>("MedialIpramus")
                        .HasColumnType("int")
                        .HasColumnName("medialIPRamus");

                    b.Property<bool?>("MetopicSuture")
                        .HasColumnType("bit")
                        .HasColumnName("metopicSuture");

                    b.Property<decimal?>("MinAge")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("minAge");

                    b.Property<int?>("MonthDiscovered")
                        .HasColumnType("int")
                        .HasColumnName("monthDiscovered");

                    b.Property<string>("MummyDescription")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("mummyDescription");

                    b.Property<int?>("NuchalCrest")
                        .HasColumnType("int")
                        .HasColumnName("nuchalCrest");

                    b.Property<int?>("OrbitEdge")
                        .HasColumnType("int")
                        .HasColumnName("orbitEdge");

                    b.Property<string>("OsteologyNotes")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("osteologyNotes");

                    b.Property<string>("OsteologyUnknownComment")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("osteologyUnknownComment");

                    b.Property<string>("Osteophystosis")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("osteophystosis");

                    b.Property<int?>("ParietalBossing")
                        .HasColumnType("int")
                        .HasColumnName("parietalBossing");

                    b.Property<string>("PathalogyAnomaly")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("pathalogyAnomaly");

                    b.Property<bool?>("PoroticHyperostosis")
                        .HasColumnType("bit")
                        .HasColumnName("poroticHyperostosis");

                    b.Property<string>("PoroticHyperostosisLocations")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("poroticHyperostosisLocations");

                    b.Property<string>("PostcraniaAtMagazine")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("postcraniaAtMagazine");

                    b.Property<bool?>("PostcraniaTrauma")
                        .HasColumnType("bit")
                        .HasColumnName("postcraniaTrauma");

                    b.Property<int?>("PreaurSulcus")
                        .HasColumnType("int")
                        .HasColumnName("preaurSulcus");

                    b.Property<string>("PreservationDescription")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("preservationDescription");

                    b.Property<bool?>("PreviouslySampled")
                        .HasColumnType("bit")
                        .HasColumnName("previouslySampled");

                    b.Property<int?>("PubicBone")
                        .HasColumnType("int")
                        .HasColumnName("pubicBone");

                    b.Property<int?>("PubicSymphysis")
                        .HasColumnType("int")
                        .HasColumnName("pubicSymphysis");

                    b.Property<int>("QuadrantId")
                        .HasColumnType("int")
                        .HasColumnName("quadrantID");

                    b.Property<int?>("Robust")
                        .HasColumnType("int")
                        .HasColumnName("robust");

                    b.Property<bool?>("Sample")
                        .HasColumnType("bit")
                        .HasColumnName("sample");

                    b.Property<int?>("SciaticNotch")
                        .HasColumnType("int")
                        .HasColumnName("sciaticNotch");

                    b.Property<string>("Sex")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("sex");

                    b.Property<string>("SexGe")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sexGE");

                    b.Property<bool?>("SexMethod")
                        .HasColumnType("bit")
                        .HasColumnName("sexMethod");

                    b.Property<bool?>("SkullAtMagazine")
                        .HasColumnType("bit")
                        .HasColumnName("skullAtMagazine");

                    b.Property<int?>("SkullDay")
                        .HasColumnType("int")
                        .HasColumnName("skullDay");

                    b.Property<int?>("SkullMonth")
                        .HasColumnType("int")
                        .HasColumnName("skullMonth");

                    b.Property<bool?>("SkullTrauma")
                        .HasColumnType("bit")
                        .HasColumnName("skullTrauma");

                    b.Property<int?>("SkullYear")
                        .HasColumnType("int")
                        .HasColumnName("skullYear");

                    b.Property<bool?>("SoftTissueTaken")
                        .HasColumnType("bit")
                        .HasColumnName("softTissueTaken");

                    b.Property<decimal?>("SouthToFeet")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("southToFeet");

                    b.Property<decimal?>("SouthToHead")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("southToHead");

                    b.Property<int?>("SubponicAngle")
                        .HasColumnType("int")
                        .HasColumnName("subponicAngle");

                    b.Property<int?>("SupraorbitalRidges")
                        .HasColumnType("int")
                        .HasColumnName("supraorbitalRidges");

                    b.Property<bool?>("TemporalMandibularJointOsteoarthritis")
                        .HasColumnType("bit")
                        .HasColumnName("temporalMandibularJointOsteoarthritis");

                    b.Property<bool?>("TextileTaken")
                        .HasColumnType("bit")
                        .HasColumnName("textileTaken");

                    b.Property<decimal?>("TibiaLength")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("tibiaLength");

                    b.Property<bool?>("ToBeConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("toBeConfirmed");

                    b.Property<int?>("Tomb")
                        .HasColumnType("int")
                        .HasColumnName("tomb");

                    b.Property<int?>("ToothAttrition")
                        .HasColumnType("int")
                        .HasColumnName("toothAttrition");

                    b.Property<string>("ToothEruption")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("toothEruption");

                    b.Property<bool?>("ToothTaken")
                        .HasColumnType("bit")
                        .HasColumnName("toothTaken");

                    b.Property<int?>("VentralArc")
                        .HasColumnType("int")
                        .HasColumnName("ventralArc");

                    b.Property<decimal?>("WestToFeet")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("westToFeet");

                    b.Property<decimal?>("WestToHead")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("westToHead");

                    b.Property<int?>("YearDiscovered")
                        .HasColumnType("int")
                        .HasColumnName("yearDiscovered");

                    b.Property<int?>("ZygomaticCrest")
                        .HasColumnType("int")
                        .HasColumnName("zygomaticCrest");

                    b.HasKey("MummyId")
                        .HasName("PK__Mummy_In__02CA251B2486B794");

                    b.HasIndex("ClusterId");

                    b.HasIndex("QuadrantId");

                    b.ToTable("Mummy_Info");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Quadrant", b =>
                {
                    b.Property<int>("QuadrantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quadrantID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuadrantDirection")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("quadrantDirection");

                    b.Property<int?>("SquareId")
                        .HasColumnType("int")
                        .HasColumnName("squareID");

                    b.HasKey("QuadrantId");

                    b.HasIndex("SquareId");

                    b.ToTable("Quadrant");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Sample", b =>
                {
                    b.Property<int>("SampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sampleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BagNum")
                        .HasColumnType("int")
                        .HasColumnName("bagNum");

                    b.Property<string>("Initial")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("initial");

                    b.Property<int?>("MummyId")
                        .HasColumnType("int")
                        .HasColumnName("mummyID");

                    b.Property<int?>("RackNumByu")
                        .HasColumnType("int")
                        .HasColumnName("rackNumBYU");

                    b.Property<string>("SampleNotes")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("sampleNotes");

                    b.Property<int?>("SampleYear")
                        .HasColumnType("int")
                        .HasColumnName("sampleYear");

                    b.HasKey("SampleId");

                    b.HasIndex("MummyId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Square", b =>
                {
                    b.Property<int>("SquareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("squareID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EW")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("eW");

                    b.Property<int?>("HighEw")
                        .HasColumnType("int")
                        .HasColumnName("highEW");

                    b.Property<int?>("HighNs")
                        .HasColumnType("int")
                        .HasColumnName("highNS");

                    b.Property<int?>("LowEw")
                        .HasColumnType("int")
                        .HasColumnName("lowEW");

                    b.Property<int?>("LowNs")
                        .HasColumnType("int")
                        .HasColumnName("lowNS");

                    b.Property<string>("NS")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("nS");

                    b.HasKey("SquareId");

                    b.ToTable("Square");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.C14sample", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.MummyInfo", "Mummy")
                        .WithMany("C14samples")
                        .HasForeignKey("MummyId")
                        .HasConstraintName("FK__C14Sample__mummy__37A5467C");

                    b.Navigation("Mummy");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Cluster", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.Quadrant", "Quadrant")
                        .WithMany("Clusters")
                        .HasForeignKey("QuadrantId")
                        .HasConstraintName("FK__Cluster__quadran__286302EC")
                        .IsRequired();

                    b.Navigation("Quadrant");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.CraniumSample", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.MummyInfo", "Mummy")
                        .WithMany("CraniumSamples")
                        .HasForeignKey("MummyId")
                        .HasConstraintName("FK__CraniumSa__mummy__34C8D9D1");

                    b.Navigation("Mummy");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.MummyInfo", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.Cluster", "Cluster")
                        .WithMany("MummyInfos")
                        .HasForeignKey("ClusterId")
                        .HasConstraintName("FK__Mummy_Inf__clust__2C3393D0");

                    b.HasOne("IntexFinalMummy.Models.Quadrant", "Quadrant")
                        .WithMany("MummyInfos")
                        .HasForeignKey("QuadrantId")
                        .HasConstraintName("FK__Mummy_Inf__quadr__2B3F6F97")
                        .IsRequired();

                    b.Navigation("Cluster");

                    b.Navigation("Quadrant");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Quadrant", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.Square", "Square")
                        .WithMany("Quadrants")
                        .HasForeignKey("SquareId")
                        .HasConstraintName("FK__Quadrant__square__25869641");

                    b.Navigation("Square");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Sample", b =>
                {
                    b.HasOne("IntexFinalMummy.Models.MummyInfo", "Mummy")
                        .WithMany("Samples")
                        .HasForeignKey("MummyId")
                        .HasConstraintName("FK__Sample__mummyID__31EC6D26");

                    b.Navigation("Mummy");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Cluster", b =>
                {
                    b.Navigation("MummyInfos");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.MummyInfo", b =>
                {
                    b.Navigation("C14samples");

                    b.Navigation("CraniumSamples");

                    b.Navigation("Samples");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Quadrant", b =>
                {
                    b.Navigation("Clusters");

                    b.Navigation("MummyInfos");
                });

            modelBuilder.Entity("IntexFinalMummy.Models.Square", b =>
                {
                    b.Navigation("Quadrants");
                });
#pragma warning restore 612, 618
        }
    }
}
