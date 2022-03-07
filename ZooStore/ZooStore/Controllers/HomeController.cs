using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZooStore.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration m_oConfiguration;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            IConfiguration configuration = configurationBuilder.Build();
            DatabaseConnectionController oDatabaseConnectionController = new DatabaseConnectionController(configuration);
            return oDatabaseConnectionController.Index();

            //SqlConnectionStringBuilder oSqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //oSqlConnectionStringBuilder.ConnectionString = "DataSource = SLAVI,InitialCatalog = Online_Zoo_Store,UserID = PisnaMi,Password = 123456654321";


            //SqlConnection connection = new SqlConnection(oSqlConnectionStringBuilder.ConnectionString);

            //connection.Open();

            //SqlCommand oSqlCommand = new SqlCommand("Select count(*) from Login", connection);
            //int nCount = (int)oSqlCommand.ExecuteScalar();

            //ViewData["Total"] = nCount;

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
