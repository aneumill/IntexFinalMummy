using System;
using System.Collections.Generic;

#nullable disable

namespace IntexFinalMummy.Models
{
    public partial class MummyInfo
    {
        public MummyInfo()
        {
            C14samples = new HashSet<C14sample>();
            CraniumSamples = new HashSet<CraniumSample>();
            Samples = new HashSet<Sample>();
        }
        
        public int? MummyId { get; set; }
        public int? QuadrantId { get; set; }
        public int? ClusterId { get; set; }
        public int? BurialNumber { get; set; }
        public bool? AdultChild { get; set; }
        public string Sex { get; set; }
        public bool? SexMethod { get; set; }
        public decimal? MinAge { get; set; }
        public decimal? MaxAge { get; set; }
        public string HairColor { get; set; }
        public bool? Sample { get; set; }
        public int? YearDiscovered { get; set; }
        public int? MonthDiscovered { get; set; }
        public int? DayDiscovered { get; set; }
        public bool? Artifacts { get; set; }
        public string ArtifactsDescription { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string MummyDescription { get; set; }
        public decimal? BurialDepth { get; set; }
        public int? ExtractedOrder { get; set; }
        public int? SkullYear { get; set; }
        public int? SkullMonth { get; set; }
        public int? SkullDay { get; set; }
        public decimal? SouthToHead { get; set; }
        public decimal? SouthToFeet { get; set; }
        public decimal? WestToHead { get; set; }
        public decimal? WestToFeet { get; set; }
        public string HeadDirection { get; set; }
        public string FieldBookYear { get; set; }
        public string FieldBookPageNum { get; set; }
        public string PreservationDescription { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string BurialSituationNotes { get; set; }
        public decimal? LengthOfRemains { get; set; }
        public decimal? GefunctionTotal { get; set; }
        public string SexGe { get; set; }
        public int? VentralArc { get; set; }
        public int? SubponicAngle { get; set; }
        public int? SciaticNotch { get; set; }
        public int? PubicBone { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? MedialIpramus { get; set; }
        public int? DorsalPitting { get; set; }
        public string FormanMagnum { get; set; }
        public decimal? FemurHead { get; set; }
        public decimal? HumerusHead { get; set; }
        public string Osteophystosis { get; set; }
        public int? PubicSymphysis { get; set; }
        public decimal? FemurLength { get; set; }
        public decimal? HumerusLength { get; set; }
        public decimal? TibiaLength { get; set; }
        public int? Robust { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonian { get; set; }
        public int? NuchalCrest { get; set; }
        public int? ZygomaticCrest { get; set; }
        public int? CranialSuture { get; set; }
        public decimal? EstLivingStature { get; set; }
        public int? ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathalogyAnomaly { get; set; }
        public bool? EpiphysealUnion { get; set; }
        public bool? ByuSample { get; set; }
        public bool? ToBeConfirmed { get; set; }
        public bool? SkullTrauma { get; set; }
        public bool? PostcraniaTrauma { get; set; }
        public bool? CibraOrbitala { get; set; }
        public bool? PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public bool? MetopicSuture { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public bool? TemporalMandibularJointOsteoarthritis { get; set; }
        public bool? LinearHypoplasiaEnamel { get; set; }
        public int? Area { get; set; }
        public int? Tomb { get; set; }
        public string FaceBundle { get; set; }
        public int? BodyAnalysisYear { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public string PostcraniaAtMagazine { get; set; }
        public string DataEntryExpert { get; set; }
        public string DataEntryChecker { get; set; }
        public string OsteologyNotes { get; set; }

        public virtual Cluster Cluster { get; set; }
        public virtual Quadrant Quadrant { get; set; }
        public virtual ICollection<C14sample> C14samples { get; set; }
        public virtual ICollection<CraniumSample> CraniumSamples { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
    }
}
