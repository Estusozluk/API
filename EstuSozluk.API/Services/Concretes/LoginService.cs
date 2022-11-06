using System;
using System.Linq;
using EstuSozluk.API.Models;
using EstuSozluk.API.Models.Dtos;
using EstuSozluk.API.Models.Mappers;
using EstuSozluk.API.Repositories;
using EstuSozluk.API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EstuSozluk.API.Services.Concretes
{
    public class LoginService : ILoginService
    {

        EstuSozlukContext _estuSozlukContext; 

        public LoginService(EstuSozlukContext context)
        {
            _estuSozlukContext = context;
        }

        public bool CheckIfUserExists(String username)
        {

            return _estuSozlukContext.Users.Where(e => e.username == username).Count() > 0;

           
        }

        public User Login(UserLoginDto UserLoginDto)
        {
           

            


            return _estuSozlukContext.Users.Where(e => e.username == UserLoginDto.username && e.password == UserLoginDto.password).First();
        }

        public User SaveUser(UserRegistrationDto user)
        {
            User userToSave = UserMapper.GetUserFromUserRegistrationDto(user);
            _estuSozlukContext.Users.Add(userToSave);
            _estuSozlukContext.SaveChanges();
            return userToSave;
        }
    }
}

