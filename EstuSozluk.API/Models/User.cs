using System;
namespace EstuSozluk.API.Models
{
    public class User
    {
       public string username { get; set; }
       public string email { get; set; }
       public string password { get; set; }
       public string nickname { get; set; }
       public int roleId { get; set; }
    }
}
