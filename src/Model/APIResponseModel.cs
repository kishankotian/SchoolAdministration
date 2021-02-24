using System.Collections.Generic;

namespace Model
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
