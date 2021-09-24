using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.DataAccess.Abstract
{
    public interface IDao<T> where T : IEntity
    {
        Task<T> Get(string id);

        Task<List<T>> Get();

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(string id);
    }
}
