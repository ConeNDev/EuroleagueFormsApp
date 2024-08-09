using Common.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ExtentionMethods
    {
        public static T GetDataFromResponse<T>(this Response response)
        {
            return (T)response.Data;
        }
    }
}
