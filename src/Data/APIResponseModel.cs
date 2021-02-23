using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class APIResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class ResponseModel
    {
        public string Message { get; set; }
    }
    public class RecipientModel
    {
        public IEnumerable<string> Recipients { get; set; }
    }
}
