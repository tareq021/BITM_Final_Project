using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace UniversityApplication.BLL
{
    public class SemesterManager
    {

            SemesterGateway gateway = new SemesterGateway();
            public List<string> GetSemester()
            {
                return gateway.GetSemester();
            }
        
    }
}