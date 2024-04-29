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
        // ********** NÃO TESTADO **********
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
                    SenhaCadastrada = reader.GetString("Senha");
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

        // 2- Método para verificar se um nome de usuário já está em uso
        // ********** NÃO TESTADO **********
        public bool VerificarUsuarioDisponivel_DAO(string funcionarioUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM funcionarios WHERE Usuario = @Usuario";
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

        // 3- Método para alterar senha do funcionário
        // ********** NÃO TESTADO **********
        public void AlterarSenhaFuncionario_DAO(int funcionarioId, string novaSenha)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE funcionarios SET Senha = @Senha WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionarioId);
                command.Parameters.AddWithValue("@Senha", novaSenha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 4- Método para cadastrar novo funcionário
        // ********** NÃO TESTADO **********
        public void CadastrarFuncionario_DAO(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO funcionarios (Nome, Sexo, Email, Cargo, Usuario, Senha, StatusAtivo) VALUES (@Nome, @Sexo, @Email, @Cargo, @Usuario, @Senha, @StatusAtivo)";
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

        // 5- Método para alterar dados do funcionário
        // ********** NÃO TESTADO **********
        public void AlterarFuncionario_DAO(Funcionario funcionario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE funcionarios SET Nome = @Nome, Sexo = @Sexo, Email = @Email, Cargo = @Cargo, Usuario = @Usuario, Senha = @Senha, StatusAtivo = @StatusAtivo WHERE ID = @ID";
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

        // 6- Método para excluir (desativar) funcionário
        // ********** NÃO TESTADO **********
        public void ExcluirFuncionario_DAO(int funcionarioId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE funcionarios SET StatusAtivo = 0 WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionarioId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // 7- Listagem
        // 7.1- Método para listar funcionários ativos
        // ********** NÃO TESTADO **********
        public List<Funcionario> ListarFuncionariosAtivos_DAO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionarios WHERE StatusAtivo = 1";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        Sexo = reader.GetString("Sexo"),
                        Email = reader.GetString("Email"),
                        Cargo = reader.GetString("Cargo"),
                        Usuario = reader.GetString("Usuario"),
                        Senha = reader.GetString("Senha"),
                        StatusAtivo = reader.GetBoolean("StatusAtivo")
                    };

                    funcionarios.Add(funcionario);
                }
            }

            return funcionarios;
        }

        // 7.2- Método para listar todos os funcionários
        // ********** NÃO TESTADO **********
        public List<Funcionario> ListarTodosFuncionarios_DAO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionarios";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        Sexo = reader.GetString("Sexo"),
                        Email = reader.GetString("Email"),
                        Cargo = reader.GetString("Cargo"),
                        Usuario = reader.GetString("Usuario"),
                        Senha = reader.GetString("Senha"),
                        StatusAtivo = reader.GetBoolean("StatusAtivo")
                    };

                    funcionarios.Add(funcionario);
                }
            }

            return funcionarios;
        }

        // 8- Consulta
        // 8.1- Método para consultar funcionário por ID
        // ********** NÃO TESTADO **********
        public Funcionario ConsultarFuncionarioID_DAO(int funcionarioId)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionarios WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", funcionarioId);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        Sexo = reader.GetString("Sexo"),
                        Email = reader.GetString("Email"),
                        Cargo = reader.GetString("Cargo"),
                        Usuario = reader.GetString("Usuario"),
                        Senha = reader.GetString("Senha"),
                        StatusAtivo = reader.GetBoolean("StatusAtivo")
                    };
                }
            }

            return funcionario;
        }

        // 8.2- Método para consultar funcionário por nome
        // ********** NÃO TESTADO **********
        public Funcionario ConsultarFuncionarioNome_DAO(string funcionarioNome)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionarios WHERE Nome = @Nome";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", funcionarioNome);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        Sexo = reader.GetString("Sexo"),
                        Email = reader.GetString("Email"),
                        Cargo = reader.GetString("Cargo"),
                        Usuario = reader.GetString("Usuario"),
                        Senha = reader.GetString("Senha"),
                        StatusAtivo = reader.GetBoolean("StatusAtivo")
                    };
                }
            }

            return funcionario;
        }

        // 8.3- Método para consultar funcionário por nome de usuário
        // ********** NÃO TESTADO **********
        public Funcionario ConsultarFuncionarioUsuario_DAO(string funcionarioUsuario)
        {
            Funcionario funcionario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM funcionarios WHERE Usuario = @Usuario";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", funcionarioUsuario);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    funcionario = new Funcionario
                    {
                        ID = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        Sexo = reader.GetString("Sexo"),
                        Email = reader.GetString("Email"),
                        Cargo = reader.GetString("Cargo"),
                        Usuario = reader.GetString("Usuario"),
                        Senha = reader.GetString("Senha"),
                        StatusAtivo = reader.GetBoolean("StatusAtivo")
                    };
                }
            }

            return funcionario;
        }

    }
}