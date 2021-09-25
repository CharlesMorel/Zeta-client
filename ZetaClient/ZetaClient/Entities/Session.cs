using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;

namespace ZetaClient.Entities
{
    public class Session : AbstractEntity
    {
        public string IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Closed { get; set; }
    }
}
