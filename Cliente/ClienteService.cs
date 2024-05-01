namespace PIMFazendaUrbana
{
    public class ClienteService // A classe ClienteService é responsável por implementar a lógica de negócio relacionada a clientes
    {
        private ClienteDAO clienteDAO; // Campo privado para armazenar uma instância de ClienteDAO

        public ClienteService(ClienteDAO clienteDAO) // O construtor da classe ClienteService recebe um ClienteDAO como parâmetro, permitindo a injeção de dependência.
        {
            this.clienteDAO = clienteDAO; // Atribui a instância de ClienteDAO recebida ao campo clienteDAO
        }

        // 1- Cadastrar Cliente
        // O método CadastrarCliente é responsável por cadastrar um novo cliente. Antes de chamar o DAO para inserir um cliente no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool CadastrarCliente(Cliente cliente)
        {
            try
            {
                // Aqui podem ser feitas validações dos dados antes de chamar o DAO
                // Exemplo: verificar se o e-mail é válido, se o CNPJ é válido, etc
                // Se alguma validação falhar, você pode lançar uma exceção para interromper o cadastro e exibir uma mensagem de erro

                // EXEMPLOS DE VALIDAÇÃO:
                // Exemplo de validação do nome:

                /*
                if (string.IsNullOrEmpty(cliente.Nome))
                {
                    throw new Exception("O nome do cliente é obrigatório."); // Lança uma exceção caso o nome do cliente seja nulo ou vazio
                }
                // Exemplo de validação do e-mail
                if (string.IsNullOrEmpty(cliente.Email) || !cliente.Email.Contains("@"))
                {
                    throw new Exception("O e-mail do cliente é inválido."); // Lança uma exceção caso o e-mail seja nulo, vazio ou não contenha o caractere '@'
                }
                // Exemplo de validação do CNPJ
                if (string.IsNullOrEmpty(cliente.CNPJ) || cliente.CNPJ.Length != 14)
                {
                    throw new Exception("O CNPJ do cliente é inválido."); // Lança uma exceção caso o CNPJ seja nulo, vazio ou não tenha 14 caracteres
                }
                // Exemplo de validação do endereço
                if (cliente.Endereco == null || string.IsNullOrEmpty(cliente.Endereco.Logradouro))
                {
                    throw new Exception("O endereço do cliente é obrigatório."); // Lança uma exceção caso o endereço seja nulo ou o logradouro seja nulo ou vazio
                }
                // Exemplo de validação do telefone
                if (cliente.Telefone == null || string.IsNullOrEmpty(cliente.Telefone.DDD) || string.IsNullOrEmpty(cliente.Telefone.Numero))
                {
                    throw new Exception("O telefone do cliente é obrigatório."); // Lança uma exceção caso o telefone seja nulo ou o DDD e/ou número sejam nulos ou vazios
                }
                */

                // Se todas as validações forem bem-sucedidas, o cadastro do cliente pode ser realizado e então o DAO é chamado para inserir o cliente no banco de dados
                clienteDAO.CadastrarCliente_DAO(cliente); // Chama o método CadastrarCliente do DAO para inserir o novo cliente no banco de dados, passando o objeto cliente como argumento

                //Console.WriteLine("Cliente cadastrado com sucesso!"); // Se o cadastro for bem-sucedido, exibe uma mensagem de sucesso

                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro ou registra o erro em um log
                //Console.WriteLine($"Erro ao cadastrar cliente: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante o cadastro
                // Você também pode lançar a exceção novamente se desejar propagá-la para camadas superiores
                // throw;

                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 2- Alterar Cliente
        // O método AlterarCliente é responsável por alterar os dados de um cliente existente. Antes de chamar o DAO para atualizar os dados no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool AlterarCliente(Cliente cliente)
        {
            try
            {
                clienteDAO.AlterarCliente_DAO(cliente); // Chama o método AlterarCliente da classe ClienteDAO, passando o objeto cliente como argumento
                //Console.WriteLine("Cliente alterado com sucesso."); // Exibe uma mensagem de sucesso após a alteração

                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Erro ao alterar cliente: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a alteração

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
                Console.WriteLine("Cliente excluído com sucesso."); // Exibe uma mensagem de sucesso após a exclusão

                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir cliente: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a exclusão

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
                // Aqui você pode adicionar qualquer lógica adicional, se necessário
                return clientes; // Retorna a lista de clientes quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar clientes ativos
                throw new Exception("Erro ao listar clientes ativos.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Cliente>(); // Retorna uma lista vazia
            }
        }

        // 4.2- Listar Todos os Clientes
        // O método ListarTodosClientes é responsável por obter a lista de todos os clientes cadastrados no banco de dados e exibir esses dados na tela, independente se estão definidos como ativos ou inativos.
        public List<Cliente> ListarTodosClientes()
        {
            try
            {
                List<Cliente> clientes = clienteDAO.ListarTodosClientes_DAO();
                // Aqui você pode adicionar qualquer lógica adicional, se necessário
                return clientes; // Retorna a lista de clientes quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar clientes
                throw new Exception("Erro ao listar clientes.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Cliente>(); // Retorna uma lista vazia
            }
        }

        // 5- Consulta
        // 5.1 - Consultar Cliente por ID
        // O método ConsultarClienteID é responsável por consultar um cliente pelo ID e exibir seus dados na tela.
        public Cliente ConsultarClienteID(int clienteId)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteID_DAO(clienteId); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo ID
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.2 - Consultar Cliente por nome
        // O método ConsultarClienteNome é responsável por consultar um cliente pelo nome e exibir seus dados na tela.
        public Cliente ConsultarClienteNome(string clienteNome)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteNome_DAO(clienteNome); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo nome
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.3 - Consultar Cliente por CNPJ
        // O método ConsultarClienteCNPJ é responsável por consultar um cliente pelo cnpj e exibir seus dados na tela.
        public Cliente ConsultarClienteCNPJ(string clienteCNPJ)
        {
            try
            {
                Cliente cliente = clienteDAO.ConsultarClienteCNPJ_DAO(clienteCNPJ); // Chama o método ConsultarCliente da classe ClienteDAO para obter os dados de um cliente pelo cnpj
                return cliente; // Retorna o cliente encontrado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}