using System;
using System.Data;
using EstuSozluk.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace EstuSozluk.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        /*
                [HttpPost]
                [Route("register")]
                public string RegisterNewUser(User user)
                {
                    MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("Default").ToString());
                    MySqlCommand command = new MySqlCommand("INSERT INTO Users(username, email, password, userrole) VALUES('"+user.username+ "', '" + user.email + "', '" + user.password + "', '" + user.roleId + "')", con);
                    con.Open();
                    int i = command.ExecuteNonQuery();
                    con.Close();

                    if (i > 0)
                    {
                        return "Registration is done successfully!";
                    }
                    else
                    {
                        return "Error";
                    }
                    return "";

                }

                [HttpPost]
                [Route("login")]
                public string UserLogin(User user)
                {
                    MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("Default").ToString());
                    con.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE email = '" + user.email + "' AND password = '" + user.password + "'", con);

                    MySqlDataAdapter da = new MySqlDataAdapter(command);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        return "Login Successfully!";
                    }

                    else
                    {
                        return "Error!";
                    }
                    con.Close();
                    return "";
                }`
                */
    }
}
