using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Oversight.Models
{
    public class BD
    {
        private MySqlConnection connection;

        public BD()
        {
            connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=oversight_api;");
        }
        public string ejecutarSQL(string sql)
        {
            string resultado = "";

            connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            int filasResultado = cmd.ExecuteNonQuery();

            if (filasResultado > -1)
            {
                resultado = "Se inserto correcto";
            }
            else
            {
                resultado = "NULL";
            }

            connection.Close();

            return resultado;
        }

        public DataTable ejecutarSQL1(string sql1)
        {

            DataTable datosTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand(sql1, connection);
            try
            {
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(datosTable);

                connection.Close();
                adapter.Dispose();
            }
            catch (Exception)
            {
                return null;
            }
            return datosTable;
        }
    }
}
