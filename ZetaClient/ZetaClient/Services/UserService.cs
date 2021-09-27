using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Constants;
using ZetaClient.DataAccess;
using ZetaClient.Entities;
using ZetaClient.Managers;
using ZetaClient.Services.Abstract;

namespace ZetaClient.Services
{
    public class UserService : AbstractService<User>
    {
        public UserService()
        {
            Dao = new UserApiDao();
        }

        public async Task Login(string email, string password)
        {
            AppConstants.ApiKey = "";
            //Dictionary<string, object> logResult = await ConnectionManager.LogUserIn(email, password);
            //AppConstants.ApiKey = logResult["ApiKey"] as string;
            // todo
            //AppConstants.CurrentUser = ...
        }

        public async Task Logout()
        {
            await ConnectionManager.LogOut();
            AppConstants.CurrentUser = null;
        }
    }
}
