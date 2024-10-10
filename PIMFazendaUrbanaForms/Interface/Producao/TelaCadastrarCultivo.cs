using System.Text.RegularExpressions;
using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaCadastrarCultivo : Form
    {
        internal CultivoService cultivoService;
        internal event EventHandler CultivoCadastradoSucesso;

        bool nomeValido = false;
        bool variedadeValida = false;
        bool categoriaValida = false;
        bool tempoTradicionalValido = false;
        bool tempoControladoValido = false;

        private ToolTip toolTip;

        private const string tooltipNome = "O nome do produto deve conter pelo menos 3 caracteres.";
        private const string tooltipVariedade = "A variedade deve conter pelo menos 3 caracteres.";
        private const string tooltipCategoria = "Selecione uma categoria válida (Verdura, Legume, Fruta ou Outro).";
        private const string tooltipTempo = "Insira um número inteiro maior que 0.";

        public TelaCadastrarCultivo()
        {
            InitializeComponent();
            cultivoService = new CultivoService();

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
            toolTip.SetToolTip(this.TextBoxVariedade, tooltipVariedade);
            toolTip.SetToolTip(this.ComboBoxCategoria, tooltipCategoria);
            toolTip.SetToolTip(this.MaskedTextBoxTempoTradicional, tooltipTempo);
            toolTip.SetToolTip(this.MaskedTextBoxTempoControlado, tooltipTempo);
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            List<string> camposInvalidos = new List<string>();

            ValidarNome(camposInvalidos);
            ValidarVariedade(camposInvalidos);
            ValidarCategoria(camposInvalidos);
            ValidarTempoTradicional(camposInvalidos);
            ValidarTempoControlado(camposInvalidos);

            if (nomeValido == true && variedadeValida == true && categoriaValida == true && tempoTradicionalValido == true && tempoControladoValido == true)
            {
                // Se todas as validações passarem, pode prosseguir com a ação do botão Confirmar
                Cultivo cultivo = new Cultivo
                {
                    Nome = TextBoxNome.Text,
                    Variedade = TextBoxVariedade.Text,
                    Categoria = ComboBoxCategoria.Text,
                    TempoProdTradicional = int.Parse(MaskedTextBoxTempoTradicional.Text),
                    TempoProdControlado = int.Parse(MaskedTextBoxTempoControlado.Text),
                    StatusAtivo = true  // Supondo que um cultivo recém-cadastrado é ativo por padrão
                };

                try
                {
                    cultivoService.CadastrarCultivo(cultivo);
                    MessageBox.Show("Cultivo cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CultivoCadastradoSucesso?.Invoke(this, EventArgs.Empty); // Disparar o evento
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefinirFoco(List<string> camposInvalidos)
        {
            // Define o foco para o primeiro item da lista de campos inválidos
            switch (camposInvalidos[0])
            {
                case "Nome":
                    this.ActiveControl = TextBoxNome;
                    break;
                case "Variedade":
                    this.ActiveControl = TextBoxVariedade;
                    break;
                case "Categoria":
                    this.ActiveControl = ComboBoxCategoria;
                    break;
                case "TempoProdTradicional":
                    this.ActiveControl = MaskedTextBoxTempoTradicional;
                    break;
                case "TempoProdControlado":
                    this.ActiveControl = MaskedTextBoxTempoControlado;
                    break;
            }

        }

        private void ValidarNome(List<string> camposInvalidos)
        {
            string nome = TextBoxNome.Text;
            if (nome.Length < 3)
            {
                camposInvalidos.Add("Nome");
                TextBoxNome.ForeColor = Color.Red;
                //MessageBox.Show("O nome do produto deve conter pelo menos 3 caracteres.");
                toolTip.Show(tooltipNome, TextBoxNome, 0, -50, 5000); // Mostrar a tooltip
                nomeValido = false;
            }
            else
            {
                TextBoxNome.ForeColor = Color.Black;
                nomeValido = true;
            }
        }

        private void ValidarVariedade(List<string> camposInvalidos)
        {
            string variedade = TextBoxVariedade.Text;
            if (variedade.Length < 3)
            {
                camposInvalidos.Add("Variedade");
                TextBoxVariedade.ForeColor = Color.Red;
                //MessageBox.Show("A variedade deve conter pelo menos 3 caracteres.");
                toolTip.Show(tooltipVariedade, TextBoxVariedade, 0, -50, 5000); // Mostrar a tooltip
                variedadeValida = false;
            }
            else
            {
                TextBoxVariedade.ForeColor = Color.Black;
                variedadeValida = true;
            }
        }

        private void ValidarCategoria(List<string> camposInvalidos)
        {
            // Lista de categorias permitidas
            List<string> categoriasPermitidas = new List<string>
            {
                "Verdura",
                "Legume",
                "Fruta",
                "Outro"
            };
            string categoria = ComboBoxCategoria.SelectedItem?.ToString();
            // Verifica se a categoria está na lista de permitidas
            if (categoria == null || !categoriasPermitidas.Contains(categoria))
            {
                camposInvalidos.Add("Categoria");
                ComboBoxCategoria.ForeColor = Color.Red;
                //MessageBox.Show("Por favor, selecione uma categoria válida.");
                toolTip.Show(tooltipCategoria, ComboBoxCategoria, 0, -50, 5000); // Mostrar a tooltip
                categoriaValida = false;
            }
            else
            {
                ComboBoxCategoria.ForeColor = Color.Black;
                categoriaValida = true;
            }
        }

        private void ValidarTempoTradicional(List<string> camposInvalidos)
        {
            string tempoTradicional = MaskedTextBoxTempoTradicional.Text;
            if (string.IsNullOrWhiteSpace(tempoTradicional) || !int.TryParse(tempoTradicional, out _) || int.Parse(tempoTradicional) <= 0)
            {
                camposInvalidos.Add("Tempo de Produção Tradicional");
                MaskedTextBoxTempoTradicional.ForeColor = Color.Red;
                //MessageBox.Show("Por favor, insira um valor válido para o tempo de plantio tradicional (número inteiro).");
                toolTip.Show(tooltipTempo, MaskedTextBoxTempoTradicional, 0, -50, 5000); // Mostrar a tooltip
                tempoTradicionalValido = false;
            }
            else
            {
                MaskedTextBoxTempoTradicional.ForeColor = Color.Black;
                tempoTradicionalValido = true;
            }
        }

        private void ValidarTempoControlado(List<string> camposInvalidos)
        {
            string tempoControlado = MaskedTextBoxTempoControlado.Text;
            if (string.IsNullOrWhiteSpace(tempoControlado) || !int.TryParse(tempoControlado, out _) || int.Parse(tempoControlado) <= 0)
            {
                camposInvalidos.Add("Tempo de Produção Controlado");
                MaskedTextBoxTempoControlado.ForeColor = Color.Red;
                //MessageBox.Show("Por favor, insira um valor válido para o tempo de plantio controlado (número inteiro).");
                toolTip.Show(tooltipTempo, MaskedTextBoxTempoControlado, 0, -50, 5000); // Mostrar a tooltip
                tempoControladoValido = false;
            }
            else
            {
                MaskedTextBoxTempoControlado.ForeColor = Color.Black;
                tempoControladoValido = true;
            }
        }


    }
}
