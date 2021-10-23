using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class ProjectMilestoneModel
    {
        public long ProjectID { get; set; }
        public string MilestoneName { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Comment { get; set; }
    }

    public class ProjectMilestoneRequest
    {
        public string MilestoneName { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Comment { get; set; }
    }

    public class ProjectMileStoneResponse : BaseResponse
    { }
}
