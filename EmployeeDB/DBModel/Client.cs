using System.Collections.Generic;

namespace ProjectDB.DBModel
{
    public class Client : AuditableEntity
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Project> ClientProjects { get; set; }
    }
}
