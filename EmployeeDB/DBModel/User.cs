
using CommonModel.Enum;

namespace ProjectDB.DBModel
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAccess { get; set; }
    }
}
