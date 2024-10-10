using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetAllCitiesWithTeams : BaseSystemOperations
    {
        public List<City> Cities { get; set; }
        
        protected override void ExecuteConcreteOperation()
        {
            Cities = repository.Select(new City()).Cast<City>().ToList();
        }
    }
}
