namespace part3_poe.Models
{
    public class get_viewEvents
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Distance { get; set; }
        public string EventType { get; set; }
        public int Age { get; set; }
        public TimeSpan StartTime { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int JoinedCount { get; set; }
    }
}