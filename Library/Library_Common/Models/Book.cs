namespace LibraryCommon.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
    }
}
