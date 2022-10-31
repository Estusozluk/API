using System;
namespace EstuSozluk.API.Models
{
    public class Entry
    {
        public int entryId { get; set; }
        public int userId { get; set; }
        public int titleId { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public DateTime editDate { get; set; }


    }
}
