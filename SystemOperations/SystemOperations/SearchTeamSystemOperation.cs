using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
	public class SearchTeamSystemOperation : BaseSystemOperations
	{
		public List<Team> filteredTeams { get; set; }
		public string filter;
		private Team team;
		protected override void ExecuteConcreteOperation()
		{
			team = new Team();
			filteredTeams = repository.Select(team, $"t.Name like '%{filter}%'")
				.Cast<Team>().ToList();
		}
	}
}
