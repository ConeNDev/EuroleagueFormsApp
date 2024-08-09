using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]
    public class Request
    {
        public object Body { get; set; }
        public Operation Operation { get; set; }

        public Request(object body, Operation operation)
        {
            Body = body;
            Operation = operation;
        }
    }
}
