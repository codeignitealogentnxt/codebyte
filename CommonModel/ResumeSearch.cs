
namespace CommonModel
{
    public class ResumeSearch
    {
        public int JobDescriptionId { get; set; }
        public int CandidateId { get; set; }
        public string CandidateResumeFileName { get; set; }
        public string CandidateResumeFilePath { get; set; }
        public decimal MatchScore { get; set; }


    }
}
