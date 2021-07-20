using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using Microsoft.Extensions.Logging;
using TesteMVC.Data;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string connectionString;
        DBCONN conn0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connectionString = "Data Source=DBMVC.db;Mode=ReadWrite;Cache=Default";
            conn0 = new DBCONN(connectionString);
            conn0.Open();            
        }

        public IActionResult Index()
        {
//            return View();
            Pessoa pessoa;// = new Pessoa();
            List<Pessoa> lstPessoas = new List<Pessoa>();
            
            Genericos genericos = new Genericos();
            SQLiteDataReader pessoas  = conn0.Consulta("SELECT  NOME, SOBRENOME, CIDADE FROM PESSOA");
            
            while (pessoas.Read())
            {
                genericos.ConvertReaderToRelevantModel(pessoas, pessoa = new Pessoa());
                lstPessoas.Add(pessoa);

            }
          
/*            pessoa = new Pessoa("jorge", "sato", "suzano");
            lstPessoas.Add (pessoa);
            pessoa = new Pessoa("jorge2", "sato2", "suzano2");
            lstPessoas.Add (pessoa);
*/            
            return View(lstPessoas.ToList());
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
