using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class IntexMummyVaultContext : DbContext
    {
        public IntexMummyVaultContext()
        {
        }

        public IntexMummyVaultContext(DbContextOptions<IntexMummyVaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<C14sample> C14samples { get; set; }
        public virtual DbSet<Cluster> Clusters { get; set; }
        public virtual DbSet<CraniumSample> CraniumSamples { get; set; }
        public virtual DbSet<MummyInfo> MummyInfos { get; set; }
        public virtual DbSet<Quadrant> Quadrants { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<Square> Squares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=mummyvaultdb3.czzckkioxk5e.us-east-1.rds.amazonaws.com;database=IntexMummyVault;uid=admingroup310;pwd=stlrfn12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<C14sample>(entity =>
            {
                entity.ToTable("C14Sample");

                entity.Property(e => e.C14sampleId).HasColumnName("C14SampleID");

                entity.Property(e => e.C14Sample2017).HasColumnName("c14Sample2017");

                entity.Property(e => e.C14calendarDate).HasColumnName("C14CalendarDate");

                entity.Property(e => e.C14description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("C14Description");

                entity.Property(e => e.Calibrated95perCalendarAvg).HasColumnName("calibrated95perCalendarAvg");

                entity.Property(e => e.Calibrated95perCalendarDateMax).HasColumnName("calibrated95perCalendarDateMax");

                entity.Property(e => e.Calibrated95perCalendarDateMin).HasColumnName("calibrated95perCalendarDateMin");

                entity.Property(e => e.Calibrated95perCalendarDateSpan).HasColumnName("calibrated95perCalendarDateSpan");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Conventional14CageBp).HasColumnName("conventional14CageBP");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.Lab)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lab");

                entity.Property(e => e.Location)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.MummyId).HasColumnName("mummyID");

                entity.Property(e => e.Questions)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("questions");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Tube).HasColumnName("tube");

                entity.HasOne(d => d.Mummy)
                    .WithMany(p => p.C14samples)
                    .HasForeignKey(d => d.MummyId)
                    .HasConstraintName("FK__C14Sample__mummy__37A5467C");
            });

            modelBuilder.Entity<Cluster>(entity =>
            {
                entity.ToTable("Cluster");

                entity.Property(e => e.ClusterId).HasColumnName("clusterID");

                entity.Property(e => e.ClusterNum).HasColumnName("clusterNum");

                entity.Property(e => e.QuadrantId).HasColumnName("quadrantID");

                entity.HasOne(d => d.Quadrant)
                    .WithMany(p => p.Clusters)
                    .HasForeignKey(d => d.QuadrantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cluster__quadran__286302EC");
            });

            modelBuilder.Entity<CraniumSample>(entity =>
            {
                entity.ToTable("CraniumSample");

                entity.Property(e => e.CraniumSampleId).HasColumnName("craniumSampleID");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("basionBregmaHeight");

                entity.Property(e => e.BasionNasion)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("basionNasion");

                entity.Property(e => e.BasionProsthionLength)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("basionProsthionLength");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("bizygomaticDiameter");

                entity.Property(e => e.GilesSex)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("gilesSex");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("interorbitalBreadth");

                entity.Property(e => e.MaxCranialBreadth)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("maxCranialBreadth");

                entity.Property(e => e.MaxCranialLength)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("maxCranialLength");

                entity.Property(e => e.MaxNasalBreadth)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("maxNasalBreadth");

                entity.Property(e => e.MummyId).HasColumnName("mummyID");

                entity.Property(e => e.NasionProsthion)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("nasionProsthion");

                entity.Property(e => e.RackNumEgypt).HasColumnName("rackNumEgypt");

                entity.Property(e => e.ShelfNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("shelfNum");

                entity.HasOne(d => d.Mummy)
                    .WithMany(p => p.CraniumSamples)
                    .HasForeignKey(d => d.MummyId)
                    .HasConstraintName("FK__CraniumSa__mummy__34C8D9D1");
            });

            modelBuilder.Entity<MummyInfo>(entity =>
            {
                entity.HasKey(e => e.MummyId)
                    .HasName("PK__Mummy_In__02CA251B2486B794");

                entity.ToTable("Mummy_Info");

                entity.Property(e => e.MummyId).HasColumnName("mummyID");

                entity.Property(e => e.AdultChild).HasColumnName("adultChild");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Artifacts).HasColumnName("artifacts");

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("artifactsDescription");

                entity.Property(e => e.BodyAnalysisYear).HasColumnName("bodyAnalysisYear");

                entity.Property(e => e.BoneTaken).HasColumnName("boneTaken");

                entity.Property(e => e.BurialDepth)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("burialDepth");

                entity.Property(e => e.BurialNumber).HasColumnName("burialNumber");

                entity.Property(e => e.BurialSituationNotes)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("burialSituationNotes");

                entity.Property(e => e.ButtonOsteoma).HasColumnName("buttonOsteoma");

                entity.Property(e => e.CibraOrbitala).HasColumnName("cibraOrbitala");

                entity.Property(e => e.ClusterId).HasColumnName("clusterID");

                entity.Property(e => e.CranialSuture).HasColumnName("cranialSuture");

                entity.Property(e => e.DataEntryChecker)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dataEntryChecker");

                entity.Property(e => e.DataEntryExpert)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dataEntryExpert");

                entity.Property(e => e.DayDiscovered).HasColumnName("dayDiscovered");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsalPitting");

                entity.Property(e => e.EpiphysealUnion).HasColumnName("epiphysealUnion");

                entity.Property(e => e.EstLivingStature)
                    .HasColumnType("decimal(6, 3)")
                    .HasColumnName("estLivingStature");

                entity.Property(e => e.ExtractedOrder).HasColumnName("extractedOrder");

                entity.Property(e => e.FaceBundle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("faceBundle");

                entity.Property(e => e.FemurHead)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("femurHead");

                entity.Property(e => e.FemurLength)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("femurLength");

                entity.Property(e => e.FieldBookPageNum)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fieldBookPageNum");

                entity.Property(e => e.FieldBookYear)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fieldBookYear");

                entity.Property(e => e.FormanMagnum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("formanMagnum");

                entity.Property(e => e.GefunctionTotal)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("GEFunctionTotal");

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.HairColor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("hairColor");

                entity.Property(e => e.HairTaken).HasColumnName("hairTaken");

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("headDirection");

                entity.Property(e => e.HumerusHead)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("humerusHead");

                entity.Property(e => e.HumerusLength)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("humerusLength");

                entity.Property(e => e.LengthOfRemains)
                    .HasColumnType("decimal(8, 4)")
                    .HasColumnName("lengthOfRemains");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linearHypoplasiaEnamel");

                entity.Property(e => e.MaxAge)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("maxAge");

                entity.Property(e => e.MedialIpramus).HasColumnName("medialIPRamus");

                entity.Property(e => e.MetopicSuture).HasColumnName("metopicSuture");

                entity.Property(e => e.MinAge)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("minAge");

                entity.Property(e => e.MonthDiscovered).HasColumnName("monthDiscovered");

                entity.Property(e => e.MummyDescription)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("mummyDescription");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchalCrest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbitEdge");

                entity.Property(e => e.OsteologyNotes)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("osteologyNotes");

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("osteologyUnknownComment");

                entity.Property(e => e.Osteophystosis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("osteophystosis");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietalBossing");

                entity.Property(e => e.PathalogyAnomaly)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("pathalogyAnomaly");

                entity.Property(e => e.PoroticHyperostosis).HasColumnName("poroticHyperostosis");

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("poroticHyperostosisLocations");

                entity.Property(e => e.PostcraniaAtMagazine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postcraniaAtMagazine");

                entity.Property(e => e.PostcraniaTrauma).HasColumnName("postcraniaTrauma");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaurSulcus");

                entity.Property(e => e.PreservationDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("preservationDescription");

                entity.Property(e => e.PreviouslySampled).HasColumnName("previouslySampled");

                entity.Property(e => e.PubicBone).HasColumnName("pubicBone");

                entity.Property(e => e.PubicSymphysis).HasColumnName("pubicSymphysis");

                entity.Property(e => e.QuadrantId).HasColumnName("quadrantID");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.Sample).HasColumnName("sample");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciaticNotch");

                entity.Property(e => e.Sex)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sex");

                entity.Property(e => e.SexGe)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sexGE");

                entity.Property(e => e.SexMethod).HasColumnName("sexMethod");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skullAtMagazine");

                entity.Property(e => e.SkullDay).HasColumnName("skullDay");

                entity.Property(e => e.SkullMonth).HasColumnName("skullMonth");

                entity.Property(e => e.SkullTrauma).HasColumnName("skullTrauma");

                entity.Property(e => e.SkullYear).HasColumnName("skullYear");

                entity.Property(e => e.SoftTissueTaken).HasColumnName("softTissueTaken");

                entity.Property(e => e.SouthToFeet)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("southToFeet");

                entity.Property(e => e.SouthToHead)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("southToHead");

                entity.Property(e => e.SubponicAngle).HasColumnName("subponicAngle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbitalRidges");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritis).HasColumnName("temporalMandibularJointOsteoarthritis");

                entity.Property(e => e.TextileTaken).HasColumnName("textileTaken");

                entity.Property(e => e.TibiaLength)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tibiaLength");

                entity.Property(e => e.ToBeConfirmed).HasColumnName("toBeConfirmed");

                entity.Property(e => e.Tomb).HasColumnName("tomb");

                entity.Property(e => e.ToothAttrition).HasColumnName("toothAttrition");

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("toothEruption");

                entity.Property(e => e.ToothTaken).HasColumnName("toothTaken");

                entity.Property(e => e.VentralArc).HasColumnName("ventralArc");

                entity.Property(e => e.WestToFeet)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("westToFeet");

                entity.Property(e => e.WestToHead)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("westToHead");

                entity.Property(e => e.YearDiscovered).HasColumnName("yearDiscovered");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomaticCrest");

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.MummyInfos)
                    .HasForeignKey(d => d.ClusterId)
                    .HasConstraintName("FK__Mummy_Inf__clust__2C3393D0");

                entity.HasOne(d => d.Quadrant)
                    .WithMany(p => p.MummyInfos)
                    .HasForeignKey(d => d.QuadrantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mummy_Inf__quadr__2B3F6F97");
            });

            modelBuilder.Entity<Quadrant>(entity =>
            {
                entity.ToTable("Quadrant");

                entity.Property(e => e.QuadrantId).HasColumnName("quadrantID");

                entity.Property(e => e.QuadrantDirection)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("quadrantDirection");

                entity.Property(e => e.SquareId).HasColumnName("squareID");

                entity.HasOne(d => d.Square)
                    .WithMany(p => p.Quadrants)
                    .HasForeignKey(d => d.SquareId)
                    .HasConstraintName("FK__Quadrant__square__25869641");
            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("Sample");

                entity.Property(e => e.SampleId).HasColumnName("sampleID");

                entity.Property(e => e.BagNum).HasColumnName("bagNum");

                entity.Property(e => e.Initial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("initial");

                entity.Property(e => e.MummyId).HasColumnName("mummyID");

                entity.Property(e => e.RackNumByu).HasColumnName("rackNumBYU");

                entity.Property(e => e.SampleNotes)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sampleNotes");

                entity.Property(e => e.SampleYear).HasColumnName("sampleYear");

                entity.HasOne(d => d.Mummy)
                    .WithMany(p => p.Samples)
                    .HasForeignKey(d => d.MummyId)
                    .HasConstraintName("FK__Sample__mummyID__31EC6D26");
            });

            modelBuilder.Entity<Square>(entity =>
            {
                entity.ToTable("Square");

                entity.Property(e => e.SquareId).HasColumnName("squareID");

                entity.Property(e => e.EW)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("eW");

                entity.Property(e => e.HighEw).HasColumnName("highEW");

                entity.Property(e => e.HighNs).HasColumnName("highNS");

                entity.Property(e => e.LowEw).HasColumnName("lowEW");

                entity.Property(e => e.LowNs).HasColumnName("lowNS");

                entity.Property(e => e.NS)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("nS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
