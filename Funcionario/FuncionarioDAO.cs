using MySql.Data.MySqlClient;

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

                if (cargo == "gerente")
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
        // ********** NÃO TESTADO **********
        public void CadastrarFuncionario_DAO(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO funcionario (nome_funcionario, sexo_funcionario, email_funcionario, cargo_funcionario, usuario_funcionario, 
                    credenciais_funcionario, ativo_funcionario) VALUES (@Nome, @Sexo, @Email, @Cargo, @Usuario, @Senha, @StatusAtivo)";
                MySqlCommand command = new MySqlCommand(query, connection);
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
        // ********** NÃO TESTADO **********
        public List<Funcionario> ListarFuncionariosAtivos_DAO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionario WHERE ativo_funcionario = 1";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario
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

                    funcionarios.Add(funcionario);
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
                string query = "SELECT * FROM funcionario";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario
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

                    funcionarios.Add(funcionario);
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