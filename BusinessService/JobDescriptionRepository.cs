using DataRepository.Abstraction;
using ProjectDB;
using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository
{
    public class JobDescriptionRepository : BaseRepository<JobDescription>, IJobDescriptionRepository
    {
        public ProjectContext _dbContext { get; }

        public JobDescriptionRepository(ProjectContext projectContext) : base(projectContext)
        {
            _dbContext = projectContext;
        }

        public IEnumerable<JobDescription> GetJobDescriptionById(int id)
        {
            return _dbContext.Set<JobDescription>().Where(x => x.ID == id);
        }

        public IEnumerable<JobDescription> GetJobDescription()
        {
            return _dbContext.Set<JobDescription>();
        }
    }
}
