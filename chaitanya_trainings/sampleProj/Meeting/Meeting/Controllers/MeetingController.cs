using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meeting.Models;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Enums.Calendar;
using DayPilot.Web.Mvc.Events.Calendar;
using System.Text.RegularExpressions;
using Meeting.Models;
namespace Meeting.Controllers
{
    public class MeetingController : Controller
    {
        //
        // GET: /Meeting/
        meetingEntities ds = new meetingEntities();

       
        public ActionResult Booking()
        {
            //MeetingEntities ds = new MeetingEntities();
            string useralias = Request.LogonUserIdentity.Name;
            string[] userfullstring;
            userfullstring = useralias.Split(new char[] { '\\' });
            ViewBag.Username = userfullstring[1];


            return View();
        }

      


        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        public class Dpc : DayPilotCalendar
        {
            public int ConferenceID = 01;
            protected override void OnCommand(CommandArgs e)
            {

                if (e.Data["ConferenceID"] != null)
                    ConferenceID = Convert.ToInt16(e.Data["ConferenceID"].ToString());
                else
                    ConferenceID = 01;
                switch (e.Command)
                {

                    case "refresh":
                        Update(CallBackUpdateType.EventsOnly);
                        break;

                    case "goto":
                        DateTime dt = new DateTime();

                        dt = (DateTime)e.Data["start"];

                        string[] startsplit = dt.ToString("dd/MM/yyyy HH:mm:ss").Split(new char[] { ' ' });
                        if (e.Data["ConferenceID"] != null)
                            ConferenceID = Convert.ToInt16(e.Data["ConferenceID"].ToString());
                        else
                            ConferenceID = 01;
                        ConferenceID = Convert.ToInt16(e.Data["ConferenceID"].ToString());
                         StartDate = (DateTime)(e.Data["start"]);
                       // StartDate = (DateTime)(startsplit[0] + "00:00:00");
                      //  StartDate = (DateTime)(e.Data["start"]);   Date = {21-09-2013 00:00:00}
                        StartDate = (DateTime)Convert.ToDateTime(startsplit[0] + " 12:00:00 AM");
                      //  StartDate = (DateTime)Convert.ToDateTime(startsplit[0]);
                     //   StartDate = (DateTime)(e.Data["start"]);
                        //  ViewType = DayPilot.Web.Mvc.Enums.Calendar.ViewType.WorkWeek;
                        if (e.Data["viewType"].ToString() == "Week")
                            ViewType = DayPilot.Web.Mvc.Enums.Calendar.ViewType.WorkWeek;

                        else if (e.Data["viewType"].ToString() == "Day")
                            ViewType = DayPilot.Web.Mvc.Enums.Calendar.ViewType.Day;


                        Update(CallBackUpdateType.Full);

                        break;
                }
            }



            protected override void OnInit(InitArgs e)
            {


                Update(CallBackUpdateType.Full);
            }






            protected override void OnPrepare()
            {
                base.OnPrepare();
                //BusinessBeginsHour = 11;
                //BusinessEndsHour = 19;
            }



            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }
                meetingEntities da = new meetingEntities();

                Events = from ev in da.EVENTs
                         where ev.CONFROOMID == ConferenceID
                         select ev;

              
             

                DataIdField = "id";
                DataTextField = "text";
                DataStartField = "eventstart";
                DataEndField = "eventend";


            }
        }

    }



}

