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
                string autenticado = funcionarioDAO.AutenticarFuncionario_DAO(usuario, senha);
                if (autenticado == "autenticado")
                {
                    return "autenticado"; // Retorna "autenticado" para indicar que o funcionário foi autenticado
                }
                else if (autenticado == "inativo")
                {
                    return "inativo"; // Retorna "inativo" para indicar que o funcionário está inativo
                }
                else if (autenticado == "naoautenticado")
                {
                    return "naoautenticado"; // Retorna "naoautenticado" para indicar que o funcionário não foi autenticado
                }
                else if (autenticado == "naoexiste")
                {
                    return "naoexiste"; // Retorna "naoexiste" para indicar que o funcionário não existe
                }
                else
                {
                    return "erro desconhecido";
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao autenticar o funcionário
            }
        }

        // 2- Método para autenticar funcionário
        public string AutenticarGerente(string usuario)
        {
            try
            {
                if (funcionarioDAO.AutenticarGerente_DAO(usuario) == true)
                {
                    // Aqui você pode fazer algo com os dados do funcionário autenticado.

                    return "gerente"; // Retorna "gerente" para indicar que o funcionário foi autenticado como gerente
                }
                else
                {
                    // Aqui você pode lidar com o caso em que o funcionário não é autenticado.

                    return "naogerente"; // Retorna "naogerente" para indicar que o funcionário não foi autenticado como gerente
                }
            }
            catch (Exception ex)
            {
                return "erro"; // Retorna "erro" para indicar que houve um erro ao autenticar o funcionário como gerente
            }
        }

        // 3- Método para verificar se um nome de usuário já está em uso
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

        // 4- Método para alterar senha do funcionário
        public bool AlterarSenhaFuncionario(string usuario, string novaSenha)
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

        // 5- Método para cadastrar novo funcionário
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

        // 6- Método para alterar dados do funcionário
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

        // 7- Método para excluir (desativar) funcionário
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

        // 8 - Listagem
        // 8.1- Método para listar funcionários ativos
        public List<Funcionario> ListarFuncionariosAtivos()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.ListarFuncionariosAtivos_DAO();
                return funcionarios; // Retorna a lista de funcionarios quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar funcionarios ativos
                throw new Exception("Erro ao listar funcionários ativos.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Funcionario>(); // Retorna uma lista vazia
            }
        }

        // 8.2- Método para listar todos os funcionários
        public List<Funcionario> ListarTodosFuncionarios()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.ListarTodosFuncionarios_DAO();
                return funcionarios; // Retorna a lista de funcionarios quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar funcionarios
                throw new Exception("Erro ao listar funcionários.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Funcionario>(); // Retorna uma lista vazia
            }
        }

        // 9 - Consulta
        // 9.1- Método para consultar funcionário por ID
        public Funcionario ConsultarFuncionarioID(int funcionarioId)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioID_DAO(funcionarioId);
                return funcionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 9.2- Método para consultar funcionário por nome
        public Funcionario ConsultarFuncionarioNome(string funcionarioNome)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioNome_DAO(funcionarioNome);
                return funcionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 9.3- Método para consultar funcionário por nome de usuário
        public Funcionario ConsultarFuncionarioUsuario(string funcionarioUsuario)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioUsuario_DAO(funcionarioUsuario);
                return funcionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
