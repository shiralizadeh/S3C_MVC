using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class Group : EntityBase
    {
        public int? GroupID { get; set; }

        [ForeignKey("GroupID")]
        public Group ParentGroup { get; set; }

        public string Title { get; set; }
    }
}
