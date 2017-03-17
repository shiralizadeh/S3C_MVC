using S3C_MVC.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Services
{
    public class ContactUsMessagesServices
    {
        public void Insert(ContactUsMessage contactUsMessage)
        {
            using (var db = new EntityContext())
            {
                db.ContactUsMessages.Add(contactUsMessage);

                db.SaveChanges();
            }
        }
    }
}
