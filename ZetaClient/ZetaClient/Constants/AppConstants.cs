using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaClient.Entities;

namespace ZetaClient.Constants
{
    public static class AppConstants
    {
        public static string BaseApiUrl { get; set; }
        public static string ApiKey { get; set; }
        public static string IdSession { get; set; }
        public static User CurrentUser { get; set; }
    }
}
