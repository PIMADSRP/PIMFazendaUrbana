namespace PIMFazendaUrbana
{
    public partial class MenuPrincipalTeste : Form
    {
        public MenuPrincipalTeste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Criar uma inst�ncia do segundo formul�rio
            TelaCadastrarCliente telaCadastrarCliente = new TelaCadastrarCliente();

            // Exibir o segundo formul�rio
            telaCadastrarCliente.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Criar uma inst�ncia do segundo formul�rio
            TelaClientes telaListarClientes = new TelaClientes();

            // Exibir o segundo formul�rio
            telaListarClientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Criar uma inst�ncia do segundo formul�rio
            TelaTeste telaTeste = new TelaTeste();

            // Exibir o segundo formul�rio
            telaTeste.Show();
        }
    }
}
