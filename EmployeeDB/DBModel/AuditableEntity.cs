using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB.DBModel
{
    public class AuditableEntity
    {
        public long ID { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
    }
}
