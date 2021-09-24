using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.DataAccess.Abstract;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.Services.Abstract
{
    public abstract class AbstractService<T> where T : IEntity
    {
        public virtual IDao<T> Dao { get; set; } 

        public async Task<List<T>> Get()
        {
            return await Dao.Get();
        }

        public async Task<T> Get(string id)
        {
            return await Dao.Get(id);
        }

        public async Task Create(T entity)
        {
            await Dao.Insert(entity);
        }

        public async Task Update(T entity)
        {
            // todo: empty object properties
            await Dao.Update(entity);
        }

        public async Task Delete(string id)
        {
            await Dao.Delete(id);
        }
    }
}
