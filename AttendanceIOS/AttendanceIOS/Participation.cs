using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceIOS
{
    public class Participation
    {
     //   public int Id { get; set; }
        public string StudentId { get; set; }
      //  public string ClassId { get; set; }
        public DateTime DateStamp { get; set; }
        public String Code { get; set; }
        public bool Attendance { get; set; }
        public string StudentMessage { get; set; }
    }
}

