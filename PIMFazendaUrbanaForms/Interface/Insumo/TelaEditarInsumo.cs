using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaEditarInsumo : Form
    {
        Insumo insumo = new Insumo();
        Insumo insumo1 = new Insumo();

        internal event EventHandler InsumoEditadoSucesso;

        internal InsumoService insumoService; // Declaração de uma instância de InsumoService

        bool nomeValido = false;
        bool categoriaValida = false;
        bool unidadeValida = false;

        private ToolTip toolTip;

        private const string tooltipNome = "O nome deve ter ao menos 3 caracteres.";
        private const string tooltipCategoria = "Selecione uma categoria válida (Sementes ou Fertilizantes).";
        private const string tooltipUnidade = "Selecione uma unidade válida.";

        public TelaEditarInsumo(int insumoID)
        {
            InitializeComponent();

            // Adicionando as unidades de medida na ComboBox
            ComboBoxUnidade.Items.AddRange(new string[] {
                "kg", "g", "l", "ml", "m", "cm", "mm", "unidade", "caixa", "tambor"
            });

            toolTip = new ToolTip(); // Inicializar tooltip genérica

            // Configurações gerais de tooltip
            toolTip.ToolTipTitle = "Informação";  // Título do balão
            toolTip.ToolTipIcon = ToolTipIcon.Info; // Ícone de informação
            toolTip.IsBalloon = false; // Mostrar como balão
            toolTip.AutoPopDelay = 5000; // Tempo que o balão ficará visível (em milissegundos)
            toolTip.InitialDelay = 250;  // Tempo antes de aparecer
            toolTip.ReshowDelay = 500;   // Tempo antes de reaparecer

            // Associação de ToolTip com os controles
            toolTip.SetToolTip(this.TextBoxNome, tooltipNome);
            toolTip.SetToolTip(this.ComboBoxCategoria, tooltipCategoria);
            toolTip.SetToolTip(this.ComboBoxUnidade, tooltipUnidade);

            insumoService = new InsumoService(); // Cria uma instância de InsumoService

            insumo = insumoService.ConsultarInsumoPorID(insumoID); // Chamando o método ConsultarInsumoID da instância insumoService

            if (insumo != null)
            {
                PreencherCampos(insumo);
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados do insumo. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void PreencherCampos(Insumo insumo)
        {
            TextBoxNome.Text = insumo.Nome;
            ComboBoxCategoria.SelectedItem = insumo.Categoria;
            ComboBoxUnidade.SelectedItem = insumo.Unidqtd;
            nomeValido = true;
            categoriaValida = true;
            unidadeValida = true;
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            List<string> camposInvalidos = new List<string>();

            ValidarNome(camposInvalidos);
            ValidarCategoria(camposInvalidos);
            ValidarUnidade(camposInvalidos);

            // Se todas as validações passarem, pode prosseguir com a ação do botão Confirmar
            if (nomeValido == true && categoriaValida == true && unidadeValida == true)
            {
                insumo1.Id = insumo.Id;
                insumo1.Nome = TextBoxNome.Text;
                insumo1.Categoria = ComboBoxCategoria.Text;
                insumo1.Qtd = insumo.Qtd;
                insumo1.Unidqtd = ComboBoxUnidade.Text;
                insumo1.Ativo = insumo.Ativo;

                try
                {
                    insumoService.AlterarInsumo(insumo1);
                    MessageBox.Show("Insumo alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InsumoEditadoSucesso?.Invoke(this, EventArgs.Empty); // Disparar o evento
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                // monta a string com os campos inválidos para a mensagem de erro
                string camposInvalidosString = string.Join(", ", camposInvalidos);

                MessageBox.Show($"Por favor, preencha todos os campos corretamente. Campos inválidos: {camposInvalidosString}", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DefinirFoco(camposInvalidos); // define foco para o primeiro item da lista de campos inválidos
            }
        }

        private void ValidarNome(List<string> camposInvalidos)
        {
            string nome = TextBoxNome.Text;

            if (nome.Length < 3)
            {
                camposInvalidos.Add("Nome");
                TextBoxNome.ForeColor = Color.Red;
                //MessageBox.Show("O nome do insumo deve conter pelo menos 3 caracteres.", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipNome, TextBoxNome, 0, -50, 5000); // Mostrar a tooltip
                nomeValido = false;
            }
            else
            {
                TextBoxNome.ForeColor = Color.Black;
                nomeValido = true;
            }
        }

        private void ValidarCategoria(List<string> camposInvalidos)
        {
            string categoria = ComboBoxCategoria.SelectedItem?.ToString();
            List<string> categoriasPermitidas = new List<string> { "Sementes", "Fertilizantes" };

            if (categoria == null || !categoriasPermitidas.Contains(categoria))
            {
                camposInvalidos.Add("Categoria");
                ComboBoxCategoria.ForeColor = Color.Red;
                //MessageBox.Show("Por favor, selecione uma categoria válida (Sementes ou Fertilizantes).", "Categoria Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipCategoria, ComboBoxCategoria, 0, -50, 5000); // Mostrar a tooltip
                categoriaValida = false;
            }
            else
            {
                ComboBoxCategoria.ForeColor = Color.Black;
                categoriaValida = true;
            }
        }

        private void ValidarUnidade(List<string> camposInvalidos)
        {
            // Lista de unidades permitidas
            List<string> unidadesPermitidas = new List<string>
            {
                "kg", "g", "l", "ml", "m", "cm", "mm", "unidade", "caixa", "tambor"
            };

            // Verifica se a unidade está na lista de permitidas
            string unidade = ComboBoxUnidade.SelectedItem?.ToString();
            if (unidade == null || !unidadesPermitidas.Contains(unidade))
            {
                camposInvalidos.Add("Unidade");
                ComboBoxUnidade.ForeColor = Color.Red;
                //MessageBox.Show("Por favor, selecione uma unidade válida.", "Unidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolTip.Show(tooltipUnidade, ComboBoxUnidade, 0, -50, 5000); // Mostrar a tooltip
                unidadeValida = false;
            }
            else
            {
                ComboBoxUnidade.ForeColor = Color.Black;
                unidadeValida = true;
            }
        }

        private void DefinirFoco(List<string> camposInvalidos)
        {
            if (camposInvalidos.Contains("Nome"))
            {
                TextBoxNome.Focus();
            }
            else if (camposInvalidos.Contains("Categoria"))
            {
                ComboBoxCategoria.Focus();
            }
            else if (camposInvalidos.Contains("Unidade"))
            {
                ComboBoxUnidade.Focus();
            }
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
