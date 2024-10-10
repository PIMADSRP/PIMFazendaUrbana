using System.ComponentModel;
using System.Text.RegularExpressions;
using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{

    public partial class TelaCadastrarFuncionario : Form
    {
        internal Funcionario funcionario1 = new Funcionario();

        bool nomevalido = false;
        bool emailvalido = false;
        bool cpfvalido = false;
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

        private ToolTip toolTip;

        private const string tooltipErrSenhasDiferentes = "As senhas são diferentes, confira e tente novamente.";
        private const string tooltipErrSenhaTamanho = "A senha deve conter no mínimo 8 caracteres.";
        private const string tooltipErrSenhaNumeros = "A senha deve conter pelo menos um número.";
        private const string tooltipErrSenhaMaiuscula = "A senha deve conter pelo menos uma letra maiúscula.";
        private const string tooltipErrSenhaMinuscula = "A senha deve conter pelo menos uma letra minúscula.";
        private const string tooltipErrSenhaCaracEsp = "A senha deve conter pelo menos um caractere especial.";
        private const string tooltipErrTelefoneTamanho = "O número de telefone deve conter no máximo 9 dígitos.";

        private const string tooltipMostrarSenha = "Clique para mostrar ou esconder a senha.";
        private const string tooltipSenha = "A senha deve conter no mínimo 8 caracteres, um número, uma letra maiúscula, uma letra minúscula, e um caractere especial.";
        private const string tooltipSenha2 = "Repita a sua senha.";
        private const string tooltipNome = "O nome deve ter ao menos 3 caracteres.";
        private const string tooltipEmail = "O e-mail deve ter o formato exemplo@exemplo.exemplo.";
        private const string tooltipCPF = "O CPF deve conter 11 números.";
        private const string tooltipUsuario = "O nome de usuário deve ter ao menos 3 caracteres.";
        private const string tooltipCargo = "O cargo deve ser 'Funcionário' ou 'Gerente'.";
        private const string tooltipSexo = "O sexo deve ser 'M', 'F' ou '-'.";
        private const string tooltipDDD = "O DDD deve conter exatamente 2 caracteres numéricos.";
        private const string tooltipTelefone = "O número de telefone deve conter 8 ou 9 caracteres numéricos.";
        private const string tooltipLogradouro = "O logradouro deve conter ao menos 3 caracteres.";
        private const string tooltipNumero = "O número deve conter apenas caracteres numéricos.";
        private const string tooltipBairro = "O bairro deve conter ao menos 3 caracteres.";
        private const string tooltipCidade = "A cidade deve conter ao menos 3 caracteres.";
        private const string tooltipUF = "Selecione uma UF válida da lista.";
        private const string tooltipCEP = "O CEP deve conter 8 números.";

        internal FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService

        public TelaCadastrarFuncionario()
        {
            InitializeComponent();

            funcionarioService = new FuncionarioService(); // Cria uma instância de FuncionarioService

            TextBoxSenha1.UseSystemPasswordChar = true;
            TextBoxSenha2.UseSystemPasswordChar = true;

            toolTip = new ToolTip(); // Inicializar tooltip genérica

            // Configurações gerais de tooltip
            toolTip.ToolTipTitle = "Informação";  // Título do balão
            toolTip.ToolTipIcon = ToolTipIcon.Info; // Ícone de informação
            toolTip.IsBalloon = false; // Mostrar como balão
            toolTip.AutoPopDelay = 5000; // Tempo que o balão ficará visível (em milissegundos)
            toolTip.InitialDelay = 250;  // Tempo antes de aparecer
            toolTip.ReshowDelay = 500;   // Tempo antes de reaparecer

            // Associação de ToolTip com os controles
            toolTip.SetToolTip(this.TextBoxNome, tooltipNome);
            toolTip.SetToolTip(this.TextBoxEmail, tooltipEmail);
            toolTip.SetToolTip(this.MaskedTextBoxCPF, tooltipCPF);
            toolTip.SetToolTip(this.TextBoxUsuario, tooltipUsuario);
            toolTip.SetToolTip(this.PictureBoxMostrarSenha, tooltipMostrarSenha);
            toolTip.SetToolTip(this.TextBoxSenha1, tooltipSenha);
            toolTip.SetToolTip(this.TextBoxSenha2, tooltipSenha2);
            toolTip.SetToolTip(this.ComboBoxCargo, tooltipCargo);
            toolTip.SetToolTip(this.ComboBoxSexo, tooltipSexo);
            toolTip.SetToolTip(this.TextBoxDDD, tooltipDDD);
            toolTip.SetToolTip(this.TextBoxTelefone, tooltipTelefone);
            toolTip.SetToolTip(this.TextBoxLogradouro, tooltipLogradouro);
            toolTip.SetToolTip(this.TextBoxNumero, tooltipNumero);
            toolTip.SetToolTip(this.TextBoxBairro, tooltipBairro);
            toolTip.SetToolTip(this.TextBoxCidade, tooltipCidade);
            toolTip.SetToolTip(this.ComboBoxUF, tooltipUF);
            toolTip.SetToolTip(this.TextBoxCEP, tooltipCEP);
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            List<string> camposInvalidos = new List<string>();

            ValidarSenha(camposInvalidos);
            ValidarNome(camposInvalidos);
            ValidarEmail(camposInvalidos);
            ValidarCPF(camposInvalidos);
            ValidarCargo(camposInvalidos);
            ValidarSexo(camposInvalidos);
            ValidarUsuario(camposInvalidos);
            ValidarDDD(camposInvalidos);
            ValidarTelefone(camposInvalidos);
            ValidarLogradouro(camposInvalidos);
            ValidarNumero(camposInvalidos);
            ValidarBairro(camposInvalidos);
            ValidarCidade(camposInvalidos);
            ValidarUF(camposInvalidos);
            ValidarCEP(camposInvalidos);

            if (nomevalido == false || emailvalido == false || cpfvalido == false || usuariovalido == false || senhavalida == false || cargovalido == false
                || sexovalido == false || dddvalido == false || telefonevalido == false || logradourovalido == false || numerocasavalido == false
                || bairrovalido == false || cidadevalida == false || ufvalido == false || cepvalido == false)
            {
                string camposInvalidosString = string.Join(", ", camposInvalidos); // constrói uma string com os itens da lista camposInvalidos separados por vírgula
                MessageBox.Show($"Por favor, preencha todos os campos corretamente. Campos inválidos: {camposInvalidosString}", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DefinirFoco(camposInvalidos); // define foco para o primeiro item da lista de campos inválidos
            }
            else
            {
                funcionario1.Nome = TextBoxNome.Text;
                funcionario1.Email = TextBoxEmail.Text;
                funcionario1.CPF = MaskedTextBoxCPF.Text.Replace(".", "").Replace("/", "").Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os pontos, barras e traços
                funcionario1.Usuario = TextBoxUsuario.Text;
                funcionario1.Senha = TextBoxSenha1.Text;
                funcionario1.Cargo = ComboBoxCargo.Text;
                funcionario1.Sexo = ComboBoxSexo.Text;
                funcionario1.StatusAtivo = true;

                funcionario1.Endereco = new Endereco();
                funcionario1.Endereco.Logradouro = TextBoxLogradouro.Text;
                funcionario1.Endereco.Numero = TextBoxNumero.Text;
                funcionario1.Endereco.Complemento = TextBoxComplemento.Text;
                funcionario1.Endereco.Bairro = TextBoxBairro.Text;
                funcionario1.Endereco.Cidade = TextBoxCidade.Text;
                funcionario1.Endereco.UF = ComboBoxUF.Text;
                funcionario1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                funcionario1.Endereco.StatusAtivo = true;

                funcionario1.Telefone = new Telefone();
                funcionario1.Telefone.DDD = TextBoxDDD.Text;
                funcionario1.Telefone.Numero = TextBoxTelefone.Text;
                funcionario1.Telefone.StatusAtivo = true;

                try
                {
                    funcionarioService.CadastrarFuncionario(funcionario1); // Chamando o método CadastrarFuncionario da instância funcionarioService
                    MessageBox.Show("Usuário cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FuncionarioCadastradoSucesso?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do funcionario
        internal event EventHandler FuncionarioCadastradoSucesso;

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void TextBoxTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um dígito
            if (char.IsDigit(e.KeyChar))
            {
                // Obtém o texto atual do TextBox
                string text = TextBoxTelefone.Text;

                // Se o comprimento do texto atual for 9, impede a inserção de mais dígitos
                if (text.Length >= 9)
                {
                    e.Handled = true;
                    //MessageBox.Show("O número de telefone deve conter no máximo 9 dígitos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolTip.Show(tooltipErrTelefoneTamanho, TextBoxTelefone, 0, -50, 5000); // Mostrar a tooltip
                }
            }
        }

        private void PictureBoxMostrarSenha_Click(object sender, EventArgs e)
        {
            if (TextBoxSenha1.UseSystemPasswordChar == true)
            {
                TextBoxSenha1.UseSystemPasswordChar = false; // Alterna a visibilidade da senha
                TextBoxSenha2.UseSystemPasswordChar = false;
                PictureBoxMostrarSenha.Image = Properties.Resources.esconderSenha; // Altera o ícone do PictureBox
            }
            else
            {
                TextBoxSenha1.UseSystemPasswordChar = true;
                TextBoxSenha2.UseSystemPasswordChar = true;
                PictureBoxMostrarSenha.Image = Properties.Resources.mostrarSenha;
            }
        }

        private void DefinirFoco(List<string> camposInvalidos)
        {
            // captura o primeiro item da lista camposInvalidos e define o foco para ele
            switch (camposInvalidos[0])
            {
                case "Nome":
                    this.ActiveControl = TextBoxNome;
                    break;
                case "Email":
                    this.ActiveControl = TextBoxEmail;
                    break;
                case "CPF":
                    this.ActiveControl = MaskedTextBoxCPF;
                    break;
                case "Usuário":
                    this.ActiveControl = TextBoxUsuario;
                    break;
                case "Senha":
                    this.ActiveControl = TextBoxSenha1;
                    break;
                case "Cargo":
                    this.ActiveControl = ComboBoxCargo;
                    break;
                case "Sexo":
                    this.ActiveControl = ComboBoxSexo;
                    break;
                case "DDD":
                    this.ActiveControl = TextBoxDDD;
                    break;
                case "Telefone":
                    this.ActiveControl = TextBoxTelefone;
                    break;
                case "Logradouro":
                    this.ActiveControl = TextBoxLogradouro;
                    break;
                case "Número":
                    this.ActiveControl = TextBoxNumero;
                    break;
                case "Bairro":
                    this.ActiveControl = TextBoxBairro;
                    break;
                case "Cidade":
                    this.ActiveControl = TextBoxCidade;
                    break;
                case "UF":
                    this.ActiveControl = ComboBoxUF;
                    break;
                case "CEP":
                    this.ActiveControl = TextBoxCEP;
                    break;
                default:
                    break;
            }
        }

        private void ValidarSenha(List<string> camposInvalidos)
        {
            if (TextBoxSenha1.Text == null) // Valida Senha 01
            {
                camposInvalidos.Add("Senha");

                //MessageBox.Show("Preencha o campo Senha", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxSenha1.ForeColor = Color.Red;
            }
            else
            {
                string senha1 = TextBoxSenha1.Text;

                // Verificar se a senha é forte o suficiente
                bool senhaforte = VerificarSenhaForte(senha1);

                if (senhaforte == false)
                {
                    camposInvalidos.Add("Senha");

                    senhavalida = false;
                    TextBoxSenha1.ForeColor = Color.Red;
                    TextBoxSenha2.ForeColor = Color.Red;
                    this.ActiveControl = TextBoxSenha1; // Define o foco para o TextBoxSenha1
                    return;
                }
                else
                {
                    TextBoxSenha1.ForeColor = Color.Black;
                    TextBoxSenha2.ForeColor = Color.Black;
                    this.ActiveControl = TextBoxSenha2; // Define o foco para o TextBoxSenha2
                }
            }

            if (TextBoxSenha2.Text == null) // Valida Senha 02
            {
                camposInvalidos.Add("Senha");

                //MessageBox.Show("Preencha o campo Senha", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxSenha2.ForeColor = Color.Red;
            }
            else
            {
                string senha1 = TextBoxSenha1.Text;
                string senha2 = TextBoxSenha2.Text;

                // Verificar se a senha é forte o suficiente
                bool senhaforte = VerificarSenhaForte(senha1);

                if (senhaforte == false)
                {
                    camposInvalidos.Add("Senha");

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
                        //MessageBox.Show("As senhas são diferentes, confira e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        toolTip.Show(tooltipErrSenhasDiferentes, TextBoxSenha2, 0, -50, 5000); // Mostrar a tooltip

                        senhavalida = false;
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

        private void ValidarNome(List<string> camposInvalidos)
        {
            string Nome = TextBoxNome.Text; // Valida Nome
            if (Nome.Length < 3)
            {
                camposInvalidos.Add("Nome");

                // Define a cor de texto para vermelho
                TextBoxNome.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipNome, TextBoxNome, 0, -50, 5000); // Mostrar a tooltip

                nomevalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNome.ForeColor = Color.Black;
                nomevalido = true;
            }
        }

        private void ValidarEmail(List<string> camposInvalidos)
        {
            string Email = TextBoxEmail.Text; // Valida Email
            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                camposInvalidos.Add("Email");

                // Define a cor de texto para vermelho
                TextBoxEmail.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipEmail, TextBoxEmail, 0, -50, 5000); // Mostrar a tooltip

                emailvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxEmail.ForeColor = Color.Black;
                emailvalido = true;
            }
        }

        private void ValidarCPF(List<string> camposInvalidos)
        {
            // Remove todos os caracteres não numéricos do texto
            string cpfDigitsOnly = MaskedTextBoxCPF.Text.Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem exatamente 11 dígitos
            if (cpfDigitsOnly.Length != 11 || !cpfDigitsOnly.All(char.IsDigit))
            {
                camposInvalidos.Add("CPF");

                // Define a cor de texto para vermelho
                MaskedTextBoxCPF.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo CPF corretamente. O CPF deve conter 11 números.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipCPF, MaskedTextBoxCPF, 0, -50, 5000); // Mostrar a tooltip

                cpfvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                MaskedTextBoxCPF.ForeColor = Color.Black;

                cpfvalido = true;
            }
        }

        private void ValidarCargo(List<string> camposInvalidos)
        {
            string text = ComboBoxCargo.Text.Trim(); // Remover espaços em branco extras    // Valida Cargo
            if (text != "Funcionário" && text != "Gerente")
            {
                camposInvalidos.Add("Cargo");

                // Define a cor de texto para vermelho
                ComboBoxCargo.ForeColor = Color.Red;

                //MessageBox.Show("O cargo deve ser 'Funcionário' ou 'Gerente'.", "Cargo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipCargo, ComboBoxCargo, 0, -50, 5000); // Mostrar a tooltip

                cargovalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxCargo.ForeColor = Color.Black;
                cargovalido = true;
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

        private void ValidarDDD(List<string> camposInvalidos)
        {
            string textD = TextBoxDDD.Text; // Valida DDD   // Mudei nome "text" para "textD" para evitar conflito com "ComboBoxText" acima
            if (!Regex.IsMatch(textD, @"^\d{2}$"))
            {
                camposInvalidos.Add("DDD");

                // Define a cor de texto para vermelho
                TextBoxDDD.ForeColor = Color.Red;

                //MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipDDD, TextBoxDDD, 0, -50, 5000); // Mostrar a tooltip

                dddvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxDDD.ForeColor = Color.Black;
                dddvalido = true;
            }
        }

        private void ValidarTelefone(List<string> camposInvalidos)
        {
            string textTelefone = TextBoxTelefone.Text; // Valida Telefone
            if (!Regex.IsMatch(textTelefone, @"^\d{8,9}$"))
            {
                camposInvalidos.Add("Telefone");

                // Define a cor de texto para vermelho
                TextBoxTelefone.ForeColor = Color.Red;

                //MessageBox.Show("O número de telefone deve conter 8 ou 9 caracteres numéricos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipTelefone, TextBoxTelefone, 0, -50, 5000); // Mostrar a tooltip

                telefonevalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxTelefone.ForeColor = Color.Black;
                telefonevalido = true;
            }
        }

        private void ValidarLogradouro(List<string> camposInvalidos)
        {
            string textLogradouro = TextBoxLogradouro.Text; // Valida Logradouro
            if (textLogradouro.Length < 3)
            {
                camposInvalidos.Add("Logradouro");

                // Define a cor de texto para vermelho
                TextBoxLogradouro.ForeColor = Color.Red;

                //MessageBox.Show("O logradouro deve conter ao menos 3 caracteres.", "Logradouro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipLogradouro, TextBoxLogradouro, 0, -50, 5000); // Mostrar a tooltip

                logradourovalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxLogradouro.ForeColor = Color.Black;
                logradourovalido = true;
            }
        }

        private void ValidarNumero(List<string> camposInvalidos)
        {
            string textNumero = TextBoxNumero.Text; // Valida Numero
            if (!Regex.IsMatch(textNumero, @"^\d+$"))
            {
                camposInvalidos.Add("Número");

                // Define a cor de texto para vermelho
                TextBoxNumero.ForeColor = Color.Red;

                //MessageBox.Show("O número deve conter apenas caracteres numéricos.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipNumero, TextBoxNumero, 0, -50, 5000); // Mostrar a tooltip

                numerocasavalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNumero.ForeColor = Color.Black;
                numerocasavalido = true;
            }
        }

        private void ValidarBairro(List<string> camposInvalidos)
        {
            string textBairro = TextBoxBairro.Text; // Valida Bairro
            if (textBairro.Length < 3)
            {
                camposInvalidos.Add("Bairro");

                // Define a cor de texto para vermelho
                TextBoxBairro.ForeColor = Color.Red;

                //MessageBox.Show("O bairro deve conter ao menos 3 caracteres.", "Bairro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipBairro, TextBoxBairro, 0, -50, 5000); // Mostrar a tooltip

                bairrovalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxBairro.ForeColor = Color.Black;
                bairrovalido = true;
            }
        }

        private void ValidarCidade(List<string> camposInvalidos)
        {
            string textCidade = TextBoxCidade.Text; // Valida Cidade
            if (textCidade.Length < 3)
            {
                camposInvalidos.Add("Cidade");

                // Define a cor de texto para vermelho
                TextBoxCidade.ForeColor = Color.Red;

                //MessageBox.Show("A cidade deve conter ao menos 3 caracteres.", "Cidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipCidade, TextBoxCidade, 0, -50, 5000); // Mostrar a tooltip

                cidadevalida = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCidade.ForeColor = Color.Black;
                cidadevalida = true;
            }
        }

        private void ValidarUF(List<string> camposInvalidos)
        {
            string textUf = ComboBoxUF.Text.Trim(); // Remover espaços em branco extras   Valida UF
            if (!Regex.IsMatch(textUf, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$"))
            {
                camposInvalidos.Add("UF");

                // Define a cor de texto para vermelho
                ComboBoxUF.ForeColor = Color.Red;

                //MessageBox.Show("Selecione uma UF válida.", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipUF, ComboBoxUF, 0, -50, 5000); // Mostrar a tooltip

                ufvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                ComboBoxUF.ForeColor = Color.Black;
                ufvalido = true;
            }
        }

        private void ValidarCEP(List<string> camposInvalidos)
        {
            // Remove todos os caracteres não numéricos do texto
            string cepDigitsOnly = TextBoxCEP.Text.Replace("-", ""); // Valida CEP

            // Verifica se o CEP tem exatamente 8 dígitos
            if (cepDigitsOnly.Length != 8 || !cepDigitsOnly.All(char.IsDigit))
            {
                camposInvalidos.Add("CEP");

                // Define a cor de texto para vermelho
                TextBoxCEP.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo CEP corretamente. O CEP deve conter 8 números.", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                toolTip.Show(tooltipCEP, TextBoxCEP, 0, -50, 5000); // Mostrar a tooltip

                cepvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCEP.ForeColor = Color.Black;
                cepvalido = true;
            }

        }

        private void TextBoxUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (TextBoxUsuario.Text.Length >= 3)
            {
                VerificarUsuarioDisponivel(TextBoxUsuario.Text);
            }
        }
    }
}
