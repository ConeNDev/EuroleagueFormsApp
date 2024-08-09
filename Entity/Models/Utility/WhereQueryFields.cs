using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Utility
{
    [Serializable]
    public class WhereQueryFields
    {
        public string FieldName { get; set; }
        public string FieldVaue { get; set; } = "";

        public WhereQueryFields(string name, string value = "")
        {
            FieldName = name;
            FieldVaue = value;
        }
    }
}
