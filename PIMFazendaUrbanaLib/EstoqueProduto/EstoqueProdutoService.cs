namespace PIMFazendaUrbanaLib
{
    public class EstoqueProdutoService
    {
        private EstoqueProdutoDAO estoqueProdutoDAO;

        public EstoqueProdutoService()
        {
            this.estoqueProdutoDAO = new EstoqueProdutoDAO();
        }

        public bool CadastrarInsumo(Insumo insumo)
        {
            try
            {
                estoqueProdutoDAO.CadastrarInsumo(insumo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar insumo: " + ex.Message);
            }
        }

        public bool AlterarInsumo(Insumo insumo)
        {
            try
            {
                estoqueProdutoDAO.AlterarInsumo(insumo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar insumo: " + ex.Message);
                return false;
            }
        }

        public Insumo ConsultarInsumoPorID(int insumoID)
        {
            try
            {
                Insumo insumo = estoqueProdutoDAO.ConsultarInsumoPorID(insumoID);
                return insumo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar estoque de produtos por ID: " + ex.Message);
            }
        }

        public List<EstoqueProduto> ListarEstoqueProdutoAtivos()
        {
            try
            {
                List<EstoqueProduto> produtos = estoqueProdutoDAO.ListarEstoqueProdutoAtivos();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar estoque de produtos: " + ex.Message);
            }
        }

        public List<Insumo> ListarInsumosEmEstoque()
        {
            try
            {
                List<Insumo> insumos = estoqueProdutoDAO.ListarInsumosEmEstoque();
                return insumos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar estoque de produtos: " + ex.Message);
            }
        }

        public List<Insumo> ListarInsumosInativos()
        {
            try
            {
                List<Insumo> insumosInativos = estoqueProdutoDAO.ListarInsumosInativos();
                return insumosInativos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar insumos inativos: " + ex.Message);
            }
        }

        public void DesativarInsumo(int insumoID)
        {
            try
            {
                estoqueProdutoDAO.DesativarInsumo(insumoID);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao desativar insumo: " + ex.Message);
            }
        }

        public List<EstoqueProduto> FiltrarProdutosNome(string produtoNome)
        {
            try
            {
                List<EstoqueProduto> produtos = estoqueProdutoDAO.FiltrarProdutosNome(produtoNome);
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar produtos por nome: " + ex.Message);
                //return null;
            }
        }

        public List<SaidaInsumo> ListarSaidaInsumos()
        {
            try
            {
                List<SaidaInsumo> saidainsumos = estoqueProdutoDAO.ListarSaidaInsumos();
                return saidainsumos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar registros de saída de insumos: " + ex.Message);
            }
        }

        // Método para filtrar insumos pela unidade
        public List<Insumo> FiltrarInsumosPorUnidade(string unidade)
        {
            try
            {
                return estoqueProdutoDAO.FiltrarInsumosPorUnidade(unidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar insumos pela unidade: " + ex.Message);
            }
        }

        // Método para obter a categoria do insumo pelo nome
        public string ObterCategoriaPorNomeInsumo(string nomeInsumo)
        {
            try
            {
                return estoqueProdutoDAO.ObterCategoriaPorNomeInsumo(nomeInsumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter categoria do insumo pelo nome: " + ex.Message);
            }
        }

        public bool CadastrarSaidaInsumo(SaidaInsumo saidainsumo, Insumo insumo)
        {
            try
            {
                estoqueProdutoDAO.CadastrarSaidaInsumo(saidainsumo, insumo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar saída de insumo: " + ex.Message);
            }
        }

        public bool AumentarQtdInsumo(Insumo insumo, int qtd)
        {
            try
            {
                estoqueProdutoDAO.AumentarQtdInsumo(insumo, qtd);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar quantidade do insumo: " + ex.Message);
                return false;
            }
        }
    }
}
