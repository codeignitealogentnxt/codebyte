using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstraction
{
    public interface ICandidateRepository : IBaseRepository<Candidates>
    {
        IEnumerable<Candidates> GetCandidateResumeById(int id);
        IEnumerable<Candidates> GetCandidateResumes();
    }
}
