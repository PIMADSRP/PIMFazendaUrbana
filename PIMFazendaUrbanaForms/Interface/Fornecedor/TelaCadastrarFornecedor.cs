using System.ComponentModel;
using System.Text.RegularExpressions;
using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaCadastrarFornecedor : Form
    {
        Fornecedor fornecedor1 = new Fornecedor();

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

        FornecedorService fornecedorService; // Declaração de uma instância de FornecedorService

        public TelaCadastrarFornecedor()
        {
            InitializeComponent();
            fornecedorService = new FornecedorService(); // Cria uma instância de FornecedorService
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
                DefinirFoco(camposInvalidos);
            }
            else
            {
                fornecedor1.Nome = TextBoxNome.Text;
                fornecedor1.CNPJ = TextBoxCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""); ; // Marcelo falou para no banco guardar como varchar, mas antes tirar os pontos, barras e traços
                fornecedor1.Email = TextBoxEmail.Text;
                fornecedor1.StatusAtivo = true;

                fornecedor1.Endereco = new Endereco();
                fornecedor1.Endereco.Logradouro = TextBoxLogradouro.Text;
                fornecedor1.Endereco.Numero = TextBoxNumero.Text;
                fornecedor1.Endereco.Complemento = TextBoxComplemento.Text;
                fornecedor1.Endereco.Bairro = TextBoxBairro.Text;
                fornecedor1.Endereco.Cidade = TextBoxCidade.Text;
                fornecedor1.Endereco.UF = ComboBoxUF.Text;
                fornecedor1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                fornecedor1.Endereco.StatusAtivo = true;

                fornecedor1.Telefone = new Telefone();
                fornecedor1.Telefone.DDD = TextBoxDDD.Text;
                fornecedor1.Telefone.Numero = TextBoxTelefone.Text;
                fornecedor1.Telefone.StatusAtivo = true;

                try
                {
                    fornecedorService.CadastrarFornecedor(fornecedor1);
                    MessageBox.Show("Fornecedor cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FornecedorCadastradoSucesso?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do fornecedor
        public event EventHandler FornecedorCadastradoSucesso;

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
            string Nome = TextBoxNome.Text; // Confirmar Nome
            if (Nome.Length < 3)
            {
                camposInvalidos.Add("Nome");

                // Define a cor de texto para vermelho
                TextBoxNome.ForeColor = Color.Red;

                // Exibe a mensagem de erro
                //MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            // Remove todos os caracteres não numéricos do texto    -   Valida CNPJ
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
            string Email = TextBoxEmail.Text; // Confirmar Email
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
            string textTelefone = TextBoxTelefone.Text; // Valida Telefone. Troquei o nome para evitar conflito com string "text"
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
            string textLogradouro = TextBoxLogradouro.Text; // Valida Logradouro. Troquei o nome para evitar conflito com string "text"
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
            string textNumero = TextBoxNumero.Text; // Valida Numero do local. Troquei o nome para evitar conflito com string "text"
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
            string textBairro = TextBoxBairro.Text; // Valida Bairro. Troquei o nome para evitar conflito com string "text"
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
            string textCidade = TextBoxCidade.Text; // Valida Cidade. Troquei o nome para evitar conflito com string "text"
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
            // Valida UF. Troquei o nome para evitar conflito com string "text"
            string textUf = ComboBoxUF.Text.Trim(); // Remover espaços em branco extras
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
            string cepDigitsOnly = TextBoxCEP.Text.Replace("-", ""); // Valida CEP. Troquei o nome para evitar conflito com string "text"

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
