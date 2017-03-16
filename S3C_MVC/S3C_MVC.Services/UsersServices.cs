using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Services
{
    public class UsersServices
    {
        public bool Auth(string username, string password)
        {
            var db = new EntityContext();

            return db.Users.Where(item => item.Username == username && item.Password == password).Any();
        }
    }
}
