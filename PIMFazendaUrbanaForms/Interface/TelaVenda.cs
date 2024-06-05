using PIMFazendaUrbanaLib;
using System.Text;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaVenda : Form
    {
        EstoqueProdutoService estoqueProdutoService;
        VendaService vendaService;

        public TelaVenda()
        {
            InitializeComponent();
            estoqueProdutoService = new EstoqueProdutoService();
            vendaService = new VendaService();

            // Formatação do DataGridViewListaInsumos:
            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewListaProdutos.AutoGenerateColumns = false;
            // Adicionar manualmente as colunas necessárias
            DataGridViewListaProdutos.Columns.Add("IDColumn", "ID");
            DataGridViewListaProdutos.Columns.Add("NomeColumn", "Produto");
            DataGridViewListaProdutos.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewListaProdutos.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewListaProdutos.Columns.Add("UnidQtdColumn", "Unidade");
            DataGridViewListaProdutos.Columns.Add("DataEntradaColumn", "Data de Entrada");
            DataGridViewListaProdutos.Columns.Add("IdProducaoColumn", "ID da Produção");
            //DataGridViewListaProdutos.Columns.Add("DataProducaoColumn", "Data do plantio");
            // Configurar as propriedades DataPropertyName das colunas  
            DataGridViewListaProdutos.Columns["IDColumn"].DataPropertyName = "Id";
            DataGridViewListaProdutos.Columns["NomeColumn"].DataPropertyName = "VariedadeCultivo";
            DataGridViewListaProdutos.Columns["CategoriaColumn"].DataPropertyName = "CategoriaCultivo";
            DataGridViewListaProdutos.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewListaProdutos.Columns["UnidQtdColumn"].DataPropertyName = "Unidqtd";
            DataGridViewListaProdutos.Columns["DataEntradaColumn"].DataPropertyName = "DataEntrada";
            DataGridViewListaProdutos.Columns["IdProducaoColumn"].DataPropertyName = "IdProducao";
            //DataGridViewListaProdutos.Columns["DataProducaoColumn"].DataPropertyName = "DataProducao";
            /*
            foreach (DataGridViewColumn column in DataGridViewListaInsumos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */
            // Definir o tamanho padrão das colunas
            DataGridViewListaProdutos.Columns["IDColumn"].Width = 40;
            DataGridViewListaProdutos.Columns["NomeColumn"].Width = 150;
            DataGridViewListaProdutos.Columns["CategoriaColumn"].Width = 85;
            DataGridViewListaProdutos.Columns["QtdColumn"].Width = 95;
            DataGridViewListaProdutos.Columns["UnidQtdColumn"].Width = 75;
            DataGridViewListaProdutos.Columns["DataEntradaColumn"].Width = 90;
            DataGridViewListaProdutos.Columns["IdProducaoColumn"].Width = 80;
            //DataGridViewListaProdutos.Columns["DataProducaoColumn"].Width = 90;
            DataGridViewListaProdutos.Columns["NomeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // ------------------------------------------------------------------------------------------------

            /*
            // Formatação do DataGridViewRegistroDeCompras:
            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewRegistroDeVendas.AutoGenerateColumns = false;
            // Adicionar manualmente as colunas necessárias
            DataGridViewRegistroDeVendas.Columns.Add("NomeProdutoColumn", "Produto");
            DataGridViewRegistroDeVendas.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewRegistroDeVendas.Columns.Add("UnidQtdColumn", "Unidade");
            DataGridViewRegistroDeVendas.Columns.Add("ValorColumn", "Valor");
            DataGridViewRegistroDeVendas.Columns.Add("DataColumn", "Data");
            DataGridViewRegistroDeVendas.Columns.Add("NomeClienteColumn", "Cliente");
            DataGridViewRegistroDeVendas.Columns.Add("IdPedidoVendaColumn", "ID do Pedido");
            // Configurar as propriedades DataPropertyName das colunas
            DataGridViewRegistroDeVendas.Columns["NomeInsumoColumn"].DataPropertyName = "NomeProduto";
            DataGridViewRegistroDeVendas.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewRegistroDeVendas.Columns["UnidQtdColumn"].DataPropertyName = "UnidQtd";
            DataGridViewRegistroDeVendas.Columns["ValorColumn"].DataPropertyName = "Valor";
            DataGridViewRegistroDeVendas.Columns["DataColumn"].DataPropertyName = "Data";
            DataGridViewRegistroDeVendas.Columns["NomeClienteColumn"].DataPropertyName = "NomeCliente";
            DataGridViewRegistroDeVendas.Columns["IdPedidoVendaColumn"].DataPropertyName = "IdPedidoVenda";
            // Configurar o modo de redimensionamento das colunas
            /*
            foreach (DataGridViewColumn column in DataGridViewRegistroDeVendas.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */
            // Definir o tamanho padrão das colunas
            /*
            DataGridViewRegistroDeVendas.Columns["NomeInsumoColumn"].Width = 180;
            DataGridViewRegistroDeVendas.Columns["QtdColumn"].Width = 95;
            DataGridViewRegistroDeVendas.Columns["UnidQtdColumn"].Width = 75;
            DataGridViewRegistroDeVendas.Columns["ValorColumn"].Width = 75;
            DataGridViewRegistroDeVendas.Columns["DataColumn"].Width = 130;
            DataGridViewRegistroDeVendas.Columns["NomeFornecedorColumn"].Width = 280;
            DataGridViewRegistroDeVendas.Columns["IdPedidoCompraColumn"].Width = 65;
            DataGridViewRegistroDeVendas.Columns["NomeInsumoColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            */
        }

        private void TelaVenda_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        private void AtualizarDataGridView()
        {
            try
            {
                CarregarProdutos();
                MessageBox.Show("Lista de produtos atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                CarregarRegistroDeVendas();
                MessageBox.Show("Lista de vendas atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProdutos()
        {
            try
            {
                DataGridViewListaProdutos.DataSource = null; // Limpa a DataSource do DataGridView

                List<EstoqueProduto> produtos = estoqueProdutoService.ListarEstoqueProdutoAtivos();

                if (produtos != null && produtos.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = produtos.Select(p => new
                    {
                        p.Id,
                        p.VariedadeCultivo,
                        p.CategoriaCultivo,
                        p.Qtd,
                        p.Unidqtd,
                        DataEntrada = p.DataEntrada.ToShortDateString(), // Para exibir apenas a data
                        p.IdProducao,
                        //DataProducao = p.DataProducao.ToShortDateString() // Para exibir apenas a data
                    }).ToList();

                    DataGridViewListaProdutos.DataSource = data; // Preencher o DataGridView com os dados formatados
                }
                else
                {
                    MessageBox.Show("Nenhum produto em estoque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarRegistroDeVendas()
        {
            /*
            try
            {
                DataGridViewRegistroDeVendas.DataSource = null; // Limpa a DataSource do DataGridView

                List<PedidoVendaItem> vendaItens = vendaService.ListarRegistrosDeVenda();

                if (vendaItens != null && vendaItens.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = vendaItens.Select(i => new
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

                    DataGridViewRegistroDeVendas.DataSource = data; // Preencher o DataGridView com os dados formatados
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
            */
        }

        private void TextBoxPesquisar_TextChanged(object sender, EventArgs e)
        {
            string produtoNome = TextBoxPesquisar.Text;
            List<EstoqueProduto> produtos = estoqueProdutoService.FiltrarProdutosNome(produtoNome);

            if (produtos != null && produtos.Count > 0)
            {
                // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                var data = produtos.Select(p => new
                {
                    p.Id,
                    p.VariedadeCultivo,
                    p.CategoriaCultivo,
                    p.Qtd,
                    p.Unidqtd,
                    DataEntrada = p.DataEntrada.ToShortDateString(), // Para exibir apenas a data
                    p.IdProducao,
                    //DataProducao = p.DataProducao.ToShortDateString() // Para exibir apenas a data
                }).ToList();

                DataGridViewListaProdutos.DataSource = data; // Preencher o DataGridView com os dados formatados
            }
            else
            {
                DataGridViewListaProdutos.DataSource = null;
            }

        }

        private void TextBoxProdutosComprados_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            TelaCadastrarVenda telaCadastrarVenda = new TelaCadastrarVenda();
            telaCadastrarVenda.Show();
            //telaCadastrarVenda.VendaCadastradaSucesso += TelaCadastrarVenda_VendaCadastradaSucesso;
        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        private void PictureBoxRelatorio_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Salvar Relatório de Estoque Produtos";
            saveFileDialog.FileName = "Estoque_de_produtos_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(DataGridViewListaProdutos, saveFileDialog.FileName);
            }
        }

        private void PictureBoxRelatorio2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Salvar Relatório de Venda de Produtos";
            saveFileDialog.FileName = "Venda_de_produtos_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(DataGridViewRegistroDeVendas, saveFileDialog.FileName);
            }
        }

        private void ExportToCSV(DataGridView dataGridView, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    // Escreve os cabeçalhos das colunas
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        writer.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();

                    // Escreve os dados das células
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            // Obter o valor da célula e converter para string
                            string cellValue = Convert.ToString(row.Cells[i].Value);

                            // Substituir ponto e vírgula por vírgula, para evitar conflito com o delimitador
                            cellValue = cellValue.Replace(";", ",");

                            // Escrever o valor da célula
                            writer.Write(cellValue);

                            if (i < dataGridView.Columns.Count - 1)
                            {
                                writer.Write(";");
                            }
                        }
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Dados exportados com sucesso para " + fileName, "Relatório Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
