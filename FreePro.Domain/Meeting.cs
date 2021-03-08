using System;
using System.Collections.Generic;

namespace FreePro.Domain
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Theme { get; set; }
        public int Invited { get; set; }
        public string Phone { get; set; }
        public List<Batch> Batches { get; set; }
        public string ImgUrl { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<HosterMeeting> HosterMeetings { get; set; }
    }
}