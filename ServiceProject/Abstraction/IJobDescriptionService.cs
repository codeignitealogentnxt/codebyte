using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject.Abstraction
{
    public interface IJobDescriptionService
    {
        IEnumerable<JobDescription> GetJobDescription();

        JobDescription GetJobDescription(int id);
    }
}
