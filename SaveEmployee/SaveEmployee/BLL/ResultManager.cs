using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace UniversityApplication.BLL
{
    public class ResultManager
    {
        ResultGateway gateway = new ResultGateway();
        public List<string> GetResults()
        {
            return gateway.GetResults();
        }
    }
}