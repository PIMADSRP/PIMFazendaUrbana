namespace PIMFazendaUrbanaForms
{
    partial class TelaEditarCultivo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            maskedTextBoxTempoControlado = new MaskedTextBox();
            label1 = new Label();
            ComboBoxCategoria = new ComboBox();
            LabelCidade = new Label();
            LabelBairro = new Label();
            LabelComplemento = new Label();
            LabelNumero = new Label();
            maskedTextBoxTempoTradicional = new MaskedTextBox();
            TextBoxVariedade = new TextBox();
            TextBoxNome = new TextBox();
            BotaoCancelar = new Button();
            BotaoConfirmar = new Button();
            PanelHeader = new Panel();
            LabelCadastrarCultivo = new Label();
            PanelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // maskedTextBoxTempoControlado
            // 
            maskedTextBoxTempoControlado.Culture = new System.Globalization.CultureInfo("");
            maskedTextBoxTempoControlado.Location = new Point(150, 176);
            maskedTextBoxTempoControlado.Mask = "000";
            maskedTextBoxTempoControlado.Name = "maskedTextBoxTempoControlado";
            maskedTextBoxTempoControlado.Size = new Size(70, 23);
            maskedTextBoxTempoControlado.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 179);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 80;
            label1.Text = "Tempo Controlado:";
            // 
            // ComboBoxCategoria
            // 
            ComboBoxCategoria.FormattingEnabled = true;
            ComboBoxCategoria.Items.AddRange(new object[] { "Hortaliças Folhosas", "Legumes", "Frutas", "Ervas Aromáticas", "Grãos", "Tubérculos", "Flores Comestíveis", "Cogumelos", "Brotos e Microverdes", "Plantas Medicinais" });
            ComboBoxCategoria.Location = new Point(150, 118);
            ComboBoxCategoria.Name = "ComboBoxCategoria";
            ComboBoxCategoria.Size = new Size(137, 23);
            ComboBoxCategoria.TabIndex = 2;
            // 
            // LabelCidade
            // 
            LabelCidade.AutoSize = true;
            LabelCidade.Location = new Point(28, 150);
            LabelCidade.Name = "LabelCidade";
            LabelCidade.Size = new Size(106, 15);
            LabelCidade.TabIndex = 79;
            LabelCidade.Text = "Tempo Tradicional:";
            // 
            // LabelBairro
            // 
            LabelBairro.AutoSize = true;
            LabelBairro.Location = new Point(79, 121);
            LabelBairro.Name = "LabelBairro";
            LabelBairro.Size = new Size(61, 15);
            LabelBairro.TabIndex = 78;
            LabelBairro.Text = "Categoria:";
            // 
            // LabelComplemento
            // 
            LabelComplemento.AutoSize = true;
            LabelComplemento.Location = new Point(76, 93);
            LabelComplemento.Name = "LabelComplemento";
            LabelComplemento.Size = new Size(61, 15);
            LabelComplemento.TabIndex = 77;
            LabelComplemento.Text = "Variedade:";
            // 
            // LabelNumero
            // 
            LabelNumero.AutoSize = true;
            LabelNumero.Location = new Point(99, 64);
            LabelNumero.Name = "LabelNumero";
            LabelNumero.Size = new Size(43, 15);
            LabelNumero.TabIndex = 76;
            LabelNumero.Text = "Nome:";
            // 
            // maskedTextBoxTempoTradicional
            // 
            maskedTextBoxTempoTradicional.Culture = new System.Globalization.CultureInfo("");
            maskedTextBoxTempoTradicional.Location = new Point(150, 147);
            maskedTextBoxTempoTradicional.Mask = "000";
            maskedTextBoxTempoTradicional.Name = "maskedTextBoxTempoTradicional";
            maskedTextBoxTempoTradicional.Size = new Size(70, 23);
            maskedTextBoxTempoTradicional.TabIndex = 3;
            // 
            // TextBoxVariedade
            // 
            TextBoxVariedade.Location = new Point(150, 89);
            TextBoxVariedade.Name = "TextBoxVariedade";
            TextBoxVariedade.Size = new Size(137, 23);
            TextBoxVariedade.TabIndex = 1;
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(150, 60);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(137, 23);
            TextBoxNome.TabIndex = 0;
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(255, 100, 100);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(223, 217);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(80, 30);
            BotaoCancelar.TabIndex = 6;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // BotaoConfirmar
            // 
            BotaoConfirmar.BackColor = Color.FromArgb(80, 200, 85);
            BotaoConfirmar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoConfirmar.ForeColor = Color.White;
            BotaoConfirmar.Location = new Point(54, 217);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(90, 30);
            BotaoConfirmar.TabIndex = 5;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            BotaoConfirmar.Click += BotaoConfirmar_Click;
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelCadastrarCultivo);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(360, 41);
            PanelHeader.TabIndex = 69;
            // 
            // LabelCadastrarCultivo
            // 
            LabelCadastrarCultivo.AutoSize = true;
            LabelCadastrarCultivo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarCultivo.ForeColor = SystemColors.ButtonHighlight;
            LabelCadastrarCultivo.Location = new Point(113, 9);
            LabelCadastrarCultivo.Name = "LabelCadastrarCultivo";
            LabelCadastrarCultivo.Size = new Size(132, 25);
            LabelCadastrarCultivo.TabIndex = 55;
            LabelCadastrarCultivo.Text = "Editar Cultivo";
            // 
            // TelaEditarCultivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 258);
            Controls.Add(maskedTextBoxTempoControlado);
            Controls.Add(label1);
            Controls.Add(ComboBoxCategoria);
            Controls.Add(LabelCidade);
            Controls.Add(LabelBairro);
            Controls.Add(LabelComplemento);
            Controls.Add(LabelNumero);
            Controls.Add(maskedTextBoxTempoTradicional);
            Controls.Add(TextBoxVariedade);
            Controls.Add(TextBoxNome);
            Controls.Add(BotaoCancelar);
            Controls.Add(BotaoConfirmar);
            Controls.Add(PanelHeader);
            Name = "TelaEditarCultivo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Cultivo";
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBoxTempoControlado;
        private Label label1;
        private ComboBox ComboBoxCategoria;
        private Label LabelCidade;
        private Label LabelBairro;
        private Label LabelComplemento;
        private Label LabelNumero;
        private MaskedTextBox maskedTextBoxTempoTradicional;
        private TextBox TextBoxVariedade;
        private TextBox TextBoxNome;
        private Button BotaoCancelar;
        private Button BotaoConfirmar;
        private Panel PanelHeader;
        private Label LabelCadastrarCultivo;
    }
}