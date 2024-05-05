namespace PIMFazendaUrbana
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();

            // Abre a tela principal
            this.Show();

            // Desabilita todos os controles da tela principal
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }

            // Abre a tela de login
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.FormClosed += (sender, e) =>
            {
                // Habilita todos os controles da tela principal quando a tela de login for fechada
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }
            };
            telaLogin.Show();

            // Define o foco para a TelaLogin (aparecer por cima da TelaPrincipal)
            telaLogin.Activate();
        }

        private void PictureBoxFuncionarios_Click(object sender, EventArgs e)
        {
            TelaFuncionarios telaUser = new TelaFuncionarios();
            telaUser.ShowDialog();
        }

        private void PictureBoxFuncionarios_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(PictureBoxFuncionarios, "Usuarios");
        }

        private void PictureBoxCategorias_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(PictureBoxCategorias, "Categorias");
        }

        private void PictureBoxProdutos_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(PictureBoxProdutos, "Produtos");
        }

        private void PictureBoxInventario_MouseHover(object sender, EventArgs e)
        {
            toolTip4.SetToolTip(PictureBoxInventario, "Inventario");
        }

        private void PictureBoxTransacoes_MouseHover(object sender, EventArgs e)
        {
            toolTip5.SetToolTip(PictureBoxTransacoes, "Transacoes");
        }

        private void PictureBoxClientes_MouseHover(object sender, EventArgs e)
        {
            toolTip6.SetToolTip(PictureBoxClientes, "Clientes");
        }

        private void PictureBoxFornecedores_MouseHover(object sender, EventArgs e)
        {
            toolTip7.SetToolTip(PictureBoxFornecedores, "Fornecedores");
        }

        private void PictureBoxClientes_Click(object sender, EventArgs e)
        {
            TelaClientes telaListarClientes = new TelaClientes();
            telaListarClientes.Show();
        }

        private void PictureBoxSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxProdutos_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxCategorias_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxFornecedores_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxInventario_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxTransacoes_Click(object sender, EventArgs e)
        {

        }

        private void BotaoTesteRecomendacoes_Click(object sender, EventArgs e)
        {
            TelaIndicarPlantio telaIndicarPlantio = new TelaIndicarPlantio();
            telaIndicarPlantio.Show();
        }

        private void BotaoLogin_Click(object sender, EventArgs e)
        {
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();
        }

        private void BotaoAbrirTelaDeTeste_Click(object sender, EventArgs e)
        {
            TelaTeste telaTeste = new TelaTeste();
            telaTeste.Show();
        }
    }
}
