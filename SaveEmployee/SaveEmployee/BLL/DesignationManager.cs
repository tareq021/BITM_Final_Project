using System.Collections.Generic;
using UniversityApplication.DAL;

namespace UniversityApplication.BLL
{
    public class DesignationManager
    {
        DesignationGateway gateway = new DesignationGateway();
        public List<string> GetDesignation()
        {
            return gateway.GetDesignation();
        }
    }
}