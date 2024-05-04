namespace PIMFazendaUrbana
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaFuncionarios telaUser = new TelaFuncionarios();
            telaUser.ShowDialog();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            //frmUsuarios frm = new frmUsuarios();
            // frm.ShowDialog();
            TelaFuncionarios telaUser = new TelaFuncionarios();
            telaUser.ShowDialog();
        }

        private void Usuarios_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Usuarios, "Usuarios");
        }

        private void Categorias_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(Categorias, "Categorias");
        }

        private void Produtos_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(Produtos, "Produtos");
        }

        private void Inventario_MouseHover(object sender, EventArgs e)
        {
            toolTip4.SetToolTip(Inventario, "Inventario");
        }

        private void Transacoes_MouseHover(object sender, EventArgs e)
        {
            toolTip5.SetToolTip(Transacoes, "Transacoes");
        }

        private void Clientes_MouseHover(object sender, EventArgs e)
        {
            toolTip6.SetToolTip(Clientes, "Clientes");
        }

        private void Fornecedores_MouseHover(object sender, EventArgs e)
        {
            toolTip7.SetToolTip(Fornecedores, "Fornecedores");
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            // Criar uma instância do segundo formulário
            TelaClientes telaListarClientes = new TelaClientes();

            // Exibir o segundo formulário
            telaListarClientes.Show();
        }

        private void PictureBoxSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
