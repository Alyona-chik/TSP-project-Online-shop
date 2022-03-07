using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ZooStore.Controllers
{
    public class DatabaseConnectionController : Controller
    {
        private readonly IConfiguration m_oConfiguration;

        public DatabaseConnectionController(IConfiguration oConfiguration)
        {
            this.m_oConfiguration = oConfiguration;
        }

        public IActionResult Index()
        {
            string strConnection = m_oConfiguration.GetConnectionString("DefaultConnectionString");

            SqlConnection connection = new SqlConnection(strConnection);
            connection.Open();
            SqlCommand oSqlCommand = new SqlCommand("Select count(*) from Login", connection);
            int nCount = (int)oSqlCommand.ExecuteScalar();

            ViewData["Total"] = nCount;
            connection.Close();
            return View();
        }
    }
}
