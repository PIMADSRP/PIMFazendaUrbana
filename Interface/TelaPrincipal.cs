namespace PIMFazendaUrbana
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

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

        private void Produtos_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            // Criar uma inst�ncia do segundo formul�rio
            TelaClientes telaListarClientes = new TelaClientes();

            // Exibir o segundo formul�rio
            telaListarClientes.Show();
        }
    }
}
