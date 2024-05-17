namespace PIMFazendaUrbanaLib
{
    public class FornecedorService // A classe FornecedorService é responsável por implementar a lógica de negócio relacionada a fornecedors
    {
        private FornecedorDAO fornecedorDAO;
        public FornecedorService()
        {
            this.fornecedorDAO = new FornecedorDAO();
        }

        // 1- Cadastrar Fornecedor
        // O método CadastrarFornecedor é responsável por cadastrar um novo fornecedor. Antes de chamar o DAO para inserir um fornecedor no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                fornecedorDAO.CadastrarFornecedor_DAO(fornecedor); // Chama o método CadastrarFornecedor do DAO para inserir o novo fornecedor no banco de dados, passando o objeto fornecedor como argumento
                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 2- Alterar Fornecedor
        // O método AlterarFornecedor é responsável por alterar os dados de um fornecedor existente. Antes de chamar o DAO para atualizar os dados no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool AlterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                fornecedorDAO.AlterarFornecedor_DAO(fornecedor);
                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
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
                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Retorna false para indicar que a exclusão falhou
            }
        }

        // 4- Listagem
        // 4.1- Listar Fornecedors Ativos
        // O método ListarFornecedorsAtivos é responsável por obter a lista de todos os fornecedors com a flag "ativo_fornecedor = true" cadastrados no banco de dados e exibir esses dados na tela.
        public List<Fornecedor> ListarFornecedorsAtivos()
        {
            try
            {
                List<Fornecedor> fornecedors = fornecedorDAO.ListarFornecedorsAtivos_DAO();
                return fornecedors; // Retorna a lista de fornecedors quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar fornecedors ativos.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar fornecedors ativos
            }
        }

        // 4.2- Listar Todos os Fornecedors
        // O método ListarTodosFornecedors é responsável por obter a lista de todos os fornecedors cadastrados no banco de dados e exibir esses dados na tela, independente se estão definidos como ativos ou inativos.
        public List<Fornecedor> ListarTodosFornecedors()
        {
            try
            {
                List<Fornecedor> fornecedors = fornecedorDAO.ListarTodosFornecedors_DAO();
                return fornecedors; // Retorna a lista de fornecedors quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar fornecedors.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar fornecedors
            }
        }

        // 5- Consulta
        // 5.1 - Consultar Fornecedor por ID
        public Fornecedor ConsultarFornecedorID(int fornecedorId)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorID_DAO(fornecedorId); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo ID
                return fornecedor; // Retorna o fornecedor encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.2 - Consultar Fornecedor por nome
        public Fornecedor ConsultarFornecedorNome(string fornecedorNome)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorNome_DAO(fornecedorNome); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo nome
                return fornecedor; // Retorna o fornecedor encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 5.3 - Consultar Fornecedor por CNPJ
        public Fornecedor ConsultarFornecedorCNPJ(string fornecedorCNPJ)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorCNPJ_DAO(fornecedorCNPJ); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo cnpj
                return fornecedor; // Retorna o fornecedor encontrado
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}