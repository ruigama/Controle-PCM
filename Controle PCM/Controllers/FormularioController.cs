using Controle_PCM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Controle_PCM.Controllers
{
    public class FormularioController
    {
        private string connectionString;

        public FormularioController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public bool Salvar(Informacoes formulario, List<string> anexos)
        {
            int idInserido = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO formulario " +
                        "(codigo, " +
                        " modelo," +
                        " aspecto_tecnico," +
                        " preco_nova," +
                        " custo," +
                        " preco_atual," +
                        " avaliacao_tecnica," +
                        " status) " +
                        "VALUES " +
                        "(@codigo," +
                        " @modelo, " +
                        " @aspecto_tecnico," +
                        " @preco_nova," +
                        " @custo," +
                        " @preco_atual," +
                        " @avaliacao_tecnica," +
                        " @status);" +
                        "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", formulario.codigo);
                        command.Parameters.AddWithValue("@Modelo", formulario.modelo);
                        command.Parameters.AddWithValue("@aspecto_tecnico", formulario.aspecto_tecnico);
                        command.Parameters.AddWithValue("@preco_nova", formulario.preco_nova);
                        command.Parameters.AddWithValue("@custo", formulario.custo);
                        command.Parameters.AddWithValue("@preco_atual", formulario.preco_atual);
                        command.Parameters.AddWithValue("@avaliacao_tecnica", formulario.avaliacao_tecnica);
                        command.Parameters.AddWithValue("@status", 1);

                        //command.ExecuteNonQuery();
                        idInserido = Convert.ToInt32(command.ExecuteScalar());

                        string sqlImagem = "INSERT INTO anexos" +
                            "(anexo, id_formulario)" +
                            "VALUES" +
                            "(@anexo, @id_formulario);";

                        foreach (var anexo in anexos)
                        {
                            using (MySqlCommand sqlCommand = new MySqlCommand(sqlImagem, connection))
                            {
                                sqlCommand.Parameters.AddWithValue("@anexo", anexo);
                                sqlCommand.Parameters.AddWithValue("@id_formulario", idInserido);

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
                return false;
            }
        }
    }
}
