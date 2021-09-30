using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.Entities
{
    public class Ingredient: AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
