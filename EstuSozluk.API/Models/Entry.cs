using System;
using System.ComponentModel.DataAnnotations;

namespace EstuSozluk.API.Models
{
    public class Entry
    {
        [Key]
        public int entryId { get; set; }
        public string entryuser { get; set; }
        public string titlename { get; set; }
        public string content { get; set; }
        public DateTime writedate { get; set; }
        public DateTime edittade { get; set; }

        public virtual User User { get; set; }
    }
}
