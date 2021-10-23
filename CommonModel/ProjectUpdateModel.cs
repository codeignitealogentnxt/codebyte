using CommonModel.Enum;
using System;

namespace CommonModel
{
    public class ProjectUpdateModel
    {
        public long ProjectID { get; set; }
        public DateTime Date { get; set; }
        public UpdateType UpdateType { get; set; }
        public string Comment { get; set; }
    }

    public class ProjectUpdateRequest
    {
        public DateTime Date { get; set; }
        public UpdateType UpdateType { get; set; }
        public string Comment { get; set; }
    }

    public class ProjectUpdateResponse : BaseResponse
    {
    }
}