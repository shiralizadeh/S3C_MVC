using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Models.Admin
{
    public class ProductDTO
    {
        public int GroupID { get; set; }

        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        [Required]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        [Required]
        public int Count { get; set; }

        public List<SimpleGroup> Groups { get; set; }
        public List<SimpleImage> Images { get; set; }
    }
}
