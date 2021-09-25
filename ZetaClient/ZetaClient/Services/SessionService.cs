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
    public class SessionService : AbstractService<Session>
    {
        public SessionService()
        {
            Dao = new SessionApiDao();
        }
    }
}
