using MySql.Data.MySqlClient;
using System.Data;

namespace PIMFazendaUrbana
{
    public class FornecedorDAO // Classe DAO (Data Access Object) para manipulação de dados de fornecedores no banco de dados
    {
        private string connectionString;
        public FornecedorDAO(string connectionString) // Construtor da classe FornecedorDAO que recebe a string de conexão como parâmetro
        {
            this.connectionString = connectionString; // Atribui a string de conexão recebida pelo parâmetro à variável de instância connectionString
        }

        // 1 - MÉTODO CADASTRAR FORNECEDOR NO BANCO
        // ********** NÃO TESTADO **********
        public void CadastrarFornecedor_DAO(Fornecedor fornecedor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados
                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string insertFornecedorQuery = @"INSERT INTO fornecedor (nome_fornecedor, email_fornecedor, cnpj_fornecedor, ativo_fornecedor) 
                                                        VALUES (@nome, @email, @cnpj, @status)"; // Define a consulta SQL para inserir os dados do fornecedor

                        using (MySqlCommand insertFornecedorCommand = new MySqlCommand(insertFornecedorQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do fornecedor, puxando da instância da classe Fornecedor
                            insertFornecedorCommand.Parameters.AddWithValue("@nome", fornecedor.Nome);
                            insertFornecedorCommand.Parameters.AddWithValue("@email", fornecedor.Email);
                            insertFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                            insertFornecedorCommand.Parameters.AddWithValue("@status", fornecedor.StatusAtivo);
                            insertFornecedorCommand.ExecuteNonQuery(); // Executa a consulta SQL para inserir os dados do fornecedor

                            int fornecedorId = (int)insertFornecedorCommand.LastInsertedId; // Recupera o ID do fornecedor recém-cadastrado

                            EnderecoFornecedor endereco = fornecedor.Endereco; // Instancia um objeto EnderecoFornecedor com os dados do endereço do fornecedor

                            string insertEnderecoQuery = @"INSERT INTO endereco_fornecedor (id_fornecedor, logradouro_endfornecedor, numero_endfornecedor, complemento_endfornecedor, 
                                                        bairro_endfornecedor, cidade_endfornecedor, uf_endfornecedor, cep_endfornecedor, ativo_endfornecedor) 
                                                        VALUES (@fornecedorId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)"; // Define a consulta SQL para cadastrar o endereço do fornecedor

                            using (MySqlCommand insertEnderecoCommand = new MySqlCommand(insertEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do endereço do fornecedor, puxando da instância da classe EnderecoFornecedor
                                insertEnderecoCommand.Parameters.AddWithValue("@fornecedorId", fornecedorId);
                                insertEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                                insertEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                                insertEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                                insertEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                                insertEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                                insertEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                                insertEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                                insertEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);
                                insertEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o endereço do fornecedor
                            }

                            TelefoneFornecedor telefone = fornecedor.Telefone; // Instancia um objeto TelefoneFornecedor com os dados do telefone do fornecedor

                            string insertTelefoneQuery = @"INSERT INTO telefone_fornecedor (id_fornecedor, ddd_telfornecedor, numero_telfornecedor, ativo_telfornecedor) 
                                                        VALUES (@fornecedorId, @ddd, @numero, @status)"; // Define a consulta SQL para cadastrar o telefone do fornecedor

                            using (MySqlCommand insertTelefoneCommand = new MySqlCommand(insertTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do telefone do fornecedor, puxando da instância da classe TelefoneFornecedor
                                insertTelefoneCommand.Parameters.AddWithValue("@fornecedorId", fornecedorId);
                                insertTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                                insertTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                                insertTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);
                                insertTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o telefone do fornecedor
                            }
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

        // 2- MÉTODO ALTERAR FORNECEDOR NO BANCO
        // ********** NÃO TESTADO **********
        public void AlterarFornecedor_DAO(Fornecedor fornecedor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateFornecedorQuery = @"UPDATE fornecedor SET nome_fornecedor = @nome, email_fornecedor = @email, 
                                                    cnpj_fornecedor = @cnpj, ativo_fornecedor = @status WHERE id_fornecedor = @fornecedorId";

                        using (MySqlCommand updateFornecedorCommand = new MySqlCommand(updateFornecedorQuery, connection, transaction))
                        {
                            updateFornecedorCommand.Parameters.AddWithValue("@nome", fornecedor.Nome);
                            updateFornecedorCommand.Parameters.AddWithValue("@email", fornecedor.Email);
                            updateFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                            updateFornecedorCommand.Parameters.AddWithValue("@status", fornecedor.StatusAtivo);
                            updateFornecedorCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);
                            updateFornecedorCommand.ExecuteNonQuery();
                        }

                        EnderecoFornecedor endereco = fornecedor.Endereco;

                        string updateEnderecoQuery = @"UPDATE endereco_fornecedor SET logradouro_endfornecedor = @logradouro, numero_endfornecedor = @numero, 
                                                    complemento_endfornecedor = @complemento, bairro_endfornecedor = @bairro, cidade_endfornecedor = @cidade, 
                                                    uf_endfornecedor = @uf, cep_endfornecedor = @cep, ativo_endfornecedor = @status WHERE id_fornecedor = @fornecedorId";

                        using (MySqlCommand updateEnderecoCommand = new MySqlCommand(updateEnderecoQuery, connection, transaction))
                        {
                            updateEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                            updateEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                            updateEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                            updateEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                            updateEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                            updateEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                            updateEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                            updateEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);
                            updateEnderecoCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);
                            updateEnderecoCommand.ExecuteNonQuery();
                        }

                        TelefoneFornecedor telefone = fornecedor.Telefone;

                        string updateTelefoneQuery = @"UPDATE telefone_fornecedor SET ddd_telfornecedor = @ddd, numero_telfornecedor = @numero, 
                                                    ativo_telfornecedor = @status WHERE id_fornecedor = @fornecedorId";

                        using (MySqlCommand updateTelefoneCommand = new MySqlCommand(updateTelefoneQuery, connection, transaction))
                        {
                            updateTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                            updateTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                            updateTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);
                            updateTelefoneCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);
                            updateTelefoneCommand.ExecuteNonQuery();
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

        // 3- MÉTODO EXCLUIR (DESATIVAR) FORNECEDOR DO BANCO
        // ********** NÃO TESTADO **********
        public void ExcluirFornecedor_DAO(int fornecedorId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Desativar o fornecedor
                        string updateFornecedorQuery = "UPDATE fornecedor SET ativo_fornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand updateFornecedorCommand = new MySqlCommand(updateFornecedorQuery, connection, transaction))
                        {
                            updateFornecedorCommand.Parameters.AddWithValue("@status", false);
                            updateFornecedorCommand.Parameters.AddWithValue("@id", fornecedorId);
                            updateFornecedorCommand.ExecuteNonQuery();
                        }

                        // Desativar o telefone do fornecedor
                        string updateTelefoneQuery = "UPDATE telefone_fornecedor SET ativo_telfornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand updateTelefoneCommand = new MySqlCommand(updateTelefoneQuery, connection, transaction))
                        {
                            updateTelefoneCommand.Parameters.AddWithValue("@status", false);
                            updateTelefoneCommand.Parameters.AddWithValue("@id", fornecedorId);
                            updateTelefoneCommand.ExecuteNonQuery();
                        }

                        // Desativar o endereço do fornecedor
                        string updateEnderecoQuery = "UPDATE endereco_fornecedor SET ativo_endfornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand updateEnderecoCommand = new MySqlCommand(updateEnderecoQuery, connection, transaction))
                        {
                            updateEnderecoCommand.Parameters.AddWithValue("@status", false);
                            updateEnderecoCommand.Parameters.AddWithValue("@id", fornecedorId);
                            updateEnderecoCommand.ExecuteNonQuery();
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

        // 4- Listagem
        // 4.1- MÉTODO LISTAR APENAS FORNECEDORES ATIVOS DO BANCO
        // ********** NÃO TESTADO **********
        public List<Fornecedor> ListarFornecedoresAtivos_DAO()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT f.id_fornecedor, f.nome_fornecedor, f.email_fornecedor, f.cnpj_fornecedor, f.ativo_fornecedor, 
                                t.ddd_telfornecedor, t.numero_telfornecedor, t.ativo_telfornecedor, 
                                e.logradouro_endfornecedor, e.numero_endfornecedor, e.complemento_endfornecedor, e.bairro_endfornecedor, e.cidade_endfornecedor, 
                                e.uf_endfornecedor, e.cep_endfornecedor, e.ativo_endfornecedor
                                FROM fornecedor f
                                LEFT JOIN telefone_fornecedor t ON f.id_fornecedor = t.id_fornecedor
                                LEFT JOIN endereco_fornecedor e ON f.id_fornecedor = e.id_fornecedor
                                WHERE f.ativo_fornecedor = true";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fornecedorId = reader.GetInt32("id_fornecedor");

                            Fornecedor fornecedor = new Fornecedor
                            {
                                ID = fornecedorId,
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),
                                Telefone = new TelefoneFornecedor
                                {
                                    DDD = reader.GetString("ddd_telfornecedor"),
                                    Numero = reader.GetString("numero_telfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfornecedor")
                                },
                                Endereco = new EnderecoFornecedor
                                {
                                    Logradouro = reader.GetString("logradouro_endfornecedor"),
                                    Numero = reader.GetString("numero_endfornecedor"),
                                    Complemento = reader.IsDBNull("complemento_endfornecedor") ? null : reader.GetString("complemento_endfornecedor"),
                                    Bairro = reader.GetString("bairro_endfornecedor"),
                                    Cidade = reader.GetString("cidade_endfornecedor"),
                                    UF = reader.GetString("uf_endfornecedor"),
                                    CEP = reader.GetString("cep_endfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfornecedor")
                                }
                            };

                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }

            return fornecedores;
        }

        // 4.2- MÉTODO LISTAR TODOS OS FORNECEDORES DO BANCO
        // ********** NÃO TESTADO **********
        public List<Fornecedor> ListarTodosFornecedores_DAO()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT f.id_fornecedor, f.nome_fornecedor, f.email_fornecedor, f.cnpj_fornecedor, f.ativo_fornecedor, 
                                t.ddd_telfornecedor, t.numero_telfornecedor, t.ativo_telfornecedor, 
                                e.logradouro_endfornecedor, e.numero_endfornecedor, e.complemento_endfornecedor, e.bairro_endfornecedor, e.cidade_endfornecedor, 
                                e.uf_endfornecedor, e.cep_endfornecedor, e.ativo_endfornecedor
                                FROM fornecedor f
                                LEFT JOIN telefone_fornecedor t ON f.id_fornecedor = t.id_fornecedor
                                LEFT JOIN endereco_fornecedor e ON f.id_fornecedor = e.id_fornecedor";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int fornecedorId = reader.GetInt32("id_fornecedor");

                            Fornecedor fornecedor = new Fornecedor
                            {
                                ID = fornecedorId,
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),
                                Telefone = new TelefoneFornecedor
                                {
                                    DDD = reader.GetString("ddd_telfornecedor"),
                                    Numero = reader.GetString("numero_telfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfornecedor")
                                },
                                Endereco = new EnderecoFornecedor
                                {
                                    Logradouro = reader.GetString("logradouro_endfornecedor"),
                                    Numero = reader.GetString("numero_endfornecedor"),
                                    Complemento = reader.IsDBNull("complemento_endfornecedor") ? null : reader.GetString("complemento_endfornecedor"),
                                    Bairro = reader.GetString("bairro_endfornecedor"),
                                    Cidade = reader.GetString("cidade_endfornecedor"),
                                    UF = reader.GetString("uf_endfornecedor"),
                                    CEP = reader.GetString("cep_endfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfornecedor")
                                }
                            };

                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }

            return fornecedores;
        }

        // 5- Consulta
        // 5.1- MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR ID (somente fornecedores ativos)
        // ********** NÃO TESTADO **********
        public Fornecedor ConsultarFornecedorID_DAO(int fornecedorId)
        {
            Fornecedor fornecedor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectFornecedorQuery = @"SELECT f.id_fornecedor, f.nome_fornecedor, f.email_fornecedor, f.cnpj_fornecedor, f.ativo_fornecedor,
                                            e.logradouro_endfornecedor, e.numero_endfornecedor, e.complemento_endfornecedor,
                                            e.bairro_endfornecedor, e.cidade_endfornecedor, e.uf_endfornecedor, e.cep_endfornecedor, e.ativo_endfornecedor,
                                            t.ddd_telfornecedor, t.numero_telfornecedor, t.ativo_telfornecedor
                                            FROM fornecedor f
                                            LEFT JOIN endereco_fornecedor e ON f.id_fornecedor = e.id_fornecedor
                                            LEFT JOIN telefone_fornecedor t ON f.id_fornecedor = t.id_fornecedor
                                            WHERE f.id_fornecedor = @id AND ativo_funcionario = 1";

                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection))
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@id", fornecedorId);

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fornecedor = new Fornecedor
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                Endereco = new EnderecoFornecedor
                                {
                                    Logradouro = reader.GetString("logradouro_endfornecedor"),
                                    Numero = reader.GetString("numero_endfornecedor"),
                                    Complemento = reader.GetString("complemento_endfornecedor"),
                                    Bairro = reader.GetString("bairro_endfornecedor"),
                                    Cidade = reader.GetString("cidade_endfornecedor"),
                                    UF = reader.GetString("uf_endfornecedor"),
                                    CEP = reader.GetString("cep_endfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfornecedor")
                                },

                                Telefone = new TelefoneFornecedor
                                {
                                    DDD = reader.GetString("ddd_telfornecedor"),
                                    Numero = reader.GetString("numero_telfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfornecedor")
                                }
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }

        // 5.2- MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR NOME (somente fornecedores ativos)
        // ********** NÃO TESTADO **********
        public Fornecedor ConsultarFornecedorNome_DAO(string fornecedorNome)
        {
            Fornecedor fornecedor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectFornecedorQuery = @"SELECT f.id_fornecedor, f.nome_fornecedor, f.email_fornecedor, f.cnpj_fornecedor, f.ativo_fornecedor, 
                                            e.logradouro_endfornecedor, e.numero_endfornecedor, e.complemento_endfornecedor, 
                                            e.bairro_endfornecedor, e.cidade_endfornecedor, e.uf_endfornecedor, e.cep_endfornecedor, e.ativo_endfornecedor, 
                                            t.ddd_telfornecedor, t.numero_telfornecedor, t.ativo_telfornecedor
                                            FROM fornecedor f
                                            LEFT JOIN endereco_fornecedor e ON f.id_fornecedor = e.id_fornecedor
                                            LEFT JOIN telefone_fornecedor t ON f.id_fornecedor = t.id_fornecedor
                                            WHERE f.nome_fornecedor = @nome AND ativo_funcionario = 1";

                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection))
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@nome", fornecedorNome);

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fornecedor = new Fornecedor
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                Endereco = new EnderecoFornecedor
                                {
                                    Logradouro = reader.GetString("logradouro_endfornecedor"),
                                    Numero = reader.GetString("numero_endfornecedor"),
                                    Complemento = reader.GetString("complemento_endfornecedor"),
                                    Bairro = reader.GetString("bairro_endfornecedor"),
                                    Cidade = reader.GetString("cidade_endfornecedor"),
                                    UF = reader.GetString("uf_endfornecedor"),
                                    CEP = reader.GetString("cep_endfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfornecedor")
                                },

                                Telefone = new TelefoneFornecedor
                                {
                                    DDD = reader.GetString("ddd_telfornecedor"),
                                    Numero = reader.GetString("numero_telfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfornecedor")
                                }
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }

        // 5.3- MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR CNPJ (somente fornecedores ativos)
        // ********** NÃO TESTADO **********
        public Fornecedor ConsultarFornecedorCNPJ_DAO(string fornecedorCNPJ)
        {
            Fornecedor fornecedor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectFornecedorQuery = @"SELECT f.id_fornecedor, f.nome_fornecedor, f.email_fornecedor, f.cnpj_fornecedor, f.ativo_fornecedor, 
                                            e.logradouro_endfornecedor, e.numero_endfornecedor, e.complemento_endfornecedor, 
                                            e.bairro_endfornecedor, e.cidade_endfornecedor, e.uf_endfornecedor, e.cep_endfornecedor, e.ativo_endfornecedor, 
                                            t.ddd_telfornecedor, t.numero_telfornecedor, t.ativo_telfornecedor
                                            FROM fornecedor f
                                            LEFT JOIN endereco_fornecedor e ON f.id_fornecedor = e.id_fornecedor
                                            LEFT JOIN telefone_fornecedor t ON f.id_fornecedor = t.id_fornecedor
                                            WHERE f.cnpj_fornecedor = @cnpj AND ativo_funcionario = 1";

                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection))
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedorCNPJ);

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fornecedor = new Fornecedor
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                Endereco = new EnderecoFornecedor
                                {
                                    Logradouro = reader.GetString("logradouro_endfornecedor"),
                                    Numero = reader.GetString("numero_endfornecedor"),
                                    Complemento = reader.GetString("complemento_endfornecedor"),
                                    Bairro = reader.GetString("bairro_endfornecedor"),
                                    Cidade = reader.GetString("cidade_endfornecedor"),
                                    UF = reader.GetString("uf_endfornecedor"),
                                    CEP = reader.GetString("cep_endfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfornecedor")
                                },

                                Telefone = new TelefoneFornecedor
                                {
                                    DDD = reader.GetString("ddd_telfornecedor"),
                                    Numero = reader.GetString("numero_telfornecedor"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfornecedor")
                                }
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }


    }
}