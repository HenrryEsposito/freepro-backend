namespace FreePro.API.Model
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string Place { get; set; }
        public string MeetingDate { get; set; }
        public string Theme { get; set; }
        public int Invited { get; set; }
        public int Batch { get; set; }
        public string ImgUrl { get; set; }
    }
}