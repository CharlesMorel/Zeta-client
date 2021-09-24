using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.DataAccess;
using ZetaClient.Entities;
using ZetaClient.Services.Abstract;

namespace ZetaClient.Services
{
    public class UserService : AbstractService<User>
    {
        public UserService()
        {
            Dao = new UserApiDao();
        }

        // todo: add connection service ...
    }
}
