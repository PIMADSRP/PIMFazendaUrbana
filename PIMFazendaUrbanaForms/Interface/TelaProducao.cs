using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaProducao : Form
    {
        private CultivoService cultivoService;

        public TelaProducao()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.TelaCultivo_Load);
            cultivoService = new CultivoService();

            DataGridViewListaCultivos.AutoGenerateColumns = false;

            DataGridViewListaCultivos.Columns.Add("IDColumn", "ID");
            DataGridViewListaCultivos.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaCultivos.Columns.Add("VariedadeColumn", "Variedade");
            DataGridViewListaCultivos.Columns.Add("TempoProdTradicionalColumn", "Tempo Produção Tradicional");
            DataGridViewListaCultivos.Columns.Add("TempoProdControladoColumn", "Tempo Produção Controlado");
            DataGridViewListaCultivos.Columns.Add("CategoriaColumn", "Categoria");
            //  DataGridViewListaCultivos.Columns.Add("StatusAtivoColumn", "Status Ativo");

            DataGridViewListaCultivos.Columns["IDColumn"].DataPropertyName = "ID";
            DataGridViewListaCultivos.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaCultivos.Columns["VariedadeColumn"].DataPropertyName = "Variedade";
            DataGridViewListaCultivos.Columns["TempoProdTradicionalColumn"].DataPropertyName = "TempoProdTradicional";
            DataGridViewListaCultivos.Columns["TempoProdControladoColumn"].DataPropertyName = "TempoProdControlado";
            DataGridViewListaCultivos.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            //  DataGridViewListaCultivos.Columns["StatusAtivoColumn"].DataPropertyName = "StatusAtivo";

            foreach (DataGridViewColumn column in DataGridViewListaCultivos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            TextBoxPesquisar.TextChanged += new EventHandler(TextBoxPesquisar_TextChanged); // Associa o evento TextChanged ao método TextBoxPesquisar_TextChanged
        }

        private void TelaCultivo_Load(object sender, EventArgs e)
        {
            CarregarCultivos();
        }

        private void CarregarCultivos()
        {
            try
            {
                List<Cultivo> cultivos = cultivoService.ListarCultivosAtivos();

                if (cultivos != null && cultivos.Count > 0)
                {
                    DataGridViewListaCultivos.DataSource = cultivos;
                }
                else
                {
                    MessageBox.Show("Nenhum cultivo encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar cultivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            TelaCadastrarCultivo telaCadastrarCultivos = new TelaCadastrarCultivo();
            telaCadastrarCultivos.CultivoCadastradoSucesso += TelaCadastrarCultivos_CultivoCadastradoSucesso;
            telaCadastrarCultivos.Show();
        }

        private void TelaCadastrarCultivos_CultivoCadastradoSucesso(object sender, EventArgs e)
        {
            CarregarCultivos();
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            CarregarCultivos();
            MessageBox.Show("Lista de cultivos atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PictureBoxEditar_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaCultivos.SelectedRows.Count == 1)
            {
                int selectedIndex = DataGridViewListaCultivos.SelectedRows[0].Index;
                int cultivoID = (int)DataGridViewListaCultivos.Rows[selectedIndex].Cells["IDColumn"].Value;
                TelaEditarCultivo telaEditarCultivo = new TelaEditarCultivo(cultivoID);
                telaEditarCultivo.CultivoEditadoSucesso += TelaEditarCultivo_CultivoEditadoSucesso;
                telaEditarCultivo.Show();
            }
            else if (DataGridViewListaCultivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cultivo para editar (botão '>' à esquerda do ID do cultivo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um cultivo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TelaEditarCultivo_CultivoEditadoSucesso(object sender, EventArgs e)
        {
            CarregarCultivos();
        }

        private void PictureBoxDeletar_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaCultivos.SelectedRows.Count > 0)
            {
                int selectedIndex = DataGridViewListaCultivos.SelectedRows[0].Index;
                int cultivoID = (int)DataGridViewListaCultivos.Rows[selectedIndex].Cells["IDColumn"].Value;

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este cultivo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cultivoService.ExcluirCultivo(cultivoID);
                        MessageBox.Show("Cultivo excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarCultivos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir cultivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cultivo para excluir (botão '>' à esquerda do ID do cultivo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxEditarCultivo_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaCultivos.SelectedRows.Count == 1)
            {
                int selectedIndex = DataGridViewListaCultivos.SelectedRows[0].Index;
                int cultivoID = (int)DataGridViewListaCultivos.Rows[selectedIndex].Cells["IDColumn"].Value;
                TelaEditarCultivo telaEditarCultivo = new TelaEditarCultivo(cultivoID);
                telaEditarCultivo.CultivoEditadoSucesso += TelaEditarCultivo_CultivoEditadoSucesso;
                telaEditarCultivo.Show();
            }
            else if (DataGridViewListaCultivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cultivo para editar (botão '>' à esquerda do ID do cultivo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um cultivo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void PictureBoxDeletarCultivo_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaCultivos.SelectedRows.Count > 0) // Verificar se alguma linha está selecionada no DataGridView
            {
                int selectedIndex = DataGridViewListaCultivos.SelectedRows[0].Index; // Obter o índice da linha selecionada
                int cultivoID = (int)DataGridViewListaCultivos.Rows[selectedIndex].Cells["IDColumn"].Value; // Obter o ID do cultivo selecionado

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este cultivo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cultivoService.ExcluirCultivo(cultivoID);
                        MessageBox.Show("Cultivo excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarCultivos(); // Atualizar o DataGridView após a exclusão
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir cultivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cultivo para excluir (botão '>' à esquerda do ID do cultivo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void TextBoxPesquisar_TextChanged(object sender, EventArgs e)
        {
            string cultivoNome = TextBoxPesquisar.Text;
            List<Cultivo> cultivos = cultivoService.FiltrarCultivosNome(cultivoNome);

            if (cultivos != null && cultivos.Count > 0)
            {
                var data = cultivos.Select(c => new
                {
                    c.ID,
                    c.Nome,
                    c.Variedade,
                    TempoProdTradicional = c.TempoProdTradicional.HasValue ? c.TempoProdTradicional.Value.ToString() : "",
                    TempoProdControlado = c.TempoProdControlado.HasValue ? c.TempoProdControlado.Value.ToString() : "",
                    c.Categoria
                }).ToList();

                DataGridViewListaCultivos.DataSource = data;
            }
            else
            {
                DataGridViewListaCultivos.DataSource = null;
            }
        }

        private void PictureBoxAtualizarCultivo_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarCultivos();
                //CarregarProducao();
                MessageBox.Show("Lista de cultivos atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro ao atualizar a lista de cultivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
