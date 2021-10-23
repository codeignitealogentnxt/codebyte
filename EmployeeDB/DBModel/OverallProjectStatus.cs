using CommonModel.Enum;
using System;

namespace ProjectDB.DBModel
{
    public class OverallProjectStatus:AuditableEntity
    {
        public ProjectArea ProjectArea { get; set; }
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
