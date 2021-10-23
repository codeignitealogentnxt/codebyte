using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class TeamCompositionModel
    {
        public long ProjectID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillingStartDate { get; set; }
        public DateTime BillingEndDate { get; set; }
        public decimal Allocation { get; set; }
    }

    public class TeamCompositionResponse : BaseResponse
    { }
}
