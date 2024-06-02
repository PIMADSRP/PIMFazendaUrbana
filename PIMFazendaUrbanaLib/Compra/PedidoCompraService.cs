namespace PIMFazendaUrbanaLib
{
    public class PedidoCompraService
    {
        private PedidoCompraDAO pedidoCompraDAO;

        public PedidoCompraService()
        {
            this.pedidoCompraDAO = new PedidoCompraDAO();
        }

        // Método para cadastrar um novo pedido de compra
        public bool CadastrarPedidoCompra(PedidoCompra pedidoCompra)
        {
            try
            {
                pedidoCompraDAO.CadastrarPedidoCompra(pedidoCompra);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar pedido de compra: " + ex.Message);
                //return false;
            }
        }

        // Método para alterar um pedido de compra existente
        public bool AlterarPedidoCompra(PedidoCompra pedidoCompra)
        {
            try
            {
                pedidoCompraDAO.AlterarPedidoCompra(pedidoCompra);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar pedido de compra: " + ex.Message);
                //return false;
            }
        }

        // Método para excluir um pedido de compra
        public bool ExcluirPedidoCompra(int idPedidoCompra)
        {
            try
            {
                pedidoCompraDAO.ExcluirPedidoCompra(idPedidoCompra);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir pedido de compra: " + ex.Message);
                //return false;
            }
        }

        // Método para listar todos os pedidos de compra
        public List<PedidoCompra> ListarPedidosCompra()
        {
            try
            {
                return pedidoCompraDAO.ListarPedidosCompra();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pedidos de compra: " + ex.Message);
            }
        }

        // Método para consultar um pedido de compra pelo ID
        public PedidoCompra ConsultarPedidoCompra(int idPedidoCompra)
        {
            try
            {
                return pedidoCompraDAO.ConsultarPedidoCompra(idPedidoCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar pedido de compra: " + ex.Message);
            }
        }

        // Método para obter o último ID de pedido de compra
        public int ObterUltimoIdPedidoCompra()
        {
            try
            {
                return pedidoCompraDAO.ObterUltimoIdPedidoCompra();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter último ID de pedido de compra: " + ex.Message);
            }
        }

    }
}
