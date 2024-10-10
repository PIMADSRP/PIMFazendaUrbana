using MySqlX.XDevAPI;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace PIMFazendaUrbanaLib
{
    public class FuncionarioService
    {
        private readonly FuncionarioDAO funcionarioDAO;
        public FuncionarioService()
        {
            this.funcionarioDAO = new FuncionarioDAO();
        }

        public string AutenticarFuncionario(string usuario, string senha)
        {
            try
            {
                string autenticado = funcionarioDAO.AutenticarFuncionario(usuario, senha);
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

        public string AutenticarGerente(string usuario)
        {
            try
            {
                if (funcionarioDAO.AutenticarGerente(usuario) == true)
                {
                    return "gerente"; // Retorna "gerente" para indicar que o funcionário foi autenticado como gerente
                }
                else
                {
                    return "naogerente"; // Retorna "naogerente" para indicar que o funcionário não foi autenticado como gerente
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar funcionário: " + ex.Message);
            }
        }

        public bool VerificarUsuarioDisponivel(string usuario)
        {
            try
            {
                if (funcionarioDAO.VerificarUsuarioDisponivel(usuario) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar disponibilidade de usuário: " + ex.Message);
            }
        }

        public bool AlterarSenhaFuncionario(string usuario, string novaSenha)
        {
            try
            {
                funcionarioDAO.AlterarSenhaFuncionario(usuario, novaSenha);

                return true; // Retorna true para indicar que a alteração da senha foi bem-sucedida
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar senha do funcionário: " + ex.Message);
            }
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                ValidarFuncionario(funcionario);
                funcionarioDAO.CadastrarFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar funcionário: " + ex.Message);
            }
        }

        public void AlterarFuncionario(Funcionario funcionario)
        {
            try
            {
                funcionarioDAO.AlterarFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar funcionário: " + ex.Message);
            }
        }

        public void ExcluirFuncionario(int funcionarioId)
        {
            try
            {
                funcionarioDAO.ExcluirFuncionario(funcionarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir funcionário: " + ex.Message);
            }
        }

        public List<Funcionario> ListarFuncionariosAtivos()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.ListarFuncionariosAtivos();
                return funcionarios; // Retorna a lista de funcionarios quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar funcionarios ativos
                throw new Exception("Erro ao listar funcionários ativos: " + ex.Message);
            }
        }

        public List<Funcionario> ListarFuncionariosInativos()
        {
            try
            {
                List<Funcionario> funcionariosInativos = funcionarioDAO.ListarFuncionariosInativos();
                return funcionariosInativos; // Retorna a lista de funcionarios quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar funcionarios inativos
                throw new Exception("Erro ao listar funcionários inativos: " + ex.Message);
            }
        }

        public Funcionario ConsultarFuncionarioID(int funcionarioId)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioID(funcionarioId);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar funcionário: " + ex.Message);
            }
        }

        public Funcionario ConsultarFuncionarioNome(string funcionarioNome)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioNome(funcionarioNome);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar funcionário: " + ex.Message);
            }
        }

        public Funcionario ConsultarFuncionarioUsuario(string funcionarioUsuario)
        {
            try
            {
                Funcionario funcionario = funcionarioDAO.ConsultarFuncionarioUsuario(funcionarioUsuario);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar funcionário: " + ex.Message);
            }
        }

        public List<Funcionario> FiltrarFuncionariosNome(string funcionarioNome)
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioDAO.FiltrarFuncionariosNome(funcionarioNome);
                return funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar funcionários por nome: " + ex.Message);
            }
        }

        public void ValidarFuncionario(Funcionario funcionario)  // método para validação dos dados do funcionario contendo as regras de negócio e mensagens de erro
        {
            var erros = new List<ValidationError>();

            if (string.IsNullOrEmpty(funcionario.Nome) || funcionario.Nome.Length < 3)
            {
                erros.Add(new ValidationError("Nome", "O nome deve ter pelo menos 3 caracteres"));
            }
            if (!Regex.IsMatch(funcionario.CPF, @"^\d{11}$") || !funcionario.CPF.All(char.IsDigit))
            {
                erros.Add(new ValidationError("CPF", "O CPF deve conter 11 dígitos"));
            }
            if (!Regex.IsMatch(funcionario.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                erros.Add(new ValidationError("Email", "Email inválido. O email deve ter o formato exemplo@exemplo.exeplo"));
            }
            if (funcionario.Cargo != "Funcionário" && funcionario.Cargo != "Gerente")
            {
                erros.Add(new ValidationError("Cargo", "O cargo deve ser 'Funcionário' ou 'Gerente'"));
            }

            // deixar validação se os dos campos de senha são iguais no front mesmo

            

            TelefoneValidation telefoneValidation = new TelefoneValidation();
            erros = telefoneValidation.ValidarTelefone(funcionario.Telefone, erros);
            EnderecoValidation enderecoValidation = new EnderecoValidation();
            erros = enderecoValidation.ValidarEndereco(funcionario.Endereco, erros);

            if (erros.Any()) // se teve algum erro, lança exceção com a lista de erros
            {
                throw new ValidationException(erros);
            }
        }

        private void ValidarSexo(List<string> camposInvalidos)
        {
            string textSexo = ComboBoxSexo.Text.Trim(); // Remover espaços em branco extras     // Valida Sexo
            if (textSexo != "M" && textSexo != "F" && textSexo != "-")
            {
                camposInvalidos.Add("Sexo");

                // Define a cor de texto para vermelho
                ComboBoxSexo.ForeColor = Color.Red;

                //MessageBox.Show("O sexo deve ser 'M', 'F' ou '-'.", "Sexo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipSexo, ComboBoxSexo, 0, -50, 5000); // Mostrar a tooltip

                sexovalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxSexo.ForeColor = Color.Black;
                sexovalido = true;
            }
        }

        private void ValidarUsuario(List<string> camposInvalidos)
        {
            string usuario = TextBoxUsuario.Text; // Valida Usuario

            if (TextBoxUsuario.Text.Length < 3)
            {
                camposInvalidos.Add("Usuário");

                TextBoxUsuario.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo Usuário corretamente. O nome de usuário deve ter ao menos 3 caracteres", "Nome de Usuário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipUsuario, TextBoxUsuario, 0, -50, 5000); // Mostrar a tooltip

                usuariovalido = false;
            }
            else
            {
                if (VerificarUsuarioDisponivel(usuario) == true)
                {
                    TextBoxUsuario.ForeColor = Color.Black;
                    usuariovalido = true;
                }
                else
                {
                    TextBoxUsuario.ForeColor = Color.Red;
                    usuariovalido = false;
                }
            }
        }

        private void TextBoxUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxUsuario.Text.Length >= 3)
            {
                VerificarUsuarioDisponivel(TextBoxUsuario.Text);
            }
        }

        // Verificar se um nome de usuário já está em uso
        private bool VerificarUsuarioDisponivel(string usuario)
        {
            string verificarUsuarioDisponivel = funcionarioService.VerificarUsuarioDisponivel(usuario); // Chamando o método VerificarUsuarioDisponivel da instância funcionarioService
            if (verificarUsuarioDisponivel == "disponivel")
            {
                MessageBox.Show("Nome de usuário disponível.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (verificarUsuarioDisponivel == "indisponivel")
            {
                MessageBox.Show("Nome de usuário indisponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (verificarUsuarioDisponivel == "erro")
            {
                MessageBox.Show("Erro ao verificar disponibilidade do nome de usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return false;
            }
        }

        // Método dedicado para verificar se a senha é forte o suficiente
        private bool VerificarSenhaForte(string senha)
        {
            // Verifica se a senha tem pelo menos 8 caracteres
            if (senha.Length < 8)
            {
                //MessageBox.Show("A senha deve conter no mínimo 8 caracteres.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipErrSenhaTamanho, TextBoxSenha1, 0, -50, 5000); // Mostrar a tooltip
                return false;
            }

            // Verifica se a senha contém pelo menos um número
            bool contemNumero = false;
            foreach (char c in senha)
            {
                if (char.IsDigit(c))
                {
                    contemNumero = true;
                    break;
                }
            }
            if (!contemNumero)
            {
                //MessageBox.Show("A senha deve conter pelo menos um número.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipErrSenhaNumeros, TextBoxSenha1, 0, -50, 5000); // Mostrar a tooltip
                return false;
            }

            // Verifica se a senha contém pelo menos uma letra maiúscula
            bool contemMaiuscula = false;
            foreach (char c in senha)
            {
                if (char.IsUpper(c))
                {
                    contemMaiuscula = true;
                    break;
                }
            }
            if (!contemMaiuscula)
            {
                //MessageBox.Show("A senha deve conter pelo menos uma letra maiúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipErrSenhaMaiuscula, TextBoxSenha1, 0, -50, 5000); // Mostrar a tooltip
                return false;
            }

            // Verifica se a senha contém pelo menos uma letra minúscula
            bool contemMinuscula = false;
            foreach (char c in senha)
            {
                if (char.IsLower(c))
                {
                    contemMinuscula = true;
                    break;
                }
            }
            if (!contemMinuscula)
            {
                //MessageBox.Show("A senha deve conter pelo menos uma letra minúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipErrSenhaMinuscula, TextBoxSenha1, 0, -50, 5000); // Mostrar a tooltip
                return false;
            }

            // Verifica se a senha contém pelo menos um caractere especial
            bool contemEspecial = false;
            foreach (char c in senha)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    contemEspecial = true;
                    break;
                }
            }
            if (!contemEspecial)
            {
                //MessageBox.Show("A senha deve conter pelo menos um caractere especial.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipErrSenhaCaracEsp, TextBoxSenha1, 0, -50, 5000); // Mostrar a tooltip
                return false;
            }

            // Se a senha passar por todas as verificações, é considerada forte
            return true;
            //MessageBox.Show("Senha forte.", "Senha Forte", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
