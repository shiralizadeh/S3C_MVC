﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.DataLayer
{
    public class Product : EntityBase
    {
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public Group Group { get; set; }

        [Display(Name = "عنوان")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        [Required]
        public int Price { get; set; }

        [Display(Name = "تعداد")]
        [Required]
        public int Count { get; set; }

        [NotMapped]
        public List<Group> Groups { get; set; }
    }
}
