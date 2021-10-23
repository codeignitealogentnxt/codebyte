using System.Collections.Generic;
using CommonModel;

namespace APIProject.Helper
{
    public interface ISearch
    {
        decimal? GetMatchScore(string[] hardSkills, string[] softSkills, string resumeText);
    }
}
