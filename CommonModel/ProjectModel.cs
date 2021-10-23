using CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
   

    

    public class ProjectModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long ClientId { get; set; }
        public int ReosurceCount { get; set; }
        public int BilledResourceCount { get; set; }
        public string ClientManagerEmail { get; set; }
        public string AccountManagerEmail { get; set; }
        public string ProjectManagerEmail { get; set; }
        public Status ProjectStatus { get; set; }
    }

    public class ProjectAddRequest
    {
        public string Name { get; set; }
        public int ReosurceCount { get; set; }
        public int BilledResourceCount { get; set; }
        public string ClientManagerEmail { get; set; }
        public string AccountManagerEmail { get; set; }
        public string ProjectManagerEmail { get; set; }
    }

    public class ProjectAddResponse
    {
        public bool Success { get; set; }
    }
}

