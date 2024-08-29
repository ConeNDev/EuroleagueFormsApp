using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.BaseSO
{

    public abstract class BaseSystemOperations
    {
        public GenericDbRepository repository;
        public BaseSystemOperations()
        {
            repository = new GenericDbRepository();
        }
        public void Execute()
        {
            try
            {
                //repository.BeginTransaction();
                ExecuteConcreteOperation();
                repository.Commit();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw ex;
            }
            finally
            {
                repository.Close();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
