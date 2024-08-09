using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class UpdatePlayerSystemOperation:BaseSystemOperations
    {
        public Player Player;

        protected override void ExecuteConcreteOperation()
        {
            repository.Update(Player, $"Players.PlayerId = {Player.PlayerId}");
        }
    }
}
