using System.Collections.Generic;
using CommonModel;

namespace APIProject.Helper
{
    public interface ISearch
    {
        MatchResult GetMatchScore(string[] hardSkills, string[] softSkills, string resumeText);
    }
}
