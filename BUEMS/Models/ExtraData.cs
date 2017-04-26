using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class MonthMap
    {
        public string MonthNameInBangla { get; set; }
        public string MonthNameInEnglish { get; set; }

        public static List<MonthMap> GetMonthData()
        {
            var data= new List<MonthMap>()
            {
                new MonthMap(){MonthNameInBangla = "জানুয়ারি" , MonthNameInEnglish = "January"},
                new MonthMap(){MonthNameInBangla = "ফেব্রুয়ারি" , MonthNameInEnglish = "February"},
                new MonthMap(){MonthNameInBangla = "মার্চ" , MonthNameInEnglish = "March"},
                new MonthMap(){MonthNameInBangla = "এপ্রিল" , MonthNameInEnglish = "April"},
                new MonthMap(){MonthNameInBangla = "মে" , MonthNameInEnglish = "May"},
                new MonthMap(){MonthNameInBangla = "জুন" , MonthNameInEnglish = "June"},
                new MonthMap(){MonthNameInBangla = "জুলাই" , MonthNameInEnglish = "July"},
                new MonthMap(){MonthNameInBangla = "আগস্ট" , MonthNameInEnglish = "August"},
                new MonthMap(){MonthNameInBangla = "সেপ্টেম্বর" , MonthNameInEnglish = "September"},
                new MonthMap(){MonthNameInBangla = "অক্টোবর" , MonthNameInEnglish = "October"},
                new MonthMap(){MonthNameInBangla = "নভেম্বের" , MonthNameInEnglish = "November"},
                new MonthMap(){MonthNameInBangla = "ডিসেম্বর" , MonthNameInEnglish = "December"}
            };
            return data;
        }
    }
}