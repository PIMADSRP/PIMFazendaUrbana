using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MySqlX.XDevAPI;

namespace PIM_FazendaUrbana
{
    // atualizado 26/04
    public class ClienteDAO // Classe DAO (Data Access Object) para manipulação de dados de clientes no banco de dados
    {
        private string connectionString;

        public ClienteDAO(string connectionString) // Construtor da classe ClienteDAO que recebe a string de conexão como parâmetro
        {
            this.connectionString = connectionString; // Atribui a string de conexão recebida pelo parâmetro à variável de instância connectionString
        }



        // ********** MÉTODO CADASTRAR CLIENTE NO BANCO **********
        public void CadastrarCliente_DAO(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        // ----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                        // ********** VVVVVVV                      VVVVVVV **********

                        string insertClienteQuery = "INSERT INTO Cliente (nome_cliente, email_cliente, CNPJ_cliente, ativo_cliente) VALUES (@nome, @email, @cnpj, @status)"; // Define a consulta SQL para inserir os dados do cliente

                        using (MySqlCommand insertClienteCommand = new MySqlCommand(insertClienteQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do cliente, puxando da instância da classe Cliente
                            insertClienteCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                            insertClienteCommand.Parameters.AddWithValue("@email", cliente.Email);
                            insertClienteCommand.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                            insertClienteCommand.Parameters.AddWithValue("@status", cliente.StatusAtivo);

                            insertClienteCommand.ExecuteNonQuery(); // Executa a consulta SQL para inserir os dados do cliente

                            int clienteId = (int)insertClienteCommand.LastInsertedId; // Recupera o ID do cliente recém-cadastrado



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            EnderecoCliente endereco = cliente.Endereco; // Instancia um objeto EnderecoCliente com os dados do endereço do cliente
                            string insertEnderecoQuery = "INSERT INTO EnderecoCliente (id_cliente, logradouro_endcliente, numero_endcliente, complemento_endcliente, bairro_endcliente, cidade_endcliente, uf_endcliente, cep_endcliente, ativo_endcliente) VALUES (@clienteId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)"; // Define a consulta SQL para cadastrar o endereço do cliente

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



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            TelefoneCliente telefone = cliente.Telefone; // Instancia um objeto TelefoneCliente com os dados do telefone do cliente
                            string insertTelefoneQuery = "INSERT INTO TelefoneCliente (id_cliente, ddd_telcliente, numero_telcliente, ativo_telcliente) VALUES (@clienteId, @ddd, @numero, @status)"; // Define a consulta SQL para cadastrar o telefone do cliente

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



        // ********** MÉTODO ALTERAR CLIENTE NO BANCO **********
        public void AlterarCliente_DAO(Cliente cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        // ----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                        // ********** VVVVVVV                      VVVVVVV **********

                        string updateClienteQuery = "UPDATE Cliente SET nome_cliente = @nome, email_cliente = @email, cnpj_cliente = @cnpj, ativo_cliente = @status WHERE id_cliente = @id"; // Define a consulta SQL para atualizar os dados do cliente
                        using (MySqlCommand updateClienteCommand = new MySqlCommand(updateClienteQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do cliente, puxando da instância da classe Cliente
                            updateClienteCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                            updateClienteCommand.Parameters.AddWithValue("@email", cliente.Email);
                            updateClienteCommand.Parameters.AddWithValue("@cnpj", cliente.CNPJ);
                            updateClienteCommand.Parameters.AddWithValue("@status", cliente.StatusAtivo); // ou só passar o valor true?
                            updateClienteCommand.Parameters.AddWithValue("@id", cliente.ID);
                            // Executa a consulta SQL para atualizar os dados do cliente
                            updateClienteCommand.ExecuteNonQuery();
                        }



                        // -----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                        // ********** VVVVVVV                       VVVVVVV **********

                        // DESATIVAR ENDEREÇO ANTIGO DO CLIENTE
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        string deactivateEnderecoQuery = "UPDATE EnderecoCliente SET ativo_endcliente = @status WHERE id_cliente = @id"; // Define a consulta SQL para desativar o endereço antigo do cliente
                        using (MySqlCommand deactivateEnderecoCommand = new MySqlCommand(deactivateEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            //deactivateEnderecoCommand.Parameters.AddWithValue("@status", cliente.Endereco.StatusAtivo); // ou só passar o valor false?
                            deactivateEnderecoCommand.Parameters.AddWithValue("@status", false); // Define o status do endereço como inativo
                            deactivateEnderecoCommand.Parameters.AddWithValue("@id", cliente.ID); // ID do cliente cujo endereço será desativado

                            deactivateEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o endereço antigo do cliente
                        }

                        // CADASTRAR NOVO ENDEREÇO DO CLIENTE
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        EnderecoCliente endereco = cliente.Endereco; // Instancia um objeto EnderecoCliente com os dados do novo endereço do cliente
                        string insertEnderecoQuery = "INSERT INTO EnderecoCliente (id_cliente, logradouro_endcliente, numero_endcliente, complemento_endcliente, bairro_endcliente, cidade_endcliente, uf_endcliente, cep_endcliente, ativo_endcliente) VALUES (@clienteId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)"; // Define a consulta SQL para cadastrar o novo endereço do cliente

                        using (MySqlCommand insertEnderecoCommand = new MySqlCommand(insertEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do endereço do cliente
                            insertEnderecoCommand.Parameters.AddWithValue("@clienteId", cliente.ID);
                            insertEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                            insertEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                            insertEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                            insertEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                            insertEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                            insertEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                            insertEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                            insertEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);

                            insertEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o novo endereço do cliente
                        }



                        // -----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE TelefoneCliente ||||||| **********
                        // ********** VVVVVVV                       VVVVVVV **********

                        // DESATIVAR TELEFONE ANTIGO DO CLIENTE
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        string deactivateTelefoneQuery = "UPDATE TelefoneCliente SET ativo_telcliente = @status WHERE id_cliente = @id"; // Define a consulta SQL para desativar o telefone antigo do cliente
                        using (MySqlCommand deactivateTelefoneCommand = new MySqlCommand(deactivateTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            //deactivateTelefoneCommand.Parameters.AddWithValue("@status", cliente.Telefone.StatusAtivo); // ou só passar o valor false?
                            deactivateTelefoneCommand.Parameters.AddWithValue("@status", false); // Define o status do telefone como inativo
                            deactivateTelefoneCommand.Parameters.AddWithValue("@id", cliente.ID); // ID do cliente cujo telefone será desativado

                            deactivateTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o telefone antigo do cliente
                        }

                        // CADASTRAR NOVO TELEFONE DO CLIENTE
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        TelefoneCliente telefone = cliente.Telefone; // Instancia um objeto Telefone com os dados do novo telefone do cliente
                        string insertTelefoneQuery = "INSERT INTO TelefoneCliente (id_cliente, ddd_telcliente, numero_telcliente, ativo_telcliente) VALUES (@clienteId, @ddd, @numero, @status)"; // Define a consulta SQL para cadastrar o novo telefone do cliente

                        using (MySqlCommand insertTelefoneCommand = new MySqlCommand(insertTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do endereço do cliente
                            insertTelefoneCommand.Parameters.AddWithValue("@clienteId", cliente.ID);
                            insertTelefoneCommand.Parameters.AddWithValue("@ddd", endereco.Logradouro);
                            insertTelefoneCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                            insertTelefoneCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);

                            insertTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o novo endereço da cliente
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



        // ********** MÉTODO EXCLUIR (DESATIVAR) CLIENTE DO BANCO **********
        public void ExcluirCliente_DAO(int clienteId) // Alteração do método ExcluirCliente para desativar o cliente ao invés de excluí-lo
        {
            // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string updateStatusQuery = "UPDATE Cliente SET ativo_cliente = @status WHERE id_cliente = @id"; // Define a consulta SQL para atualizar o status do cliente para inativo
                        using (MySqlCommand updateStatusCommand = new MySqlCommand(updateStatusQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com o valor do status e ID do cliente
                            updateStatusCommand.Parameters.AddWithValue("@status", false); // Define o status como inativo
                            updateStatusCommand.Parameters.AddWithValue("@id", clienteId); // ID do cliente a ser desativado

                            updateStatusCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o cliente
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



        // ********** MÉTODO LISTAR CLIENTES DO BANCO **********
        public List<Cliente> ListarClientes_DAO() // Usa um loop while ir adicionando clientes a uma lista que vai ser retornada
        {
            List<Cliente> clientes = new List<Cliente>(); // Inicializa a lista de clientes

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectClientesQuery = "SELECT * FROM Cliente"; // Define a consulta SQL para selecionar todos os clientes
                using (MySqlCommand selectClientesCommand = new MySqlCommand(selectClientesQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    using (MySqlDataReader reader = selectClientesCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        while (reader.Read()) // Itera sobre cada linha de resultado
                        {
                            Cliente cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                // Preenche os dados do cliente com os valores do resultado da consulta
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),

                                // Inicializa os objetos Endereco e Telefone do cliente
                                Endereco = new EnderecoCliente(),
                                Telefone = new TelefoneCliente()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            // Consulta o endereço do cliente com base no clienteId
                            string selectEnderecoQuery = "SELECT * FROM EnderecoCliente WHERE id_cliente = @clienteId";
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                // Adiciona o parâmetro @clienteId ao comando com o valor do ID da cliente
                                selectEnderecoCommand.Parameters.AddWithValue("@clienteId", cliente.ID);

                                // Executa a consulta SQL do endereço e obtém os resultados
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader())
                                {
                                    // Verifica se há uma linha de resultado para o endereço
                                    if (enderecoReader.Read())
                                    {
                                        // Preenche os detalhes do endereço do cliente
                                        cliente.Endereco.Logradouro = enderecoReader.GetString("logradouro_endcliente");
                                        cliente.Endereco.Numero = enderecoReader.GetInt32("numero_endcliente");
                                        cliente.Endereco.Complemento = enderecoReader.GetString("complemento_endcliente");
                                        cliente.Endereco.Bairro = enderecoReader.GetString("bairro_endcliente");
                                        cliente.Endereco.Cidade = enderecoReader.GetString("cidade_endcliente");
                                        cliente.Endereco.UF = enderecoReader.GetString("uf_endcliente");
                                        cliente.Endereco.CEP = enderecoReader.GetString("cep_endcliente");
                                        cliente.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endcliente");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            // Consulta o telefone do cliente com base no clienteId
                            string selectTelefoneQuery = "SELECT * FROM TelefoneCliente WHERE id_cliente = @clienteId";
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                // Adiciona o parâmetro @clienteId ao comando com o valor do ID do cliente
                                selectTelefoneCommand.Parameters.AddWithValue("@clienteId", cliente.ID);

                                // Executa a consulta SQL do telefone e obtém os resultados
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader())
                                {
                                    // Verifica se há uma linha de resultado para o telefone
                                    if (telefoneReader.Read())
                                    {
                                        // Preenche os detalhes do telefone do cliente
                                        cliente.Telefone.Numero = telefoneReader.GetString("numero_telcliente");
                                        cliente.Telefone.DDD = telefoneReader.GetString("ddd_telcliente");
                                        cliente.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telcliente");
                                    }
                                }
                            }


                            clientes.Add(cliente); // Adiciona o cliente à lista de clientes
                        }
                    }
                }
            }

            return clientes; // Retorna a lista de clientes consultada
        }



        // ********** MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR ID **********
        public Cliente ConsultarClienteID_DAO(int clienteId)
        {
            // Inicializa o objeto cliente como nulo
            Cliente cliente = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectClienteQuery = "SELECT * FROM Cliente WHERE id_cliente = @id"; // Define a consulta SQL para selecionar um cliente com base no ID fornecido
                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@id", clienteId); // Adiciona o parâmetro @id ao comando com o valor do clienteId

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do cliente
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                Email = reader.GetString("email_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),

                                // Inicializa os objetos Endereco e Telefone do cliente
                                Endereco = new EnderecoCliente(),
                                Telefone = new TelefoneCliente()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoCliente WHERE id_cliente = @clienteId"; // Consulta o endereço do cliente com base no clienteId
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@clienteId", cliente.ID); // Adiciona o parâmetro @clienteId ao comando com o valor do ID do cliente
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do cliente
                                        cliente.Endereco.Logradouro = enderecoReader.GetString("logradouro_endcliente");
                                        cliente.Endereco.Numero = enderecoReader.GetInt32("numero_endcliente");
                                        cliente.Endereco.Complemento = enderecoReader.GetString("complemento_endcliente");
                                        cliente.Endereco.Bairro = enderecoReader.GetString("bairro_endcliente");
                                        cliente.Endereco.Cidade = enderecoReader.GetString("cidade_endcliente");
                                        cliente.Endereco.UF = enderecoReader.GetString("uf_endcliente");
                                        cliente.Endereco.CEP = enderecoReader.GetString("cep_endcliente");
                                        cliente.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endcliente");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TELEFONE ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneCliente WHERE id_cliente = @clienteId"; // Consulta o telefone do cliente com base no clienteId
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@clienteId", cliente.ID); // Adiciona o parâmetro @clienteId ao comando com o valor do ID do cliente
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone da cliente
                                        cliente.Telefone.Numero = telefoneReader.GetString("numero_telcliente");
                                        cliente.Telefone.DDD = telefoneReader.GetString("ddd_telcliente");
                                        cliente.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telcliente");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }



        // ********** MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR NOME **********
        public Cliente ConsultarClienteNome_DAO(string clienteNome)
        {
            // Inicializa o objeto cliente como nulo
            Cliente cliente = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectClienteQuery = "SELECT * FROM Cliente WHERE nome_cliente = @nome"; // Define a consulta SQL para selecionar um cliente com base no nome fornecido
                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@nome", clienteNome); // Adiciona o parâmetro @nome ao comando com o valor do clienteNome

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do cliente
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                Email = reader.GetString("email_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),

                                // Inicializa os objetos Endereco e Telefone do cliente
                                Endereco = new EnderecoCliente(),
                                Telefone = new TelefoneCliente()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoCliente WHERE nome_cliente = @clienteNome"; // Consulta o endereço do cliente com base no clienteNome
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@clienteNome", cliente.Nome); // Adiciona o parâmetro @clienteNome ao comando com o valor do nome do cliente
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do cliente
                                        cliente.Endereco.Logradouro = enderecoReader.GetString("logradouro_endcliente");
                                        cliente.Endereco.Numero = enderecoReader.GetInt32("numero_endcliente");
                                        cliente.Endereco.Complemento = enderecoReader.GetString("complemento_endcliente");
                                        cliente.Endereco.Bairro = enderecoReader.GetString("bairro_endcliente");
                                        cliente.Endereco.Cidade = enderecoReader.GetString("cidade_endcliente");
                                        cliente.Endereco.UF = enderecoReader.GetString("uf_endcliente");
                                        cliente.Endereco.CEP = enderecoReader.GetString("cep_endcliente");
                                        cliente.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endcliente");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TELEFONE ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneCliente WHERE nome_cliente = @clienteNome"; // Consulta o telefone do cliente com base no clienteNome
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@clienteNome", cliente.Nome); // Adiciona o parâmetro @clienteNome ao comando com o valor do nome do cliente
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone do cliente
                                        cliente.Telefone.Numero = telefoneReader.GetString("numero_telcliente");
                                        cliente.Telefone.DDD = telefoneReader.GetString("ddd_telcliente");
                                        cliente.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telcliente");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }



        // ********** MÉTODO CONSULTAR (PESQUISAR) CLIENTE NO BANCO POR CNPJ **********
        public Cliente ConsultarClienteCNPJ_DAO(string clienteCNPJ)
        {
            // Inicializa o objeto cliente como nulo
            Cliente cliente = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Cliente ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectClienteQuery = "SELECT * FROM Cliente WHERE cnpj_cliente = @cnpj"; // Define a consulta SQL para selecionar um cliente com base no cnpj fornecido
                using (MySqlCommand selectClienteCommand = new MySqlCommand(selectClienteQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectClienteCommand.Parameters.AddWithValue("@cnpj", clienteCNPJ); // Adiciona o parâmetro @cnpj ao comando com o valor do clienteCNPJ

                    using (MySqlDataReader reader = selectClienteCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do cliente
                        {
                            cliente = new Cliente // Inicializa um novo objeto Cliente com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_cliente"),
                                Nome = reader.GetString("nome_cliente"),
                                Email = reader.GetString("email_cliente"),
                                CNPJ = reader.GetString("cnpj_cliente"),
                                StatusAtivo = reader.GetBoolean("ativo_cliente"),

                                // Inicializa os objetos Endereco e Telefone do cliente
                                Endereco = new EnderecoCliente(),
                                Telefone = new TelefoneCliente()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoCliente WHERE cnpj_cliente = @clienteCNPJ"; // Consulta o endereço da cliente com base no clienteCNPJ
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@clienteCNPJ", cliente.CNPJ); // Adiciona o parâmetro @clienteCNPJ ao comando com o valor do cnpj do cliente
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do cliente
                                        cliente.Endereco.Logradouro = enderecoReader.GetString("logradouro_endcliente");
                                        cliente.Endereco.Numero = enderecoReader.GetInt32("numero_endcliente");
                                        cliente.Endereco.Complemento = enderecoReader.GetString("complemento_endcliente");
                                        cliente.Endereco.Bairro = enderecoReader.GetString("bairro_endcliente");
                                        cliente.Endereco.Cidade = enderecoReader.GetString("cidade_endcliente");
                                        cliente.Endereco.UF = enderecoReader.GetString("uf_endcliente");
                                        cliente.Endereco.CEP = enderecoReader.GetString("cep_endcliente");
                                        cliente.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endcliente");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneCliente ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneCliente WHERE cnpj_cliente = @clienteCNPJ"; // Consulta o telefone do cliente com base no clienteCNPJ
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@clienteCNPJ", cliente.CNPJ); // Adiciona o parâmetro @clienteCNPJ ao comando com o valor do cnpj do cliente
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone do cliente
                                        cliente.Telefone.Numero = telefoneReader.GetString("numero_telcliente");
                                        cliente.Telefone.DDD = telefoneReader.GetString("ddd_telcliente");
                                        cliente.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telcliente");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cliente; // Retorna o objeto cliente consultado
        }





    }
}
