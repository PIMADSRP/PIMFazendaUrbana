using MySql.Data.MySqlClient;
using System.Data;

namespace PIMFazendaUrbana
{
    public class ClienteDAO // Classe DAO (Data Access Object) para manipulação de dados de clientes no banco de dados
    {
        private string connectionString;
        public ClienteDAO(string connectionString) // Construtor da classe ClienteDAO que recebe a string de conexão como parâmetro
        {
            this.connectionString = connectionString; // Atribui a string de conexão recebida pelo parâmetro à variável de instância connectionString
        }

        // 1 - MÉTODO CADASTRAR CLIENTE NO BANCO
        // ********** FUNCIONAL **********
        public void CadastrarCliente_DAO(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados
                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string insertClienteQuery = @"INSERT INTO cliente (nome_cliente, email_cliente, cnpj_cliente, ativo_cliente) 
                                                    VALUES (@nome, @email, @cnpj, @status)"; // Define a consulta SQL para inserir os dados do cliente

                        using (MySqlCommand insertClienteCommand = new MySqlCommand(insertClienteQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do cliente, puxando da instância da classe Cliente
                            insertClienteCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                            insertClienteCommand.Parameters.AddWithValue("@email", cliente.Email);
                            insertClienteCommand.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                            insertClienteCommand.Parameters.AddWithValue("@status", cliente.StatusAtivo);
                            insertClienteCommand.ExecuteNonQuery(); // Executa a consulta SQL para inserir os dados do cliente

                            int clienteId = (int)insertClienteCommand.LastInsertedId; // Recupera o ID do cliente recém-cadastrado

                            EnderecoCliente endereco = cliente.Endereco; // Instancia um objeto EnderecoCliente com os dados do endereço do cliente

                            string insertEnderecoQuery = @"INSERT INTO endereco_cliente (id_cliente, logradouro_endcliente, numero_endcliente, complemento_endcliente, 
                                                        bairro_endcliente, cidade_endcliente, uf_endcliente, cep_endcliente, ativo_endcliente) 
                                                        VALUES (@clienteId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)"; // Define a consulta SQL para cadastrar o endereço do cliente

                            using (MySqlCommand insertEnderecoCommand = new MySqlCommand(insertEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do endereço do cliente, puxando da instância da classe EnderecoCliente
                                insertEnderecoCommand.Parameters.AddWithValue("@clienteId", clienteId);
                                insertEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                                insertEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                                insertEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                                insertEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                                insertEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                                insertEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                                insertEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                                insertEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);
                                insertEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o endereço do cliente
                            }

                            TelefoneCliente telefone = cliente.Telefone; // Instancia um objeto TelefoneCliente com os dados do telefone do cliente

                            string insertTelefoneQuery = @"INSERT INTO telefone_cliente (id_cliente, ddd_telcliente, numero_telcliente, ativo_telcliente) 
                                                        VALUES (@clienteId, @ddd, @numero, @status)"; // Define a consulta SQL para cadastrar o telefone do cliente

                            using (MySqlCommand insertTelefoneCommand = new MySqlCommand(insertTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do telefone do cliente, puxando da instância da classe TelefoneCliente
                                insertTelefoneCommand.Parameters.AddWithValue("@clienteId", clienteId);
                                insertTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                                insertTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                                insertTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);
                                insertTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o telefone do cliente
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

        // 2- MÉTODO ALTERAR CLIENTE NO BANCO
        // ********** NÃO TESTADO **********
        public void AlterarCliente_DAO(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction()) 
                {
                    try
                    {
                        string updateClienteQuery = @"UPDATE cliente SET nome_cliente = @nome, email_cliente = @email, 
                                                    cnpj_cliente = @cnpj, ativo_cliente = @status WHERE id_cliente = @clienteId";

                        using (MySqlCommand updateClienteCommand = new MySqlCommand(updateClienteQuery, connection, transaction))
                        {
                            updateClienteCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                            updateClienteCommand.Parameters.AddWithValue("@email", cliente.Email);
                            updateClienteCommand.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                            updateClienteCommand.Parameters.AddWithValue("@status", cliente.StatusAtivo);
                            updateClienteCommand.Parameters.AddWithValue("@clienteId", cliente.ID);
                            updateClienteCommand.ExecuteNonQuery();
                        }

                        EnderecoCliente endereco = cliente.Endereco;

                        string updateEnderecoQuery = @"UPDATE endereco_cliente SET logradouro_endcliente = @logradouro, numero_endcliente = @numero, 
                                                    complemento_endcliente = @complemento, bairro_endcliente = @bairro, cidade_endcliente = @cidade, 
                                                    uf_endcliente = @uf, cep_endcliente = @cep, ativo_endcliente = @status WHERE id_cliente = @clienteId";

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
                            updateEnderecoCommand.Parameters.AddWithValue("@clienteId", cliente.ID);
                            updateEnderecoCommand.ExecuteNonQuery();
                        }

                        TelefoneCliente telefone = cliente.Telefone;

                        string updateTelefoneQuery = @"UPDATE telefone_cliente SET ddd_telcliente = @ddd, numero_telcliente = @numero, 
                                                    ativo_telcliente = @status WHERE id_cliente = @clienteId";

                        using (MySqlCommand updateTelefoneCommand = new MySqlCommand(updateTelefoneQuery, connection, transaction))
                        {
                            updateTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                            updateTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                            updateTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);
                            updateTelefoneCommand.Parameters.AddWithValue("@clienteId", cliente.ID);
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

        // 3- MÉTODO EXCLUIR (DESATIVAR) CLIENTE DO BANCO
        // ********** NÃO TESTADO **********
        public void ExcluirCliente_DAO(int clienteId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Desativar o cliente
                        string updateClienteQuery = "UPDATE cliente SET ativo_cliente = @status WHERE id_cliente = @id";
                        using (MySqlCommand updateClienteCommand = new MySqlCommand(updateClienteQuery, connection, transaction))
                        {
                            updateClienteCommand.Parameters.AddWithValue("@status", false);
                            updateClienteCommand.Parameters.AddWithValue("@id", clienteId);
                            updateClienteCommand.ExecuteNonQuery();
                        }

                        // Desativar o telefone do cliente
                        string updateTelefoneQuery = "UPDATE telefone_cliente SET ativo_telcliente = @status WHERE id_cliente = @id";
                        using (MySqlCommand updateTelefoneCommand = new MySqlCommand(updateTelefoneQuery, connection, transaction))
                        {
                            updateTelefoneCommand.Parameters.AddWithValue("@status", false);
                            updateTelefoneCommand.Parameters.AddWithValue("@id", clienteId);
                            updateTelefoneCommand.ExecuteNonQuery();
                        }

                        // Desativar o endereço do cliente
                        string updateEnderecoQuery = "UPDATE endereco_cliente SET ativo_endcliente = @status WHERE id_cliente = @id";
                        using (MySqlCommand updateEnderecoCommand = new MySqlCommand(updateEnderecoQuery, connection, transaction))
                        {
                            updateEnderecoCommand.Parameters.AddWithValue("@status", false);
                            updateEnderecoCommand.Parameters.AddWithValue("@id", clienteId);
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
        // 4.1- MÉTODO LISTAR APENAS CLIENTES ATIVOS DO BANCO
        // ********** FUNCIONAL **********
        public List<Cliente> ListarClientesAtivos_DAO()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT c.id_cliente, c.nome_cliente, c.email_cliente, c.cnpj_cliente, c.ativo_cliente, 
                                t.ddd_telcliente, t.numero_telcliente, t.ativo_telcliente, 
                                e.logradouro_endcliente, e.numero_endcliente, e.complemento_endcliente, e.bairro_endcliente, e.cidade_endcliente, 
                                e.uf_endcliente, e.cep_endcliente, e.ativo_endcliente
                                FROM cliente c
                                LEFT JOIN telefone_cliente t ON c.id_cliente = t.id_cliente
                                LEFT JOIN endereco_cliente e ON c.id_cliente = e.id_cliente
                                WHERE c.ativo_cliente = true";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clienteId = reader.GetInt32("id_cliente");

                            Cliente cliente = new Cliente
                            {
                                ID = clienteId,
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),
                                Telefone = new TelefoneCliente
                                {
                                    DDD = reader.GetString("ddd_telcliente"),
                                    Numero = reader.GetString("numero_telcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_telcliente")
                                },
                                Endereco = new EnderecoCliente
                                {
                                    Logradouro = reader.GetString("logradouro_endcliente"),
                                    Numero = reader.GetString("numero_endcliente"),
                                    Complemento = reader.IsDBNull("complemento_endcliente") ? null : reader.GetString("complemento_endcliente"),
                                    Bairro = reader.GetString("bairro_endcliente"),
                                    Cidade = reader.GetString("cidade_endcliente"),
                                    UF = reader.GetString("uf_endcliente"),
                                    CEP = reader.GetString("cep_endcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_endcliente")
                                }
                            };

                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }

        // 4.2- MÉTODO LISTAR TODOS OS CLIENTES DO BANCO
        // ********** NÃO TESTADO **********
        public List<Cliente> ListarTodosClientes_DAO()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT c.id_cliente, c.nome_cliente, c.email_cliente, c.cnpj_cliente, c.ativo_cliente, 
                                t.ddd_telcliente, t.numero_telcliente, t.ativo_telcliente, 
                                e.logradouro_endcliente, e.numero_endcliente, e.complemento_endcliente, e.bairro_endcliente, e.cidade_endcliente, 
                                e.uf_endcliente, e.cep_endcliente, e.ativo_endcliente
                                FROM cliente c
                                LEFT JOIN telefone_cliente t ON c.id_cliente = t.id_cliente
                                LEFT JOIN endereco_cliente e ON c.id_cliente = e.id_cliente";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clienteId = reader.GetInt32("id_cliente");

                            Cliente cliente = new Cliente
                            {
                                ID = clienteId,
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),
                                Telefone = new TelefoneCliente
                                {
                                    DDD = reader.GetString("ddd_telcliente"),
                                    Numero = reader.GetString("numero_telcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_telcliente")
                                },
                                Endereco = new EnderecoCliente
                                {
                                    Logradouro = reader.GetString("logradouro_endcliente"),
                                    Numero = reader.GetString("numero_endcliente"),
                                    Complemento = reader.IsDBNull("complemento_endcliente") ? null : reader.GetString("complemento_endcliente"),
                                    Bairro = reader.GetString("bairro_endcliente"),
                                    Cidade = reader.GetString("cidade_endcliente"),
                                    UF = reader.GetString("uf_endcliente"),
                                    CEP = reader.GetString("cep_endcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_endcliente")
                                }
                            };

                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }

        // 5- Consulta
        // 5.1- MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR ID (somente clientes ativos)
        // ********** NÃO TESTADO **********
        public Cliente ConsultarClienteID_DAO(int clienteId)
        {
            Cliente cliente = null; // Inicializa o objeto cliente como nulo

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma conexão com o banco de dados
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // Define a consulta SQL para selecionar um cliente com base no ID fornecido
                string selectClienteQuery = @"SELECT c.id_cliente, c.nome_cliente, c.email_cliente, c.cnpj_cliente, c.ativo_cliente,
                                            e.logradouro_endcliente, e.numero_endcliente, e.complemento_endcliente,
                                            e.bairro_endcliente, e.cidade_endcliente, e.uf_endcliente, e.cep_endcliente, e.ativo_endcliente,
                                            t.ddd_telcliente, t.numero_telcliente, t.ativo_telcliente
                                            FROM cliente c
                                            LEFT JOIN endereco_cliente e ON c.id_cliente = e.id_cliente
                                            LEFT JOIN telefone_cliente t ON c.id_cliente = t.id_cliente
                                            WHERE c.id_cliente = @id";

                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@id", clienteId); // Adiciona o parâmetro @id ao comando com o valor do clienteId

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),
                                
                                Endereco = new EnderecoCliente // Inicializa os objetos Endereco e Telefone do cliente
                                {
                                    Logradouro = reader.GetString("logradouro_endcliente"),
                                    Numero = reader.GetString("numero_endcliente"),
                                    Complemento = reader.GetString("complemento_endcliente"),
                                    Bairro = reader.GetString("bairro_endcliente"),
                                    Cidade = reader.GetString("cidade_endcliente"),
                                    UF = reader.GetString("uf_endcliente"),
                                    CEP = reader.GetString("cep_endcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_endcliente")
                                },

                                Telefone = new TelefoneCliente
                                {
                                    DDD = reader.GetString("ddd_telcliente"),
                                    Numero = reader.GetString("numero_telcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_telcliente")
                                }
                            };
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }

        // 5.2- MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR NOME (somente clientes ativos)
        // ********** NÃO TESTADO **********
        public Cliente ConsultarClienteNome_DAO(string clienteNome)
        {
            Cliente cliente = null; // Inicializa o objeto cliente como nulo

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma conexão com o banco de dados
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // Define a consulta SQL para selecionar um cliente com base no nome fornecido
                string selectClienteQuery = @"SELECT c.id_cliente, c.nome_cliente, c.email_cliente, c.cnpj_cliente, c.ativo_cliente, 
                                            e.logradouro_endcliente, e.numero_endcliente, e.complemento_endcliente, 
                                            e.bairro_endcliente, e.cidade_endcliente, e.uf_endcliente, e.cep_endcliente, e.ativo_endcliente, 
                                            t.ddd_telcliente, t.numero_telcliente, t.ativo_telcliente
                                            FROM cliente c
                                            LEFT JOIN endereco_cliente e ON c.id_cliente = e.id_cliente
                                            LEFT JOIN telefone_cliente t ON c.id_cliente = t.id_cliente
                                            WHERE c.nome_cliente = @nome";

                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@nome", clienteNome); // Adiciona o parâmetro @nome ao comando com o valor do clienteNome

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),
                                
                                Endereco = new EnderecoCliente // Inicializa os objetos Endereco e Telefone do cliente
                                {
                                    Logradouro = reader.GetString("logradouro_endcliente"),
                                    Numero = reader.GetString("numero_endcliente"),
                                    Complemento = reader.GetString("complemento_endcliente"),
                                    Bairro = reader.GetString("bairro_endcliente"),
                                    Cidade = reader.GetString("cidade_endcliente"),
                                    UF = reader.GetString("uf_endcliente"),
                                    CEP = reader.GetString("cep_endcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_endcliente")
                                },
                                Telefone = new TelefoneCliente
                                {
                                    DDD = reader.GetString("ddd_telcliente"),
                                    Numero = reader.GetString("numero_telcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_telcliente")
                                }
                            };
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }

        // 5.3- MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR CNPJ (somente clientes ativos)
        // ********** NÃO TESTADO **********
        public Cliente ConsultarClienteCNPJ_DAO(string clienteCNPJ)
        {
            Cliente cliente = null; // Inicializa o objeto cliente como nulo

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma conexão com o banco de dados
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // Define a consulta SQL para selecionar um cliente com base no CNPJ fornecido
                string selectClienteQuery = @"SELECT c.id_cliente, c.nome_cliente, c.email_cliente, c.cnpj_cliente, c.ativo_cliente, 
                                            e.logradouro_endcliente, e.numero_endcliente, e.complemento_endcliente, 
                                            e.bairro_endcliente, e.cidade_endcliente, e.uf_endcliente, e.cep_endcliente, e.ativo_endcliente, 
                                            t.ddd_telcliente, t.numero_telcliente, t.ativo_telcliente
                                            FROM Cliente c
                                            LEFT JOIN endereco_cliente e ON c.id_cliente = e.id_cliente
                                            LEFT JOIN telefone_cliente t ON c.id_cliente = t.id_cliente
                                            WHERE c.cnpj_cliente = @cnpj";

                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@cnpj", clienteCNPJ); // Adiciona o parâmetro @cnpj ao comando com o valor do clienteCNPJ

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("CNPJ_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),
                                
                                Endereco = new EnderecoCliente // Inicializa o objeto Endereco do cliente
                                {
                                    Logradouro = reader.GetString("logradouro_endcliente"),
                                    Numero = reader.GetString("numero_endcliente"),
                                    Complemento = reader.GetString("complemento_endcliente"),
                                    Bairro = reader.GetString("bairro_endcliente"),
                                    Cidade = reader.GetString("cidade_endcliente"),
                                    UF = reader.GetString("uf_endcliente"),
                                    CEP = reader.GetString("cep_endcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_endcliente")
                                },

                                Telefone = new TelefoneCliente // Inicializa o objeto Telefone do cliente
                                {
                                    DDD = reader.GetString("ddd_telcliente"),
                                    Numero = reader.GetString("numero_telcliente"),
                                    StatusAtivo = reader.GetBoolean("ativo_telcliente")
                                }
                            };
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }

    }
}
