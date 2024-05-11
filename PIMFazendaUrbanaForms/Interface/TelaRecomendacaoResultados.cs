using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaRecomendacaoResultados : Form
    {
        public TelaRecomendacaoResultados(List<Cultivo> resultados, string regiao, string estacao, bool ambienteControlado)
        {
            InitializeComponent();

            if (ambienteControlado == true)
            {
                // Inverte as estações
                switch (estacao)
                {
                    case "Verão":
                        estacao = "Inverno";
                        break;
                    case "Outono":
                        estacao = "Primavera";
                        break;
                    case "Inverno":
                        estacao = "Verão";
                        break;
                    case "Primavera":
                        estacao = "Outono";
                        break;
                    // Adicione mais casos conforme necessário
                    default:
                        // Caso a estação não esteja nas opções esperadas, não faz nada
                        break;
                }

                TextBoxRecomenda.Text = $"Recomenda-se o plantio das seguintes culturas na região {regiao} durante a estação {estacao} em um ambiente controlado, para suprir a demanda do mercado:";
            }
            else
            {
                TextBoxRecomenda.Text = $"Recomenda-se o plantio das seguintes culturas na região {regiao} durante a estação {estacao}, para as melhores condições de cultivo:";
                TextBoxRecomenda.Height = 56;
                DataGridViewResultados.Height = 344;
                DataGridViewResultados.Location = new Point(28, 143);
            }

            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewResultados.AutoGenerateColumns = false;

            // Adicione manualmente as colunas necessárias
            DataGridViewResultados.Columns.Add("IDColumn", "ID");
            DataGridViewResultados.Columns.Add("NomeColumn", "Nome");
            DataGridViewResultados.Columns.Add("VariedadeColumn", "Variedade");
            DataGridViewResultados.Columns.Add("CategoriaColumn", "Categoria");
            DataGridViewResultados.Columns["IDColumn"].DataPropertyName = "ID";
            DataGridViewResultados.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewResultados.Columns["VariedadeColumn"].DataPropertyName = "Variedade";
            DataGridViewResultados.Columns["CategoriaColumn"].DataPropertyName = "Categoria";
            if (ambienteControlado == true)
            {
                DataGridViewResultados.Columns.Add("Tempo2Column", "Tempo Médio de Produção (dias)");
                DataGridViewResultados.Columns["Tempo2Column"].DataPropertyName = "TempoControlado";
            }
            else
            {
                DataGridViewResultados.Columns.Add("Tempo1Column", "Tempo Médio de Produção (dias)");
                DataGridViewResultados.Columns["Tempo1Column"].DataPropertyName = "TempoTradicional";
            }

            // Configurar o modo de redimensionamento das colunas
            foreach (DataGridViewColumn column in DataGridViewResultados.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (resultados != null && resultados.Count > 0)
            {
                // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                var data = resultados.Select(c => new
                {
                    c.ID,
                    c.Nome,
                    c.Variedade,
                    c.Categoria,
                    c.TempoTradicional,
                    c.TempoControlado,
                }).ToList();

                // Preencher o DataGridView com os dados formatados
                DataGridViewResultados.DataSource = data;
            }
            else
            {
                MessageBox.Show("Nenhum resultado encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BotaoFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
