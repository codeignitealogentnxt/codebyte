using CommonModel;
using System;
using System.Text.RegularExpressions;

namespace APIProject.Helper
{
    public class Search : ISearch
    {
        public decimal? GetMatchScore(string[] hardSkills, string[] softSkills ,string resumeText)
        {
            int totalSkillCount;
            int resumeWordLength = resumeText.Split(" ").Length;
            int totalHardSkillCount = 0;
            int totalSoftSkillCount = 0;

            if (resumeText.Length <= 0) return null;

            foreach (var item in hardSkills)
            {
                totalHardSkillCount += GetResumeMatchCount(item, resumeText);
            }

            foreach (var item in softSkills)
            {
                totalSoftSkillCount += GetResumeMatchCount(item, resumeText);
            }

            totalSkillCount = totalHardSkillCount + totalSoftSkillCount;
            return (totalSkillCount * 100)/ resumeWordLength;     
        }

        private int GetResumeMatchCount(string skill, string resumeText)
        {
            return Regex.Matches(resumeText, skill).Count;
        }
    }    
}
