using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUEMS.Models
{
    public static class DropDownDataCreator
    {
        public static List<SelectListItem> GetGradesDropDownData(List<Grade> grades)
        {
            List<SelectListItem> dataList = new List<SelectListItem>();
            foreach(Grade grade in grades)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = grade.GradeRange,
                    Value = grade.GradeRange
                };
                dataList.Add(item);
            }

            return dataList;
        }
    }
}