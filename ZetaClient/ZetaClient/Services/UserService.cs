using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Constants;
using ZetaClient.DataAccess;
using ZetaClient.Entities;
using ZetaClient.Entities.Enums;
using ZetaClient.Managers;
using ZetaClient.Services.Abstract;

namespace ZetaClient.Services
{
    public class UserService
    {
        public async Task Login(string username, string password)
        {
            Dictionary<string, object> logResult = await ConnectionManager.LogUserIn(username, password);

            if(logResult.ContainsKey("Error"))
            {
                throw new Exception(logResult["Error"].ToString());
            }

            AppConstants.ApiKey = logResult["ApiKey"] as string;
            // todo
            AppConstants.CurrentUserDepartment = UserDepartment.RD;
        }

        public async Task Logout()
        {
            //await ConnectionManager.LogOut();
            AppConstants.CurrentUserDepartment = UserDepartment.None;
            AppConstants.ApiKey = null;
        }
    }
}
