using CommonModel;
using System;
using System.Text.RegularExpressions;

namespace APIProject.Helper
{
    public class Search : ISearch
    {
        public MatchResult GetMatchScore(string[] hardSkills, string[] softSkills ,string resumeText)
        {
            int totalHardSkillCount = 0, totalSoftSkillCount = 0;
            int resumeWordLength = resumeText.Trim().Split(" ").Length;

            if (resumeText.Length <= 0) return null;

            foreach (var item in hardSkills)
            {
                totalHardSkillCount += GetResumeMatchCount(item, resumeText);
            }

            foreach (var item in softSkills)
            {
                totalSoftSkillCount += GetResumeMatchCount(item, resumeText);
            }

            return new MatchResult
            {
                HardSkillMatchPercentage = Math.Round((decimal)((totalHardSkillCount * 100) / resumeWordLength), 2),
                SoftSkillMatchPercentage = Math.Round((decimal)(totalSoftSkillCount * 100) / resumeWordLength, 2),
                TotalMatchPercentage = Math.Round((decimal)((totalHardSkillCount + totalSoftSkillCount) * 100) / resumeWordLength, 2)
            };
        }

        private int GetResumeMatchCount(string skill, string resumeText)
        {
            return Regex.Matches(resumeText, skill).Count;
        }
    }    
}
