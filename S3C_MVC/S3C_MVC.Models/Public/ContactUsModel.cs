using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Models.Public
{
    public class ContactUsModel
    {
        public static List<ContactUsModel> List { get; set; } = new List<ContactUsModel>();

        [Required(ErrorMessage = "لطفا نام را وارد نمائید.")]
        [Display(Name = "نام من")]
        public string Firstname { get; set; }

        [Range(0, 100, ErrorMessage = "test")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
