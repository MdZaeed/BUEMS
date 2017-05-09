using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class SalaryHis
    {
        [Key]
        public int SerialNo { get; set; }
        public string Data { get; set; }
    }
}