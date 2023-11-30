using Controle_PCM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_PCM.Controllers
{
    public class PesquisaController
    {
        private string connectionString;

        public PesquisaController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public List<Informacoes> PesquisarEquipamentos(string codigo)
        {
            List<Informacoes> informacoes = new List<Informacoes>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string informacoesQuery = "SELECT * FROM formulario WHERE codigo = @codigo;";
                MySqlCommand commandInfo = new MySqlCommand(informacoesQuery, connection);
                commandInfo.Parameters.AddWithValue("@codigo", codigo);

                using (MySqlDataReader infoReader = commandInfo.ExecuteReader())
                {
                    while (infoReader.Read())
                    {
                        Informacoes informacao = new Informacoes
                        {
                            id = (int)infoReader["id"],
                            codigo = (string)infoReader["codigo"],
                            modelo = (string)infoReader["modelo"],
                            aspecto_tecnico = (string)infoReader["aspecto_tecnico"],
                            preco_nova = (string)infoReader["preco_nova"],
                            custo = (string)infoReader["custo"],
                            preco_atual = (string)infoReader["preco_atual"],
                            avaliacao_tecnica = (string)infoReader["avaliacao_tecnica"],
                            status = (int)infoReader["status"]
                        };

                        int id_formulario = (int)informacao.id;

                        using(MySqlConnection conection2 = new MySqlConnection(connectionString)) 
                        {
                            conection2.Open();
                            string itensQuery = "SELECT * FROM anexos WHERE id_formulario = @id_formulario;";
                            MySqlCommand itensCommand = new MySqlCommand(itensQuery, conection2);
                            itensCommand.Parameters.AddWithValue("@id_formulario", id_formulario);

                            using (MySqlDataReader anexosReader = itensCommand.ExecuteReader())
                            {
                                while (anexosReader.Read())
                                {
                                    Anexo item = new Anexo
                                    {
                                        id = (int)anexosReader["id"],
                                        anexo = (string)anexosReader["anexo"],
                                        id_formulario = (int)anexosReader["id_formulario"]
                                    };

                                    informacao.Anexos.Add(item);
                                }
                            }
                        }

                        informacoes.Add(informacao);
                    }
                }
            }
            return informacoes;
        }
    }
}
