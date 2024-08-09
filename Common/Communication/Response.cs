using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]

    public class Response
    {
        public object Data { get; set; }
        public Operation Operation { get; set; }
        public string Message { get; set; }

        public Response(object data, Operation operation, string message)
        {
            Data = data;
            Operation = operation;
            Message = message;
        }
        public Response()
        {
        }
    }
}
