using DataRepository;
using ProjectDB;
using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository
{
    public class CandidateRepository : BaseRepository<Candidates>, ICandidateRepository
    {
        public ProjectContext _dbContext { get; }

        public CandidateRepository(ProjectContext projectContext) : base(projectContext)
        {
            _dbContext = projectContext;
        }

        public IEnumerable<Candidates> GetCandidateResumeById(int id)
        {
            return _dbContext.Set<Candidates>().Where(x => x.ID == id);
        }

        public IEnumerable<Candidates> GetCandidateResumes()
        {
            return _dbContext.Set<Candidates>();
        }
    }
}
