using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_FazendaUrbana
{
    public partial class TelaCadastrarCliente : Form
    {
        Cliente cliente1 = new Cliente();

        bool nomevalido = false;
        bool cnpjvalido = false;
        bool emailvalido = false;

        ClienteDAO clienteDAO; // Declaração de uma instância de ClienteDAO
        ClienteService clienteService; // Declaração de uma instância de ClienteService

        public TelaCadastrarCliente()
        {
            InitializeComponent();

            string connectionString = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"; // Substitua pelos valores reais da conexão com o banco de dados

            clienteDAO = new ClienteDAO(connectionString); // Cria uma instância de ClienteDAO passando a string de conexão como parâmetro
            clienteService = new ClienteService(clienteDAO); // Cria uma instância de ClienteService passando o clienteDAO como parâmetro
        }
        private void TelaCadastrarCliente_Load(object sender, EventArgs e)
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
            else
            {
                cliente1.Nome = TextBoxNome.Text;
                cliente1.CNPJ = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""); ; // Marcelo falou para no banco guardar como varchar, mas antes tirar os pontos, barras e traços
                // MessageBox.Show($"{cliente1.CNPJ}", "CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Information); DEBUG com MessageBox
                cliente1.Email = TextBoxEmail.Text;
                cliente1.StatusAtivo = true;

                cliente1.Endereco = new EnderecoCliente();
                cliente1.Endereco.Logradouro = TextBoxLogradouro.Text;
                cliente1.Endereco.Numero = Convert.ToInt32(TextBoxNumero.Text);
                cliente1.Endereco.Complemento = TextBoxComplemento.Text;
                cliente1.Endereco.Bairro = TextBoxBairro.Text;
                cliente1.Endereco.Cidade = TextBoxCidade.Text;
                cliente1.Endereco.UF = TextBoxUF.Text;
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar cliente. Verifique se o CNPJ já está cadastrado, ou entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Verifica se o CNPJ tem exatamente 14 dígitos e se todos são iguais
            if (cnpjDigitsOnly.Length != 14 || !cnpjDigitsOnly.All(char.IsDigit) || cnpjDigitsOnly.Distinct().Count() == 1)
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

        }
        private void TextBoxTelefone_Validating(object sender, CancelEventArgs e)
        {

        }

        private void TextBoxLogradouro_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxNumero_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxComplemento_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxBairro_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxCidade_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxUF_Validating(object sender, CancelEventArgs e)
        {

        }
        private void TextBoxCEP_Validating(object sender, CancelEventArgs e)
        {

        }



    }
}
