using MySqlX.XDevAPI;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PIMFazendaUrbana
{
    public partial class TelaCadastrarFuncionario : Form
    {
        Funcionario funcionario1 = new Funcionario();

        bool nomevalido = false;
        bool emailvalido = false;
        bool usuariovalido = false;
        bool senhavalida = false;
        bool cargovalido = false;
        bool sexovalido = false;

        bool dddvalido = false;
        bool telefonevalido = false;

        bool logradourovalido = false;
        bool numerocasavalido = false;
        bool bairrovalido = false;
        bool cidadevalida = false;
        bool ufvalido = false;
        bool cepvalido = false;

        FuncionarioDAO funcionarioDAO; // Declaração de uma instância de FuncionarioDAO
        FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService

        public TelaCadastrarFuncionario()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; ; // Substitua pelos valores reais da conexão com o banco de dados

            funcionarioDAO = new FuncionarioDAO(connectionString); // Cria uma instância de FuncionarioDAO passando a string de conexão como parâmetro
            funcionarioService = new FuncionarioService(funcionarioDAO); // Cria uma instância de FuncionarioService passando o funcionarioDAO como parâmetro
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            if (nomevalido == false)
            {
                MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (emailvalido == false)
            {
                MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cargovalido == false)
            {
                MessageBox.Show("Preencha o campo Cargo corretamente. O cargo deve ser 'Funcionário' ou 'Gerente'", "Cargo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (sexovalido == false)
            {
                MessageBox.Show("Preencha o campo Sexo corretamente. O sexo deve ser 'M', 'F' ou '-'", "Sexo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*
            else if (usuariovalido == false)
            {
                MessageBox.Show("Preencha o campo Usuário corretamente. O usuário deve ter ao menos 3 caracteres", "Usuário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
            else if (senhavalida == false)
            {
                MessageBox.Show("Preencha ambos os campos de Senha corretamente. A senha deve ter ao menos 8 caracteres, uma letra maiúscula, uma letra minúscula, um número e um caracter especial", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxSenha1; // Define o foco para o TextBoxSenha1
                return;
            }
            else if (dddvalido == false)
            {
                MessageBox.Show("Preencha o campo DDD corretamente. O DDD deve ter 2 números", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxDDD; // Define o foco para o TextBoxDDD
                return;
            }
            else if (telefonevalido == false)
            {
                MessageBox.Show("Preencha o campo Telefone corretamente. O telefone deve ter 8 ou 9 números", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxTelefone; // Define o foco para o TextBoxTelefone
                return;
            }
            else if (logradourovalido == false)
            {
                MessageBox.Show("Preencha o campo Logradouro corretamente. O logradouro deve ter ao menos 3 caracteres", "Logradouro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxLogradouro; // Define o foco para o TextBoxLogradouro
                return;
            }
            else if (numerocasavalido == false)
            {
                MessageBox.Show("Preencha o campo Número corretamente. O número deve ter apenas caracteres numéricos", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxNumero; // Define o foco para o TextBoxNumero
                return;
            }
            else if (bairrovalido == false)
            {
                MessageBox.Show("Preencha o campo Bairro corretamente. O bairro deve ter ao menos 3 caracteres", "Bairro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxBairro; // Define o foco para o TextBoxBairro
                return;
            }
            else if (cidadevalida == false)
            {
                MessageBox.Show("Preencha o campo Cidade corretamente. A cidade deve ter ao menos 3 caracteres", "Cidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxCidade; // Define o foco para o TextBoxCidade
                return;
            }
            else if (ufvalido == false)
            {
                MessageBox.Show("Preencha o campo UF corretamente. A UF deve ter 2 caracteres maiúsculos do alfabeto", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = ComboBoxUF; // Define o foco para o ComboBoxUF
                return;
            }
            else if (cepvalido == false)
            {
                MessageBox.Show("Preencha o campo CEP corretamente. O CEP deve ter 8 números", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxCEP; // Define o foco para o TextBoxCEP
                return;
            }
            else
            {
                funcionario1.Nome = TextBoxNome.Text;
                funcionario1.Email = TextBoxEmail.Text;
                funcionario1.Usuario = TextBoxUsuario.Text;
                funcionario1.Senha = TextBoxSenha1.Text;

                funcionario1.Cargo = ComboBoxCargo.Text;
                funcionario1.Sexo = ComboBoxSexo.Text;

                funcionario1.StatusAtivo = true;

                funcionario1.Endereco = new EnderecoFuncionario();
                funcionario1.Endereco.Logradouro = TextBoxLogradouro.Text;
                funcionario1.Endereco.Numero = TextBoxNumero.Text;
                funcionario1.Endereco.Complemento = TextBoxComplemento.Text;
                funcionario1.Endereco.Bairro = TextBoxBairro.Text;
                funcionario1.Endereco.Cidade = TextBoxCidade.Text;
                funcionario1.Endereco.UF = ComboBoxUF.Text;
                funcionario1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                funcionario1.Endereco.StatusAtivo = true;

                funcionario1.Telefone = new TelefoneFuncionario();
                funcionario1.Telefone.DDD = TextBoxDDD.Text;
                funcionario1.Telefone.Numero = TextBoxTelefone.Text;
                funcionario1.Telefone.StatusAtivo = true;

                bool sucesso = funcionarioService.CadastrarFuncionario(funcionario1); // Chamando o método CadastrarFuncionario da instância funcionarioService
                if (sucesso == true)
                {
                    MessageBox.Show("Usuário cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FuncionarioCadastradoSucesso?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar usuário. Verifique se o usuário já está cadastrado, ou entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do funcionario
        public event EventHandler FuncionarioCadastradoSucesso;

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxNome_Validating(object sender, CancelEventArgs e)
        {
            string Nome = TextBoxNome.Text;
            if (Nome.Length < 3)
            {
                // Define a cor de texto para vermelho
                TextBoxNome.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nomevalido = false;
                this.ActiveControl = TextBoxNome; // Define o foco para o TextBoxNome
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNome.ForeColor = Color.Black;
                nomevalido = true;
            }
        }

        private void TextBoxEmail_Validating(object sender, EventArgs e)
        {
            string Email = TextBoxEmail.Text;
            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxEmail.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                emailvalido = false;
                this.ActiveControl = TextBoxEmail; // Define o foco para o TextBoxEmail
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxEmail.ForeColor = Color.Black;
                emailvalido = true;
            }
        }

        private void ComboBoxCargo_Validating(object sender, CancelEventArgs e)
        {
            string text = ComboBoxCargo.Text.Trim(); // Remover espaços em branco extras
            if (text != "Funcionário" && text != "Gerente")
            {
                // Define a cor de texto para vermelho
                ComboBoxCargo.ForeColor = Color.Red;

                MessageBox.Show("O cargo deve ser 'Funcionário' ou 'Gerente'.", "Cargo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cargovalido = false;
                this.ActiveControl = ComboBoxCargo; // Define o foco para o ComboBoxCargo
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxCargo.ForeColor = Color.Black;
                cargovalido = true;
            }
        }

        private void ComboBoxSexo_Validating(object sender, CancelEventArgs e)
        {
            string text = ComboBoxSexo.Text.Trim(); // Remover espaços em branco extras
            if (text != "M" && text != "F" && text != "-")
            {
                // Define a cor de texto para vermelho
                ComboBoxSexo.ForeColor = Color.Red;

                MessageBox.Show("O sexo deve ser 'M', 'F' ou '-'.", "Sexo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sexovalido = false;
                this.ActiveControl = ComboBoxSexo; // Define o foco para o ComboBoxSexo
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxSexo.ForeColor = Color.Black;
                sexovalido = true;
            }
        }

        private void TextBoxUsuario_Validating(object sender, CancelEventArgs e)
        {
            string usuario = TextBoxUsuario.Text;
            if (VerificarUsuarioDisponivel(usuario) == true)
            {
                TextBoxUsuario.ForeColor = Color.Black;
                usuariovalido = true;
                this.ActiveControl = TextBoxUsuario; // Define o foco para o TextBoxUsuario
            }
            else
            {
                TextBoxUsuario.ForeColor = Color.Red;
                usuariovalido = false;
            }
        }

        // Verificar se um nome de usuário já está em uso
        // ********** DANDO ERRO **********
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
                MessageBox.Show("Nome de usuário indisponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (verificarUsuarioDisponivel == "erro")
            {
                MessageBox.Show("Erro ao verificar disponibilidade do nome de usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return false;
            }
        }

        private void TextBoxDDD_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxDDD.Text;
            if (!Regex.IsMatch(text, @"^\d{2}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxDDD.ForeColor = Color.Red;

                MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dddvalido = false;
                this.ActiveControl = TextBoxDDD; // Define o foco para o TextBoxDDD
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxDDD.ForeColor = Color.Black;
                dddvalido = true;
            }
        }

        private void TextBoxTelefone_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxTelefone.Text;
            if (!Regex.IsMatch(text, @"^\d{8,9}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxTelefone.ForeColor = Color.Red;

                MessageBox.Show("O número de telefone deve conter 8 ou 9 caracteres numéricos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                telefonevalido = false;
                this.ActiveControl = TextBoxTelefone; // Define o foco para o TextBoxTelefone
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxTelefone.ForeColor = Color.Black;
                telefonevalido = true;
            }
        }

        private void TextBoxLogradouro_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxLogradouro.Text;
            if (text.Length < 3)
            {
                // Define a cor de texto para vermelho
                TextBoxLogradouro.ForeColor = Color.Red;

                MessageBox.Show("O logradouro deve conter ao menos 3 caracteres.", "Logradouro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logradourovalido = false;
                this.ActiveControl = TextBoxLogradouro; // Define o foco para o TextBoxLogradouro
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxLogradouro.ForeColor = Color.Black;
                logradourovalido = true;
            }
        }

        private void TextBoxNumero_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxNumero.Text;
            if (!Regex.IsMatch(text, @"^\d+$"))
            {
                // Define a cor de texto para vermelho
                TextBoxNumero.ForeColor = Color.Red;

                MessageBox.Show("O número deve conter apenas caracteres numéricos.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numerocasavalido = false;
                this.ActiveControl = TextBoxNumero; // Define o foco para o TextBoxNumero
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNumero.ForeColor = Color.Black;
                numerocasavalido = true;
            }
        }

        private void TextBoxBairro_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxBairro.Text;
            if (text.Length < 3)
            {
                // Define a cor de texto para vermelho
                TextBoxBairro.ForeColor = Color.Red;

                MessageBox.Show("O bairro deve conter ao menos 3 caracteres.", "Bairro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bairrovalido = false;
                this.ActiveControl = TextBoxBairro; // Define o foco para o TextBoxBairro
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxBairro.ForeColor = Color.Black;
                bairrovalido = true;
            }
        }

        private void TextBoxCidade_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxCidade.Text;
            if (text.Length < 3)
            {
                // Define a cor de texto para vermelho
                TextBoxCidade.ForeColor = Color.Red;

                MessageBox.Show("A cidade deve conter ao menos 3 caracteres.", "Cidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cidadevalida = false;
                this.ActiveControl = TextBoxCidade; // Define o foco para o TextBoxCidade
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCidade.ForeColor = Color.Black;
                cidadevalida = true;
            }
        }

        private void ComboBoxUF_Validating(object sender, CancelEventArgs e)
        {
            string text = ComboBoxUF.Text.Trim(); // Remover espaços em branco extras
            if (!Regex.IsMatch(text, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$"))
            {
                // Define a cor de texto para vermelho
                ComboBoxUF.ForeColor = Color.Red;

                MessageBox.Show("Selecione uma UF válida.", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ufvalido = false;
                this.ActiveControl = ComboBoxUF; // Define o foco para o ComboBoxUF
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxUF.ForeColor = Color.Black;
                ufvalido = true;
            }
        }

        private void TextBoxCEP_Validating(object sender, CancelEventArgs e)
        {
            // Remove todos os caracteres não numéricos do texto
            string cepDigitsOnly = TextBoxCEP.Text.Replace("-", "");

            // Verifica se o CEP tem exatamente 8 dígitos
            if (cepDigitsOnly.Length != 8 || !cepDigitsOnly.All(char.IsDigit))
            {
                // Define a cor de texto para vermelho
                TextBoxCEP.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                MessageBox.Show("Preencha o campo CEP corretamente. O CEP deve conter 8 números.", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cepvalido = false;
                this.ActiveControl = TextBoxCEP; // Define o foco para o TextBoxCEP
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCEP.ForeColor = Color.Black;
                cepvalido = true;
            }
        }

        private void TextBoxSenha2_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxSenha1.Text == null)
            {
                MessageBox.Show("Preencha o campo Senha", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxSenha1.ForeColor = Color.Red;
            }
            else
            {
                string senha1 = TextBoxSenha1.Text;
                string senha2 = TextBoxSenha2.Text;

                // Verificar se a senha é forte o suficiente
                bool senhaforte = VerificarSenhaForte(senha1);

                if (senhaforte == false)
                {
                    senhavalida = false;
                    TextBoxSenha1.ForeColor = Color.Red;
                    TextBoxSenha2.ForeColor = Color.Red;
                    this.ActiveControl = TextBoxSenha1; // Define o foco para o TextBoxSenha1
                    return;
                }
                else
                {
                    if (senha1 != senha2)
                    {
                        MessageBox.Show("As senhas são diferentes, confira e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        senhavalida = false;
                        TextBoxSenha1.ForeColor = Color.Red;
                        TextBoxSenha2.ForeColor = Color.Red;
                        this.ActiveControl = TextBoxSenha2; // Define o foco para o TextBoxSenha1
                    }
                    else
                    {
                        senhavalida = true;
                        TextBoxSenha1.ForeColor = Color.Black;
                        TextBoxSenha2.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Método dedicado para verificar se a senha é forte o suficiente
        // ********** FUNCIONAL **********
        public bool VerificarSenhaForte(string senha)
        {
            // Verifica se a senha tem pelo menos 8 caracteres
            if (senha.Length < 8)
            {
                MessageBox.Show("A senha deve conter no mínimo 8 caracteres.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                MessageBox.Show("A senha deve conter pelo menos um número.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("A senha deve conter pelo menos uma letra maiúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("A senha deve conter pelo menos uma letra minúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("A senha deve conter pelo menos um caractere especial.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Se a senha passar por todas as verificações, é considerada forte
            return true;
            //MessageBox.Show("Senha forte.", "Senha Forte", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
