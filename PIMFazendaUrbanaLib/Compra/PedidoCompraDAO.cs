using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace PIMFazendaUrbanaLib
{
    public class PedidoCompraDAO
    {
        private string connectionString;

        public PedidoCompraDAO()
        {
            this.connectionString = ConnectionString.GetConnectionString();
        }

        // Método para cadastrar um novo pedido de compra
        public void CadastrarPedidoCompra(PedidoCompra pedidoCompra)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertPedidoQuery = @"INSERT INTO pedidocompra (data_pedidocompra, id_fornecedor) 
                                                     VALUES (@dataPedidoCompra, @idFornecedor)";
                        using (MySqlCommand insertPedidoCommand = new MySqlCommand(insertPedidoQuery, connection, transaction))
                        {
                            insertPedidoCommand.Parameters.AddWithValue("@dataPedidoCompra", pedidoCompra.DataPedidoCompra);
                            insertPedidoCommand.Parameters.AddWithValue("@idFornecedor", pedidoCompra.IdFornecedor);
                            insertPedidoCommand.ExecuteNonQuery();
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

        // Método para alterar um pedido de compra existente
        public void AlterarPedidoCompra(PedidoCompra pedidoCompra)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updatePedidoQuery = @"UPDATE pedidocompra SET 
                                                     data_pedidocompra = @dataPedidoCompra,
                                                     id_fornecedor = @idFornecedor
                                                     WHERE id_pedidocompra = @idPedidoCompra";
                        using (MySqlCommand updatePedidoCommand = new MySqlCommand(updatePedidoQuery, connection, transaction))
                        {
                            updatePedidoCommand.Parameters.AddWithValue("@dataPedidoCompra", pedidoCompra.DataPedidoCompra);
                            updatePedidoCommand.Parameters.AddWithValue("@idFornecedor", pedidoCompra.IdFornecedor);
                            updatePedidoCommand.Parameters.AddWithValue("@idPedidoCompra", pedidoCompra.IdPedidoCompra);
                            updatePedidoCommand.ExecuteNonQuery();
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

        // Método para excluir (desativar) um pedido de compra
        public void ExcluirPedidoCompra(int idPedidoCompra)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deletePedidoQuery = "DELETE FROM pedidocompra WHERE id_pedidocompra = @idPedidoCompra";
                        using (MySqlCommand deletePedidoCommand = new MySqlCommand(deletePedidoQuery, connection, transaction))
                        {
                            deletePedidoCommand.Parameters.AddWithValue("@idPedidoCompra", idPedidoCompra);
                            deletePedidoCommand.ExecuteNonQuery();
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

        // Método para listar todos os pedidos de compra
        public List<PedidoCompra> ListarPedidosCompra()
        {
            List<PedidoCompra> pedidosCompra = new List<PedidoCompra>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_pedidocompra, data_pedidocompra, id_fornecedor FROM pedidocompra";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PedidoCompra pedidoCompra = new PedidoCompra
                            {
                                IdPedidoCompra = reader.GetInt32("id_pedidocompra"),
                                DataPedidoCompra = reader.GetDateTime("data_pedidocompra"),
                                IdFornecedor = reader.GetInt32("id_fornecedor")
                            };
                            pedidosCompra.Add(pedidoCompra);
                        }
                    }
                }
            }
            return pedidosCompra;
        }

        // Método para consultar um pedido de compra pelo ID
        public PedidoCompra ConsultarPedidoCompra(int idPedidoCompra)
        {
            PedidoCompra pedidoCompra = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT id_pedidocompra, data_pedidocompra, id_fornecedor FROM pedidocompra WHERE id_pedidocompra = @idPedidoCompra";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPedidoCompra", idPedidoCompra);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedidoCompra = new PedidoCompra
                        {
                            IdPedidoCompra = reader.GetInt32("id_pedidocompra"),
                            DataPedidoCompra = reader.GetDateTime("data_pedidocompra"),
                            IdFornecedor = reader.GetInt32("id_fornecedor")
                        };
                    }
                }
            }
            return pedidoCompra;
        }

        // Método para obter o ID do último pedido de compra cadastrado
        public int ObterUltimoIdPedidoCompra()
        {
            int idPedidoCompra = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(id_pedidocompra) FROM pedidocompra";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idPedidoCompra = reader.GetInt32(0);
                        }
                    }
                }
            }
            return idPedidoCompra;
        }
    }
}
