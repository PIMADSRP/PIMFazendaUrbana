using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PIMFazendaUrbanaLib
{
    public class CompraItemDAO
    {
        private readonly string connectionString;

        public CompraItemDAO()
        {
            connectionString = ConnectionString.GetConnectionString();
        }

        // Método para cadastrar um novo item de compra
        public void CadastrarCompraItem(CompraItem compraItem)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertItemQuery = @"INSERT INTO compraitem (qtd_compraitem, unidqtd_compraitem, valor_compraitem, id_pedidocompra, id_insumo) 
                                                   VALUES (@qtdCompraItem, @unidQtdCompraItem, @valorCompraItem, @idPedidoCompra, @idInsumo)";
                        using (MySqlCommand insertItemCommand = new MySqlCommand(insertItemQuery, connection, transaction))
                        {
                            insertItemCommand.Parameters.AddWithValue("@qtdCompraItem", compraItem.QtdCompraItem);
                            insertItemCommand.Parameters.AddWithValue("@unidQtdCompraItem", compraItem.UnidQtdCompraItem);
                            insertItemCommand.Parameters.AddWithValue("@valorCompraItem", compraItem.ValorCompraItem);
                            insertItemCommand.Parameters.AddWithValue("@idPedidoCompra", compraItem.IdPedidoCompra);
                            insertItemCommand.Parameters.AddWithValue("@idInsumo", compraItem.IdInsumo);
                            insertItemCommand.ExecuteNonQuery();
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

        // Método para alterar um item de compra existente
        public void AlterarCompraItem(CompraItem compraItem)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateItemQuery = @"UPDATE compraitem SET 
                                                   qtd_compraitem = @qtdCompraItem,
                                                   unidqtd_compraitem = @unidQtdCompraItem,
                                                   valor_compraitem = @valorCompraItem,
                                                   id_pedidocompra = @idPedidoCompra,
                                                   id_insumo = @idInsumo
                                                   WHERE id_compraitem = @idCompraItem";
                        using (MySqlCommand updateItemCommand = new MySqlCommand(updateItemQuery, connection, transaction))
                        {
                            updateItemCommand.Parameters.AddWithValue("@qtdCompraItem", compraItem.QtdCompraItem);
                            updateItemCommand.Parameters.AddWithValue("@unidQtdCompraItem", compraItem.UnidQtdCompraItem);
                            updateItemCommand.Parameters.AddWithValue("@valorCompraItem", compraItem.ValorCompraItem);
                            updateItemCommand.Parameters.AddWithValue("@idPedidoCompra", compraItem.IdPedidoCompra);
                            updateItemCommand.Parameters.AddWithValue("@idInsumo", compraItem.IdInsumo);
                            updateItemCommand.Parameters.AddWithValue("@idCompraItem", compraItem.IdCompraItem);
                            updateItemCommand.ExecuteNonQuery();
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

        // Método para excluir um item de compra
        public void ExcluirCompraItem(int idCompraItem)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteItemQuery = "DELETE FROM compraitem WHERE id_compraitem = @idCompraItem";
                        using (MySqlCommand deleteItemCommand = new MySqlCommand(deleteItemQuery, connection, transaction))
                        {
                            deleteItemCommand.Parameters.AddWithValue("@idCompraItem", idCompraItem);
                            deleteItemCommand.ExecuteNonQuery();
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

        // Método para listar todos os itens de compra
        public List<CompraItem> ListarCompraItens()
        {
            List<CompraItem> compraItens = new List<CompraItem>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_compraitem, qtd_compraitem, unidqtd_compraitem, valor_compraitem, id_pedidocompra, id_insumo FROM compraitem";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompraItem compraItem = new CompraItem
                            {
                                IdCompraItem = reader.GetInt32("id_compraitem"),
                                QtdCompraItem = reader.GetInt32("qtd_compraitem"),
                                UnidQtdCompraItem = reader.GetString("unidqtd_compraitem"),
                                ValorCompraItem = reader.GetDecimal("valor_compraitem"),
                                IdPedidoCompra = reader.GetInt32("id_pedidocompra"),
                                IdInsumo = reader.GetInt32("id_insumo")
                            };
                            compraItens.Add(compraItem);
                        }
                    }
                }
            }
            return compraItens;
        }

        // Método para consultar um item de compra pelo ID
        public CompraItem ConsultarCompraItem(int idCompraItem)
        {
            CompraItem compraItem = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id_compraitem, qtd_compraitem, unidqtd_compraitem, valor_compraitem, id_pedidocompra, id_insumo FROM compraitem WHERE id_compraitem = @idCompraItem";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCompraItem", idCompraItem);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        compraItem = new CompraItem
                        {
                            IdCompraItem = reader.GetInt32("id_compraitem"),
                            QtdCompraItem = reader.GetInt32("qtd_compraitem"),
                            UnidQtdCompraItem = reader.GetString("unidqtd_compraitem"),
                            ValorCompraItem = reader.GetDecimal("valor_compraitem"),
                            IdPedidoCompra = reader.GetInt32("id_pedidocompra"),
                            IdInsumo = reader.GetInt32("id_insumo")
                        };
                    }
                }
            }
            return compraItem;
        }
    }
}
