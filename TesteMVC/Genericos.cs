using System;
using System.Diagnostics;
using System.IO;
//using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace TesteMVC
{
    public class Genericos
    {
        public Genericos()
        {
            
        }
        public void ConvertReaderToRelevantModel(SQLiteDataReader reader, object model)
        {
            try{
                foreach (var item in model.GetType().GetProperties())
                {
                    if (item.Name == "ID")
                    {
                        model.GetType().GetProperty(item.Name).SetValue(model, Convert.ToInt32(reader[item.Name] == DBNull.Value ? 0 :  reader[item.Name]) , null);
                     //   model.GetType().GetProperty(item.Name).SetValue(model, Convert.ToInt32(reader[item.Name]), null);
                    }
                    else if (item.Name == "DATA")
                    {
                        model.GetType().GetProperty(item.Name).SetValue(model, reader[item.Name] == DBNull.Value ? "" :  reader[item.Name] , null);
                    }
                    else
                    {
                        model.GetType().GetProperty(item.Name).SetValue(model, reader[item.Name] == DBNull.Value ? "" :  reader[item.Name], null);
                    } 
                }
 
            }       
            catch(IOException e)
            {
                Debug.Print("Text" + e);
            }
    
        }
    }
}