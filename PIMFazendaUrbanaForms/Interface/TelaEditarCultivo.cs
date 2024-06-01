using System.ComponentModel;
using System.Text.RegularExpressions;
using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    public partial class TelaEditarCultivo : Form
    {
        private Cultivo cultivo;
        private CultivoService cultivoService;
        public event EventHandler CultivoEditadoSucesso;

        bool nomeValido = true;
        bool variedadeValida = true;
        bool categoriaValida = true;
        bool tempoTradicionalValido = true;
        bool tempoControladoValido = true;

        public TelaEditarCultivo(int cultivoID)
        {
            InitializeComponent();
            cultivoService = new CultivoService();

            cultivo = cultivoService.ConsultarCultivoID(cultivoID);
            if (cultivo != null)
            {
                PreencherCampos(cultivo);
            }
            else
            {
                MessageBox.Show("Erro ao carregar dados do cultivo. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void PreencherCampos(Cultivo cultivo)
        {
            TextBoxNome.Text = cultivo.Nome;
            TextBoxVariedade.Text = cultivo.Variedade;
            ComboBoxCategoria.SelectedItem = cultivo.Categoria;
            maskedTextBoxTempoTradicional.Text = cultivo.TempoProdTradicional.ToString();
            maskedTextBoxTempoControlado.Text = cultivo.TempoProdControlado.ToString();
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
        {
            if (!nomeValido)
            {
                MessageBox.Show("Preencha o campo Nome corretamente. O nome deve ter ao menos 3 caracteres alfabéticos", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxNome;
                return;
            }
            if (!variedadeValida)
            {
                MessageBox.Show("Preencha o campo Variedade corretamente. A variedade deve ter ao menos 3 caracteres alfabéticos", "Variedade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = TextBoxVariedade;
                return;
            }
            if (!categoriaValida)
            {
                MessageBox.Show("Por favor, selecione uma categoria válida.", "Categoria Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = ComboBoxCategoria;
                return;
            }
            if (!tempoTradicionalValido)
            {
                MessageBox.Show("Por favor, insira um valor válido para o tempo tradicional (número inteiro).", "Tempo Tradicional Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = maskedTextBoxTempoTradicional;
                return;
            }
            if (!tempoControladoValido)
            {
                MessageBox.Show("Por favor, insira um valor válido para o tempo controlado (número inteiro).", "Tempo Controlado Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = maskedTextBoxTempoControlado;
                return;
            }

            cultivo.Nome = TextBoxNome.Text;
            cultivo.Variedade = TextBoxVariedade.Text;
            cultivo.Categoria = ComboBoxCategoria.SelectedItem.ToString();
            cultivo.TempoProdTradicional = int.Parse(maskedTextBoxTempoTradicional.Text);
            cultivo.TempoProdControlado = int.Parse(maskedTextBoxTempoControlado.Text);

            bool sucesso = cultivoService.AlterarCultivo(cultivo);
            if (sucesso)
            {
                MessageBox.Show("Cultivo alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CultivoEditadoSucesso?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao editar cultivo. Se o erro persistir, entre em contato com o administrador do banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxNome_Validating(object sender, CancelEventArgs e)
        {
            string nome = TextBoxNome.Text;
            if (!Regex.IsMatch(nome, @"^[A-Za-z]{3,}$"))
            {
                TextBoxNome.ForeColor = Color.Red;
                nomeValido = false;
            }
            else
            {
                TextBoxNome.ForeColor = Color.Black;
                nomeValido = true;
            }
        }

        private void TextBoxVariedade_Validating(object sender, CancelEventArgs e)
        {
            string variedade = TextBoxVariedade.Text;
            if (!Regex.IsMatch(variedade, @"^[A-Za-z]{3,}$"))
            {
                TextBoxVariedade.ForeColor = Color.Red;
                variedadeValida = false;
            }
            else
            {
                TextBoxVariedade.ForeColor = Color.Black;
                variedadeValida = true;
            }
        }

        private void ComboBoxCategoria_Validating(object sender, CancelEventArgs e)
        {
            string categoria = ComboBoxCategoria.SelectedItem?.ToString();
            List<string> categoriasPermitidas = new List<string>
            {
                "Hortaliças Folhosas", "Legumes", "Frutas", "Ervas Aromáticas",
                "Grãos", "Tubérculos", "Flores Comestíveis", "Cogumelos",
                "Brotos e Microverdes", "Plantas Medicinais"
            };

            if (categoria == null || !categoriasPermitidas.Contains(categoria))
            {
                ComboBoxCategoria.ForeColor = Color.Red;
                categoriaValida = false;
            }
            else
            {
                ComboBoxCategoria.ForeColor = Color.Black;
                categoriaValida = true;
            }
        }

        private void MaskedTextBoxTempoTradicional_Validating(object sender, CancelEventArgs e)
        {
            string tempoTradicional = maskedTextBoxTempoTradicional.Text;
            if (!int.TryParse(tempoTradicional, out _))
            {
                maskedTextBoxTempoTradicional.ForeColor = Color.Red;
                tempoTradicionalValido = false;
            }
            else
            {
                maskedTextBoxTempoTradicional.ForeColor = Color.Black;
                tempoTradicionalValido = true;
            }
        }

        private void MaskedTextBoxTempoControlado_Validating(object sender, CancelEventArgs e)
        {
            string tempoControlado = maskedTextBoxTempoControlado.Text;
            if (!int.TryParse(tempoControlado, out _))
            {
                maskedTextBoxTempoControlado.ForeColor = Color.Red;
                tempoControladoValido = false;
            }
            else
            {
                maskedTextBoxTempoControlado.ForeColor = Color.Black;
                tempoControladoValido = true;
            }
        }

    }
}
