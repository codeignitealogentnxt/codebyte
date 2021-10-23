using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject
{
    public interface IJobDescriptionService
    {
        IEnumerable<JobDescription> GetJobDescription();

        JobDescription GetJobDescription(int id);
    }
}
