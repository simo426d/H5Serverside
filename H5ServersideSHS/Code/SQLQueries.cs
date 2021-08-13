using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
//using H5ServersideSHS.Areas.ToDoList.Models;

namespace H5ServersideSHS.Code
{
    public class SQLQueries
    {
        SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Serverside;Trusted_Connection=True;MultipleActiveResultSets=true");
        //InfoModel info = new();

        // Et forsøg på at finde UserID

        //public async Task<string> GetId(string userID, IServiceProvider _serviceProvider)
        //{
        //    var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //    await UserManager.GetUserIdAsync(userID);


        //    //int id = Convert.ToInt32(identityUser);
        //    return userID;
        //}

        public void InsertData()
        {
            
            //SqlCommand cmd = new SqlCommand(null, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //con.Open();
            //cmd.CommandText = "INSERT INTO Info(UserName, Titel, Beskrivelse) VALUES(@UserName, @Titel, @Beskrivelse)";
            //cmd.Parameters.AddWithValue("@UserName", info.UserName);
            //cmd.Parameters.AddWithValue("@Titel", info.Titel);
            //cmd.Parameters.AddWithValue("@Beskrivelse", info.Beskrivelse);
            //cmd.ExecuteNonQuery();
            //con.Close();
             
        }

        public void DisplayData()
        {
            //SqlCommand cmd = new SqlCommand(null, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //con.Open();
            //cmd.CommandText = "SELECT FROM Info(UserName, Titel, Beskrivelse) WHERE UserName=@UserName";
            //cmd.Parameters.AddWithValue("@UserName", info.UserName);
            //cmd.ExecuteNonQuery();
            //con.Close();
        }


    }
}
