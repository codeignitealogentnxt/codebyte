using System;
using System.Collections.Generic;
using System.Text;
namespace ProjectDB.DBModel
{
    public class Candidates : AuditableEntity
    {
        public long UserId { get; set; }
        public string SoftSkills { get; set; }
        public string ResumeText { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}