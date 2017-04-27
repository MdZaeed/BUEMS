using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SerialNo { get; set; }
        public string IdNo { get; set; }
        [Display(Name = "নাম")]
        public string Name { get; set; }
        [Display(Name = "পদবি")]
        public string Title { get; set; }
        [Display(Name = "বিভাগ/ইনস্ন্টিটিউট/দপ্তর")]
        public string Institute { get; set; }
        [Display(Name = "বর্তমান পদে যোগদানের তারিখ")]
        public string JoiningDate { get; set; }
        [Display(Name = "মাসের নাম")]
        public string Month { get; set; }
        [Display(Name = "ব্যাংক হিসাব নং")]
        public string AccountNo { get; set; }
        [Display(Name = "বেতন স্কেল/ গ্রেড")]
        public string Grade { get; set; }
        [Display(Name = "মূল বেতন")]
        public int MainSalary { get; set; }
        [Display(Name = "প্রাপ্য মূল বেতন")]
        public int PayableMainSalary { get; set; }
        [Display(Name = "বাড়িভাড়া")]
        public string HouseRent { get; set; }
        [Display(Name = "মহার্ঘ্য ভাতা")]
        public string MoharghoAlloowance { get; set; }
        [Display(Name = "চিকিৎসা ভাতা")]
        public string MedicalAllowance { get; set; }
        [Display(Name = "টেলিফোন ভাতা")]
        public string TelephoneAllowance { get; set; }
        [Display(Name = "শিক্ষা সহয়তা ভাতা")]
        public string CurriculumAssitanceAllowance { get; set; }
        [Display(Name = "প্রক্টর/ সহকারী প্রক্টর ভাতা")]
        public string AssistantProctorAllowance { get; set; }
        [Display(Name = "ডিন ভাতা")]
        public string DeanAllowance { get; set; }
        [Display(Name = "চেয়ারম্যান ভাতা")]
        public string ChairmanAllowance { get; set; }
        [Display(Name = "প্রোভোস্ট ভাতা")]
        public string ProvostAllowance { get; set; }
        [Display(Name = "সহকারী প্রোভোস্ট ভাতা")]
        public string AssistantProvostAllowance { get; set; }
        [Display(Name = "ওয়ার্ডেন পরিচালক ভাতা")]
        public string WardenDirectorAllowance { get; set; }
        [Display(Name = "শিক্ষার্থী উপদেস্টা ভাতা")]
        public string StudentAdvisorAllowance { get; set; }
        [Display(Name = "গবেষনা ভাতা")]
        public string ResearchAllowance { get; set; }
        [Display(Name = "বই ভাতা")]
        public string BookAllowance { get; set; }
        [Display(Name = "অতিরিক্ত দায়িত্ব ভাতা")]
        public string AdditionalDutiesAllowance { get; set; }
        [Display(Name = "প্রেষণ ভাতা")]
        public string PresonAllowance { get; set; }
        [Display(Name = "অন্যান্য(যদি থাকে) ")]
        public string OthersAddition { get; set; }
        [Display(Name = "সমন্বয়")]
        public string Somonnoy { get; set; }
        [Display(Name = "সর্বমোট")]
        public string Total { get; set; }
        [Display(Name = "ভবিষ্যৎ তহবিল")]
        public string GPF { get; set; }
        [Display(Name = "ছাত্র কল্যান তহবিল")]
        public string BF { get; set; }
        [Display(Name = "ভবিষ্যৎ তহবিল আগাম প্রদান")]
        public string FutureFund { get; set; }
        [Display(Name = "পরিবহন সুবিধা")]
        public string TransportationAllowance { get; set; }
        [Display(Name = "আয়কর")]
        public string IncomeTax { get; set; }
        [Display(Name = "রেভিনিউ স্ট্যাম্প")]
        public string RevenueStamp { get; set; }
        [Display(Name = "কল্যান ফান্ড")]
        public string DevelopmentFund{ get; set; }
        [Display(Name = "ছাত্র কল্যান ভাতা")]
        public string StudentDevelopmentFund{get;set;}
        [Display(Name = "শিক্ষক পরিবার কল্যান")]
        public string TeacherFamilyDevelopment{get;set;}
        [Display(Name = "ক্লাব")]
        public string Club{ get; set; }
        [Display(Name = "বাসা ভাড়া")]
        public string HouseRentSub{ get; set; }
        [Display(Name = "গ্যাস বিল")]
        public string GasBill { get; set; }
        [Display(Name = "ইন্টারনেট বিল")]
        public string InternetBill {get; set; }
        [Display(Name = "গ্রুপ ইন্সুরেন্স")]
        public string GroupInsurance {get; set; }
        [Display(Name = "মোট কর্তন")]
        public string TotalSubtraction { get; set; }
        [Display(Name = "নীট বেতন ভাতা")]
        public string NeatSalary { get; set; }
        [Display(Name = "উৎসব ভাতা")]
        public string FestivalAllowance { get; set; }

    }
}