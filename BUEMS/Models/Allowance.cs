using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
	public class Allowance
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SerialNo { get; set; }
        public string DutyName { get; set; }
        public int AllowanceAmount { get; set; }
	}
}