
namespace CommonModel
{
    public class ResumeSearch
    {
        public long JobDescriptionId { get; set; }
        public long CandidateId { get; set; }
        public string CandidateResumeFileName { get; set; }
        public string CandidateResumeFilePath { get; set; }
        public decimal? TotalMatchScore { get; set; }
        public decimal? TotalHardSkillMatchScore { get; set; }
        public decimal? TotalSoftSkillMatchScore { get; set; }
    }
}
