using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaClient.Entities.Abstract
{
    public abstract class AbstractEntity : IEntity
    {
        public string Id { get; set; }
    }
}
