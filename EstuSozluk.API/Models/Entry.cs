using System;
using System.Collections.Generic;

namespace EstuSozluk.API.Models
{
    public class Entry
    {
        public int entryId { get; set; }
        public int userId { get; set; }
        public string titleName { get; set; }
        public string content { get; set; }
        public DateTime writeDate { get; set; }
        public DateTime editDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<LikedEntries> LikedEntries { get; set; }
        public virtual ICollection<DislikedEntries> DislikedEntries { get; set; }
        

    }
}
