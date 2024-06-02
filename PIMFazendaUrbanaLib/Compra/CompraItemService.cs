using System.Collections.Generic;

namespace PIMFazendaUrbanaLib
{
    public class CompraItemService
    {
        private readonly CompraItemDAO _compraItemDAO;

        public CompraItemService(CompraItemDAO compraItemDAO)
        {
            _compraItemDAO = compraItemDAO;
        }

        // Método para cadastrar um novo item de compra
        public bool CadastrarCompraItem(CompraItem compraItem)
        {
            try
            {
                _compraItemDAO.CadastrarCompraItem(compraItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para alterar um item de compra existente
        public bool AlterarCompraItem(CompraItem compraItem)
        {
            try
            {
                _compraItemDAO.AlterarCompraItem(compraItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para excluir um item de compra
        public bool ExcluirCompraItem(int idCompraItem)
        {
            try
            {
                _compraItemDAO.ExcluirCompraItem(idCompraItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para listar todos os itens de compra
        public List<CompraItem> ListarCompraItens()
        {
            try
            {
                return _compraItemDAO.ListarCompraItens();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar itens de compra.", ex);
            }
        }

        // Método para consultar um item de compra pelo ID
        public CompraItem ConsultarCompraItem(int idCompraItem)
        {
            try
            {
                return _compraItemDAO.ConsultarCompraItem(idCompraItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar item de compra.", ex);
            }
        }
    }
}
