using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_PCM.Controllers
{
    public class LoginController
    {
        private string connectionString;

        public LoginController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public bool VerificaUsuario(string username, string password)
        {
            int count = 0;

            using(MySqlConnection connection = new MySqlConnection(connectionString)) 
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM users WHERE name = @name AND password = @password;";

                using(MySqlCommand command = new MySqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@name", username);
                    command.Parameters.AddWithValue("@password", password);

                    object contador = command.ExecuteScalar();
                    count = Convert.ToInt32(contador);
                }
            }

            if(count > 0)
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
