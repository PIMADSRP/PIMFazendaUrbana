namespace PIMFazendaUrbana
{
    public class FuncionarioService
    {
        private FuncionarioDAO funcionarioDAO;

        public FuncionarioService(FuncionarioDAO funcionarioDAO)
        {
            this.funcionarioDAO = funcionarioDAO;
        }

        // 1- Método para autenticar funcionário
        public string AutenticarFuncionario(string usuario, string senha)
        {
            try
            {
                if (funcionarioDAO.AutenticarFuncionario_DAO(usuario, senha) == true)
                {
                    // Aqui você pode fazer algo com os dados do funcionário autenticado.

                    return "autenticado"; // Retorna "autenticado" para indicar que o funcionário foi autenticado
                }
                else
                {
                    // Aqui você pode lidar com o caso em que o funcionário não é autenticado.

                    return "naoautenticado"; // Retorna "naoautenticado" para indicar que o funcionário não foi autenticado
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao autenticar o funcionário
            }
        }

        // 2- Método para verificar se um nome de usuário já está em uso
        public string VerificarUsuarioDisponivel(string usuario)
        {
            try
            {
                if (funcionarioDAO.VerificarUsuarioDisponivel_DAO(usuario) == true)
                {
                    return "disponivel"; // Retorna "disponivel" para indicar que o usuário está disponível
                }
                else
                {
                    return "indisponivel"; // Retorna "indisponivel" para indicar que o usuário já está em uso
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao verificar a disponibilidade do usuário
            }
        }

        // 3- Método para alterar senha do funcionário
        public bool AlterarSenhaFuncionario(int usuario, string novaSenha)
        {
            try
            {
                funcionarioDAO.AlterarSenhaFuncionario_DAO(usuario, novaSenha);

                return true; // Retorna true para indicar que a alteração da senha foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a alteração da senha falhou
            }
        }

        // 4- Método para cadastrar novo funcionário
        public bool CadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                // Aqui você pode realizar validações dos dados do funcionário antes de chamara o DAO

                funcionarioDAO.CadastrarFuncionario_DAO(funcionario);

                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 5- Método para alterar dados do funcionário
        public bool AlterarFuncionario(Funcionario funcionario)
        {
            try
            {
                funcionarioDAO.AlterarFuncionario_DAO(funcionario);

                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a alteração falhou
            }
        }

        // 6- Método para excluir (desativar) funcionário
        public bool ExcluirFuncionario(int funcionarioId)
        {
            try
            {
                funcionarioDAO.ExcluirFuncionario_DAO(funcionarioId);

                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a exclusão falhou
            }
        }

        // 7 - Listagem
        // 7.1- Método para listar funcionários ativos
        public bool ListarFuncionariosAtivos()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.ListarFuncionariosAtivos_DAO();

                // Aqui você pode fazer algo com a lista de funcionários, como exibir em uma interface gráfica ou console.

                return true; // Retorna true para indicar que a listagem foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a listagem falhou
            }
        }

        // 7.2- Método para listar todos os funcionários
        public bool ListarTodosFuncionarios()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.ListarTodosFuncionarios_DAO();
                
                // Aqui você pode fazer algo com a lista de funcionários, como exibir em uma interface gráfica ou console.

                return true;  // Retorna true para indicar que a listagem foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false;  // Retorna false para indicar que a listagem falhou
            }
        }

        // 8 - Consulta
        // 8.1- Método para consultar funcionário por ID
        public string ConsultarFuncionarioID(int funcionarioId)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioID_DAO(funcionarioId);
                if (funcionario != null)
                {
                    // Aqui você pode fazer algo com os dados do funcionário encontrado.

                    return "encontrado"; // Retorna "encontrado" para indicar que o funcionário foi encontrado
                }
                else
                {
                    // Aqui você pode lidar com o caso em que o funcionário não é encontrado.

                    return "naoencontrado"; // Retorna "naoencontrado" para indicar que o funcionário não foi encontrado
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao consultar o funcionário
            }
        }

        // 8.2- Método para consultar funcionário por nome
        public string ConsultarFuncionarioNome(string funcionarioNome)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioNome_DAO(funcionarioNome);
                if (funcionario != null)
                {
                    // Aqui você pode fazer algo com os dados do funcionário encontrado.

                    return "encontrado"; // Retorna "encontrado" para indicar que o funcionário foi encontrado
                }
                else
                {
                    // Aqui você pode lidar com o caso em que o funcionário não é encontrado.

                    return "naoencontrado"; // Retorna "naoencontrado" para indicar que o funcionário não foi encontrado
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao consultar o funcionário
            }
        }

        // 8.3- Método para consultar funcionário por nome de usuário
        public string ConsultarFuncionarioUsuario(string funcionarioUsuario)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioUsuario_DAO(funcionarioUsuario);
                if (funcionario != null)
                {
                    // Aqui você pode fazer algo com os dados do funcionário encontrado.

                    return "encontrado"; // Retorna "encontrado" para indicar que o funcionário foi encontrado
                }
                else
                {
                    // Aqui você pode lidar com o caso em que o funcionário não é encontrado.

                    return "naoencontrado"; // Retorna "naoencontrado" para indicar que o funcionário não foi encontrado
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao consultar o funcionário
            }
        }

    }
}
