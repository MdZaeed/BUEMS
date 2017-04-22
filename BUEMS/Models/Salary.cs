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
        [Display(Name = "যোগদানের তারিখ")]
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
        public int HouseRent { get; set; }
        [Display(Name = "মহার্ঘ্য ভাতা")]
        public int MoharghoAlloowance { get; set; }
        [Display(Name = "চিকিৎসা ভাতা")]
        public int MedicalAllowance { get; set; }
        [Display(Name = "টেলিফোন ভাতা")]
        public int TelephoneAllowance { get; set; }
        [Display(Name = "শিক্ষা সহয়তা ভাতা")]
        public int CurriculumAssitanceAllowance { get; set; }
        [Display(Name = "প্রক্টর/ সহকারী প্রক্টর ভাতা")]
        public int AssistantProctorAllowance { get; set; }
        [Display(Name = "ডিন ভাতা")]
        public int DeanAllowance { get; set; }
        [Display(Name = "চেয়ারম্যান ভাতা")]
        public int ChairmanAllowance { get; set; }
        [Display(Name = "প্রোভোস্ট ভাতা")]
        public int ProvostAllowance { get; set; }
        [Display(Name = "সহকারী প্রোভোস্ট ভাতা")]
        public int AssistantProvostAllowance { get; set; }
        [Display(Name = "ওয়ার্ডেন পরিচালক ভাতা")]
        public int WardenDirectorAllowance { get; set; }
        [Display(Name = "শিক্ষার্থী উপদেস্টা ভাতা")]
        public int StudentAdvisorAllowance { get; set; }
        [Display(Name = "গবেষনা ভাতা")]
        public int ResearchAllowance { get; set; }
        [Display(Name = "বই ভাতা")]
        public int BookAllowance { get; set; }
        [Display(Name = "অতিরিক্ত দায়িত্ব ভাতা")]
        public int AdditionalDutiesAllowance { get; set; }
        [Display(Name = "প্রেষণ ভাতা")]
        public int PresonAllowance { get; set; }
        [Display(Name = "অন্যান্য(যদি থাকে) ")]
        public int OthersAddition { get; set; }
        [Display(Name = "সমন্বয়")]
        public int Somonnoy { get; set; }
        [Display(Name = "সর্বমোট")]
        public int Total { get; set; }
        [Display(Name = "ভবিষ্যৎ তহবিল")]
        public int GPF { get; set; }
        [Display(Name = "ছাত্র কল্যান তহবিল")]
        public int BF { get; set; }
        [Display(Name = "ভবিষ্যৎ তহবিল আগাম প্রদান")]
        public int FutureFund { get; set; }
        [Display(Name = "পরিবহন সুবিধা")]
        public int TransportationAllowance { get; set; }
        [Display(Name = "আয়কর")]
        public int IncomeTax { get; set; }
        [Display(Name = "রেভিনিউ স্ট্যাম্প")]
        public int RevenueStamp { get; set; }
        [Display(Name = "কল্যান ফান্ড")]
        public int DevelopmentFund{ get; set; }
        [Display(Name = "ছাত্র কল্যান ভাতা")]
        public int StudentDevelopmentFund{get;set;}
        [Display(Name = "শিক্ষক পরিবার কল্যান")]
        public int TeacherFamilyDevelopment{get;set;}
        [Display(Name = "ক্লাব")]
        public int Club{ get; set; }
        [Display(Name = "বাসা ভাড়া")]
        public int HouseRentSub{ get; set; }
        [Display(Name = "গ্যাস বিল")]
        public int GasBill { get; set; }
        [Display(Name = "ইন্টারনেট বিল")]
        public int InternetBill {get; set; }
        [Display(Name = "গ্রুপ ইন্সুরেন্স")]
        public int GroupInsurance {get; set; }
        [Display(Name = "মোট কর্তন")]
        public int TotalSubtraction { get; set; }
        [Display(Name = "নীট বেতন ভাতা")]
        public int NeatSalary { get; set; }
        [Display(Name = "উৎসব ভাতা")]
        public int FestivalAllowance { get; set; }

    }
}