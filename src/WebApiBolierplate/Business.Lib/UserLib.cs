using Business.Lib.Core;
using Core.Constants;
using Model;
using System;

namespace Business.Lib
{
    public class UserLib : Base
    {
        private const string BrandonStark = "Brandon Stark";
        private const string EddardStark = "Eddard Stark";

        public UserLib()
        {

        }

        public int ValidateLogin(LoginDTO login)
        {
            try
            {
                if (login.UserName == BrandonStark && login.Password == "My direwolf is Summer")
                {
                    return 1;
                }
                else if (login.UserName == EddardStark && login.Password == "I'm the lord of WinterFell")
                {
                    return 1;
                }
                else if (login.UserName == BrandonStark && login.Password == "My direwolf is Lady")
                {
                    return -103; // invalid credential
                }
                else if(login.UserName == BrandonStark && login.Password == "Eddard's elder brother")
                {
                    return -104; // account deleted
                }
                else if (login.UserName == "No one" && login.Password == "A man wants an exception")
                {
                    throw new Exception("This is an excpetion");
                }
                return -102; // account not found
            }
            catch (Exception ex)
            {
                csvLogger.Error(ex);
                return -1;
            }
        }

        public User GetUser(string userName)
        {
            try
            {
                var user = new User()
                {
                    Name = userName,
                    Email = $"{userName}@gameofthrones.com",
                    CompanyId = "GOT",
                    Roles = userName == EddardStark ? Roles.Admin : Roles.User,
                    Id = Guid.NewGuid().ToString("D")
                };
                return user;
            }
            catch (Exception ex)
            {
                csvLogger.Error(ex);
                return null;
            }
        }
    }
}
