namespace FreePro.Domain
{
    public class HosterMeeting
    {
        public int HosterId { get; set; }
        public Hoster Hoster { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}