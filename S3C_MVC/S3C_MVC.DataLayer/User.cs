using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class User : EntityBase
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
