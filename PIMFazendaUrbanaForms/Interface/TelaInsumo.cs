using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaInsumo : Form
    {
        InsumoService insumoService;

        public TelaInsumo()
        {
            InitializeComponent();

            insumoService = new InsumoService();

            this.Load += new EventHandler(PictureBoxAtualizar_Click);

            // Configurar o DataGridView para estoque de insumos
            DataGridViewListaInsumos.AutoGenerateColumns = false;

            DataGridViewListaInsumos.Columns.Add("IDColumn", "ID");
            DataGridViewListaInsumos.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaInsumos.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewListaInsumos.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewListaInsumos.Columns.Add("UnidQtdColumn", "Unidade");

            DataGridViewListaInsumos.Columns["IDColumn"].DataPropertyName = "Id";
            DataGridViewListaInsumos.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaInsumos.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            DataGridViewListaInsumos.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewListaInsumos.Columns["UnidQtdColumn"].DataPropertyName = "Unidqtd";

            foreach (DataGridViewColumn column in DataGridViewListaInsumos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            // Deixar a coluna nome com tamanho fixo
            DataGridViewListaInsumos.Columns["NomeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //----------------------------------------------------------------------------------------
            // Configurar o DataGridView para registro de saída de insumos
            DataGridViewSaidaInsumos.AutoGenerateColumns = false;

            DataGridViewSaidaInsumos.Columns.Add("IDColumn", "ID");
            DataGridViewSaidaInsumos.Columns.Add("NomeColumn", "Nome");
            DataGridViewSaidaInsumos.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewSaidaInsumos.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewSaidaInsumos.Columns.Add("UnidQtdColumn", "Unidade");
            DataGridViewSaidaInsumos.Columns.Add("DataColumn", "Data");

            DataGridViewSaidaInsumos.Columns["IDColumn"].DataPropertyName = "IdInsumo";
            DataGridViewSaidaInsumos.Columns["NomeColumn"].DataPropertyName = "NomeInsumo";
            DataGridViewSaidaInsumos.Columns["CategoriaColumn"].DataPropertyName = "CategoriaInsumo";
            DataGridViewSaidaInsumos.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewSaidaInsumos.Columns["UnidQtdColumn"].DataPropertyName = "Unidqtd";
            DataGridViewSaidaInsumos.Columns["DataColumn"].DataPropertyName = "Data";

            foreach (DataGridViewColumn column in DataGridViewSaidaInsumos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            // Deixar a coluna nome com tamanho fixo
            DataGridViewSaidaInsumos.Columns["NomeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                    MessageBox.Show("Nenhum insumo encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar insumos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarSaidaInsumos()
        {
            try
            {
                DataGridViewSaidaInsumos.DataSource = null; // Limpa a DataSource do DataGridView

                List<SaidaInsumo> saidainsumos = insumoService.ListarSaidaInsumos();

                if (saidainsumos != null && saidainsumos.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = saidainsumos.Select(si => new
                    {
                        si.IdInsumo,
                        si.NomeInsumo,
                        si.CategoriaInsumo,
                        si.Qtd,
                        si.Unidqtd,
                        si.Data
                    }).ToList();

                    DataGridViewSaidaInsumos.DataSource = data; // Preencher o DataGridView com os dados formatados
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar registros de saída de insumos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TelaCadastrarSaidaInsumo_SaidaInsumoCadastradoSucesso(object sender, EventArgs e)
        {
            CarregarSaidaInsumos();
            CarregarInsumos();
        }

        private void TelaCadastrarInsumo_InsumoCadastradoSucesso(object sender, EventArgs e)
        {
            CarregarInsumos();
        }

        private void TelaEditarInsumo_InsumoEditadoSucesso(object sender, EventArgs e)
        {
            CarregarInsumos();
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarInsumos();
                CarregarSaidaInsumos();
                MessageBox.Show("Lista de insumos atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro ao atualizar a lista de insumos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            TelaCadastrarInsumo telaCadastrarInsumo = new TelaCadastrarInsumo();
            telaCadastrarInsumo.InsumoCadastradoSucesso += TelaCadastrarInsumo_InsumoCadastradoSucesso;
            telaCadastrarInsumo.Show();
        }

        private void PictureBoxCadastrarSaida_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaInsumos.SelectedRows.Count == 1) // Verifica se alguma linha está selecionada no DataGridView
            {
                int selectedIndex = DataGridViewListaInsumos.SelectedRows[0].Index; // Obter o índice da linha selecionada
                int insumoID = (int)DataGridViewListaInsumos.Rows[selectedIndex].Cells["IDColumn"].Value; // Obter o ID do insumo selecionado

                TelaCadastrarSaidaInsumo telaCadastrarSaidaInsumo = new TelaCadastrarSaidaInsumo(insumoID); // Criar uma instância do form de cadastrar saída
                telaCadastrarSaidaInsumo.Show(); // Exibir o form cadastrar saída
                telaCadastrarSaidaInsumo.SaidaInsumoCadastradoSucesso += TelaCadastrarSaidaInsumo_SaidaInsumoCadastradoSucesso; // Evento para atualizar
            }
            else if (DataGridViewListaInsumos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um insumo da tabela da esquerda para dar saída (botão '>' à esquerda do ID do insumo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um insumo para dar saída.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxEditar_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaInsumos.SelectedRows.Count == 1)
            {
                int selectedIndex = DataGridViewListaInsumos.SelectedRows[0].Index;
                int insumoID = (int)DataGridViewListaInsumos.Rows[selectedIndex].Cells["IDColumn"].Value;
                TelaEditarInsumo telaEditarInsumo = new TelaEditarInsumo(insumoID);
                telaEditarInsumo.InsumoEditadoSucesso += TelaEditarInsumo_InsumoEditadoSucesso;
                telaEditarInsumo.Show();
            }
            else if (DataGridViewListaInsumos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um insumo para editar (botão '>' à esquerda do ID do insumo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um insumo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxDeletar_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaInsumos.SelectedRows.Count > 0) // Verificar se alguma linha está selecionada no DataGridView
            {
                int selectedIndex = DataGridViewListaInsumos.SelectedRows[0].Index; // Obter o índice da linha selecionada
                int insumoID = (int)DataGridViewListaInsumos.Rows[selectedIndex].Cells["IDColumn"].Value; // Obter o ID do insumo selecionado

                // Confirmar a exclusão com o usuário
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este insumo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        insumoService.DesativarInsumo(insumoID);
                        MessageBox.Show("Insumo excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarInsumos(); // Atualizar o DataGridView após a exclusão
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir insumo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um insumo para excluir (botão '>' à esquerda do ID do insumo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxPesquisar_TextChanged(object sender, EventArgs e)
        {
            string insumoNome = TextBoxPesquisar.Text;
            List<Insumo> insumos = insumoService.FiltrarInsumosNome(insumoNome);

            if (insumos != null && insumos.Count > 0) // Verificar se a lista de insumos não está vazia
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
        }

    }
}
