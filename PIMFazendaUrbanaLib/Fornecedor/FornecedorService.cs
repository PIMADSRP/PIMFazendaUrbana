namespace PIMFazendaUrbana
{
    public class FornecedorService // A classe FornecedorService é responsável por implementar a lógica de negócio relacionada a fornecedores
    {
        private FornecedorDAO fornecedorDAO; // Campo privado para armazenar uma instância de FornecedorDAO

        public FornecedorService(FornecedorDAO fornecedorDAO) // O construtor da classe FornecedorService recebe um FornecedorDAO como parâmetro, permitindo a injeção de dependência.
        {
            this.fornecedorDAO = fornecedorDAO; // Atribui a instância de FornecedorDAO recebida ao campo fornecedorDAO
        }

        // 1- Cadastrar Fornecedor
        // O método CadastrarFornecedor é responsável por cadastrar um novo fornecedor. Antes de chamar o DAO para inserir um fornecedor no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                // Aqui podem ser feitas validações dos dados antes de chamar o DAO
                // Exemplo: verificar se o e-mail é válido, se o CNPJ é válido, etc
                // Se alguma validação falhar, você pode lançar uma exceção para interromper o cadastro e exibir uma mensagem de erro

                // EXEMPLOS DE VALIDAÇÃO:
                // Exemplo de validação do nome:

                /*
                if (string.IsNullOrEmpty(fornecedor.Nome))
                {
                    throw new Exception("O nome do fornecedor é obrigatório."); // Lança uma exceção caso o nome do fornecedor seja nulo ou vazio
                }
                // Exemplo de validação do e-mail
                if (string.IsNullOrEmpty(fornecedor.Email) || !fornecedor.Email.Contains("@"))
                {
                    throw new Exception("O e-mail do fornecedor é inválido."); // Lança uma exceção caso o e-mail seja nulo, vazio ou não contenha o caractere '@'
                }
                // Exemplo de validação do CNPJ
                if (string.IsNullOrEmpty(fornecedor.CNPJ) || fornecedor.CNPJ.Length != 14)
                {
                    throw new Exception("O CNPJ do fornecedor é inválido."); // Lança uma exceção caso o CNPJ seja nulo, vazio ou não tenha 14 caracteres
                }
                // Exemplo de validação do endereço
                if (fornecedor.Endereco == null || string.IsNullOrEmpty(fornecedor.Endereco.Logradouro))
                {
                    throw new Exception("O endereço do fornecedor é obrigatório."); // Lança uma exceção caso o endereço seja nulo ou o logradouro seja nulo ou vazio
                }
                // Exemplo de validação do telefone
                if (fornecedor.Telefone == null || string.IsNullOrEmpty(fornecedor.Telefone.DDD) || string.IsNullOrEmpty(fornecedor.Telefone.Numero))
                {
                    throw new Exception("O telefone do fornecedor é obrigatório."); // Lança uma exceção caso o telefone seja nulo ou o DDD e/ou número sejam nulos ou vazios
                }
                */

                // Se todas as validações forem bem-sucedidas, o cadastro do fornecedor pode ser realizado e então o DAO é chamado para inserir o fornecedor no banco de dados
                fornecedorDAO.CadastrarFornecedor_DAO(fornecedor); // Chama o método CadastrarFornecedor do DAO para inserir o novo fornecedor no banco de dados, passando o objeto fornecedor como argumento

                //Console.WriteLine("Fornecedor cadastrado com sucesso!"); // Se o cadastro for bem-sucedido, exibe uma mensagem de sucesso

                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro ou registra o erro em um log
                //Console.WriteLine($"Erro ao cadastrar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante o cadastro
                // Você também pode lançar a exceção novamente se desejar propagá-la para camadas superiores
                // throw;

                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 2- Alterar Fornecedor
        // O método AlterarFornecedor é responsável por alterar os dados de um fornecedor existente. Antes de chamar o DAO para atualizar os dados no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool AlterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                fornecedorDAO.AlterarFornecedor_DAO(fornecedor); // Chama o método AlterarFornecedor da classe FornecedorDAO, passando o objeto fornecedor como argumento
                //Console.WriteLine("Fornecedor alterado com sucesso."); // Exibe uma mensagem de sucesso após a alteração

                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Erro ao alterar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a alteração

                return false; // Retorna false para indicar que a alteração falhou
            }
        }

        // 3- Excluir (DESATIVAR) Fornecedor
        // O método ExcluirFornecedor é responsável por excluir (DESATIVAR) um fornecedor do banco de dados. Antes de chamar o DAO para realizar a exclusão, este método pode realizar validações ou outras operações necessárias.
        public bool ExcluirFornecedor(int fornecedorId)
        {
            try
            {
                fornecedorDAO.ExcluirFornecedor_DAO(fornecedorId); // Chama o método ExcluirFornecedor da classe FornecedorDAO, passando o ID do fornecedor como argumento
                Console.WriteLine("Fornecedor excluído com sucesso."); // Exibe uma mensagem de sucesso após a exclusão

                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a exclusão

                return false; // Retorna false para indicar que a exclusão falhou
            }
        }

        // 4- Listagem
        // 4.1- Listar Fornecedores Ativos
        // O método ListarFornecedoresAtivos é responsável por obter a lista de todos os fornecedores com a flag "ativo_fornecedor = true" cadastrados no banco de dados e exibir esses dados na tela.
        public List<Fornecedor> ListarFornecedoresAtivos()
        {
            try
            {
                List<Fornecedor> fornecedores = fornecedorDAO.ListarFornecedoresAtivos_DAO();
                // Aqui você pode adicionar qualquer lógica adicional, se necessário
                return fornecedores; // Retorna a lista de fornecedores quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar fornecedores ativos
                throw new Exception("Erro ao listar fornecedores ativos.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Fornecedor>(); // Retorna uma lista vazia
            }
        }

        // 4.2- Listar Todos os Fornecedores
        // O método ListarTodosFornecedores é responsável por obter a lista de todos os fornecedores cadastrados no banco de dados e exibir esses dados na tela, independente se estão definidos como ativos ou inativos.
        public List<Fornecedor> ListarTodosFornecedores()
        {
            try
            {
                List<Fornecedor> fornecedores = fornecedorDAO.ListarTodosFornecedores_DAO();
                // Aqui você pode adicionar qualquer lógica adicional, se necessário
                return fornecedores; // Retorna a lista de fornecedores quando tudo corre bem
            }
            catch (Exception ex)
            {
                // Lança uma exceção indicando que ocorreu um erro ao listar fornecedores
                throw new Exception("Erro ao listar fornecedores.", ex);
                // Ou, se preferir, poderia retornar uma lista vazia ou nula em vez de lançar uma exceção
                // return new List<Fornecedor>(); // Retorna uma lista vazia
            }
        }

        // 5- Consulta
        // 5.1 - Consultar Fornecedor por ID
        // O método ConsultarFornecedorID é responsável por consultar um fornecedor pelo ID e exibir seus dados na tela.
        public Fornecedor ConsultarFornecedorID(int fornecedorId)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorID_DAO(fornecedorId); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo ID
                return fornecedor;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.2 - Consultar Fornecedor por nome
        // O método ConsultarFornecedorNome é responsável por consultar um fornecedor pelo nome e exibir seus dados na tela.
        public Fornecedor ConsultarFornecedorNome(string fornecedorNome)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorNome_DAO(fornecedorNome); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo nome
                return fornecedor;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.3 - Consultar Fornecedor por CNPJ
        // O método ConsultarFornecedorCNPJ é responsável por consultar um fornecedor pelo cnpj e exibir seus dados na tela.
        public Fornecedor ConsultarFornecedorCNPJ(string fornecedorCNPJ)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorCNPJ_DAO(fornecedorCNPJ); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo cnpj
                return fornecedor;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}