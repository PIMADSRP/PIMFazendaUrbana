using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MySqlX.XDevAPI;

namespace PIM_FazendaUrbana
{
    public class FornecedorDAO // Classe DAO (Data Access Object) para manipulação de dados de fornecedores no banco de dados
    {
        private string connectionString;

        public FornecedorDAO(string connectionString) // Construtor da classe FornecedorDAO que recebe a string de conexão como parâmetro
        {
            this.connectionString = connectionString; // Atribui a string de conexão recebida pelo parâmetro à variável de instância connectionString
        }



        // ********** MÉTODO CADASTRAR FORNECEDOR NO BANCO **********
        public void CadastrarFornecedor_DAO(Fornecedor fornecedor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        // ----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE Fornecedor ||||||| **********
                        // ********** VVVVVVV                      VVVVVVV **********

                        string insertFornecedorQuery = "INSERT INTO Fornecedor (nome_fornecedor, email_fornecedor, CNPJ_fornecedor, ativo_fornecedor) VALUES (@nome, @email, @cnpj, @status)";
                        using (MySqlCommand insertFornecedorCommand = new MySqlCommand(insertFornecedorQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do fornecedor, puxando da instância da classe Fornecedor
                            insertFornecedorCommand.Parameters.AddWithValue("@nome", fornecedor.Nome);
                            insertFornecedorCommand.Parameters.AddWithValue("@email", fornecedor.Email);
                            insertFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                            insertFornecedorCommand.Parameters.AddWithValue("@status", fornecedor.StatusAtivo);

                            insertFornecedorCommand.ExecuteNonQuery(); // Executa a consulta SQL para inserir os dados do fornecedor

                            int fornecedorId = (int)insertFornecedorCommand.LastInsertedId; // Recupera o ID do fornecedor recém-cadastrado



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            EnderecoFornecedor endereco = fornecedor.Endereco; // Instancia um objeto EnderecoFornecedor com os dados do endereço do fornecedor
                            string insertEnderecoQuery = "INSERT INTO EnderecoFornecedor (id_fornecedor, logradouro_endfornecedor, numero_endfornecedor, complemento_endfornecedor, bairro_endfornecedor, cidade_endfornecedor, uf_endfornecedor, cep_endfornecedor, ativo_endfornecedor) VALUES (@fornecedorId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)";
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



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            TelefoneFornecedor telefone = fornecedor.Telefone; // Instancia um objeto TelefoneFornecedor com os dados do telefone do fornecedor
                            string insertTelefoneQuery = "INSERT INTO TelefoneFornecedor (id_fornecedor, ddd_telfornecedor, numero_telfornecedor, ativo_telfornecedor) VALUES (@fornecedorId, @ddd, @numero, @status)";
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



        // ********** MÉTODO ALTERAR FORNECEDOR NO BANCO **********
        public void AlterarFornecedor_DAO(Fornecedor fornecedor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        // ----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE Fornecedor ||||||| **********
                        // ********** VVVVVVV                      VVVVVVV **********

                        string updateFornecedorQuery = "UPDATE Fornecedor SET nome_fornecedor = @nome, email_fornecedor = @email, cnpj_fornecedor = @cnpj, ativo_fornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand updateFornecedorCommand = new MySqlCommand(updateFornecedorQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do fornecedor, puxando da instância da classe Fornecedor
                            updateFornecedorCommand.Parameters.AddWithValue("@nome", fornecedor.Nome);
                            updateFornecedorCommand.Parameters.AddWithValue("@email", fornecedor.Email);
                            updateFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                            updateFornecedorCommand.Parameters.AddWithValue("@status", fornecedor.StatusAtivo);
                            updateFornecedorCommand.Parameters.AddWithValue("@id", fornecedor.ID);

                            updateFornecedorCommand.ExecuteNonQuery(); // Executa a consulta SQL para atualizar os dados do fornecedor
                        }



                        // -----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                        // ********** VVVVVVV                       VVVVVVV **********

                        // DESATIVAR ENDEREÇO ANTIGO DO FORNECEDOR
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        string deactivateEnderecoQuery = "UPDATE EnderecoFornecedor SET ativo_endfornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand deactivateEnderecoCommand = new MySqlCommand(deactivateEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            deactivateEnderecoCommand.Parameters.AddWithValue("@status", false); // Define o status do endereço como inativo
                            deactivateEnderecoCommand.Parameters.AddWithValue("@id", fornecedor.ID); // ID do fornecedor cujo endereço será desativado

                            deactivateEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o endereço antigo do fornecedor
                        }

                        // CADASTRAR NOVO ENDEREÇO DO FORNECEDOR
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        EnderecoFornecedor endereco = fornecedor.Endereco; // Instancia um objeto EnderecoFornecedor com os dados do novo endereço do fornecedor
                        string insertEnderecoQuery = "INSERT INTO EnderecoFornecedor (id_fornecedor, logradouro_endfornecedor, numero_endfornecedor, complemento_endfornecedor, bairro_endfornecedor, cidade_endfornecedor, uf_endfornecedor, cep_endfornecedor, ativo_endfornecedor) VALUES (@fornecedorId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)";
                        using (MySqlCommand insertEnderecoCommand = new MySqlCommand(insertEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do endereço do fornecedor
                            insertEnderecoCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);
                            insertEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                            insertEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                            insertEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                            insertEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                            insertEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                            insertEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                            insertEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                            insertEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);

                            insertEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o novo endereço do fornecedor
                        }



                        // -----------------------------------------------------------
                        // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                        // ********** VVVVVVV                       VVVVVVV **********

                        // DESATIVAR TELEFONE ANTIGO DO FORNECEDOR
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        string deactivateTelefoneQuery = "UPDATE TelefoneFornecedor SET ativo_telfornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand deactivateTelefoneCommand = new MySqlCommand(deactivateTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            deactivateTelefoneCommand.Parameters.AddWithValue("@status", false); // Define o status do telefone como inativo
                            deactivateTelefoneCommand.Parameters.AddWithValue("@id", fornecedor.ID); // ID do fornecedor cujo telefone será desativado

                            deactivateTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o telefone antigo do fornecedor
                        }

                        // CADASTRAR NOVO TELEFONE DO FORNECEDOR
                        // PROVAVELMENTE EM UM MÉTODO SEPARADO???
                        TelefoneFornecedor telefone = fornecedor.Telefone; // Instancia um objeto TelefoneFornecedor com os dados do novo telefone do fornecedor
                        string insertTelefoneQuery = "INSERT INTO TelefoneFornecedor (id_fornecedor, ddd_telfornecedor, numero_telfornecedor, ativo_telfornecedor) VALUES (@fornecedorId, @ddd, @numero, @status)";
                        using (MySqlCommand insertTelefoneCommand = new MySqlCommand(insertTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do endereço do fornecedor
                            insertTelefoneCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);
                            insertTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                            insertTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                            insertTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);

                            insertTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o novo endereço do fornecedor
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



        // ********** MÉTODO EXCLUIR (DESATIVAR) FORNECEDOR DO BANCO **********
        public void ExcluirFornecedor_DAO(int fornecedorId) // Alteração do método ExcluirFornecedor para desativar o fornecedor ao invés de excluí-lo
        {
            // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string updateStatusQuery = "UPDATE Fornecedor SET ativo_fornecedor = @status WHERE id_fornecedor = @id";
                        using (MySqlCommand updateStatusCommand = new MySqlCommand(updateStatusQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com o valor do status e ID do fornecedor
                            updateStatusCommand.Parameters.AddWithValue("@status", false); // Define o status como inativo
                            updateStatusCommand.Parameters.AddWithValue("@id", fornecedorId); // ID do fornecedor a ser desativado

                            updateStatusCommand.ExecuteNonQuery(); // Executa a consulta SQL para desativar o fornecedor
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



        // ********** MÉTODO LISTAR FORNECEDORES DO BANCO **********
        public List<Fornecedor> ListarFornecedores_DAO() // Usa um loop while ir adicionando fornecedores a uma lista que vai ser retornada
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>(); // Inicializa a lista de fornecedores

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados

                string selectFornecedoresQuery = "SELECT * FROM Fornecedor";
                using (MySqlCommand selectFornecedoresCommand = new MySqlCommand(selectFornecedoresQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    using (MySqlDataReader reader = selectFornecedoresCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        while (reader.Read()) // Itera sobre cada linha de resultado
                        {
                            Fornecedor fornecedor = new Fornecedor // Inicializa um novo objeto Fornecedor com os dados do resultado da consulta
                            {
                                // Preenche os dados do fornecedor com os valores do resultado da consulta
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                // Inicializa os objetos Endereco e Telefone do fornecedor
                                Endereco = new EnderecoFornecedor(),
                                Telefone = new TelefoneFornecedor()
                            };

                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            // Consulta o endereço do fornecedor com base no fornecedorId
                            string selectEnderecoQuery = "SELECT * FROM EnderecoFornecedor WHERE id_fornecedor = @fornecedorId";
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                // Adiciona o parâmetro @fornecedorId ao comando com o valor do ID do fornecedor
                                selectEnderecoCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);

                                // Executa a consulta SQL do endereço e obtém os resultados
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader())
                                {
                                    // Verifica se há uma linha de resultado para o endereço
                                    if (enderecoReader.Read())
                                    {
                                        // Preenche os detalhes do endereço do fornecedor
                                        fornecedor.Endereco.Logradouro = enderecoReader.GetString("logradouro_endfornecedor");
                                        fornecedor.Endereco.Numero = enderecoReader.GetInt32("numero_endfornecedor");
                                        fornecedor.Endereco.Complemento = enderecoReader.GetString("complemento_endfornecedor");
                                        fornecedor.Endereco.Bairro = enderecoReader.GetString("bairro_endfornecedor");
                                        fornecedor.Endereco.Cidade = enderecoReader.GetString("cidade_endfornecedor");
                                        fornecedor.Endereco.UF = enderecoReader.GetString("uf_endfornecedor");
                                        fornecedor.Endereco.CEP = enderecoReader.GetString("cep_endfornecedor");
                                        fornecedor.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endfornecedor");
                                    }
                                }
                            }

                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            // Consulta o telefone do fornecedor com base no fornecedorId
                            string selectTelefoneQuery = "SELECT * FROM TelefoneFornecedor WHERE id_fornecedor = @fornecedorId";
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                // Adiciona o parâmetro @fornecedorId ao comando com o valor do ID do fornecedor
                                selectTelefoneCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID);

                                // Executa a consulta SQL do telefone e obtém os resultados
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader())
                                {
                                    // Verifica se há uma linha de resultado para o telefone
                                    if (telefoneReader.Read())
                                    {
                                        // Preenche os detalhes do telefone do fornecedor
                                        fornecedor.Telefone.Numero = telefoneReader.GetString("numero_telfornecedor");
                                        fornecedor.Telefone.DDD = telefoneReader.GetString("ddd_telfornecedor");
                                        fornecedor.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telfornecedor");
                                    }
                                }
                            }

                            fornecedores.Add(fornecedor); // Adiciona o fornecedor à lista de fornecedores
                        }
                    }
                }
            }

            return fornecedores; // Retorna a lista de fornecedores consultada
        }

        // ********** MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR ID **********
        public Fornecedor ConsultarFornecedorID_DAO(int fornecedorId)
        {
            // Inicializa o objeto fornecedor como nulo
            Fornecedor fornecedor = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Fornecedor ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectFornecedorQuery = "SELECT * FROM Fornecedor WHERE id_fornecedor = @id"; // Define a consulta SQL para selecionar um fornecedor com base no ID fornecido
                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@id", fornecedorId); // Adiciona o parâmetro @id ao comando com o valor do fornecedorId

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do fornecedor
                        {
                            fornecedor = new Fornecedor // Inicializa um novo objeto Fornecedor com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                // Inicializa os objetos Endereco e Telefone do fornecedor
                                Endereco = new EnderecoFornecedor(),
                                Telefone = new TelefoneFornecedor()
                            };

                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoFornecedor WHERE id_fornecedor = @fornecedorId"; // Consulta o endereço do fornecedor com base no fornecedorId
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID); // Adiciona o parâmetro @fornecedorId ao comando com o valor do ID do fornecedor
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do fornecedor
                                        fornecedor.Endereco.Logradouro = enderecoReader.GetString("logradouro_endfornecedor");
                                        fornecedor.Endereco.Numero = enderecoReader.GetInt32("numero_endfornecedor");
                                        fornecedor.Endereco.Complemento = enderecoReader.GetString("complemento_endfornecedor");
                                        fornecedor.Endereco.Bairro = enderecoReader.GetString("bairro_endfornecedor");
                                        fornecedor.Endereco.Cidade = enderecoReader.GetString("cidade_endfornecedor");
                                        fornecedor.Endereco.UF = enderecoReader.GetString("uf_endfornecedor");
                                        fornecedor.Endereco.CEP = enderecoReader.GetString("cep_endfornecedor");
                                        fornecedor.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endfornecedor");
                                    }
                                }
                            }

                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneFornecedor WHERE id_fornecedor = @fornecedorId"; // Consulta o telefone do fornecedor com base no fornecedorId
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@fornecedorId", fornecedor.ID); // Adiciona o parâmetro @fornecedorId ao comando com o valor do ID do fornecedor
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone do fornecedor
                                        fornecedor.Telefone.Numero = telefoneReader.GetString("numero_telfornecedor");
                                        fornecedor.Telefone.DDD = telefoneReader.GetString("ddd_telfornecedor");
                                        fornecedor.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telfornecedor");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fornecedor; // Retorna o objeto fornecedor consultado
        }



        // ********** MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR NOME **********
        public Fornecedor ConsultarFornecedorNome_DAO(string fornecedorNome)
        {
            // Inicializa o objeto fornecedor como nulo
            Fornecedor fornecedor = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Fornecedor ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectFornecedorQuery = "SELECT * FROM Fornecedor WHERE nome_fornecedor = @nome"; // Define a consulta SQL para selecionar um fornecedor com base no nome fornecido
                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@nome", fornecedorNome); // Adiciona o parâmetro @nome ao comando com o valor do fornecedorNome

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do fornecedor
                        {
                            fornecedor = new Fornecedor // Inicializa um novo objeto Fornecedor com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                // Inicializa os objetos Endereco e Telefone do fornecedor
                                Endereco = new EnderecoFornecedor(),
                                Telefone = new TelefoneFornecedor()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoFornecedor WHERE nome_fornecedor = @fornecedorNome"; // Consulta o endereço do fornecedor com base no fornecedorNome
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@fornecedorNome", fornecedor.Nome); // Adiciona o parâmetro @fornecedorNome ao comando com o valor do nome do fornecedor
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do fornecedor
                                        fornecedor.Endereco.Logradouro = enderecoReader.GetString("logradouro_endfornecedor");
                                        fornecedor.Endereco.Numero = enderecoReader.GetInt32("numero_endfornecedor");
                                        fornecedor.Endereco.Complemento = enderecoReader.GetString("complemento_endfornecedor");
                                        fornecedor.Endereco.Bairro = enderecoReader.GetString("bairro_endfornecedor");
                                        fornecedor.Endereco.Cidade = enderecoReader.GetString("cidade_endfornecedor");
                                        fornecedor.Endereco.UF = enderecoReader.GetString("uf_endfornecedor");
                                        fornecedor.Endereco.CEP = enderecoReader.GetString("cep_endfornecedor");
                                        fornecedor.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endfornecedor");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneFornecedor WHERE nome_fornecedor = @fornecedorNome"; // Consulta o telefone do fornecedor com base no fornecedorNome
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@fornecedorNome", fornecedor.Nome); // Adiciona o parâmetro @fornecedorNome ao comando com o valor do nome do fornecedor
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone do fornecedor
                                        fornecedor.Telefone.Numero = telefoneReader.GetString("numero_telfornecedor");
                                        fornecedor.Telefone.DDD = telefoneReader.GetString("ddd_telfornecedor");
                                        fornecedor.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telfornecedor");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fornecedor; // Retorna o objeto fornecedor consultado
        }



        // ********** MÉTODO CONSULTAR (PESQUISAR) FORNECEDOR NO BANCO POR CNPJ **********
        public Fornecedor ConsultarFornecedorCNPJ_DAO(string fornecedorCNPJ)
        {
            // Inicializa o objeto fornecedor como nulo
            Fornecedor fornecedor = null;

            // Cria uma conexão com o banco de dados usando a classe MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Abre a conexão com o banco de dados

                // ----------------------------------------------------------
                // ********** ||||||| DADOS CLASSE Fornecedor ||||||| **********
                // ********** VVVVVVV                      VVVVVVV **********

                string selectFornecedorQuery = "SELECT * FROM Fornecedor WHERE cnpj_fornecedor = @cnpj"; // Define a consulta SQL para selecionar um fornecedor com base no cnpj fornecido
                using (MySqlCommand selectFornecedorCommand = new MySqlCommand(selectFornecedorQuery, connection)) // Cria um comando MySqlCommand com a consulta SQL e a conexão
                {
                    selectFornecedorCommand.Parameters.AddWithValue("@cnpj", fornecedorCNPJ); // Adiciona o parâmetro @cnpj ao comando com o valor do fornecedorCNPJ

                    using (MySqlDataReader reader = selectFornecedorCommand.ExecuteReader()) // Executa a consulta SQL e obtém os resultados usando um MySqlDataReader
                    {
                        if (reader.Read()) // Verifica se há uma linha de resultado; se sim, preenche os dados do fornecedor
                        {
                            fornecedor = new Fornecedor // Inicializa um novo objeto Fornecedor com os dados do resultado da consulta
                            {
                                ID = reader.GetInt32("id_fornecedor"),
                                Nome = reader.GetString("nome_fornecedor"),
                                Email = reader.GetString("email_fornecedor"),
                                CNPJ = reader.GetString("cnpj_fornecedor"),
                                StatusAtivo = reader.GetBoolean("ativo_fornecedor"),

                                // Inicializa os objetos Endereco e Telefone do fornecedor
                                Endereco = new EnderecoFornecedor(),
                                Telefone = new TelefoneFornecedor()
                            };



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE EnderecoFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectEnderecoQuery = "SELECT * FROM EnderecoFornecedor WHERE cnpj_fornecedor = @fornecedorCNPJ"; // Consulta o endereço da fornecedor com base no fornecedorCNPJ
                            using (MySqlCommand selectEnderecoCommand = new MySqlCommand(selectEnderecoQuery, connection))
                            {
                                selectEnderecoCommand.Parameters.AddWithValue("@fornecedorCNPJ", fornecedor.CNPJ); // Adiciona o parâmetro @fornecedorCNPJ ao comando com o valor do cnpj do fornecedor
                                using (MySqlDataReader enderecoReader = selectEnderecoCommand.ExecuteReader()) // Executa a consulta SQL do endereço e obtém os resultados
                                {
                                    if (enderecoReader.Read()) // Verifica se há uma linha de resultado para o endereço; se sim, preenche os dados do endereço
                                    {
                                        // Preenche os detalhes do endereço do fornecedor
                                        fornecedor.Endereco.Logradouro = enderecoReader.GetString("logradouro_endfornecedor");
                                        fornecedor.Endereco.Numero = enderecoReader.GetInt32("numero_endfornecedor");
                                        fornecedor.Endereco.Complemento = enderecoReader.GetString("complemento_endfornecedor");
                                        fornecedor.Endereco.Bairro = enderecoReader.GetString("bairro_endfornecedor");
                                        fornecedor.Endereco.Cidade = enderecoReader.GetString("cidade_endfornecedor");
                                        fornecedor.Endereco.UF = enderecoReader.GetString("uf_endfornecedor");
                                        fornecedor.Endereco.CEP = enderecoReader.GetString("cep_endfornecedor");
                                        fornecedor.Endereco.StatusAtivo = enderecoReader.GetBoolean("ativo_endfornecedor");
                                    }
                                }
                            }



                            // -----------------------------------------------------------
                            // ********** ||||||| DADOS CLASSE TelefoneFornecedor ||||||| **********
                            // ********** VVVVVVV                       VVVVVVV **********

                            string selectTelefoneQuery = "SELECT * FROM TelefoneFornecedor WHERE cnpj_fornecedor = @fornecedorCNPJ"; // Consulta o telefone do fornecedor com base no fornecedorCNPJ
                            using (MySqlCommand selectTelefoneCommand = new MySqlCommand(selectTelefoneQuery, connection))
                            {
                                selectTelefoneCommand.Parameters.AddWithValue("@fornecedorCNPJ", fornecedor.CNPJ); // Adiciona o parâmetro @fornecedorCNPJ ao comando com o valor do cnpj do fornecedor
                                using (MySqlDataReader telefoneReader = selectTelefoneCommand.ExecuteReader()) // Executa a consulta SQL do telefone e obtém os resultados
                                {
                                    if (telefoneReader.Read()) // Verifica se há uma linha de resultado para o telefone; se sim, preenche os dados do telefone
                                    {
                                        // Preenche os detalhes do telefone do fornecedor
                                        fornecedor.Telefone.Numero = telefoneReader.GetString("numero_telfornecedor");
                                        fornecedor.Telefone.DDD = telefoneReader.GetString("ddd_telfornecedor");
                                        fornecedor.Telefone.StatusAtivo = telefoneReader.GetBoolean("ativo_telfornecedor");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fornecedor; // Retorna o objeto fornecedor consultado
        }


    }
}