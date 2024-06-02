namespace PIMFazendaUrbanaLib
{
    public class ProducaoService
    {
        private ProducaoDAO producaoDAO;

        public ProducaoService()
        {
            this.producaoDAO = new ProducaoDAO();
        }

        // 1 - MÉTODO CADASTRAR PRODUCAO
        public bool CadastrarProducao(Producao producao)
        {
            try
            {
                producaoDAO.CadastrarProducao(producao);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar produção: " + ex.Message);
                //return false;
            }
        }

        // 2 - MÉTODO ALTERAR PRODUCAO
        public bool AlterarProducao(Producao producao)
        {
            try
            {
                producaoDAO.AlterarProducao(producao);
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
                producaoDAO.FinalizarProducao(producaoId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao finalizar produção: " + ex.Message);
                //return false;
            }
        }

        // 4 - Listagem
        // 4.1 - MÉTODO LISTAR PRODUCOES
        public List<Producao> ListarProducoes()
        {
            try
            {
                List<Producao> producoes = producaoDAO.ListarProducoes();
                return producoes; // Retorna a lista de produções quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produções: " + ex.Message); // Lança uma exceção indicando que ocorreu um erro
            }
        }

        // 4.2 - MÉTODO LISTAR PRODUCOES (NÃO FINALIZADAS)
        public List<Producao> ListarProducoesNaoFinalizadas()
        {
            try
            {
                List<Producao> producoes = producaoDAO.ListarProducoesNaoFinalizadas();
                return producoes; // Retorna a lista de produções quando tudo corre bem
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produções.", ex); // Lança uma exceção indicando que ocorreu um erro
            }
        }

        // 5 - MÉTODO CONSULTAR PRODUCAO POR ID
        public Producao ConsultarProducaoID(int producaoId)
        {
            try
            {
                Producao producao = producaoDAO.ConsultarProducaoID(producaoId);
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
