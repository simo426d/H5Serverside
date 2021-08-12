using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5ServersideSHS.Code;
using H5ServersideSHS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace H5ServersideSHS.Areas.ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Serverside;Trusted_Connection=True;MultipleActiveResultSets=true");
        InfoModel info = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InfoModel info)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(InsertData(info))
                    {
                        ViewBag.Message = "Succes";
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }

            
        }

        public bool InsertData(InfoModel obj)
        {

            SqlCommand cmd = new SqlCommand(null, con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.CommandText = "INSERT INTO Info(UserName, Titel, Beskrivelse) VALUES(@UserID, @Titel, @Beskrivelse)";
            cmd.Parameters.AddWithValue("@UserName", info.UserName);
            cmd.Parameters.AddWithValue("@Titel", info.Titel);
            cmd.Parameters.AddWithValue("@Beskrivelse", info.Beskrivelse);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }

}
