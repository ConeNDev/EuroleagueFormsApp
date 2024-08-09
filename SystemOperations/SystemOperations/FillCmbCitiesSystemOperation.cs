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
	public class FillCmbCitiesSystemOperation : BaseSystemOperations
	{
		public List<City> cities;
		protected override void ExecuteConcreteOperation()
		{
			City city=new City();
			cities = repository.Select(city).Cast<City>().ToList();


		}
	}
}
