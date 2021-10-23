using CommonModel.Enum;
using System;

namespace CommonModel
{
    public class RiskModel
    {
        public long ProjectID { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        public DateTime IdentfiedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Mitigation { get; set; }
    }

    public class RiskResponse : BaseResponse
    { }
}