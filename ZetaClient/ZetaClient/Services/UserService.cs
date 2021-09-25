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
            Dictionary<string, object> logResult = await ConnectionManager.LogUserIn(email, password);
            AppConstants.ApiKey = logResult["ApiKey"] as string;
            AppConstants.IdSession = logResult["SessionToken"] as string;
            AppConstants.CurrentUser = logResult["ConnectedUser"] as User;
        }

        public async Task Logout()
        {
            await ConnectionManager.LogOut();
            AppConstants.IdSession = null;
            AppConstants.CurrentUser = null;
        }
    }
}
