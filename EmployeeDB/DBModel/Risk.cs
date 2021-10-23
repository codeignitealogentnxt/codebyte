using CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class Risk:AuditableEntity
    {
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        public DateTime IdentfiedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Mitigation { get; set; }
    }
}
