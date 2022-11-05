using System.Collections.Generic;

namespace EstuSozluk.API.Models
{
    public class UserFollows
    {
        public UserFollows()
        {
            this.Entries = new List<Entry>();
        }

        public virtual User user { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }

    }
}
