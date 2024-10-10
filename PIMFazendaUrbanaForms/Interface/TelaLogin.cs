using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaLogin : Form
    {
        internal Funcionario UsuarioLogado { get; private set; }

        internal FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService

        private ToolTip toolTip;
        private const string tooltipMostrarSenha = "Clique para mostrar ou esconder a senha.";

        public TelaLogin()
        {
            InitializeComponent();

            funcionarioService = new FuncionarioService(); // Cria uma instância de FuncionarioService

            toolTip = new ToolTip(); // Inicializar tooltip genérica

            // Configurações gerais de tooltip
            toolTip.ToolTipTitle = "Informação";  // Título do balão
            toolTip.ToolTipIcon = ToolTipIcon.Info; // Ícone de informação
            toolTip.IsBalloon = false; // Mostrar como balão
            toolTip.AutoPopDelay = 5000; // Tempo que o balão ficará visível (em milissegundos)
            toolTip.InitialDelay = 250;  // Tempo antes de aparecer
            toolTip.ReshowDelay = 500;   // Tempo antes de reaparecer

            toolTip.SetToolTip(this.PictureBoxMostrarSenha, tooltipMostrarSenha); // Adicionar tooltip ao PictureBoxMostrarSenha
        }

        private void BotaoEntrar_Click(object sender, EventArgs e)
        {
            if (TextBoxUsuario.Text == "")
            {
                MessageBox.Show("Preencha o campo usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TextBoxSenha.Text == "")
            {
                MessageBox.Show("Preencha o campo senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string usuario = TextBoxUsuario.Text;
            string senha = TextBoxSenha.Text;

            bool autenticado = AutenticarFuncionario(usuario, senha); // Chamando o método dedicado AutenticarFuncionario
            if (autenticado == true)
            {
                UsuarioLogado = funcionarioService.ConsultarFuncionarioUsuario(usuario);

                this.DialogResult = DialogResult.OK;
                this.Close(); // Fecha a TelaLogin
            }

        }

        // Método dedicado para autenticar login do funcionário
        private bool AutenticarFuncionario(string usuario, string senha)
        {
            string autenticarfuncionario = funcionarioService.AutenticarFuncionario(usuario, senha); // Chamando o método AutenticarFuncionario da instância funcionarioService
            if (autenticarfuncionario == "autenticado")
            {
                MessageBox.Show("Acesso permitido, usuário autenticado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (autenticarfuncionario == "naoautenticado")
            {
                MessageBox.Show("Acesso negado, usuário não autenticado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (autenticarfuncionario == "inativo")
            {
                MessageBox.Show("Acesso negado, usuário está desativado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (autenticarfuncionario == "naoexiste")
            {
                MessageBox.Show("Acesso negado, usuário não existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (autenticarfuncionario == "erro")
            {
                MessageBox.Show("Erro ao autenticar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (autenticarfuncionario == "errodesconhecido")
            {
                MessageBox.Show("Erro desconhecido ao autenticar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return false;
            }
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBoxSenha_TextChanged(object sender, EventArgs e)
        {
            TextBoxSenha.UseSystemPasswordChar = true;
        }

        private void PictureBoxX_Click(object sender, EventArgs e) // Para pular o login, apenas para testes
        {
            MessageBox.Show("Acesso permitido para testes.", "Acesso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close(); // Fecha a TelaLogin
        }

        private void PictureBoxMostrarSenha_Click(object sender, EventArgs e)
        {
            if (TextBoxSenha.UseSystemPasswordChar == true)
            {
                TextBoxSenha.UseSystemPasswordChar = false; // Alterna a visibilidade da senha
                PictureBoxMostrarSenha.Image = Properties.Resources.esconderSenha; // Altera o ícone do PictureBox
            }
            else
            {
                TextBoxSenha.UseSystemPasswordChar = true;
                PictureBoxMostrarSenha.Image = Properties.Resources.mostrarSenha;
            }
        }
    }
}
