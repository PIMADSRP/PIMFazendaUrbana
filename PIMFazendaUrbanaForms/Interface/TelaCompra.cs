using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaCompra : Form
    {
        InsumoService insumoService;
        CompraService compraService;

        public TelaCompra()
        {
            InitializeComponent();
            insumoService = new InsumoService();
            compraService = new CompraService();

            // Formatação do DataGridViewListaInsumos:
            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewListaInsumos.AutoGenerateColumns = false;
            // Adicionar manualmente as colunas necessárias
            DataGridViewListaInsumos.Columns.Add("IDColumn", "ID");
            DataGridViewListaInsumos.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaInsumos.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewListaInsumos.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewListaInsumos.Columns.Add("UnidQtdColumn", "Unidade");
            // Configurar as propriedades DataPropertyName das colunas  
            DataGridViewListaInsumos.Columns["IDColumn"].DataPropertyName = "Id";
            DataGridViewListaInsumos.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaInsumos.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            DataGridViewListaInsumos.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewListaInsumos.Columns["UnidQtdColumn"].DataPropertyName = "Unidqtd";
            /*
            foreach (DataGridViewColumn column in DataGridViewListaInsumos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */
            // Definir o tamanho padrão das colunas
            DataGridViewListaInsumos.Columns["IDColumn"].Width = 40;
            DataGridViewListaInsumos.Columns["NomeColumn"].Width = 200;
            DataGridViewListaInsumos.Columns["CategoriaColumn"].Width = 100;
            DataGridViewListaInsumos.Columns["QtdColumn"].Width = 95;
            DataGridViewListaInsumos.Columns["UnidQtdColumn"].Width = 75;
            DataGridViewListaInsumos.Columns["NomeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // ------------------------------------------------------------------------------------------------

            // Formatação do DataGridViewRegistroDeCompras:
            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewRegistroDeCompras.AutoGenerateColumns = false;
            // Adicionar manualmente as colunas necessárias
            DataGridViewRegistroDeCompras.Columns.Add("NomeInsumoColumn", "Insumo");
            DataGridViewRegistroDeCompras.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewRegistroDeCompras.Columns.Add("UnidQtdColumn", "Unidade");
            DataGridViewRegistroDeCompras.Columns.Add("ValorColumn", "Valor");
            DataGridViewRegistroDeCompras.Columns.Add("DataColumn", "Data");
            DataGridViewRegistroDeCompras.Columns.Add("NomeFornecedorColumn", "Fornecedor");
            DataGridViewRegistroDeCompras.Columns.Add("IdPedidoCompraColumn", "ID do Pedido");
            // Configurar as propriedades DataPropertyName das colunas
            DataGridViewRegistroDeCompras.Columns["NomeInsumoColumn"].DataPropertyName = "NomeInsumo";
            DataGridViewRegistroDeCompras.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewRegistroDeCompras.Columns["UnidQtdColumn"].DataPropertyName = "UnidQtd";
            DataGridViewRegistroDeCompras.Columns["ValorColumn"].DataPropertyName = "Valor";
            DataGridViewRegistroDeCompras.Columns["DataColumn"].DataPropertyName = "Data";
            DataGridViewRegistroDeCompras.Columns["NomeFornecedorColumn"].DataPropertyName = "NomeFornecedor";
            DataGridViewRegistroDeCompras.Columns["IdPedidoCompraColumn"].DataPropertyName = "IdPedidoCompra";
            // Configurar o modo de redimensionamento das colunas
            /*
            foreach (DataGridViewColumn column in DataGridViewRegistroDeCompras.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */
            // Definir o tamanho padrão das colunas
            DataGridViewRegistroDeCompras.Columns["NomeInsumoColumn"].Width = 180;
            DataGridViewRegistroDeCompras.Columns["QtdColumn"].Width = 95;
            DataGridViewRegistroDeCompras.Columns["UnidQtdColumn"].Width = 75;
            DataGridViewRegistroDeCompras.Columns["ValorColumn"].Width = 75;
            DataGridViewRegistroDeCompras.Columns["DataColumn"].Width = 130;
            DataGridViewRegistroDeCompras.Columns["NomeFornecedorColumn"].Width = 280;
            DataGridViewRegistroDeCompras.Columns["IdPedidoCompraColumn"].Width = 65;
            DataGridViewRegistroDeCompras.Columns["NomeInsumoColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void TelaCompra_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        private void AtualizarDataGridView()
        {
            try
            {
                CarregarInsumos();
                MessageBox.Show("Lista de insumos atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                CarregarRegistroDeCompras();
                MessageBox.Show("Lista de compras atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarInsumos()
        {
            try
            {
                DataGridViewListaInsumos.DataSource = null; // Limpa a DataSource do DataGridView

                List<Insumo> insumos = insumoService.ListarInsumosAtivos();

                if (insumos != null && insumos.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = insumos.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.Categoria,
                        i.Qtd,
                        i.Unidqtd
                    }).ToList();

                    DataGridViewListaInsumos.DataSource = data; // Preencher o DataGridView com os dados formatados
                }
                else
                {
                    MessageBox.Show("Nenhum insumo em estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarRegistroDeCompras()
        {
            try
            {
                DataGridViewRegistroDeCompras.DataSource = null; // Limpa a DataSource do DataGridView

                List<PedidoCompraItem> compraItens = compraService.ListarRegistrosDeCompra();

                if (compraItens != null && compraItens.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = compraItens.Select(i => new
                    {
                        i.NomeInsumo,
                        i.Qtd,
                        i.UnidQtd,
                        Valor = "R$ " + i.Valor.ToString("N2"), // Formatar o valor como "R$ valor,centavos"
                        // Data = i.Data.ToShortDateString(), // Para exibir apenas a data
                        i.Data, // Para exibir a data e a hora
                        i.NomeFornecedor,
                        i.IdPedidoCompra
                    }).ToList();

                    DataGridViewRegistroDeCompras.DataSource = data; // Preencher o DataGridView com os dados formatados
                }
                else
                {
                    MessageBox.Show("Nenhum registro de compra encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxPesquisar_TextChanged(object sender, EventArgs e)
        {
            string insumoNome = TextBoxPesquisar.Text;
            List<Insumo> insumos = insumoService.FiltrarInsumosNome(insumoNome);

            if (insumos != null && insumos.Count > 0)
            {
                var data = insumos.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.Categoria,
                    i.Qtd,
                    i.Unidqtd
                }).ToList();

                DataGridViewListaInsumos.DataSource = data;
            }
            else
            {
                DataGridViewListaInsumos.DataSource = null;
            }
        }

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            TelaCadastrarCompra telaCadastrarCompra = new TelaCadastrarCompra();
            telaCadastrarCompra.Show();
        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }
    }
}
