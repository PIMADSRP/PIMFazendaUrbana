using MySqlX.XDevAPI;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace PIMFazendaUrbana
{
    public partial class TelaEditarFuncionario : Form
    {
        Funcionario funcionario1 = new Funcionario();

        string usuarioAntigo = null;

        bool nomevalido = true;
        bool emailvalido = true;
        bool usuariovalido = true;
        bool cargovalido = true;
        bool sexovalido = true;

        bool dddvalido = true;
        bool telefonevalido = true;

        bool logradourovalido = true;
        bool numerocasavalido = true;
        bool bairrovalido = true;
        bool cidadevalida = true;
        bool ufvalido = true;
        bool cepvalido = true;

        FuncionarioDAO funcionarioDAO; // Declaração de uma instância de FuncionarioDAO
        FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService

        public TelaEditarFuncionario(int funcionarioID)
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; ; // Substitua pelos valores reais da conexão com o banco de dados

            funcionarioDAO = new FuncionarioDAO(connectionString); // Cria uma instância de FuncionarioDAO passando a string de conexão como parâmetro
            funcionarioService = new FuncionarioService(funcionarioDAO); // Cria uma instância de FuncionarioService passando o funcionarioDAO como parâmetro

            Funcionario funcionario = funcionarioService.ConsultarFuncionarioID(funcionarioID); // Chamando o método ConsultarFuncionarioID da instância funcionarioService

            // Preencher os campos do formulário TelaEditarFuncionario com os dados do funcionário
            if (funcionario != null)
            {
                PreencherCampos(funcionario);
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados do funcionário. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void PreencherCampos(Funcionario funcionario)
        {
            TextBoxCodigo.Text = funcionario.ID.ToString();

            TextBoxNome.Text = funcionario.Nome;
            TextBoxEmail.Text = funcionario.Email;
            TextBoxUsuario.Text = funcionario.Usuario;
            usuarioAntigo = funcionario.Usuario;

            ComboBoxCargo.Text = funcionario.Cargo;
            ComboBoxSexo.Text = funcionario.Sexo;

            // Instanciar e preencher o endereço
            funcionario1.Endereco = new EnderecoFuncionario();

            funcionario1.Endereco.Logradouro = funcionario.Endereco.Logradouro;
            funcionario1.Endereco.Numero = funcionario.Endereco.Numero;
            funcionario1.Endereco.Complemento = funcionario.Endereco.Complemento;
            funcionario1.Endereco.Bairro = funcionario.Endereco.Bairro;
            funcionario1.Endereco.Cidade = funcionario.Endereco.Cidade;
            funcionario1.Endereco.UF = funcionario.Endereco.UF;
            funcionario1.Endereco.CEP = funcionario.Endereco.CEP;

            // Instanciar e preencher o telefone
            funcionario1.Telefone = new TelefoneFuncionario();
            funcionario1.Telefone.DDD = funcionario.Telefone.DDD;
            funcionario1.Telefone.Numero = funcionario.Telefone.Numero;

            TextBoxLogradouro.Text = funcionario.Endereco.Logradouro;
            TextBoxNumero.Text = funcionario.Endereco.Numero;
            TextBoxComplemento.Text = funcionario.Endereco.Complemento;
            TextBoxBairro.Text = funcionario.Endereco.Bairro;
            TextBoxCidade.Text = funcionario.Endereco.Cidade;
            ComboBoxUF.Text = funcionario.Endereco.UF;
            TextBoxCEP.Text = funcionario.Endereco.CEP;

            TextBoxDDD.Text = funcionario.Telefone.DDD;
            TextBoxTelefone.Text = funcionario.Telefone.Numero;
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
            else if (usuariovalido == false)
            {
                MessageBox.Show("Preencha o campo Usuário corretamente. O usuário deve ter ao menos 3 caracteres", "Usuário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Nome: " + funcionario1.Nome);
                funcionario1.Email = TextBoxEmail.Text;
                MessageBox.Show("Email: " + funcionario1.Email);
                funcionario1.Usuario = TextBoxUsuario.Text;
                MessageBox.Show("Usuário: " + funcionario1.Usuario);
                funcionario1.Cargo = ComboBoxCargo.Text;
                MessageBox.Show("Cargo: " + funcionario1.Cargo);
                funcionario1.Sexo = ComboBoxSexo.Text;
                MessageBox.Show("Sexo: " + funcionario1.Sexo);

                funcionario1.Endereco = new EnderecoFuncionario();
                funcionario1.Endereco.Logradouro = TextBoxLogradouro.Text;
                MessageBox.Show("Logradouro: " + funcionario1.Endereco.Logradouro);
                funcionario1.Endereco.Numero = TextBoxNumero.Text;
                MessageBox.Show("Número: " + funcionario1.Endereco.Numero);
                funcionario1.Endereco.Complemento = TextBoxComplemento.Text;
                MessageBox.Show("Complemento: " + funcionario1.Endereco.Complemento);
                funcionario1.Endereco.Bairro = TextBoxBairro.Text;
                MessageBox.Show("Bairro: " + funcionario1.Endereco.Bairro);
                funcionario1.Endereco.Cidade = TextBoxCidade.Text;
                MessageBox.Show("Cidade: " + funcionario1.Endereco.Cidade);
                funcionario1.Endereco.UF = ComboBoxUF.Text;
                MessageBox.Show("UF: " + funcionario1.Endereco.UF);
                funcionario1.Endereco.CEP = TextBoxCEP.Text.Replace("-", ""); // Marcelo falou para no banco guardar como varchar, mas antes tirar os traços
                MessageBox.Show("CEP: " + funcionario1.Endereco.CEP);

                funcionario1.Telefone = new TelefoneFuncionario();
                funcionario1.Telefone.DDD = TextBoxDDD.Text;
                MessageBox.Show("DDD: " + funcionario1.Telefone.DDD);
                funcionario1.Telefone.Numero = TextBoxTelefone.Text;
                MessageBox.Show("Telefone: " + funcionario1.Telefone.Numero);

                bool sucesso = funcionarioService.AlterarFuncionario(funcionario1); // Chamando o método AlterarFuncionario da instância funcionarioService
                if (sucesso == true)
                {
                    MessageBox.Show("Usuário alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FuncionarioEditadoSucesso?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao editar usuário. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Definir um evento para notificar o cadastro bem-sucedido do funcionario
        public event EventHandler FuncionarioEditadoSucesso;

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

                MessageBox.Show("O cargo deve ser 'Funcionário' ou 'Gerente'.", "Cargo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("O sexo deve ser 'M', 'F' ou '-'.", "Sexo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (usuarioAntigo == usuario)
            {
                TextBoxUsuario.ForeColor = Color.Black;
                usuariovalido = true;
            }
            else
            {
                if (TextBoxUsuario.Text.Length < 3)
                {
                    TextBoxUsuario.ForeColor = Color.Red;

                    // Exibe a mensagem de erro
                    MessageBox.Show("Preencha o campo Usuário corretamente. O nome de usuário deve ter ao menos 3 caracteres", "Nome de Usuário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    usuariovalido = false;
                    this.ActiveControl = TextBoxUsuario; // Define o foco para o TextBoxUsuario
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
                        this.ActiveControl = TextBoxUsuario; // Define o foco para o TextBoxUsuario
                    }
                }
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

        private void TextBoxDDD_Validating(object sender, CancelEventArgs e)
        {
            string text = TextBoxDDD.Text;
            if (!Regex.IsMatch(text, @"^\d{2}$"))
            {
                // Define a cor de texto para vermelho
                TextBoxDDD.ForeColor = Color.Red;

                MessageBox.Show("O DDD deve conter exatamente 2 caracteres numéricos.", "DDD Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("O número de telefone deve conter 8 ou 9 caracteres numéricos.", "Telefone Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("O logradouro deve conter ao menos 3 caracteres.", "Logradouro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("O número deve conter apenas caracteres numéricos.", "Número Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("O bairro deve conter ao menos 3 caracteres.", "Bairro Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("A cidade deve conter ao menos 3 caracteres.", "Cidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Selecione uma UF válida.", "UF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    }
}
