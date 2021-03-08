using System;

namespace FreePro.Domain
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Amount { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; }
    }
}