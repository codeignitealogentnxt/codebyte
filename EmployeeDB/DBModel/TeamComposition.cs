using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class TeamComposition : AuditableEntity
    {
        public virtual User User { get; set; }
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillingStartDate { get; set; }
        public DateTime BillingEndDate { get; set; }
        public decimal Allocation { get; set; }
    }
}
