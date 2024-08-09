using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class GetSelectedPlayerSystemOperation : BaseSystemOperations
    {
        public Player selectedPlayer;
        protected override void ExecuteConcreteOperation()
        {
            List<Player> player = repository.Select(selectedPlayer,
                $" PlayerId = '{selectedPlayer.PlayerId}'").Cast<Player>().ToList();
            if (player == null)
            {
                throw new Exception("Player doesn't exist in database :( ");
            }
            else
            {
                selectedPlayer = player[0];
            }
        }
    }
}
