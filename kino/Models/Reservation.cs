namespace Kino.Models
{
    public class Reservation
    {
        public string UserEmail { get; set; }
        public string MovieTitle { get; set; }
        public string ShowTime { get; set; }
        public List<string> Seats { get; set; }
        public List<string> Snacks { get; set; }
    }
}