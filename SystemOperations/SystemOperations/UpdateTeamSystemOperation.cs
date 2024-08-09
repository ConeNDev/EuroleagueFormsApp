using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class UpdateTeamSystemOperation : BaseSystemOperations
    {
        public Team Team;
        public Game Game=new Game();
        protected override void ExecuteConcreteOperation()
        {
            repository.Update(Team, $"Teams.TeamId = {Team.TeamId}");
            
        }
    }
}
