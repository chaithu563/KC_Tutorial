using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Meeting.Models;
using System.Data.Objects.SqlClient;
namespace Meeting.Controllers
{
    public class MeetingAPIController : ApiController
    {
        meetingEntities ds = new meetingEntities();

        [ActionName("getRooms")]
        [HttpGet]
        public IEnumerable<MeetingRoomslist> getRooms()
        {
           
            //List<MeetingRoomslist> obj = new List<Employee>();
            //obj.Add(new Employee("chaita1", "1"));
            //obj.Add(new Employee("chaita2", "2"));

          //return obj;
            IEnumerable<MeetingRoomslist> rooms = ds.MEETINGROOMs.Select(x => new MeetingRoomslist
                {
                    name = x.NAME,
                    value = x.ID
                   
                });

            return rooms;


        }



        [ActionName("SubmitMeeting")]
        [HttpGet]
        public void SubmitMeeting(string title, string project, string stratTime, string endTime, string ConferenceRoomId, string username)
        {
            string uid;
            if (ds.USERS.Any(x => x.NAME == username))
            {
                uid = ds.USERS.Single(x => x.NAME == username).ID.ToString();
            }

            else
            {
                USER usr = new USER { NAME = username };

                ds.USERS.Add(usr);
                ds.SaveChanges();
                uid = ds.USERS.Single(x => x.NAME == username).ID.ToString();

            }
            var toBeCreated = new EVENT
            {
                TEXT = title,
               
              //  PROJECT = data.project,
                EVENTSTART = Convert.ToDateTime(stratTime),
                EVENTEND = Convert.ToDateTime(endTime),
                CONFROOMID = Convert.ToInt16(ConferenceRoomId),
               // PROJECT   =project,

                USERID =Convert.ToInt16(uid),
                STATUS = "Booked"
            };


            ds.EVENTs.Add(toBeCreated);

            ds.SaveChanges();
        }



        [ActionName("UpdateMeeting")]
        [HttpGet]
        public void UpdateMeeting(string eventid,string title, string project, string stratTime, string endTime, string ConferenceRoomId, string username)
        {
            Decimal eid = DecimalTryParseOrZero(eventid);
            EVENT eventObj = ds.EVENTs.Where(e => e.ID == eid).First();
            eventObj. TEXT = title;
         
               
              //  PROJECT = data.project,
               eventObj.EVENTSTART = Convert.ToDateTime(stratTime);
                eventObj. EVENTEND = Convert.ToDateTime(endTime);
                eventObj. CONFROOMID = Convert.ToInt16(ConferenceRoomId);
              //  eventObj. PROJECT   =project;


            ds.SaveChanges();
        }


        [ActionName("DeleteMeeting")]
        [HttpGet]
        public void DeleteMeeting(string eventid)
        {
            Decimal eid = DecimalTryParseOrZero(eventid);
            EVENT eventObj = ds.EVENTs.Where(e => e.ID == eid).First();

            ds.EVENTs.Remove(eventObj);
            ds.SaveChanges();
        }

        [ActionName("isConflicts")]
        [HttpGet]
        public bool isConflicts(string stratTime, string endTime, string ConferenceRoomId)
        {
            Boolean result=false;
           
            Decimal confid=DecimalTryParseOrZero(ConferenceRoomId);
            DateTime clientstart = Convert.ToDateTime(stratTime);
            DateTime clientend = Convert.ToDateTime(endTime);
            //var conflicEvents = from v in ds.EVENTS
            //                    where v.CONFROOMID == confid
            //                    where clientstart > v.EVENTSTART
            //                    where clientstart < v.EVENTEND
            //                    where clientend > v.EVENTSTART
            //                    where clientend < v.EVENTEND
            //                    where (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART)
            //                    select v.ID;
            var conflicEvents = from v in ds.EVENTs
                                where v.CONFROOMID == confid &&
                                ( (clientstart > v.EVENTSTART && clientstart < v.EVENTEND)
                                || (clientend > v.EVENTSTART && clientend < v.EVENTEND)
                                || (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART))
                                select v.ID;


            if (conflicEvents.Count() != 0)
                result = true;


            return result;
        }


        [ActionName("isUpdateConflicts")]
        [HttpGet]
        public bool isUpdateConflicts(string stratTime, string endTime, string ConferenceRoomId, string eventid)
        {
            Boolean result = false;
            Decimal evid = DecimalTryParseOrZero(eventid);
            Decimal confid = DecimalTryParseOrZero(ConferenceRoomId);
            DateTime clientstart = Convert.ToDateTime(stratTime);
            DateTime clientend = Convert.ToDateTime(endTime);
            //var conflicEvents = from v in ds.EVENTS
            //                    where v.CONFROOMID == confid
            //                    where clientstart > v.EVENTSTART
            //                    where clientstart < v.EVENTEND
            //                    where clientend > v.EVENTSTART
            //                    where clientend < v.EVENTEND
            //                    where (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART)
            //                    select v.ID;
            var conflicEvents = from v in ds.EVENTs
                                where v.CONFROOMID == confid && v.ID != evid &&
                                ((clientstart > v.EVENTSTART && clientstart < v.EVENTEND)
                                || (clientend > v.EVENTSTART && clientend < v.EVENTEND)
                                || (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART))
                                select v.ID;


            if (conflicEvents.Count() != 0)
                result = true;


            return result;
        }

        [ActionName("isBookedUser")]
        [HttpGet]
        public MeetingData isBookedUser(string eid, string user)
        {
            Boolean result = false;
            string value = eid;
            decimal deventid = DecimalTryParseOrZero(eid);

            //var euserid = (from ev in ds.EVENTS 
            //              join use in  ds.USERS

            //               // on use.NAME == user
            //              on ev.USERID equals use.ID

            //             where ev.ID==DecimalTryParseOrZero(eid)
            //               select ev.USERID).First();

            string euserid = ds.EVENTs.Single(x => x.ID == deventid).USERID.ToString();

            string uid = ds.USERS.Single(x => x.NAME == user).ID.ToString();


            if (euserid.ToString() == uid)
                result = true;
            decimal eventid = DecimalTryParseOrZero(eid);
            EVENT meetdata = ds.EVENTs.Single(x => x.ID == eventid);

            MeetingData data = new MeetingData
            {
                title = meetdata.TEXT,
               // project = meetdata.PROJECT,
                stratTime = meetdata.EVENTSTART.ToString(),
                endTime = meetdata.EVENTEND.ToString(),
                username = ds.USERS.Single(x => x.ID == meetdata.USERID).NAME,
                status = result
            };


            return data;
        }


        Decimal DecimalTryParseOrZero(String input)
        {
            Decimal d;
            Decimal.TryParse(input, out d);
            return d;
        }

        //[ActionName("getFeatures")]
        //[HttpGet]
        //public List<string> getFeatures(string confid)
        //{
        //    List<string> sroomfeatures = new List<string>();
        //    decimal conid = DecimalTryParseOrZero(confid);
        //    //var data=from f in ds.FEATURES
        //    //       //  where f.ID != null
        //    //           join  rf in ds.ROOMFEATURES
        //    //               on  f.ID equals rf.FEATUREID
        //    //               where rf.ROOMID== conid
        //    //               select f.FEATURE1;


        //   // var roomfeatures = ds.ROOMFEATURES.Select(x => new { x.ROOMID });
        //    //var roomfeatures = from p1 in ds.ROOMFEATURES
        //    //                   select new { p1.ROOMID, p1.FEATUREID, p1.ID };



        //    //var features = from p2 in ds.FEATURES

        //    //               select new { p2.ID, p2.FEATURE1 };


        //    //var featureids = roomfeatures.Where(x => x.ROOMID == conid).Select(x=>x.FEATUREID);


        //    //foreach (var d in featureids)
        //    //{
        //    //    decimal data = DecimalTryParseOrZero(d);
        //    //    string featue = features.First(x => x.ID == data).FEATURE1;
        //    //    sroomfeatures.Add(featue);

        //    //}
        //    //if (sroomfeatures.Count() == 0)
        //    //{
        //    //    sroomfeatures.Add("Not Available");
        //    //    return sroomfeatures;
        //    //}
        //    //else
        //    //{
        //    //    return sroomfeatures;
        //    //}

        //}




        [ActionName("isOutlookConflicts")]
        [HttpGet]
        public bool isOutlookConflicts(string stratTime, string endTime, string ConferenceRoom)
        {
            Boolean result = false;

            Decimal confid = ds.MEETINGROOMs.Single(x => x.NAME == ConferenceRoom).ID;
            DateTime clientstart = Convert.ToDateTime(stratTime);
            DateTime clientend = Convert.ToDateTime(endTime);
            //var conflicEvents = from v in ds.EVENTS
            //                    where v.CONFROOMID == confid
            //                    where clientstart > v.EVENTSTART
            //                    where clientstart < v.EVENTEND
            //                    where clientend > v.EVENTSTART
            //                    where clientend < v.EVENTEND
            //                    where (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART)
            //                    select v.ID;
            var conflicEvents = from v in ds.EVENTs
                                where v.CONFROOMID == confid &&
                                ((clientstart > v.EVENTSTART && clientstart < v.EVENTEND)
                                || (clientend > v.EVENTSTART && clientend < v.EVENTEND)
                                || (clientstart <= v.EVENTSTART && clientend >= v.EVENTSTART))
                                select v.ID;


            if (conflicEvents.Count() != 0)
                result = true;


            return result;
        }


        [ActionName("OutlookSubmitMeeting")]
        [HttpGet]
        public void OutlookSubmitMeeting(string title, string stratTime, string endTime, string username,string ConferenceRoom)
        {
            string uid;
            Decimal confid = ds.MEETINGROOMs.Single(x => x.NAME == ConferenceRoom).ID;
            if (ds.USERS.Any(x => x.NAME == username))
            {
                uid = ds.USERS.Single(x => x.NAME == username).ID.ToString();
            }

            else
            {
                USER usr = new USER { NAME = username };

                ds.USERS.Add(usr);
                ds.SaveChanges();
                uid = ds.USERS.Single(x => x.NAME == username).ID.ToString();

            }
            var toBeCreated = new EVENT
            {
                TEXT = title,

                //  PROJECT = data.project,
                EVENTSTART = Convert.ToDateTime(stratTime),
                EVENTEND = Convert.ToDateTime(endTime),
                CONFROOMID = Convert.ToInt16(confid),
              //  PROJECT = "",

                USERID = Convert.ToInt16(uid),
                STATUS = "Booked"
            };


            ds.EVENTs.Add(toBeCreated);

            ds.SaveChanges();
        }


        [ActionName("OutlookDeleteMeeting")]
        [HttpGet]
        public void OutlookDeleteMeeting(string title, string stratTime, string endTime,  string username,string ConferenceRoom)
        {
         //   Decimal eid = DecimalTryParseOrZero(eventid);
               Decimal confid = ds.MEETINGROOMs.Single(x => x.NAME == ConferenceRoom).ID;


            DateTime  ST= Convert.ToDateTime(stratTime);
            DateTime ET = Convert.ToDateTime(endTime);
               EVENT eventObj = ds.EVENTs.Where(e => (e.TEXT == title && e.EVENTSTART ==ST && e.EVENTEND == ET && e.CONFROOMID == confid)).First();

            ds.EVENTs.Remove(eventObj);
            ds.SaveChanges();
        }
    
    }

 
}