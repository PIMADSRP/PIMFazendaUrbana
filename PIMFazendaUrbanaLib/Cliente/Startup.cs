namespace PIMFazendaUrbanaLib
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) // com ASP.NET
        {
            // Injeção de dependências
            services.AddScoped<IClienteDAO, ClienteDAO>(); // ClienteDAO como implementação de IClienteDAO
            services.AddScoped<IClienteService, ClienteService>(); // ClienteService como serviço

            services.AddControllers(); // Habilita controladores para APIs
        }
    }
}
