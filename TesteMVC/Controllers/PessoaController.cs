using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteMVC.Data;
//using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Linq;

namespace TesteMVC.Controllers
{
    public class PessoaController : Controller
    {
        string connectionString = "";
        DBCONN conn0;
        public PessoaController()
        {
            
            connectionString = "Data Source=DBMVC.db;Version=3;";            
            conn0 = new DBCONN(connectionString);
//            conn0.Open();
        }
        public ActionResult Index()
        {
            List<Pessoa> lstPessoas = new List<Pessoa>();
            /*
            Genericos genericos = new Genericos();
            SqliteDataReader pessoas  = conn0.Consulta("SELECT NOME, SOBRENOME, CIDADE FROM PESSOA");
            Pessoa pessoa = new Pessoa();
            
            while (pessoas.Read())
            {
                genericos.ConvertReaderToRelevantModel(pessoas,pessoa);
                lstPessoas.Add(pessoa);

            }
            */
            lstPessoas.Add (
                new Pessoa("jorge","sato", "suzano"));
            return View(lstPessoas.ToList());
        }
    }
}