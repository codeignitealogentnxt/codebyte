using APIProject.Helper;
using CommonModel;
using Microsoft.AspNetCore.Mvc;
using ProjectDB.DBModel;
using ServiceProject.Abstraction;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeSearchController : ControllerBase
    {
        private IJobDescriptionService _jobDescriptionService;
        private ICandidateService _candidateService;
        List<ResumeSearch> _matchedCandidateResume;

        public ResumeSearchController(IJobDescriptionService jobDescriptionService, ICandidateService candidateService)
        {
            _jobDescriptionService = jobDescriptionService;
            _candidateService = candidateService;
        }

        [HttpGet]
        public IActionResult GetResumeMatches(int jobDescriptionId)
        {
            _matchedCandidateResume =new List<ResumeSearch>();
            var jobDescription = _jobDescriptionService.GetJobDescription(jobDescriptionId);
            var candidates = _candidateService.GetCandidate();

            ISearch search = new Search();

            foreach (var item in candidates)
            {
                MatchResult results = search.GetMatchScore(jobDescription.HardSkills.Split(','), jobDescription.SoftSkills.Split(','), item.ResumeText);
                if (results == null) continue;

                if (results.TotalMatchPercentage >= jobDescription.MinimumWeight)
                {
                    _matchedCandidateResume.Add(new ResumeSearch {                     
                        CandidateId= item.ID,
                        CandidateResumeFileName = item.FileName,
                        CandidateResumeFilePath = item.FilePath,
                        JobDescriptionId = item.ID,
                        TotalHardSkillMatchScore =results.HardSkillMatchPercentage,
                        TotalSoftSkillMatchScore =results.SoftSkillMatchPercentage,
                        TotalMatchScore = results.TotalMatchPercentage             
                    });
                }
            }

            var matches = _matchedCandidateResume.OrderByDescending(i => i.TotalMatchScore);
            return Ok(matches);
        }

    }
}
