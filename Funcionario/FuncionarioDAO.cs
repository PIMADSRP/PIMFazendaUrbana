﻿using MySql.Data.MySqlClient;
using System.Data;

namespace PIMFazendaUrbana
{
    public class FuncionarioDAO
    {
        private string connectionString;

        public FuncionarioDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // 1- Método para autenticar funcionário
        // ********** FUNCIONAL **********
        public bool AutenticarFuncionario_DAO(string funcionarioUsuario, string funcionarioSenha)
        {
            string SenhaCadastrada = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Funcionario funcionario = null;

                string query = "SELECT credenciais_funcionario FROM funcionario WHERE usuario_funcionario = @Usuario";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);
                command.Parameters.AddWithValue("@Senha", funcionarioSenha);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    SenhaCadastrada = reader.GetString("credenciais_funcionario");
                }
            }
            if (SenhaCadastrada == funcionarioSenha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 2- Método para autenticar se funcionário é gerente
        // ********** FUNCIONAL **********
        public bool AutenticarGerente_DAO(string funcionarioUsuario)
        {
            // Verificar se o funcionário é um gerente
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string cargo = null;
                string query = "SELECT cargo_funcionario FROM funcionario WHERE usuario_funcionario = @Usuario";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    cargo = reader.GetString("cargo_funcionario");
                }

                if (cargo == "Gerente")
                {
                    return true; // Apenas retorna true se o funcionário for um gerente
                }
                else
                {
                    return false; // Retorna false se o funcionário não for um gerente
                }
            }
        }

        // 3- Método para verificar se um nome de usuário já está em uso
        // ********** ERRO **********
        public bool VerificarUsuarioDisponivel_DAO(string funcionarioUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM funcionario WHERE usuario_funcionario = @Usuario";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // 4- Método para alterar senha do funcionário
        // ********** FUNCIONAL **********
        public void AlterarSenhaFuncionario_DAO(string funcionarioUsuario, string novaSenha)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE funcionario SET credenciais_funcionario = @Senha WHERE usuario_funcionario = @Usuario";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);
                command.Parameters.AddWithValue("@Senha", novaSenha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 5- Método para cadastrar novo funcionário
        // ********** FUNCIONAL **********
        public void CadastrarFuncionario_DAO(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Cria uma nova conexão com o banco de dados usando a classe MySqlConnection
            {
                connection.Open(); // Abre a conexão com o banco de dados
                using (MySqlTransaction transaction = connection.BeginTransaction()) // Inicia uma transação para garantir a consistência dos dados
                {
                    try // Tenta executar as operações dentro da transação
                    {
                        string insertFuncionarioQuery = @"INSERT INTO funcionario (nome_funcionario, sexo_funcionario, email_funcionario, cargo_funcionario, 
                                                        usuario_funcionario, credenciais_funcionario, ativo_funcionario) 
                                                        VALUES (@Nome, @Sexo, @Email, @Cargo, @Usuario, @Senha, @StatusAtivo)";
                        
                        using (MySqlCommand insertFuncionarioCommand = new MySqlCommand(insertFuncionarioQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                        {
                            // Adiciona os parâmetros ao comando com os valores do funcionario, puxando da instância da classe Funcionario
                            insertFuncionarioCommand.Parameters.AddWithValue("@Nome", funcionario.Nome);
                            insertFuncionarioCommand.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                            insertFuncionarioCommand.Parameters.AddWithValue("@Email", funcionario.Email);
                            insertFuncionarioCommand.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                            insertFuncionarioCommand.Parameters.AddWithValue("@Usuario", funcionario.Usuario);
                            insertFuncionarioCommand.Parameters.AddWithValue("@Senha", funcionario.Senha);
                            insertFuncionarioCommand.Parameters.AddWithValue("@StatusAtivo", funcionario.StatusAtivo);
                            insertFuncionarioCommand.ExecuteNonQuery(); // Executa a consulta SQL para inserir os dados do funcionario

                            int funcionarioId = (int)insertFuncionarioCommand.LastInsertedId; // Recupera o ID do funcionario recém-cadastrado

                            EnderecoFuncionario endereco = funcionario.Endereco; // Instancia um objeto EnderecoFuncionario com os dados do endereço do funcionario

                            string insertEnderecoQuery = @"INSERT INTO endereco_funcionario (id_funcionario, logradouro_endfuncionario, numero_endfuncionario, complemento_endfuncionario, 
                                                        bairro_endfuncionario, cidade_endfuncionario, uf_endfuncionario, cep_endfuncionario, ativo_endfuncionario) 
                                                        VALUES (@funcionarioId, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep, @status)"; // Define a consulta SQL para cadastrar o endereço do funcionario

                            using (MySqlCommand insertEnderecoCommand = new MySqlCommand(insertEnderecoQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do endereço do funcionario, puxando da instância da classe EnderecoFuncionario
                                insertEnderecoCommand.Parameters.AddWithValue("@funcionarioId", funcionarioId);
                                insertEnderecoCommand.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                                insertEnderecoCommand.Parameters.AddWithValue("@numero", endereco.Numero);
                                insertEnderecoCommand.Parameters.AddWithValue("@complemento", endereco.Complemento);
                                insertEnderecoCommand.Parameters.AddWithValue("@bairro", endereco.Bairro);
                                insertEnderecoCommand.Parameters.AddWithValue("@cidade", endereco.Cidade);
                                insertEnderecoCommand.Parameters.AddWithValue("@uf", endereco.UF);
                                insertEnderecoCommand.Parameters.AddWithValue("@cep", endereco.CEP);
                                insertEnderecoCommand.Parameters.AddWithValue("@status", endereco.StatusAtivo);
                                insertEnderecoCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o endereço do funcionario
                            }

                            TelefoneFuncionario telefone = funcionario.Telefone; // Instancia um objeto TelefoneFuncionario com os dados do telefone do funcionario

                            string insertTelefoneQuery = @"INSERT INTO telefone_funcionario (id_funcionario, ddd_telfuncionario, numero_telfuncionario, ativo_telfuncionario) 
                                                        VALUES (@funcionarioId, @ddd, @numero, @status)"; // Define a consulta SQL para cadastrar o telefone do funcionario

                            using (MySqlCommand insertTelefoneCommand = new MySqlCommand(insertTelefoneQuery, connection, transaction)) // Cria um comando MySqlCommand com a consulta SQL, a conexão e a transação
                            {
                                // Adiciona os parâmetros ao comando com os valores do telefone do funcionario, puxando da instância da classe TelefoneFuncionario
                                insertTelefoneCommand.Parameters.AddWithValue("@funcionarioId", funcionarioId);
                                insertTelefoneCommand.Parameters.AddWithValue("@ddd", telefone.DDD);
                                insertTelefoneCommand.Parameters.AddWithValue("@numero", telefone.Numero);
                                insertTelefoneCommand.Parameters.AddWithValue("@status", telefone.StatusAtivo);
                                insertTelefoneCommand.ExecuteNonQuery(); // Executa a consulta SQL para cadastrar o telefone do funcionario
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

        // 6- Método para alterar dados do funcionário
        // ********** NÃO TESTADO **********
        public void AlterarFuncionario_DAO(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE funcionario SET nome_funcionario = @Nome, sexo_funcionario = @Sexo, email_funcionario = @Email, cargo_funcionario = @Cargo, 
                    usuario_funcionario = @Usuario, credenciais_funcionario = @Senha, ativo_funcionario = @StatusAtivo WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionario.ID);
                command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                command.Parameters.AddWithValue("@Email", funcionario.Email);
                command.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
                command.Parameters.AddWithValue("@Usuario", funcionario.Usuario);
                command.Parameters.AddWithValue("@Senha", funcionario.Senha);
                command.Parameters.AddWithValue("@StatusAtivo", funcionario.StatusAtivo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 7- Método para excluir (desativar) funcionário
        // ********** FUNCIONAL **********
        public void ExcluirFuncionario_DAO(int funcionarioId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE funcionario SET ativo_funcionario = 0 WHERE id_funcionario = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionarioId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 8- Listagem
        // 8.1- Método para listar funcionários ativos
        // ********** FUNCIONAL **********
        public List<Funcionario> ListarFuncionariosAtivos_DAO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT f.id_funcionario, f.nome_funcionario, f.sexo_funcionario, f.email_funcionario, f.cargo_funcionario, 
                                f.usuario_funcionario, f.ativo_funcionario, 
                                t.ddd_telfuncionario, t.numero_telfuncionario, t.ativo_telfuncionario, 
                                e.logradouro_endfuncionario, e.numero_endfuncionario, e.complemento_endfuncionario, e.bairro_endfuncionario, e.cidade_endfuncionario, 
                                e.uf_endfuncionario, e.cep_endfuncionario, e.ativo_endfuncionario
                                FROM funcionario f
                                LEFT JOIN telefone_funcionario t ON f.id_funcionario = t.id_funcionario
                                LEFT JOIN endereco_funcionario e ON f.id_funcionario = e.id_funcionario
                                WHERE f.ativo_funcionario = true";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int funcionarioId = reader.GetInt32("id_funcionario");

                            Funcionario funcionario = new Funcionario
                            {
                                ID = funcionarioId,
                                Nome = reader.GetString("nome_funcionario"),
                                Sexo = reader.GetString("sexo_funcionario"),
                                Email = reader.GetString("email_funcionario"),
                                Cargo = reader.GetString("cargo_funcionario"),
                                Usuario = reader.GetString("usuario_funcionario"),
                                StatusAtivo = reader.GetBoolean("ativo_funcionario"),
                                Telefone = new TelefoneFuncionario
                                {
                                    DDD = reader.GetString("ddd_telfuncionario"),
                                    Numero = reader.GetString("numero_telfuncionario"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfuncionario")
                                },
                                Endereco = new EnderecoFuncionario
                                {
                                    Logradouro = reader.GetString("logradouro_endfuncionario"),
                                    Numero = reader.GetString("numero_endfuncionario"),
                                    Complemento = reader.IsDBNull("complemento_endfuncionario") ? null : reader.GetString("complemento_endfuncionario"),
                                    Bairro = reader.GetString("bairro_endfuncionario"),
                                    Cidade = reader.GetString("cidade_endfuncionario"),
                                    UF = reader.GetString("uf_endfuncionario"),
                                    CEP = reader.GetString("cep_endfuncionario"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfuncionario")
                                }
                            };

                            funcionarios.Add(funcionario);
                        }
                    }
                }
            }
            return funcionarios;
        }

        // 8.2- Método para listar todos os funcionários
        // ********** NÃO TESTADO **********
        public List<Funcionario> ListarTodosFuncionarios_DAO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT f.id_funcionario, f.nome_funcionario, f.email_funcionario, f.sexo_funcionario, f.cargo_funcionario, 
                                f.usuario_funcionario, f.ativo_funcionario, 
                                t.ddd_telfuncionario, t.numero_telfuncionario, t.ativo_telfuncionario, 
                                e.logradouro_endfuncionario, e.numero_endfuncionario, e.complemento_endfuncionario, e.bairro_endfuncionario, e.cidade_endfuncionario, 
                                e.uf_endfuncionario, e.cep_endfuncionario, e.ativo_endfuncionario
                                FROM funcionario f
                                LEFT JOIN telefone_funcionario t ON f.id_funcionario = t.id_funcionario
                                LEFT JOIN endereco_funcionario e ON c.id_funcionario = e.id_funcionario
                                ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int funcionarioId = reader.GetInt32("id_funcionario");

                            Funcionario funcionario = new Funcionario
                            {
                                ID = funcionarioId,
                                Nome = reader.GetString("nome_funcionario"),
                                Email = reader.GetString("email_funcionario"),
                                Sexo = reader.GetString("sexo_funcionario"),
                                Cargo = reader.GetString("cargo_funcionario"),
                                Usuario = reader.GetString("usuario_funcionario"),
                                StatusAtivo = reader.GetBoolean("ativo_funcionario"),
                                Telefone = new TelefoneFuncionario
                                {
                                    DDD = reader.GetString("ddd_telfuncionario"),
                                    Numero = reader.GetString("numero_telfuncionario"),
                                    StatusAtivo = reader.GetBoolean("ativo_telfuncionario")
                                },
                                Endereco = new EnderecoFuncionario
                                {
                                    Logradouro = reader.GetString("logradouro_endfuncionario"),
                                    Numero = reader.GetString("numero_endfuncionario"),
                                    Complemento = reader.IsDBNull("complemento_endfuncionario") ? null : reader.GetString("complemento_endfuncionario"),
                                    Bairro = reader.GetString("bairro_endfuncionario"),
                                    Cidade = reader.GetString("cidade_endfuncionario"),
                                    UF = reader.GetString("uf_endfuncionario"),
                                    CEP = reader.GetString("cep_endfuncionario"),
                                    StatusAtivo = reader.GetBoolean("ativo_endfuncionario")
                                }
                            };

                            funcionarios.Add(funcionario);
                        }
                    }
                }
            }
            return funcionarios;
        }

        // 9- Consulta
        // 9.1- Método para consultar funcionário por ID (somente funcionários ativos)
        // ********** FUNCIONAL **********
        public Funcionario ConsultarFuncionarioID_DAO(int funcionarioId)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionario WHERE id_funcionario = @ID AND ativo_funcionario = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionarioId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("id_funcionario"),
                        Nome = reader.GetString("nome_funcionario"),
                        Sexo = reader.GetString("sexo_funcionario"),
                        Email = reader.GetString("email_funcionario"),
                        Cargo = reader.GetString("cargo_funcionario"),
                        Usuario = reader.GetString("usuario_funcionario"),
                        Senha = reader.GetString("credenciais_funcionario"),
                        StatusAtivo = reader.GetBoolean("ativo_funcionario")
                    };
                }
            }

            return funcionario;
        }

        // 9.2- Método para consultar funcionário por nome (somente funcionários ativos)
        // ********** FUNCIONAL **********
        public Funcionario ConsultarFuncionarioNome_DAO(string funcionarioNome)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionario WHERE nome_funcionario = @Nome AND ativo_funcionario = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", funcionarioNome);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("id_funcionario"),
                        Nome = reader.GetString("nome_funcionario"),
                        Sexo = reader.GetString("sexo_funcionario"),
                        Email = reader.GetString("email_funcionario"),
                        Cargo = reader.GetString("cargo_funcionario"),
                        Usuario = reader.GetString("usuario_funcionario"),
                        Senha = reader.GetString("credenciais_funcionario"),
                        StatusAtivo = reader.GetBoolean("ativo_funcionario")
                    };
                }
            }

            return funcionario;
        }

        // 9.3- Método para consultar funcionário por nome de usuário (somente funcionários ativos)
        // ********** FUNCIONAL **********
        public Funcionario ConsultarFuncionarioUsuario_DAO(string funcionarioUsuario)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionario WHERE usuario_funcionario = @Usuario AND ativo_funcionario = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("id_funcionario"),
                        Nome = reader.GetString("nome_funcionario"),
                        Sexo = reader.GetString("sexo_funcionario"),
                        Email = reader.GetString("email_funcionario"),
                        Cargo = reader.GetString("cargo_funcionario"),
                        Usuario = reader.GetString("usuario_funcionario"),
                        Senha = reader.GetString("credenciais_funcionario"),
                        StatusAtivo = reader.GetBoolean("ativo_funcionario")
                    };
                }
            }

            return funcionario;
        }

    }
}