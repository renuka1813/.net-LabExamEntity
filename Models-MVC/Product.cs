using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLabExam.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please enter vaild Product Name")]
        [DataType(DataType.Text)]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter vaild Product Rate")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Please enter vaild Product Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter vaild Product Category")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}