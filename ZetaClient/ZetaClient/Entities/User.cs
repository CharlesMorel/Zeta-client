using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities.Abstract;
using ZetaClient.Entities.Enums;
using ZetaClient.Helpers;

namespace ZetaClient.Entities
{
    public class User: AbstractEntity
    {
        public string Email { get; set; }
        public UserDepartment Department { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; } = HashHelper.GenerateSalt();
    }
}
