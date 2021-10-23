using System;
using System.Collections.Generic;
using System.Text;
namespace ProjectDB.DBModel
{
    public class JobDescription : AuditableEntity
    {
        public string HardSkills { get; set; }
        public string SoftSkills { get; set; }
        public int MinimumWeight { get; set; }
        public string FilePath { get; set; }
        public int MinExpierence { get; set; }
        public int MaxExpierence { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}