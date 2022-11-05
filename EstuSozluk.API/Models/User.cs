using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstuSozluk.API.Models
{
    public class User
    {

        public User()
        {
            this.Entries = new List<Entry>();
        }

        [Key]
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userrole { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
        public virtual IEnumerable<Followships> Following { get; set; }
        public virtual IEnumerable<Followships> Followed { get; set; }

    }
}
