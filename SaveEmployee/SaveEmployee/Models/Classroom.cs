using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Classroom
    {
        [Required]
        [DisplayName("Department")]
        public string ClassRoomDepartmentCode { get; set; }
        [Required]
        [DisplayName("Course")]
        public string ClassRoomCourseCode { get; set; }
        [Required]
        [DisplayName("Room No")]
        public string ClassRoomRoomNo { get; set; }
        [Required]
        [DisplayName("Day")]
        public string ClassRoomWeekDay { get; set; }
        [Required]
        [DisplayName("From")]
        [DataType(DataType.Time)]
        [Remote("IsStartTimeAvailable", "Classrooms", AdditionalFields = "ClassRoomWeekDay,ClassRoomRoomNo", ErrorMessage = "Time slot is in use.")]
        public TimeSpan ClassRoomStartsAt { get; set; }
        [Required]
        [DisplayName("To")]
        [DataType(DataType.Time)]
        [Remote("IsStartAndEndTimeAvailable", "Classrooms", AdditionalFields = "ClassRoomStartsAt,ClassRoomWeekDay,ClassRoomRoomNo", ErrorMessage = "Time slot is in use.")]
        public TimeSpan ClassRoomEndssAt { get; set; }
        public int ClassroomId { get; set; }
    }
}