using CommonModel.Enum;

namespace ProjectDB.DBModel
{
    public class Project : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int ReosurceCount { get; set; }
        public int BilledResourceCount { get; set; }
        public string ClientManagerEmail { get; set; }
        public string AccountManagerEmail { get; set; }
        public string ProjectManagerEmail { get; set; }
        public Status ProjectStatus { get; set; }
    }
}
