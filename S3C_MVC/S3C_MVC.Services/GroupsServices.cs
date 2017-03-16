using S3C_MVC.DataLayer;
using S3C_MVC.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Services
{
    public class GroupsServices
    {
        public List<Group> Get()
        {
            using (var db = new EntityContext())
            {
                var groups = db.Groups.ToList();

                return groups;
            }
        }

        public List<SimpleGroup> GetForDropdown()
        {
            using (var db = new EntityContext())
            {
                var groups = from item in db.Groups
                             select new SimpleGroup()
                             {
                                 ID = item.ID,
                                 Title = item.Title
                             };

                return groups.ToList();
            }
        }
    }
}
