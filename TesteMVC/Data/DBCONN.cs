using System;
using System.Data;
using System.Reflection;
//using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace TesteMVC.Data
{
    public class DBCONN
    {
        //public SqliteConnection Conn ;
        public SQLiteConnection Conn;
        public string strConnection { get; set; }
        //public SqliteCommand sqlCommand { get; set; }
        public SQLiteCommand sqlCommand { get; set; }
        
        public DBCONN(string _strConnection)
        {
            strConnection = _strConnection;
            //Conn = new SqliteConnection(strConnection);
            Conn = new SQLiteConnection(strConnection);
        }
        public DBCONN()
        {
            //Conn = new SqliteConnection(strConnection);
            Conn = new SQLiteConnection (strConnection);
        }        
        public void Close()
        {
            Conn.Close();
        }
        public void Open()
        {
            Conn.Open();
        }
        public void Executa(string sqlExpression)
        {
            long i;
            sqlCommand = new SQLiteCommand (sqlExpression, Conn);
            //sqlCommand.CommandType = System.Data.CommandType.Text;
            //sqlCommand.CommandText = sqlExpression;
            i = sqlCommand.ExecuteNonQuery();
        }
        public void GravaObj( Object _ent, string _tabName)
        {
            Type inteiro = typeof(System.Int32);
            Type type = _ent.GetType();
            string FieldName ;
            string FieldValueStr;
            string strSQL;
            string strValues;
            FieldValueStr = "";
            strSQL = "INSERT INTO " + _tabName + " (";
            strValues = " Values (";

             foreach(PropertyInfo pi in type.GetProperties())
             {
                FieldName = pi.Name;
                FieldValueStr = pi.GetValue(_ent).ToString();
                strSQL = strSQL + (strSQL.Substring(strSQL.Length - 1, 1) == "("?"":",") + FieldName;
                //tive que declarar um tipo Type para fazer a comparação
                if (pi.GetValue(_ent).GetType().Equals(inteiro))
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + FieldValueStr;
                }
                else
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + "'" + FieldValueStr + "'";
                }
                
             }
             strSQL = strSQL + " )";
             strValues = strValues + " )";
             
             Executa(strSQL + strValues);
        }

        public void CarregaObj( Object _ent, string _tabName)
        {
            Type inteiro = typeof(System.Int32);
            Type type = _ent.GetType();
            string FieldName ;
            string FieldValueStr;
            string strSQL;
            string strValues;
            FieldValueStr = "";
            strSQL = "SELECT * FROM " + _tabName + " ";
            strValues = "";

             foreach(PropertyInfo pi in type.GetProperties())
             {
                FieldName = pi.Name;
                FieldValueStr = pi.GetValue(_ent).ToString();
                strSQL = strSQL + (strSQL.Substring(strSQL.Length - 1, 1) == "("?"":",") + FieldName;
                //tive que declarar um tipo Type para fazer a comparação
                if (pi.GetValue(_ent).GetType().Equals(inteiro))
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + FieldValueStr;
                }
                else
                {
                    strValues  = strValues + (strValues.Substring(strValues.Length - 1, 1) == "("?"":",") + "'" + FieldValueStr + "'";
                }
                
             }
             strSQL = strSQL + " )";
             strValues = strValues + " )";
             
             Executa(strSQL + strValues);
        }        
        public SQLiteDataReader  Consulta(string _sqlQuery)
        {
             
            SQLiteCommand   _cmd = new SQLiteCommand (_sqlQuery, Conn);

            SQLiteDataReader _sqlDataReader = _cmd.ExecuteReader();
            return _sqlDataReader;
        }
        /*public Object ToObj(SqliteDataReader dados, Type _tabName)
        {
            Object obj;
            DataTable dt;
            dt = dados.GetSchemaTable();
            foreach(DataRow row in dt.Rows)
            {

            }
            return obj;
        }
        */
        
    }
}