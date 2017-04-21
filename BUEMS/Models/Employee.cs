using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "ক্রমিক নং")]
        public int SerialNo { get; set; }
        [Display(Name = "আইডি নং")]
        public string IdNo { get; set; }
        [Display(Name = "পুর্ণ নাম")]
        public string FullName { get; set; }
        [Display(Name = "পদবি")]
        public string Podobi { get; set; }
        [Display(Name = "বেতন")]
        public int Salary { get; set; }
        [Display(Name = "চাকরির ধরন")]
        public string Category { get; set; }
        [Display(Name = "ডিপার্টমেন্ট")]
        public string Department { get; set; }
        [Display(Name = "যোগদানের তারিখ")]
        public string JoiningDate { get; set; }
        [Display(Name = "অ্যাকাউন্ট নাম্বার")]
        public string AccountNo { get; set; }
        [Display(Name = "বেতন স্কেল/ গ্রেড")]
        public string MainSalaryGrade { get; set; }
        [Display(Name = "লিঙ্গ")]
        public string Sex { get; set; }
        [Display(Name = "মুক্তিযোদ্ধা")]
        public Boolean IsFreedomFighter { get; set; }
        [Display(Name = "অতিরিক্ত দায়িত্ব")]
        public Boolean IsAddiitonalDuties { get; set; }
        [Display(Name = "ছাত্র উপদেষ্টা")]
        public Boolean IsStudentAdviser { get; set; }
        [Display(Name = "ডিন")]
        public Boolean IsDean { get; set; }
        [Display(Name = "চেয়ারম্যান")]
        public Boolean IsChairman { get; set; }
        [Display(Name = "প্রভোস্ট")]
        public Boolean IsProvost { get; set; }
        [Display(Name = "প্রক্টর")]
        public Boolean IsProctor { get; set; }
        [Display(Name = "সহকারী প্রক্টর")]
        public Boolean IsAssistantProctor { get; set; }
        [Display(Name = "নিজস্ব পরিবহন সুবিধা")]
        public Boolean HasOwnTransportationMethod { get; set; }
        [Display(Name = "শিক্ষক")]
        public Boolean IsTeacher { get; set; }
    }
}