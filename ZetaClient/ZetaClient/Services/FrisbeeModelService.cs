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
    public class FrisbeeModelService : AbstractService<FrisbeeModel>
    {
        public FrisbeeModelService()
        {
            Dao = new FrisbeeModelApiDao();
        }
    }
}
