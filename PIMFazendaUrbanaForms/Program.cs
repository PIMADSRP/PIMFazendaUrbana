using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        internal static Funcionario UsuarioLogado { get; set; }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            TelaSplash telaSplash = new TelaSplash();
            telaSplash.Show();
            Application.DoEvents(); // Faz com que o form seja totalmente renderizado antes do delay
            Thread.Sleep(3000);
            telaSplash.Close();

            TelaLogin telaLogin = new TelaLogin();
            if (telaLogin.ShowDialog() == DialogResult.OK)
            {
                UsuarioLogado = telaLogin.UsuarioLogado;
                Application.Run(new TelaPrincipal());
            }
            else
            {
                Application.Exit();
            }

        }
    }
}