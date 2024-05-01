namespace PIMFazendaUrbana
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Criar uma instância do segundo formulário
            TelaCadastrarCliente telaCadastrarCliente = new TelaCadastrarCliente();

            // Exibir o segundo formulário
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
            // Criar uma instância do segundo formulário
            TelaListarClientes telaListarClientes = new TelaListarClientes();

            // Exibir o segundo formulário
            telaListarClientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Criar uma instância do segundo formulário
            TelaTeste telaTeste = new TelaTeste();

            // Exibir o segundo formulário
            telaTeste.Show();
        }
    }
}
