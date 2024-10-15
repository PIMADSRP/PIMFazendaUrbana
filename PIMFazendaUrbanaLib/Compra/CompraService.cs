using MySql.Data.MySqlClient;

namespace PIMFazendaUrbanaLib
{
    public class CompraService
    {
        private CompraDAO pedidoCompraDAO;
        private string connectionString;

        public CompraService()
        {
            this.pedidoCompraDAO = new CompraDAO();
            this.connectionString = ConnectionString.GetConnectionString();
        }

        // Método para cadastrar um novo pedido de compra
        public void CadastrarPedidoCompraComItens(PedidoCompra pedidoCompra, List<PedidoCompraItem> compraItems)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        ValidarCompra(pedidoCompra, compraItems);

                        // Cadastrar PedidoCompra
                        pedidoCompraDAO.CadastrarPedidoCompra(pedidoCompra, transaction);

                        // Cadastrar Itens de Compra
                        foreach (var item in compraItems)
                        {
                            item.IdPedidoCompra = pedidoCompra.Id;
                            pedidoCompraDAO.CadastrarCompraItem(item, transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao cadastrar pedido de compra: " + ex.Message);
                    }
                }
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
        public int? ObterUltimoIdPedidoCompra()
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

        // Método para listar todos os itens de compra
        public List<PedidoCompraItem> ListarRegistrosDeCompra()
        {
            try
            {
                return pedidoCompraDAO.ListarRegistrosDeCompra();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar registros de compra: " + ex.Message);
            }
        }

        public List<PedidoCompraItem> FiltrarRegistrosDeCompraNome(string insumoNome)
        {
            try
            {
                List<PedidoCompraItem> compraItems = pedidoCompraDAO.FiltrarRegistrosDeCompraNome(insumoNome);
                return compraItems;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar registros de compra por nome de insumo: " + ex.Message);
            }
        }

        // Método para consultar um item de compra pelo ID
        public PedidoCompraItem ConsultarCompraItem(int idCompraItem)
        {
            try
            {
                return pedidoCompraDAO.ConsultarCompraItem(idCompraItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar item de compra: " + ex.Message);
            }
        }

        public List<PedidoCompraItem> FiltrarRegistrosDeCompraPorNomeEPeriodo(string insumoNome, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return pedidoCompraDAO.FiltrarRegistrosDeCompraPorNomeEPeriodo(insumoNome, dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao filtrar registros de compra por nome de insumo e período: " + ex.Message);
            }
        }

        /*
         * =-=-=-=-=-=-=-=-=-=-=-=- VALIDAÇÃO COMPRA =-=-=-=-=-=-=-=-=-=-=-=-
         */

        public void ValidarCompra(PedidoCompra pedidoCompra, List<PedidoCompraItem> compraItems)
        {
            var erros = new List<ValidationError>();

            //Código anterior: (!int.TryParse(TextBoxQuantidade.Text, out int quantidade) || quantidade <= 0). Removi a primeira validação do texbox e mantiva só se o valor é maior que 0
            if (compraItems.Count <= 0) //Verifica se a quantidade de itens é maior que 0
            {
                erros.Add((new ValidationError("Quantidade", "A quantidade deve ser um número inteiro maior que zero.")));
            }

            // Valida cada item da compra
            foreach (var item in compraItems)
            {
                // Verifica se a quantidade do item de cada compra é menor ou igual a zero
                if (item.Qtd <= 0)
                {
                    erros.Add(new ValidationError("Quantidade", $"A quantidade do item '{item.NomeInsumo}' deve ser um número inteiro maior que zero."));
                }
            }

            /* Métodos de referência da classe TelaCadastrarCompra:
               - TextBoxQuantidade_Validating
               - TextBoxValorUnitario_Validating
             */

        }

    }
}
