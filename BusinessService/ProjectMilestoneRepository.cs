using ProjectDB;
using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
    public class ProjectMilestoneRepository:BaseRepository<ProjectMilestone>,IProjectMilestoneRepository
    {
        public ProjectMilestoneRepository(ProjectContext projectContext):base(projectContext)
        {
        }
    }
}
