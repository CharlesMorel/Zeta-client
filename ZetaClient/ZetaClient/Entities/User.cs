using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Helpers;

namespace ZetaClient.Entities
{
    public class User: AbstractEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; } = HashHelper.GenerateSalt();
    }
}
