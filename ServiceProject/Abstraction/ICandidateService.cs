using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject.Abstraction
{
    public interface ICandidateService
    {
        IEnumerable<Candidates> GetCandidate();

        Candidates GetCandidate(int id);
    }
}
