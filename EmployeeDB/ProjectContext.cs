using Microsoft.EntityFrameworkCore;
using ProjectDB.DBModel;

namespace ProjectDB
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<OverallProjectStatus> OverallProjectStatus { get; set; }
        DbSet<ProjectMilestone> ProjectMilestone { get; set; }
        DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        DbSet<Risk> Risks { get; set; }
        DbSet<TeamComposition> TeamComposition { get; set; }
        DbSet<WorkAccomplished> WorkAccomplished { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Project> Projects { get; set; }
    }
}
