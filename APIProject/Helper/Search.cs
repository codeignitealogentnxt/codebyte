using CommonModel;
using System;
using System.Text.RegularExpressions;

namespace APIProject.Helper
{
    public class Search : ISearch
    {
        public ResumeSearch SearchResume(string[] hardSkills, string[] softSkills ,string resumeText)
        {
            int totalSkillCount,totalMatchScorePercentage = 0;
            int resumeLength = resumeText.Length;

            int totalHardSkillCount = 0;
            int totalSoftSkillCount = 0;

            foreach (var item in hardSkills)
            {
                totalHardSkillCount += GetResumeMatchCount(item, resumeText);
            }

            foreach (var item in softSkills)
            {
                totalSoftSkillCount += GetResumeMatchCount(item, resumeText);
            }

            totalSkillCount = totalHardSkillCount + totalSoftSkillCount;
            totalMatchScorePercentage = (totalSkillCount * 100) / resumeLength;

            return new ResumeSearch
            {
                MatchScore = totalMatchScorePercentage
            };            
        }

        private int GetResumeMatchCount(string skill, string resumeText)
        {
            return Regex.Matches(resumeText, skill).Count;
        }
    }    
}
