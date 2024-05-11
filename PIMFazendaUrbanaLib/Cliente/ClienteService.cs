namespace PIMFazendaUrbanaLib
{
    public class ClienteService // A classe ClienteService é responsável por implementar a lógica de negócio relacionada a clientes
    {
        private ClienteDAO clienteDAO;
        public ClienteService()
        {
            this.clienteDAO = new ClienteDAO();
        }

        // 1- Cadastrar Cliente
        // O método CadastrarCliente é responsável por cadastrar um novo cliente. Antes de chamar o DAO para inserir um cliente no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool CadastrarCliente(Cliente cliente)
        {
            try
            {
                clienteDAO.CadastrarCliente_DAO(cliente); // Chama o método CadastrarCliente do DAO para inserir o novo cliente no banco de dados, passando o objeto cliente como argumento
                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 2- Alterar Cliente
        // O método AlterarCliente é responsável por alterar os dados de um cliente existente. Antes de chamar o DAO para atualizar os dados no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool AlterarCliente(Cliente cliente)
        {
            try
            {
                clienteDAO.AlterarCliente_DAO(cliente);
                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a alteração falhou
            }
        }

        // 3- Excluir (DESATIVAR) Cliente
        // O método ExcluirCliente é responsável por excluir (DESATIVAR) um cliente do banco de dados. Antes de chamar o DAO para realizar a exclusão, este método pode realizar validações ou outras operações necessárias.
        public bool ExcluirCliente(int clienteId)
        {
            try
            {
                clienteDAO.ExcluirCliente_DAO(clienteId); // Chama o método ExcluirCliente da classe ClienteDAO, passando o ID do cliente como argumento
                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a exclusão falhou
            }
        }

        // 4- Listagem
        // 4.1- Listar Clientes Ativos
        // O método ListarClientesAtivos é responsável por obter a lista de todos os clientes com a flag "ativo_cliente = true" cadastrados no banco de dados e exibir esses dados na tela.
        public List<Cliente> ListarClientesAtivos()
        {
            try
            {
                List<Cliente> clientes = clienteDAO.ListarClientesAtivos_DAO();
                return clientes; // Retorna a lista de clientes quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes ativos.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar clientes ativos
            }
        }

        // 4.2- Listar Todos os Clientes
        // O método ListarTodosClientes é responsável por obter a lista de todos os clientes cadastrados no banco de dados e exibir esses dados na tela, independente se estão definidos como ativos ou inativos.
        public List<Cliente> ListarTodosClientes()
        {
            try
            {
                List<Cliente> clientes = clienteDAO.ListarTodosClientes_DAO();
                return clientes; // Retorna a lista de clientes quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar clientes
            }
        }

        // 5- Consulta
        // 5.1 - Consultar Cliente por ID
        public Cliente ConsultarClienteID(int clienteId)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteID_DAO(clienteId); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo ID
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.2 - Consultar Cliente por nome
        public Cliente ConsultarClienteNome(string clienteNome)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteNome_DAO(clienteNome); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo nome
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.3 - Consultar Cliente por CNPJ
        public Cliente ConsultarClienteCNPJ(string clienteCNPJ)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteCNPJ_DAO(clienteCNPJ); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo cnpj
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}