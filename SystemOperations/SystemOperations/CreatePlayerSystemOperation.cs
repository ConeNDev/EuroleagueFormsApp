using Entity;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.BaseSO;

namespace SystemOperations.SystemOperations
{
    public class CreatePlayerSystemOperation : BaseSystemOperations
    {
        public Player Player { get; set; }
        
        protected override void ExecuteConcreteOperation()
        {
            if (Player == null)
            {
                throw new Exception("Player is null");
            }
            repository.Insert(Player);
        }
    }
}
