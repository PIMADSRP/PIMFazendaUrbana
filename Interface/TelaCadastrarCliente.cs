using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PIMFazendaUrbana
{
    public partial class TelaCadastrarCliente : Form
    {
        Cliente cliente1 = new Cliente();

        bool nomevalido = false;
        bool cnpjvalido = false;
        bool emailvalido = false;

        bool dddvalido = false;
        bool telefonevalido = false;

        bool logradourovalido = false;
        bool numerocasavalido = false;
        bool bairrovalido = false;
        bool cidadevalida = false;
        bool ufvalido = false;
        bool cepvalido = false;

        ClienteDAO clienteDAO; // Declaração de uma instância de ClienteDAO
        ClienteService clienteService; // Declaração de uma instância de ClienteService

        public TelaCadastrarCliente()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; ; // Substitua pelos valores reais da conexão com o banco de dados

            clienteDAO = new ClienteDAO(connectionString); // Cria uma instância de ClienteDAO passando a string de conexão como parâmetro
            clienteService = new ClienteService(clienteDAO); // Cria uma instância de ClienteService passando o clienteDAO como parâmetro
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            if (nomevalido == false)
            {
                MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxNome; // Define o foco para o TextBoxNome
                return;
            }
            else if (cnpjvalido == false)
            {
                MessageBox.Show("Preencha o campo CNPJ corretamente. O CNPJ deve ter 14 números", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxCNPJ; // Define o foco para o TextBoxCNPJ
                return;
            }
            else if (emailvalido == false)
            {
                MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxEmail; // Define o foco para o TextBoxEmail
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
                MessageBox.Show("Preencha o campo UF corretamente. A UF não pode ser vazia", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cliente1.Nome = TextBoxNome.Text;
                cliente1.CNPJ = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""); ; // Marcelo falou para no banco guardar como varchar, mas antes tirar os pontos, barras e traços
                cliente1.Email = TextBoxEmail.Text;
                cliente1.StatusAtivo = true;

                cliente1.Endereco = new EnderecoCliente();
                cliente1.Endereco.Logradouro = TextBoxLogradouro.Text;
                cliente1.Endereco.Numero = TextBoxNumero.Text;
                cliente1.Endereco.Complemento = TextBoxComplemento.Text;
                cliente1.Endereco.Bairro = TextBoxBairro.Text;
                cliente1.Endereco.Cidade = TextBoxCidade.Text;
                cliente1.Endereco.UF = ComboBoxUF.Text;
                cliente1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                cliente1.Endereco.StatusAtivo = true;

                cliente1.Telefone = new TelefoneCliente();
                cliente1.Telefone.DDD = TextBoxDDD.Text;
                cliente1.Telefone.Numero = TextBoxTelefone.Text;
                cliente1.Telefone.StatusAtivo = true;

                bool sucesso = clienteService.CadastrarCliente(cliente1); // Chamando o método CadastrarCliente da instância clienteService
                if (sucesso == true)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClienteCadastradoSucesso?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar cliente. Verifique se o cliente já está cadastrado, ou entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do cliente
        public event EventHandler ClienteCadastradoSucesso;

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
                MessageBox.Show("Preencha o campo CNPJ corretamente. O CNPJ deve conter 14 números.", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cnpjvalido = false;
                this.ActiveControl = TextBoxCNPJ; // Define o foco para o TextBoxCNPJ
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

                MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dddvalido = false;
                this.ActiveControl = TextBoxDDD;
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
                this.ActiveControl = TextBoxTelefone;
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


    }
}
