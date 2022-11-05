using System.Collections.Generic;

namespace EstuSozluk.API.Models
{
    public class UserFollowed
    {
        public UserFollowed()
        {
            this.Entries = new List<Entry>();
        }

        public virtual User user { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
