using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class ContactUsMessage : EntityBase
    {
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
