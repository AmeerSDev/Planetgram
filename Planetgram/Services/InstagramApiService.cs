using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetgram.Services
{
    public class InstagramApiService
    {
        private static UserSessionData user;
        private static IInstaApi api;

        public InstagramApiService(string username = "" , string password = "")
        {
            user = new UserSessionData();
            user.UserName = username;
            user.Password = password;
            InitApi();
        
        }
        private void InitApi()
        {
            api = InstaApiBuilder.CreateBuilder()
           .SetUser(user)
           .UseLogger(new DebugLogger(LogLevel.Exceptions))
           //.SetRequestDelay(TimeSpan.FromSeconds(10))
           .Build();
        }
    }
}
