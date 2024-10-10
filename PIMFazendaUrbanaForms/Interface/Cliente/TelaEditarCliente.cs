using System.ComponentModel;
using System.Text.RegularExpressions;
using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaEditarCliente : Form
    {
        Cliente cliente1 = new Cliente();

        bool nomevalido = true;
        bool cnpjvalido = true;
        bool emailvalido = true;

        bool dddvalido = true;
        bool telefonevalido = true;

        bool logradourovalido = true;
        bool numerocasavalido = true;
        bool bairrovalido = true;
        bool cidadevalida = true;
        bool ufvalido = true;
        bool cepvalido = true;

        ClienteService clienteService; // Declaração de uma instância de ClienteService

        public TelaEditarCliente(int clienteID)
        {
            InitializeComponent();

            clienteService = new ClienteService(); // Cria uma instância de ClienteService

            Cliente cliente = clienteService.ConsultarClienteID(clienteID); // Chamando o método ConsultarClienteID da instância clienteService

            // Preencher os campos do formulário TelaEditarCliente com os dados do cliente
            if (cliente != null)
            {
                PreencherCampos(cliente);
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados do cliente. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void PreencherCampos(Cliente cliente)
        {
            TextBoxCodigo.Text = cliente.ID.ToString();

            TextBoxNome.Text = cliente.Nome;
            TextBoxEmail.Text = cliente.Email;
            TextBoxCNPJ.Text = cliente.CNPJ;

            // Instanciar e preencher o endereço
            cliente1.Endereco = new Endereco();
            cliente1.Endereco.Logradouro = cliente.Endereco.Logradouro;
            cliente1.Endereco.Numero = cliente.Endereco.Numero;
            cliente1.Endereco.Complemento = cliente.Endereco.Complemento;
            cliente1.Endereco.Bairro = cliente.Endereco.Bairro;
            cliente1.Endereco.Cidade = cliente.Endereco.Cidade;
            cliente1.Endereco.UF = cliente.Endereco.UF;
            cliente1.Endereco.CEP = cliente.Endereco.CEP;

            TextBoxLogradouro.Text = cliente.Endereco.Logradouro;
            TextBoxNumero.Text = cliente.Endereco.Numero;
            TextBoxComplemento.Text = cliente.Endereco.Complemento;
            TextBoxBairro.Text = cliente.Endereco.Bairro;
            TextBoxCidade.Text = cliente.Endereco.Cidade;
            ComboBoxUF.Text = cliente.Endereco.UF;
            TextBoxCEP.Text = cliente.Endereco.CEP;

            // Instanciar e preencher o telefone
            cliente1.Telefone = new Telefone();
            cliente1.Telefone.DDD = cliente.Telefone.DDD;
            cliente1.Telefone.Numero = cliente.Telefone.Numero;

            TextBoxDDD.Text = cliente.Telefone.DDD;
            TextBoxTelefone.Text = cliente.Telefone.Numero;
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            List<string> camposInvalidos = new List<string>();

            ValidarNome(camposInvalidos);
            ValidarCNPJ(camposInvalidos);
            ValidarEmail(camposInvalidos);
            ValidarDDD(camposInvalidos);
            ValidarTelefone(camposInvalidos);
            ValidarLogradouro(camposInvalidos);
            ValidarNumero(camposInvalidos);
            ValidarBairro(camposInvalidos);
            ValidarCidade(camposInvalidos);
            ValidarUF(camposInvalidos);
            ValidarCEP(camposInvalidos);

            if (!nomevalido || !cnpjvalido || !emailvalido || !dddvalido || !telefonevalido || !logradourovalido ||
                !numerocasavalido || !bairrovalido || !cidadevalida || !ufvalido || !cepvalido)
            {
                // monta a string com os campos inválidos para a mensagem de erro
                string camposInvalidosString = string.Join(", ", camposInvalidos);

                MessageBox.Show($"Por favor, preencha todos os campos corretamente. Campos inválidos: {camposInvalidosString}", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DefinirFoco(camposInvalidos); // define foco para o primeiro item da lista de campos inválidos
            }
            else
            {
                cliente1.ID = Convert.ToInt32(TextBoxCodigo.Text);
                cliente1.Nome = TextBoxNome.Text;
                cliente1.Email = TextBoxEmail.Text;
                cliente1.CNPJ = TextBoxCNPJ.Text;

                cliente1.Endereco = new Endereco();
                cliente1.Endereco.Logradouro = TextBoxLogradouro.Text;
                cliente1.Endereco.Numero = TextBoxNumero.Text;
                cliente1.Endereco.Complemento = TextBoxComplemento.Text;
                cliente1.Endereco.Bairro = TextBoxBairro.Text;
                cliente1.Endereco.Cidade = TextBoxCidade.Text;
                cliente1.Endereco.UF = ComboBoxUF.Text;
                cliente1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços

                cliente1.Telefone = new Telefone();
                cliente1.Telefone.DDD = TextBoxDDD.Text;
                cliente1.Telefone.Numero = TextBoxTelefone.Text;

                try
                {
                    clienteService.AlterarCliente(cliente1); // Chamando o método AlterarCliente da instância clienteService
                    MessageBox.Show("Cliente alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClienteEditadoSucesso?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do cliente
        public event EventHandler ClienteEditadoSucesso;

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
                //MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nomevalido = false;
                //this.ActiveControl = TextBoxNome; // Define o foco para o TextBoxNome
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
                //MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                emailvalido = false;
                //this.ActiveControl = TextBoxEmail; // Define o foco para o TextBoxEmail
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxEmail.ForeColor = Color.Black;
                emailvalido = true;
            }
        }
        private void TextBoxCNPJ_Validating(object sender, CancelEventArgs e)
        {
            // Remove todos os caracteres não numéricos do texto
            string cnpjDigitsOnly = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");

            // Verifica se o CNPJ tem exatamente 14 dígitos
            if (cnpjDigitsOnly.Length != 14 || !cnpjDigitsOnly.All(char.IsDigit))
            {
                // Define a cor de texto para vermelho
                TextBoxCNPJ.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo CNPJ corretamente. O CNPJ deve conter 14 números.", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cnpjvalido = false;
                //this.ActiveControl = TextBoxCNPJ; // Define o foco para o TextBoxCNPJ
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCNPJ.ForeColor = Color.Black;

                cnpjvalido = true;
            }
        }

        private void TextBoxDDD_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxDDD.Text;
            if (!Regex.IsMatch(text, @"^\d{2}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxDDD.ForeColor = Color.Red;

                //MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dddvalido = false;
                //this.ActiveControl = TextBoxDDD;
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

                //MessageBox.Show("O número de telefone deve conter 8 ou 9 caracteres numéricos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                telefonevalido = false;
                //this.ActiveControl = TextBoxTelefone;
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

                //MessageBox.Show("O logradouro deve conter ao menos 3 caracteres.", "Logradouro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logradourovalido = false;
                //this.ActiveControl = TextBoxLogradouro; // Define o foco para o TextBoxLogradouro
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

                //MessageBox.Show("O número deve conter apenas caracteres numéricos.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numerocasavalido = false;
                //this.ActiveControl = TextBoxNumero; // Define o foco para o TextBoxNumero
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

                //MessageBox.Show("O bairro deve conter ao menos 3 caracteres.", "Bairro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bairrovalido = false;
                //this.ActiveControl = TextBoxBairro; // Define o foco para o TextBoxBairro
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

                //MessageBox.Show("A cidade deve conter ao menos 3 caracteres.", "Cidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cidadevalida = false;
                //this.ActiveControl = TextBoxCidade; // Define o foco para o TextBoxCidade
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

                //MessageBox.Show("Selecione uma UF válida.", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ufvalido = false;
                //this.ActiveControl = ComboBoxUF; // Define o foco para o ComboBoxUF
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
                //MessageBox.Show("Preencha o campo CEP corretamente. O CEP deve conter 8 números.", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cepvalido = false;
                //this.ActiveControl = TextBoxCEP; // Define o foco para o TextBoxCEP
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCEP.ForeColor = Color.Black;
                cepvalido = true;
            }
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
                    MessageBox.Show("O número de telefone deve conter no máximo 9 dígitos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DefinirFoco(List<string> camposInvalidos)
        {
            // Define o foco para o primeiro item da lista de campos inválidos
            switch (camposInvalidos[0])
            {
                case "Nome":
                    this.ActiveControl = TextBoxNome;
                    break;
                case "CNPJ":
                    this.ActiveControl = TextBoxCNPJ;
                    break;
                case "Email":
                    this.ActiveControl = TextBoxEmail;
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
                //MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres.", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nomevalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNome.ForeColor = Color.Black;
                nomevalido = true;
            }
        }

        private void ValidarCNPJ(List<string> camposInvalidos)
        {
            // Remove todos os caracteres não numéricos do texto    // Valida CNPJ
            string cnpjDigitsOnly = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "");

            // Verifica se o CNPJ tem exatamente 14 dígitos
            if (cnpjDigitsOnly.Length != 14 || !cnpjDigitsOnly.All(char.IsDigit))
            {
                camposInvalidos.Add("CNPJ");

                // Define a cor de texto para vermelho
                TextBoxCNPJ.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo CNPJ corretamente. O CNPJ deve conter 14 números.", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cnpjvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCNPJ.ForeColor = Color.Black;

                cnpjvalido = true;
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

                emailvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxEmail.ForeColor = Color.Black;
                emailvalido = true;
            }
        }

        private void ValidarDDD(List<string> camposInvalidos)
        {
            string text = TextBoxDDD.Text; // Valida DDD
            if (!Regex.IsMatch(text, @"^\d{2}$"))
            {
                camposInvalidos.Add("DDD");

                // Define a cor de texto para vermelho
                TextBoxDDD.ForeColor = Color.Red;

                //MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string textNumero = TextBoxNumero.Text; // Valida Número
            if (!Regex.IsMatch(textNumero, @"^\d+$"))
            {
                camposInvalidos.Add("Número");

                // Define a cor de texto para vermelho
                TextBoxNumero.ForeColor = Color.Red;

                //MessageBox.Show("O número deve conter apenas caracteres numéricos.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                cepvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxCEP.ForeColor = Color.Black;
                cepvalido = true;
            }
        }

    }
}
