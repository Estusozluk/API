using System;
using EstuSozluk.API.Models;
using EstuSozluk.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EstuSozluk.API.Services.Abstracts
{
    public interface ILoginService
    {

        public object GetUser(String username);
        public User SaveUser(UserRegistrationDto user);
        public object Login(UserLoginDto UserLoginDto);

        public Followships Follow(FollowshipsDto followshipsDto);

        public object UpdateUser(int userid, UserUpdateDto UserUpdateDto);

        //public object GetUserByUsername(String Username);




    }
}

