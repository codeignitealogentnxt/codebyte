using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class ProjectMilestone: AuditableEntity
    {
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string MilestoneName { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Comment { get; set; }
    }
}
