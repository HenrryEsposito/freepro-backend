using System.Collections.Generic;

namespace FreePro.Domain
{
    public class Hoster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCV { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<HosterMeeting> HosterMeetings { get; set; }
    }
}