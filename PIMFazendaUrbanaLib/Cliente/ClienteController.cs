namespace PIMFazendaUrbanaLib
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase // Controller com ASP.NET
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult CadastrarCliente([FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.CadastrarCliente(cliente);
                return Ok("Cliente cadastrado com sucesso.");
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Erros = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }
    }

}
