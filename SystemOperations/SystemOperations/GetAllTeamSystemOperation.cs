using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
	public class GetAllTeamSystemOperation : BaseSystemOperations
	{
		public List<Team> TeamList { get; set; }
		private Team Team;

		protected override void ExecuteConcreteOperation()
		{
			Team=new Team();
			TeamList = repository.Select(Team).Cast<Team>().ToList();
		}
	}
}
