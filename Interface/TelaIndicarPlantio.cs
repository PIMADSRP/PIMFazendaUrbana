namespace PIMFazendaUrbana
{
    public partial class TelaIndicarPlantio : Form
    {
        public TelaIndicarPlantio()
        {
            InitializeComponent();
        }

        private void txtBox_Data_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBox_Data.Text))
            {
                MessageBox.Show("Por favor, informe a data.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtBox_Data;
            }

        }

        private void cb_estacaoAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_Regiao.Text))
            {
                MessageBox.Show("Por favor, selecione uma região.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cb_Regiao;
            }

        }

private void cb_Regiao_SelectedIndexChanged(object sender, EventArgs e)
{
    // Verificar se alguma região está selecionada
    if (cb_Regiao.SelectedItem == null)
    {
        return; // Não há região selecionada, então não precisamos fazer mais nada
    }

    // Imprimir a região selecionada para depuração
    string regiaoSelecionada = cb_Regiao.SelectedItem.ToString().Trim(); // Removendo espaços extras
    Console.WriteLine("Região Selecionada: " + regiaoSelecionada); // Adicionando essa linha para imprimir a região selecionada

    // Verificar se a região selecionada é uma das opções aceitas
    string[] regioesAceitas = { "Norte", "Nordeste", "Sul", "Sudeste", "Centro-oeste" };

    // Verificando se a região selecionada está na lista de regiões aceitas, ignorando a diferença de caixa
    if (!regioesAceitas.Any(r => string.Equals(r, regiaoSelecionada, StringComparison.OrdinalIgnoreCase)))
    {
        // Se a região selecionada não estiver na lista de regiões aceitas, exibir uma mensagem de erro
        MessageBox.Show("Por favor, selecione uma das seguintes regiões: Norte, Nordeste, Sul, Sudeste, Centro-oeste", "Região Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // Limpar a seleção do ComboBox
        cb_Regiao.SelectedIndex = -1;
        ActiveControl = cb_Regiao;
    }
}

        private void painel_indicacao_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRecomendar_Click(object sender, EventArgs e)

        {
            if (cb_Regiao.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione uma região.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se a data não é válida
            if (!DateTime.TryParseExact(txtBox_Data.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                MessageBox.Show("Por favor, informe uma data válida no formato dd/MM/yyyy.", "Campo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determinar a estação do ano com base na data fornecida
            string estacao = DeterminarEstacaoDoAno(data);

            // Determinar a região selecionada pelo usuário
            string regiao = cb_Regiao.SelectedItem.ToString();

            // Combinar a estação do ano e a região para fornecer a recomendação de plantio correspondente
            string recomendacao = ObterRecomendacaoDePlantio(estacao, regiao);

            // Exibir a recomendação
            MessageBox.Show(recomendacao, "Recomendação de Plantio");
        }

        // Método para determinar a estação do ano com base na data fornecida
        private string DeterminarEstacaoDoAno(DateTime data)
        {
            int mes = data.Month;

            if (mes >= 3 && mes <= 5)
            {
                return "Outono";
            }
            else if (mes >= 6 && mes <= 8)
            {
                return "Inverno";
            }
            else if (mes >= 9 && mes <= 11)
            {
                return "Primavera";
            }
            else
            {
                return "Verão";
            }
        }

        // Método para obter a recomendação de plantio com base na estação do ano e na região
        private string ObterRecomendacaoDePlantio(string estacao, string regiao)
        {
            switch (estacao)
            {
                case "Verão":
                    switch (regiao)
                    {
                        case "Norte":
                            return "Milho, feijão, cacau e açaí";
                        case "Nordeste":
                            return "Algodão, mamona, mandioca e amendoim";
                        case "Sul":
                            return "Soja, milho, feijão e trigo";
                        case "Sudeste":
                            return "Café, cana-de-açúcar, laranja e tomate";
                        case "Centro-oeste":
                            return "Algodão, arroz, sorgo e feijão";
                        default:
                            return "Região não especificada";
                    }

                case "Outono":
                    switch (regiao)
                    {
                        case "Norte":
                            return "Maracujá, pupunha, guaraná e pupunha";
                        case "Nordeste":
                            return "Cana-de-açúcar, manga, goiaba e banana";
                        case "Sul":
                            return "Maçã, uva, trigo e cevada";
                        case "Sudeste":
                            return "Café, batata, cebola e alface";
                        case "Centro-oeste":
                            return "Milho, girassol, feijão e trigo";
                        default:
                            return "Região não especificada";
                    }
                case "Inverno":
                    switch (regiao)
                    {
                        case "Norte":
                            return "Tucumã, castanha-do-brasil, açaí e cupuaçu";
                        case "Nordeste":
                            return "Feijão, mandioca, melancia e abóbora";
                        case "Sul":
                            return "Maçã, uva, trigo e cevada";
                        case "Sudeste":
                            return "Café, alface, cenoura e batata";
                        case "Centro-oeste":
                            return "Soja, milho, feijão e algodão";
                        default:
                            return "Região não especificada";
                    }
                case "Primavera":
                    switch (regiao)
                    {
                        case "Norte":
                            return "Bananeira, abacaxi, mandioca e cupuaçu";
                        case "Nordeste":
                            return "Milho, feijão, melancia e abóbora";
                        case "Sul":
                            return "Trigo, cevada, milho e feijão";
                        case "Sudeste":
                            return "Café, milho, feijão e batata";
                        case "Centro-oeste":
                            return "Soja, milho, girassol e feijão";
                        default:
                            return "Região não especificada";
                    }



                default:
                    return "Estação do ano não identificada";
            }
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Indicação Cancelada","Aviso");
            this.Close();
        }
    }
}
