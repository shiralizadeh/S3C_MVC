using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            RegisterDate = DateTime.Now;
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { get; set; }
    }
}
