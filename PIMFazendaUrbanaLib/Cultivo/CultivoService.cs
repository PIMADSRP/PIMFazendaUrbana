namespace PIMFazendaUrbanaLib
{
    public class CultivoService
    {
        private CultivoDAO cultivoDAO;

        public CultivoService()
        {
            this.cultivoDAO = new CultivoDAO();
        }

        // 1- Cadastrar Cultivo
        public bool CadastrarCultivo(Cultivo cultivo)
        {
            try
            {
                cultivoDAO.CadastrarCultivo(cultivo); // Chama o método CadastrarCultivo do DAO para inserir o novo cultivo no banco de dados, passando o objeto cultivo como argumento
                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                return false; // Retorna false para indicar que o cadastro falhou
            }
        }

        // 2- Alterar Cultivo
        public bool AlterarCultivo(Cultivo cultivo)
        {
            try
            {
                cultivoDAO.AlterarCultivo(cultivo); // Chama o método AlterarCultivo do DAO para atualizar os dados do cultivo no banco de dados
                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                return false; // Retorna false para indicar que a alteração falhou
            }
        }

        // 3- Excluir (DESATIVAR) Cultivo
        public bool ExcluirCultivo(int cultivoId)
        {
            try
            {
                cultivoDAO.ExcluirCultivo(cultivoId); // Chama o método ExcluirCultivo do DAO para desativar o cultivo no banco de dados
                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                return false; // Retorna false para indicar que a exclusão falhou
            }
        }

        // 4- Listagem
        // 4.1- Listar Cultivos Ativos
        public List<Cultivo> ListarCultivosAtivos()
        {
            try
            {
                List<Cultivo> cultivos = cultivoDAO.ListarCultivosAtivos(); // Chama o método ListarCultivosAtivos do DAO para obter a lista de cultivos ativos
                return cultivos; // Retorna a lista de cultivos ativos quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar cultivos ativos.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar cultivos ativos
            }
        }

        // 4.2- Listar Cultivos Inativos
        public List<Cultivo> ListarCultivosInativos()
        {
            try
            {
                List<Cultivo> cultivosInativos = cultivoDAO.ListarCultivosInativos(); // Chama o método ListarCultivosInativos do DAO para obter a lista de cultivos inativos
                return cultivosInativos; // Retorna a lista de cultivos inativos quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar cultivos inativos.", ex); // Lança uma exceção indicando que ocorreu um erro ao listar cultivos inativos
            }
        }

        // 5- Consulta
        // 5.1 - Consultar Cultivo por ID
        public Cultivo ConsultarCultivoID(int cultivoId)
        {
            try
            {
                Cultivo cultivo = cultivoDAO.ConsultarCultivoID(cultivoId); // Chama o método ConsultarCultivoID do DAO para obter os dados de um cultivo pelo ID
                return cultivo; // Retorna o cultivo encontrado
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                return null; // Retorna null para indicar que a consulta falhou
            }
        }

        // 5.2 - Consultar Cultivo por nome
        public Cultivo ConsultarCultivoNome(string cultivoNome)
        {
            try
            {
                Cultivo cultivo = cultivoDAO.ConsultarCultivoNome(cultivoNome); // Chama o método ConsultarCultivoNome do DAO para obter os dados de um cultivo pelo nome
                return cultivo; // Retorna o cultivo encontrado
            }
            catch (Exception ex)
            {
                // Log exception details for debugging
                return null; // Retorna null para indicar que a consulta falhou
            }
        }

        public List<Cultivo> FiltrarCultivosNome(string cultivoNome)
        {
            return cultivoDAO.FiltrarCultivosNome(cultivoNome);
        }
    }
}
