using System;
using System.Collections.Generic;

namespace EstuSozluk.API.Models
{
    public class UserConstrants
    {
        public static List<User> users = new List<User>()
        {
            new User() {username = "ahmetjorganxhi", email = "ahmetjorganxhi@gmail.com", password="ahmet123", nickname="ahmet", roleId=1},
            new User() {username = "ardijorganxhi", email = "ardijorganxhi@gmail.com", password="ardi123", nickname="ardi", roleId=1},
        };
    }
}
