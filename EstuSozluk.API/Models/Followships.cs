namespace EstuSozluk.API.Models
{
    public class Followships
    {
        public string follower { get; set; }
        public virtual User User1 { get; set; }
        public string followed { get; set; }
        public virtual User User2 { get; set; }

    }
}
