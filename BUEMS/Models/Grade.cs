using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class Grade
    {
        [Key]
        public int GradeNo { get; set; }
        public string GradeRange { get; set; }
    }
}