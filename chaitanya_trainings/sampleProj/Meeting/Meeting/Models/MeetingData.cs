using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Models
{
    public class MeetingData
    {
     

        public string title { get; set; }

        //  [Required]
        public string project { get; set; }

        //  [Required]
        public string stratTime { get; set; }

        //   [Required]
        public string endTime { get; set; }

        public string ConferenceRoomId { get; set; }

        public string username { get; set; }

        public bool status { get; set; }

        public IEnumerable<MeetingRoomslist> rooms { get; set; }




    }

    public class MeetingRoomslist
    {
        public decimal value { get; set; }
        public string name { get; set; }
    }
}