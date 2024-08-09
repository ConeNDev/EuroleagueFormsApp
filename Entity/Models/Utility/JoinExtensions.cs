using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Utility
{
    [Serializable]
    public class JoinExtensions
    {
        public IEntity JoinTable { get; set; }
        public string JoinKey { get; set; }
    }
}
