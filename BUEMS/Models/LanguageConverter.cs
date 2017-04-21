using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public static class LanguageConverter
    {

        public static string EnglishToBangla(string english)
        {
            string bengali_text = string.Concat(english.Select(c => (char)('\u09E6' + c - '0'))); // "১২৩৪৫৬৭৮৯০"
            return bengali_text;
        }
        public static string BanglaToEnglish(string bangla)
        {
            string english_text = string.Concat(bangla.Select(c => (char)('0' + c - '\u09E6'))); // "1234567890"
            return english_text;
        }
    }
}