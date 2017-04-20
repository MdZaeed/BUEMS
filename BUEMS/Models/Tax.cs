using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class Tax
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SerialNo { get; set; }
        public int Scale { get; set; }
        public int Grade { get; set; }
        public int MainSalary { get; set; }
        public int MonthlyTaxMale { get; set; }
        public int MonthlyTaxFemale { get; set; }
        public int MonthlyTaxFreedomFighter { get; set; }
    }
}