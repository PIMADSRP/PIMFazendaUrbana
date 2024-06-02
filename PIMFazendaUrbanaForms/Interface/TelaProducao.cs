﻿using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaProducao : Form
    {
        private CultivoService cultivoService;
        private ProducaoService producaoService;

        public TelaProducao()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.PictureBoxAtualizar_Click);
            cultivoService = new CultivoService();
            producaoService = new ProducaoService();

            DataGridViewListaCultivos.AutoGenerateColumns = false;

            DataGridViewListaCultivos.Columns.Add("IDColumn", "ID");
            DataGridViewListaCultivos.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaCultivos.Columns.Add("VariedadeColumn", "Variedade");
            DataGridViewListaCultivos.Columns.Add("TempoProdTradicionalColumn", "Tempo de Produção Tradicional");
            DataGridViewListaCultivos.Columns.Add("TempoProdControladoColumn", "Tempo de Produção Controlada");
            DataGridViewListaCultivos.Columns.Add("CategoriaColumn", "Categoria");
            // DataGridViewListaCultivos.Columns.Add("StatusAtivoColumn", "Status Ativo");

            DataGridViewListaCultivos.Columns["IDColumn"].DataPropertyName = "ID";
            DataGridViewListaCultivos.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaCultivos.Columns["VariedadeColumn"].DataPropertyName = "Variedade";
            DataGridViewListaCultivos.Columns["TempoProdTradicionalColumn"].DataPropertyName = "TempoProdTradicional";
            DataGridViewListaCultivos.Columns["TempoProdControladoColumn"].DataPropertyName = "TempoProdControlado";
            DataGridViewListaCultivos.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            // DataGridViewListaCultivos.Columns["StatusAtivoColumn"].DataPropertyName = "StatusAtivo";

            /*
            foreach (DataGridViewColumn column in DataGridViewListaCultivos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */

            // Definindo o tamanho padrão das colunas
            DataGridViewListaCultivos.Columns["IDColumn"].Width = 40;
            DataGridViewListaCultivos.Columns["NomeColumn"].Width = 175;
            DataGridViewListaCultivos.Columns["VariedadeColumn"].Width = 300;
            DataGridViewListaCultivos.Columns["CategoriaColumn"].Width = 85;
            DataGridViewListaCultivos.Columns["TempoProdTradicionalColumn"].Width = 85;
            DataGridViewListaCultivos.Columns["TempoProdControladoColumn"].Width = 85;

            DataGridViewListaCultivos.Columns["VariedadeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            //----------------------------------------------------------------------------------------
            // Configurar o DataGridView para registro de saída de insumos
            DataGridViewProducao.AutoGenerateColumns = false;

            DataGridViewProducao.Columns.Add("IDColumn", "ID");
            //DataGridViewProducao.Columns.Add("NomeColumn", "Nome");
            DataGridViewProducao.Columns.Add("VariedadeColumn", "Variedade");
            //DataGridViewProducao.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewProducao.Columns.Add("QtdColumn", "Quantidade");
            DataGridViewProducao.Columns.Add("UnidQtdColumn", "Unidade");
            DataGridViewProducao.Columns.Add("AmbienteControlado", "Climatizado");
            DataGridViewProducao.Columns.Add("DataColumn", "Data de Plantio");
            DataGridViewProducao.Columns.Add("DataColheitaColumn", "Data de Colheita");
            DataGridViewProducao.Columns.Add("Finalizada", "Finalizada");

            DataGridViewProducao.Columns["IDColumn"].DataPropertyName = "Id";
            //DataGridViewProducao.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewProducao.Columns["VariedadeColumn"].DataPropertyName = "Variedade";
            //DataGridViewProducao.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            DataGridViewProducao.Columns["QtdColumn"].DataPropertyName = "Qtd";
            DataGridViewProducao.Columns["UnidQtdColumn"].DataPropertyName = "Unidqtd";
            DataGridViewProducao.Columns["AmbienteControlado"].DataPropertyName = "AmbienteControlado";
            DataGridViewProducao.Columns["DataColumn"].DataPropertyName = "Data";
            DataGridViewProducao.Columns["DataColheitaColumn"].DataPropertyName = "DataColheita";
            DataGridViewProducao.Columns["Finalizada"].DataPropertyName = "StatusFinalizado";

            /*
            foreach (DataGridViewColumn column in DataGridViewSaidaInsumos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            */

            // Definindo o tamanho padrão das colunas
            DataGridViewProducao.Columns["IDColumn"].Width = 40;
            //DataGridViewProducao.Columns["NomeColumn"].Width = 200;
            DataGridViewProducao.Columns["VariedadeColumn"].Width = 150;
            //DataGridViewProducao.Columns["CategoriaColumn"].Width = 100;
            DataGridViewProducao.Columns["QtdColumn"].Width = 75;
            DataGridViewProducao.Columns["UnidQtdColumn"].Width = 60;
            DataGridViewProducao.Columns["AmbienteControlado"].Width = 75;
            DataGridViewProducao.Columns["DataColumn"].Width = 70;
            DataGridViewProducao.Columns["DataColheitaColumn"].Width = 70;
            DataGridViewProducao.Columns["Finalizada"].Width = 65;

            DataGridViewProducao.Columns["VariedadeColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            TextBoxPesquisar.TextChanged += new EventHandler(TextBoxPesquisar_TextChanged); // Associa o evento TextChanged ao método TextBoxPesquisar_TextChanged
        }

        private void CarregarCultivos()
        {
            try
            {
                DataGridViewListaCultivos.DataSource = null; // Limpa a DataSource do DataGridView

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

        private void CarregarProducoes()
        {
            try
            {
                DataGridViewProducao.DataSource = null; // Limpa a DataSource do DataGridView

                List<Producao> producoes = producaoService.ListarProducoes();

                if (producoes != null && producoes.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = producoes.Select(p => new
                    {
                        p.Id,
                        p.Variedade,
                        p.Qtd,
                        p.Unidqtd,
                        AmbienteControlado = p.AmbienteControlado ? "Sim" : "Não",
                        Data = Program.utility.FormatarDataSemHora(p.Data), // Para exibir a data sem a hora
                        DataColheita = Program.utility.FormatarDataSemHora(p.DataColheita), // Para exibir a data sem a hora
                        StatusFinalizado = p.StatusFinalizado ? "Sim" : "Não"
                    }).ToList();

                    DataGridViewProducao.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Nenhuma produção encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TelaCadastrarProducao_ProducaoCadastradaSucesso(object sender, EventArgs e)
        {
            CarregarProducoes();
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

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarCultivos();
                CarregarProducoes();
                MessageBox.Show("Listas de cultivos e produções atualizadas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro ao atualizar a lista de cultivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxCadastrarProducao_Click(object sender, EventArgs e)
        {
            if (DataGridViewListaCultivos.SelectedRows.Count == 1) // Verifica se alguma linha está selecionada no DataGridView
            {
                int selectedIndex = DataGridViewListaCultivos.SelectedRows[0].Index; // Obter o índice da linha selecionada
                int cultivoID = (int)DataGridViewListaCultivos.Rows[selectedIndex].Cells["IDColumn"].Value; // Obter o ID do cultivo selecionado

                TelaCadastrarProducao telaCadastrarProducao = new TelaCadastrarProducao(cultivoID); // Criar uma instância do form de cadastrar produção
                telaCadastrarProducao.Show(); // Exibir o form cadastrar produção
                telaCadastrarProducao.ProducaoCadastradaSucesso += TelaCadastrarProducao_ProducaoCadastradaSucesso; // Evento para atualizar
            }
            else if (DataGridViewListaCultivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um cultivo da tabela da esquerda para cadastrar seu plantio (botão '>' à esquerda do ID do cultivo).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um cultivo para cadastrar seu plantio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxFinalizarProducao_Click(object sender, EventArgs e)
        {
            if (DataGridViewProducao.SelectedRows.Count == 1) // Verifica se alguma linha está selecionada no DataGridView
            {
                int selectedIndex = DataGridViewProducao.SelectedRows[0].Index; // Obter o índice da linha selecionada
                int producaoID = (int)DataGridViewProducao.Rows[selectedIndex].Cells["IDColumn"].Value; // Obter o ID da produção selecionada

                try
                {
                    producaoService.FinalizarProducao(producaoID); // Finalizar a produção

                    MessageBox.Show("Produção finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarProducoes(); // Atualizar o DataGridView após a finalização

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (DataGridViewListaCultivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma produção da tabela da direita para finalizar (botão '>' à esquerda do ID da produção).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas uma produção para finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
