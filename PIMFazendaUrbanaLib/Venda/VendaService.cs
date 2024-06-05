using MySql.Data.MySqlClient;

namespace PIMFazendaUrbanaLib
{
    public class VendaService
    {
        private VendaDAO pedidoVendaDAO;
        private string connectionString;

        public VendaService()
        {
            this.pedidoVendaDAO = new VendaDAO();
            this.connectionString = ConnectionString.GetConnectionString();
        }

        // Método para cadastrar um novo pedido de venda
        public void CadastrarPedidoVendaComItens(PedidoVenda pedidoVenda, List<PedidoVendaItem> vendaItems)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Cadastrar PedidoVenda
                        pedidoVendaDAO.CadastrarPedidoVenda(pedidoVenda, transaction);

                        // Cadastrar Itens de Venda
                        foreach (var item in vendaItems)
                        {
                            item.IdPedidoVenda = pedidoVenda.Id;
                            pedidoVendaDAO.CadastrarVendaItem(item, transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Método para listar todos os pedidos de venda
        public List<PedidoVenda> ListarPedidosVenda()
        {
            try
            {
                return pedidoVendaDAO.ListarPedidosVenda();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar pedidos de venda: " + ex.Message);
            }
        }

        // Método para consultar um pedido de venda pelo ID
        public PedidoVenda ConsultarPedidoVenda(int idPedidoVenda)
        {
            try
            {
                return pedidoVendaDAO.ConsultarPedidoVenda(idPedidoVenda);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar pedido de venda: " + ex.Message);
            }
        }

        // Método para obter o último ID de pedido de venda
        public int? ObterUltimoIdPedidoVenda()
        {
            try
            {
                return pedidoVendaDAO.ObterUltimoIdPedidoVenda();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter último ID de pedido de venda: " + ex.Message);
            }
        }

        // Método para listar todos os itens de venda
        public List<PedidoVendaItem> ListarRegistrosDeVenda()
        {
            try
            {
                return pedidoVendaDAO.ListarRegistrosDeVenda();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar registros de venda: " + ex.Message);
            }
        }

        // Método para consultar um item de venda pelo ID
        public PedidoVendaItem ConsultarVendaItem(int idVendaItem)
        {
            try
            {
                return pedidoVendaDAO.ConsultarVendaItem(idVendaItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar item de venda: " + ex.Message);
            }
        }

    }
}
