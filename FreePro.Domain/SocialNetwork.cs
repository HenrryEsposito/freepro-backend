namespace FreePro.Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; }
        public int HosterId { get; set; }
        public Hoster Hoster { get; }


    }
}