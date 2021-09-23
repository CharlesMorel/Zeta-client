using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaClient.Entities
{
    public class FrisbeeModel : AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string pUHT { get; set; }
        public string Range { get; set; }
    }
}
