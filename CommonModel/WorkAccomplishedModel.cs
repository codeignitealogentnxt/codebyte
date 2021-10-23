using System;

namespace CommonModel
{
    public class WorkAccomplishedModel
    {
        public long ProjectID { get; set; }
        public string WorkAccomplishedDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }

    public class WorkAccomplishedResponse:BaseResponse
    {
    }
}