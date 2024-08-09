    using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class CreateTeamSystemOperation : BaseSystemOperations
    {
        public Team Team { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            if (Team == null)
            {
                throw new Exception("Team is null");
            }

            List<Team> teamFromDb=repository.Select(Team,$" t.Name = '{Team.Name}' or" +
                $"  t.Coach = '{Team.Coach}'").Cast<Team>().ToList();

            if (teamFromDb.Count!=0)
            {
				throw new Exception("System can't create that team," +
                    " because it already exists");
			}
            else
            {
				repository.Insert(Team);
			}
            
        }
    }
}
