namespace PIMFazendaUrbanaLib
{
    public class InsumoService
    {
        private InsumoDAO insumoDAO;

        public InsumoService()
        {
            this.insumoDAO = new InsumoDAO();
        }

        public bool CadastrarInsumo(Insumo insumo)
        {
            try
            {
                insumoDAO.CadastrarInsumo(insumo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar insumo.", ex);
            }
        }

        public bool AlterarInsumo(Insumo insumo)
        {
            try
            {
                insumoDAO.AlterarInsumo(insumo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar insumo.", ex);
                return false;
            }
        }

        public Insumo ConsultarInsumoPorID(int insumoID)
        {
            try
            {
                Insumo insumo = insumoDAO.ConsultarInsumoPorID(insumoID);
                return insumo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar insumo por ID.", ex);
            }
        }

        public List<Insumo> ListarInsumosAtivos()
        {
            try
            {
                List<Insumo> insumos = insumoDAO.ListarInsumosAtivos();
                return insumos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar insumos ativos.", ex);
            }
        }

        public List<Insumo> ListarInsumosInativos()
        {
            try
            {
                List<Insumo> insumosInativos = insumoDAO.ListarInsumosInativos();
                return insumosInativos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar insumos inativos.", ex);
            }
        }

        public void DesativarInsumo(int insumoID)
        {
            try
            {
                insumoDAO.DesativarInsumo(insumoID);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao desativar insumo.", ex);
            }
        }

        public List<Insumo> FiltrarInsumosNome(string insumoNome)
        {
            try
            {
                List<Insumo> insumos = insumoDAO.FiltrarInsumosNome(insumoNome);
                return insumos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
