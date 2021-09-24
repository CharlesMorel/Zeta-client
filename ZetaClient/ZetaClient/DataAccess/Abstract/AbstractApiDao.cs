using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.DataAccess.Abstract
{
    public abstract class AbstractApiDao<T> : IDao<T> where T : class, IEntity
    {
        public async Task<T> Get(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            var test = typeof(T);
            throw new NotImplementedException();
        }
    }
}
