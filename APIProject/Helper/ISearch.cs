using System.Collections.Generic;
using CommonModel;

namespace APIProject.Helper
{
    public interface ISearch
    {
        ResumeSearch SearchResume(string[] hardSkills, string[] softSkills, string resumeText);
    }
}
