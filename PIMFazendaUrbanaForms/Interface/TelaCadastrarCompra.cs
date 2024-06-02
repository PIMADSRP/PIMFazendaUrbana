using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaCadastrarCompra : Form
    {
        private FornecedorService fornecedorService;
        private InsumoService insumoService;
        private PedidoCompraService pedidoCompraService;
        private CompraItemService compraItemService;
        private List<Fornecedor> fornecedores;
        private List<Insumo> insumos;
        private decimal valorUnitario; // Valor unitário do insumo selecionado
        Insumo insumo = new Insumo();
        public event EventHandler CompraCadastradaSucesso;

        public TelaCadastrarCompra()
        {
            InitializeComponent();
            fornecedorService = new FornecedorService();
            insumoService = new InsumoService();
            pedidoCompraService = new PedidoCompraService();
            compraItemService = new CompraItemService(new CompraItemDAO());
        }

        private void TelaCadastrarCompra_Load(object sender, EventArgs e)
        {
            // Carregar todos os fornecedores no ComboBox quando o formulário é carregado
            fornecedores = fornecedorService.ListarFornecedoresAtivos();
            insumos = insumoService.ListarInsumosAtivos();

            if (fornecedores != null && fornecedores.Count > 0)
            {
                // Limpar a ComboBox antes de adicionar novos itens
                ComboBoxFornecedor.Items.Clear();

                // Adicionar cada fornecedor na ComboBox
                foreach (var fornecedor in fornecedores)
                {
                    ComboBoxFornecedor.Items.Add(fornecedor.Nome);
                }
            }

            if (insumos != null && insumos.Count > 0)
            {
                // Limpar a ComboBox antes de adicionar novos itens
                ComboBoxProduto.Items.Clear();

                // Adicionar cada insumo na ComboBox
                foreach (var insumo in insumos)
                {
                    ComboBoxProduto.Items.Add(insumo.Nome);
                }
            }
        }

        private void TextBoxQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TextBoxQuantidade.Text, out decimal quantidadeDecimal))
            {
                // Calcular o valor total
                decimal valorTotal = quantidadeDecimal * valorUnitario;

                // Atualizar o campo textBoxValorTotal
                TextBoxValorTotal.Text = valorTotal.ToString("C");

            }
            else
            {
                // Limpar o campo textBoxValorTotal se a quantidade não for um número válido
                TextBoxValorTotal.Text = string.Empty;
            }
        }

        private void TextBoxValorUnitario_TextChanged(object sender, EventArgs e)
        {
            // Lógica para multiplicar a quantidade pelo valor digitado e exibir o resultado na textBoxValorTotal
            if (decimal.TryParse(TextBoxQuantidade.Text, out decimal quantidadeDecimal) && decimal.TryParse(TextBoxValor.Text, out decimal valor))
            {
                decimal valorTotal = quantidadeDecimal * valor;
                TextBoxValorTotal.Text = valorTotal.ToString("C");
            }
            else
            {
                TextBoxValorTotal.Text = string.Empty;
            }
        }

        private void TextBoxValorTotal_TextChanged(object sender, EventArgs e)
        {
            // Adicione lógica aqui, se necessário
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            bool quantidadeValida = false;
            bool valorunitarioValido = false;
            bool fornecedorValido = false;
            bool insumoValido = false;

            /*
            // Validar se todos os campos obrigatórios estão preenchidos
            if (ComboBoxFornecedor.SelectedIndex == -1 || ComboBoxProduto.SelectedIndex == -1 || !decimal.TryParse(TextBoxQuantidade.Text, out decimal quantidade) ||
                quantidade <= 0)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            // Obter o fornecedor e insumo selecionados
            string fornecedorSelecionado = ComboBoxFornecedor.SelectedItem.ToString();
            if (fornecedorSelecionado == null)
            {
                TextBoxQuantidade.ForeColor = Color.Red;
                fornecedorValido = false;
                MessageBox.Show("Fornecedor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TextBoxQuantidade.ForeColor = Color.Black;
                fornecedorValido = true;
            }

            string insumoSelecionado = ComboBoxProduto.SelectedItem.ToString();
            if (insumoSelecionado == null)
            {
                TextBoxQuantidade.ForeColor = Color.Red;
                insumoValido = false;
                MessageBox.Show("Insumo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TextBoxQuantidade.ForeColor = Color.Black;
                insumoValido = true;
            }

            string quantidadeDigitada = TextBoxQuantidade.Text;
            int quantidade = 0;

            // Verifica se a quantidade é válida
            if (quantidadeDigitada == null || !int.TryParse(quantidadeDigitada, out quantidade) || quantidade <= 0)
            {
                TextBoxQuantidade.ForeColor = Color.Red;
                MessageBox.Show("A quantidade deve ser um número inteiro maior que zero.", "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxQuantidade;
                quantidadeValida = false;
            }
            else if (quantidade > insumo.Qtd)
            {
                TextBoxQuantidade.ForeColor = Color.Red;
                MessageBox.Show("A quantidade de saída deve ser menor ou igual a quantidade atual no estoque.", "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxQuantidade;
                quantidadeValida = false;
            }
            else
            {
                TextBoxQuantidade.ForeColor = Color.Black;
                quantidadeValida = true;
            }

            string valorUnitarioDigitado = TextBoxValor.Text;
            if (valorUnitarioDigitado == null || !decimal.TryParse(valorUnitarioDigitado, out valorUnitario) || valorUnitario <= 0)
            {
                TextBoxValor.ForeColor = Color.Red;
                MessageBox.Show("O valor unitário deve ser um número decimal maior que zero.", "Valor Unitário Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxValor;
                valorunitarioValido = false;
            }
            else
            {
                TextBoxValor.ForeColor = Color.Black;
                valorunitarioValido = true;
            }

            // Se todas as validações passarem, pode prosseguir com a ação do botão Confirmar
            if (quantidadeValida || valorunitarioValido || fornecedorValido || insumoValido)
            {
                /*
                // Cadastrar o PedidoCompra e obter o ID gerado
                try
                {
                    pedidoCompraService.CadastrarPedidoCompra(pedidoCompra);
                }
                catch
                {
                    MessageBox.Show("Erro ao cadastrar o pedido de compra.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int idPedidoCompra = pedidoCompra.IdPedidoCompra;
                */


                int idPedidoCompra = 0;
                // Obter o último ID de PedidoCompra cadastrado
                try
                {
                    idPedidoCompra = pedidoCompraService.ObterUltimoIdPedidoCompra();
                    if (idPedidoCompra == 0 || idPedidoCompra == null)
                    {
                        idPedidoCompra = 1;
                    }
                    else
                    {
                        idPedidoCompra++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar um objeto CompraItem
                CompraItem compraItem = new CompraItem
                {
                    QtdCompraItem = quantidade,
                    UnidQtdCompraItem = TextBoxUnidade.Text,
                    ValorCompraItem = valorUnitario,
                    IdPedidoCompra = idPedidoCompra,
                    IdInsumo = insumo.Id
                };

                // Cadastrar a compra
                try
                {
                    // Criar um objeto PedidoCompra
                    PedidoCompra pedidoCompra = new PedidoCompra
                    {
                        DataPedidoCompra = DateTime.Now,
                        IdFornecedor = fornecedorService.ConsultarFornecedorNome(fornecedorSelecionado).ID
                    };

                    pedidoCompraService.CadastrarPedidoCompra(pedidoCompra);

                    compraItemService.CadastrarCompraItem(compraItem);



                    MessageBox.Show("Compra cadastrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CompraCadastradaSucesso?.Invoke(this, EventArgs.Empty); // Disparar o evento
                    this.Close(); // Fecha o formulário após a confirmação bem-sucedida
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void TextBoxUnidade_TextChanged(object sender, EventArgs e)
        {
            // Lógica para filtrar insumos pela unidade (unidqtd_insumo)
            string unidade = TextBoxUnidade.Text;
            if (!string.IsNullOrEmpty(unidade))
            {
                var insumosFiltrados = insumoService.FiltrarInsumosPorUnidade(unidade);
                // Exibir ou utilizar os insumos filtrados conforme necessário
                // Por exemplo, exibir os nomes dos insumos filtrados em uma mensagem
                string insumosNomes = string.Join(", ", insumosFiltrados.Select(i => i.Nome));
                MessageBox.Show($"Insumos filtrados: {insumosNomes}", "Insumos Filtrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
