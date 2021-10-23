using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class WorkAccomplished:AuditableEntity
    {
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string WorkAccomplishedDetails{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }
}
