using MySql.Data.MySqlClient;

namespace PIMFazendaUrbanaLib
{
    public class ProducaoDAO
    {
        private string connectionString;
        public ProducaoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // 1 - MÉTODO CADASTRAR PRODUCAO NO BANCO
        public void CadastrarProducao_DAO(Producao producao)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados
                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string insertClienteQuery = @"INSERT INTO producao 
                                                    (qtd_producao, dt_producao, finalizado_producao, ativo_producao) 
                                                    VALUES (@qtd, @data, @statusfinalizado, @statusativo)";

                        using (MySqlCommand insertClienteCommand = new MySqlCommand(insertClienteQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            insertClienteCommand.Parameters.AddWithValue("@qtd", producao.Quantidade);
                            insertClienteCommand.Parameters.AddWithValue("@data", producao.Data);
                            insertClienteCommand.Parameters.AddWithValue("@statusfinalizado", producao.StatusFinalizado);
                            insertClienteCommand.Parameters.AddWithValue("@statusativo", producao.StatusAtivo);
                            insertClienteCommand.ExecuteNonQuery();
                        }
                        // COMMIT de todas as inserções no banco de dados
                        transaction.Commit(); // Efetua o commit da transação se todas as operações forem bem-sucedidas
                    }
                    catch (Exception) // Captura exceções caso ocorram erros durante a execução das operações
                    {
                        transaction.Rollback(); // Em caso de erro, faz o rollback da transação
                        throw;
                    }
                }
            }
        }

        // 2 - MÉTODO ALTERAR PRODUCAO NO BANCO
        public void AlterarProducao_DAO(Producao producao)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateProducaoQuery = @"UPDATE producao SET 
                                                qtd_producao = @qtd,
                                                dt_producao = @data,
                                                finalizado_producao = @statusfinalizado
                                                WHERE id_producao = @ProducaoId";

                        using (MySqlCommand updateProducaoCommand = new MySqlCommand(updateProducaoQuery, connection, transaction))
                        {
                            updateProducaoCommand.Parameters.AddWithValue("@ProducaoId", producao.ID);
                            updateProducaoCommand.Parameters.AddWithValue("@qtd", producao.Quantidade);
                            updateProducaoCommand.Parameters.AddWithValue("@data", producao.Data);
                            updateProducaoCommand.Parameters.AddWithValue("@statusfinalizado", producao.StatusFinalizado);
                            updateProducaoCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // 3 - MÉTODO FINALIZAR PRODUCAO NO BANCO
        public void FinalizarProducao_DAO(int producaoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateProducaoQuery = "UPDATE producao SET finalizado_producao = @statusfinalizado WHERE id_producao = @id";
                        using (MySqlCommand updateClienteCommand = new MySqlCommand(updateProducaoQuery, connection, transaction))
                        {
                            updateClienteCommand.Parameters.AddWithValue("@statusfinalizado", true);
                            updateClienteCommand.Parameters.AddWithValue("@id", producaoId);
                            updateClienteCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // 4 - MÉTODO EXCLUIR (DESATIVAR) PRODUCAO NO BANCO
        public void ExcluirProducao_DAO(int producaoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateProducaoQuery = "UPDATE producao SET ativo_producao = @statusativo WHERE id_producao = @id";
                        using (MySqlCommand updateClienteCommand = new MySqlCommand(updateProducaoQuery, connection, transaction))
                        {
                            updateClienteCommand.Parameters.AddWithValue("@statusativo", false);
                            updateClienteCommand.Parameters.AddWithValue("@id", producaoId);
                            updateClienteCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // 5 - Listagem
        // 5.1 - MÉTODO LISTAR PRODUCOES (ATIVAS) NO BANCO
        public List<Producao> ListarProducoesAtivas_DAO()
        {
            List<Producao> producoes = new List<Producao>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT p.id_producao, p.qtd_producao, p.dt_producao, p.finalizado_producao, p.ativo_producao
                                FROM producao p
                                WHERE p.ativo_producao = true";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int producaoId = reader.GetInt32("id_producao");

                            Producao producao = new Producao
                            {
                                ID = producaoId,
                                Quantidade = reader.GetInt32(reader.GetString("qtd_producao")),
                                Data = reader.GetString("dt_producao"),
                                StatusFinalizado = reader.GetBoolean("finalizado_producao"),
                                StatusAtivo = reader.GetBoolean("ativo_producao")
                            };
                            producoes.Add(producao);
                        }
                    }
                }
            }
            return producoes;
        }

        // 5.2 - MÉTODO LISTAR PRODUCOES (ATIVAS E NÃO FINALIZADAS) NO BANCO
        public List<Producao> ListarProducoesAtivasNaoFinalizadas_DAO()
        {
            List<Producao> producoes = new List<Producao>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT p.id_producao, p.qtd_producao, p.dt_producao, p.finalizado_producao, p.ativo_producao
                                FROM producao p
                                WHERE p.ativo_producao = true
                                AND p.finalizado_producao = false
                                ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int producaoId = reader.GetInt32("id_producao");

                            Producao producao = new Producao
                            {
                                ID = producaoId,
                                Quantidade = reader.GetInt32(reader.GetString("qtd_producao")),
                                Data = reader.GetString("dt_producao"),
                                StatusFinalizado = reader.GetBoolean("finalizado_producao"),
                                StatusAtivo = reader.GetBoolean("ativo_producao")
                            };
                            producoes.Add(producao);
                        }
                    }
                }
            }
            return producoes;
        }

        // 6 - MÉTODO CONSULTAR PRODUCAO POR ID NO BANCO
        public Producao ConsultarProducaoID_DAO(int producaoId)
        {
            Producao producao = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT p.id_producao, p.qtd_producao, p.dt_producao, p.finalizado_producao, p.ativo_producao
                                FROM producao p
                                WHERE id_producao = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", producaoId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        producao = new Producao
                        {
                            ID = producaoId,
                            Quantidade = reader.GetInt32(reader.GetString("qtd_producao")),
                            Data = reader.GetString("dt_producao"),
                            StatusFinalizado = reader.GetBoolean("finalizado_producao"),
                            StatusAtivo = reader.GetBoolean("ativo_producao")
                        };
                    }
                    return producao;
                }
            }
        }


    }
}
