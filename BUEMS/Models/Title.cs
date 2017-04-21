using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class Title
    {
        [Key]
        public int SerialNo { get; set; }
        public string TitleName { get; set; }
        public string Category { get; set; }
    }
}