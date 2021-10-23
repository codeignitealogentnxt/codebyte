using CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class ProjectUpdate:AuditableEntity
    {
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public DateTime Date { get; set; }
        public UpdateType UpdateType { get; set; }
        public string Comment { get; set; }
    }    
}
