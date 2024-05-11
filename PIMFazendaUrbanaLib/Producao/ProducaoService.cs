namespace PIMFazendaUrbanaLib
{
    public class ProducaoService
    {
        private ProducaoDAO producaoDAO;

        public ProducaoService(ProducaoDAO producaoDAO)
        {
            this.producaoDAO = producaoDAO;
        }

        // 1 - MÉTODO CADASTRAR PRODUCAO
        public bool CadastrarProducao(Producao producao)
        {
            try
            {
                producaoDAO.CadastrarProducao_DAO(producao);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 2 - MÉTODO ALTERAR PRODUCAO
        public bool AlterarProducao(Producao producao)
        {
            try
            {
                producaoDAO.AlterarProducao_DAO(producao);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 3 - MÉTODO FINALIZAR PRODUCAO
        public bool FinalizarProducao(int producaoId)
        {
            try
            {
                producaoDAO.FinalizarProducao_DAO(producaoId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 4 - MÉTODO EXCLUIR (DESATIVAR) PRODUCAO
        public bool ExcluirProducao(int producaoId)
        {
            try
            {
                producaoDAO.ExcluirProducao_DAO(producaoId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // 5 - Listagem
        // 5.1 - MÉTODO LISTAR PRODUCOES (ATIVAS)
        public List<Producao> ListarProducoesAtivas()
        {
            try
            {
                List<Producao> producoes = producaoDAO.ListarProducoesAtivas_DAO();
                return producoes; // Retorna a lista de produções quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produções ativas.", ex); // Lança uma exceção indicando que ocorreu um erro
            }
        }

        // 5.2 - MÉTODO LISTAR PRODUCOES (ATIVAS E NÃO FINALIZADAS)
        public List<Producao> ListarProducoesAtivasNaoFinalizadas()
        {
            try
            {
                List<Producao> producoes = producaoDAO.ListarProducoesAtivasNaoFinalizadas_DAO();
                return producoes; // Retorna a lista de produções quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produções ativas.", ex); // Lança uma exceção indicando que ocorreu um erro
            }
        }

        // 6 - MÉTODO CONSULTAR PRODUCAO POR ID
        public Producao ConsultarProducaoID(int producaoId)
        {
            try
            {
                Producao producao = producaoDAO.ConsultarProducaoID_DAO(producaoId);
                return producao;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao consultar produção: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
