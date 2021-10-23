using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
    public class BaseResponse
    {
        public bool Success { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
