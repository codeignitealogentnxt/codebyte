using System.Collections.Generic;
using CommonModel;

namespace APIProject.Helper
{
    public interface ISearch
    {
        ResumeSearch SearchPattern(string hardSkills, string softSkills, string resumeText);
    }
}
