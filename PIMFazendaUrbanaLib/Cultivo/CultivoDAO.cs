using MySql.Data.MySqlClient;

namespace PIMFazendaUrbanaLib
{
    public class CultivoDAO
    {

        /*
        
        private string connectionString;
        public CultivoDAO()
        {
            this.connectionString = ConnectionString.GetConnectionString();
        }

        // 1 - MÉTODO CADASTRAR CULTIVO NO BANCO
        public void CadastrarCultivo(Cultivo cultivo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados
                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string insertCultivoQuery = @"INSERT INTO cultivo 
                                                    (nome_cultivo, clima_cultivo, categoria_cultivo, tempoproducao_cultivo, ativo_cultivo) 
                                                    VALUES (@nome, @clima, @categoria, @tempoproducao, @statusativo)";

                        using (MySqlCommand insertCultivoCommand = new MySqlCommand(insertCultivoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            insertCultivoCommand.Parameters.AddWithValue("@nome", cultivo.Nome);
                            insertCultivoCommand.Parameters.AddWithValue("@clima", cultivo.Clima);
                            insertCultivoCommand.Parameters.AddWithValue("@categoria", cultivo.Categoria);
                            insertCultivoCommand.Parameters.AddWithValue("@tempoproducao", cultivo.TempoProducao);
                            insertCultivoCommand.Parameters.AddWithValue("@statusativo", cultivo.StatusAtivo);
                            insertCultivoCommand.ExecuteNonQuery();
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

        // 2 - MÉTODO ALTERAR CULTIVO NO BANCO
        public void AlterarCultivo(Cultivo cultivo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateCultivoQuery = @"UPDATE cultivo SET 
                                                nome_cultivo = @nome,            
                                                clima_cultivo = @clima,
                                                categoria_cultivo = @categoria,
                                                tempoproducao_cultivo = @tempoproducao
                                                WHERE id_cultivo = @CultivoId";

                        using (MySqlCommand updateCultivoCommand = new MySqlCommand(updateCultivoQuery, connection, transaction))
                        {
                            updateCultivoCommand.Parameters.AddWithValue("@CultivoId", cultivo.ID);
                            updateCultivoCommand.Parameters.AddWithValue("@nome", cultivo.Nome);
                            updateCultivoCommand.Parameters.AddWithValue("@clima", cultivo.Clima);
                            updateCultivoCommand.Parameters.AddWithValue("@categoria", cultivo.Categoria);
                            updateCultivoCommand.Parameters.AddWithValue("@tempoproducao", cultivo.TempoProducao);
                            updateCultivoCommand.ExecuteNonQuery();
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

        // 3 - MÉTODO EXCLUIR (DESATIVAR) CULTIVO NO BANCO
        public void ExcluirCultivo_DAO(int cultivoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateCultivoQuery = "UPDATE cultivo SET ativo_cultivo = @status WHERE id_cultivo = @id";
                        using (MySqlCommand updateCultivoCommand = new MySqlCommand(updateCultivoQuery, connection, transaction))
                        {
                            updateCultivoCommand.Parameters.AddWithValue("@status", false);
                            updateCultivoCommand.Parameters.AddWithValue("@id", cultivoId);
                            updateCultivoCommand.ExecuteNonQuery();
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

        // 4 - MÉTODO LISTAR CULTIVOS (ATIVOS) NO BANCO
        public List<Cultivo> ListarCultivosAtivos()
        {
            List<Cultivo> cultivos = new List<Cultivo>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT c.id_cultivo, c.nome_cultivo, c.clima_cultivo, c.categoria_cultivo, 
                                c.tempoproducao_cultivo, c.ativo_cultivo
                                FROM cultivo c
                                WHERE c.ativo_cultivo = true";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int cultivoId = reader.GetInt32("id_cultivo");

                            Cultivo cultivo = new Cultivo
                            {
                                ID = cultivoId,
                                Nome = reader.GetString("nome_cultivo"),
                                Clima = reader.GetString("clima_cultivo"),
                                Categoria = reader.GetString("categoria_cultivo"),
                                TempoProducao = reader.GetInt32("tempoproducao_cultivo"),
                                StatusAtivo = reader.GetBoolean("ativo_cultivo")
                            };
                            cultivos.Add(cultivo);
                        }
                    }
                }
            }
            return cultivos;
        }

        // 5 - MÉTODO CONSULTAR CULTIVO POR ID NO BANCO
        public Cultivo ConsultarCultivoID(int cultivoId)
        {
            Cultivo cultivo = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT c.id_cultivo, c.nome_cultivo, c.clima_cultivo, c.categoria_cultivo, 
                                c.tempoproducao_cultivo, c.ativo_cultivo
                                FROM cultivo c
                                WHERE id_cultivo = @Id";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", cultivoId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        cultivo = new Cultivo
                        {
                            ID = cultivoId,
                            Nome = reader.GetString("nome_cultivo"),
                            Clima = reader.GetString("clima_cultivo"),
                            Categoria = reader.GetString("categoria_cultivo"),
                            TempoProducao = reader.GetInt32("tempoproducao_cultivo"),
                            StatusAtivo = reader.GetBoolean("ativo_cultivo")
                        };
                    }
                    return cultivo;
                }
            }
        }

        */
    }
}
