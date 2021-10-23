using CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class OverallProjectStatusModel
    {
        public ProjectArea ProjectArea { get; set; }
        public long ProjectID { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }

    public class OverallProjectStatusResponse:BaseResponse
    {
    }
}
