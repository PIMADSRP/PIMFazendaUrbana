using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMFazendaUrbanaLib
{
    public class CompraItem
    {
        public int IdCompraItem { get; set; }
        public int QtdCompraItem { get; set; }
        public string UnidQtdCompraItem { get; set; }
        public decimal ValorCompraItem { get; set; }
        public int IdPedidoCompra { get; set; }
        public int IdInsumo { get; set; }

        public CompraItem() { }

        public CompraItem(int idCompraItem, int qtdCompraItem, string unidQtdCompraItem, decimal valorCompraItem, int idPedidoCompra, int idInsumo)
        {
            IdCompraItem = idCompraItem;
            QtdCompraItem = qtdCompraItem;
            UnidQtdCompraItem = unidQtdCompraItem;
            ValorCompraItem = valorCompraItem;
            IdPedidoCompra = idPedidoCompra;
            IdInsumo = idInsumo;
        }

        public override string ToString()
        {
            return $"ID: {IdCompraItem}, Quantidade: {QtdCompraItem} {UnidQtdCompraItem}, Valor: {ValorCompraItem}, Pedido: {IdPedidoCompra}, Insumo: {IdInsumo}";
        }
    }
}

