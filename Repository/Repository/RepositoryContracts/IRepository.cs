using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryContracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity, string criteria);
        void Delete(TEntity entity, string criteria);

        List<TEntity> Select(TEntity entity, string criteria);

    }
}
