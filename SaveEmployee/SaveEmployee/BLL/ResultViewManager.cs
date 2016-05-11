using SaveEmployee.DAL;
using SaveEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace SaveEmployee.BLL
{
    public class ResultViewManager
    {
        
        ResultViewGateway gateway = new ResultViewGateway();
        public List<ViewResult> GetCourseInfos(string regNo)
        {
            return gateway.GetCourseInfos(regNo);
        }
    }
}