using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIMFazendaUrbana
{
    public partial class TelaCadastrarFornecedor : Form
    {
        Fornecedor fornecedor1 = new Fornecedor();

        bool nomevalido = false;
        bool cnpjvalido = false;
        bool emailvalido = false;
        bool dddvalido = false;
        bool telefonevalido = false;
        bool numerocasavalido = false;
        bool ufvalido = false;
        bool cepvalido = false;

        FornecedorDAO fornecedorDAO; // Declaração de uma instância de FornecedorDAO
        FornecedorService fornecedorService; // Declaração de uma instância de FornecedorService

        public TelaCadastrarFornecedor()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados

            fornecedorDAO = new FornecedorDAO(connectionString); // Cria uma instância de FornecedorDAO passando a string de conexão como parâmetro
            fornecedorService = new FornecedorService(fornecedorDAO); // Cria uma instância de FornecedorService passando o fornecedorDAO como parâmetro
        }

        private void TelaCadastrarFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void BotaoOK_Click(object sender, EventArgs e)
        {

            if (nomevalido == false)
            {
                MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cnpjvalido == false)
            {
                MessageBox.Show("Preencha o campo CNPJ corretamente. O CNPJ deve ter 14 números", "CNPJ Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (emailvalido == false)
            {
                MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dddvalido == false)
            {
                MessageBox.Show("Preencha o campo DDD corretamente. O DDD deve ter 2 números", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (telefonevalido == false)
            {
                MessageBox.Show("Preencha o campo Telefone corretamente. O telefone deve ter 8 ou 9 números", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (numerocasavalido == false)
            {
                MessageBox.Show("Preencha o campo Número corretamente. O número deve ter apenas caracteres numéricos", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ufvalido == false)
            {
                MessageBox.Show("Preencha o campo UF corretamente. A UF deve ter 2 caracteres maiúsculos do alfabeto", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cepvalido == false)
            {
                MessageBox.Show("Preencha o campo CEP corretamente. O CEP deve ter 8 números", "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fornecedor1.Nome = TextBoxNome.Text;
                fornecedor1.CNPJ = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os pontos, barras e traços
                fornecedor1.Email = TextBoxEmail.Text;
                fornecedor1.StatusAtivo = true;

                fornecedor1.Endereco = new EnderecoFornecedor();
                fornecedor1.Endereco.Logradouro = TextBoxLogradouro.Text;
                fornecedor1.Endereco.Numero = TextBoxNumero.Text;
                fornecedor1.Endereco.Complemento = TextBoxComplemento.Text;
                fornecedor1.Endereco.Bairro = TextBoxBairro.Text;
                fornecedor1.Endereco.Cidade = TextBoxCidade.Text;
                fornecedor1.Endereco.UF = TextBoxUF.Text;
                fornecedor1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                fornecedor1.Endereco.StatusAtivo = true;

                fornecedor1.Telefone = new TelefoneFornecedor();
                fornecedor1.Telefone.DDD = TextBoxDDD.Text;
                fornecedor1.Telefone.Numero = TextBoxTelefone.Text;
                fornecedor1.Telefone.StatusAtivo = true;

                bool sucesso = fornecedorService.CadastrarFornecedor(fornecedor1); // Chamando o método CadastrarFornecedor da instância fornecedorService
                if (sucesso == true)
                {
                    MessageBox.Show("Fornecedor cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar fornecedor. Verifique se o fornecedor já está cadastrado, ou entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BotaoVoltar_Click(object sender, EventArgs e)
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
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNome.ForeColor = Color.Black;
                nomevalido = true;
            }
        }

        private void TextBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = TextBoxEmail.Text;
            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxEmail.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                MessageBox.Show("Preencha o campo E-mail corretamente.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                emailvalido = false;
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
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxTelefone.ForeColor = Color.Black;
                telefonevalido = true;
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
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxNumero.ForeColor = Color.Black;
                numerocasavalido = true;
            }
        }

        private void TextBoxUF_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxUF.Text;
            if (!Regex.IsMatch(text, @"^[A-Z]{2}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxUF.ForeColor = Color.Red;

                MessageBox.Show("A UF deve conter exatamente 2 caracteres maiúsculos do alfabeto.", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ufvalido = false;
            }
            else
            {
                // Define a cor de texto para preto
                TextBoxUF.ForeColor = Color.Black;
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
