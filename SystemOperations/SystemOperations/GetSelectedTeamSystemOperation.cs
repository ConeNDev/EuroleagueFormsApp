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
    public class GetSelectedTeamSystemOperation : BaseSystemOperations
    {
        public Team selectedTeam;
        protected override void ExecuteConcreteOperation()
        {
            List<Team>team=repository.Select(selectedTeam,
                $" TeamId = '{selectedTeam.TeamId}'").Cast<Team>().ToList();
            if (team == null)
            {
                throw new Exception("Team doesn't exist in database :( ");
            }
            else
            {
                selectedTeam = team[0];
            }
        }
    }
}
