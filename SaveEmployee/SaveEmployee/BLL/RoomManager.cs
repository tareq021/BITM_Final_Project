using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace UniversityApplication.BLL
{
    public class RoomManager
    {
        RoomGateway gateway = new RoomGateway();

        public List<string> GetRooms()
        {
            return gateway.GetRooms();
        }
    }
}