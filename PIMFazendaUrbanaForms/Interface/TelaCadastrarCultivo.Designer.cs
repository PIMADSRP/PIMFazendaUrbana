namespace PIMFazendaUrbanaForms
{
    partial class TelaCadastrarCultivo
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
            PanelHeader = new Panel();
            LabelCadastrarCultivo = new Label();
            ComboBoxCategoria = new ComboBox();
            LabelTempoTradicional = new Label();
            LabelCategoria = new Label();
            LabelVariedade = new Label();
            LabelNome = new Label();
            MaskedTextBoxTempoTradicional = new MaskedTextBox();
            TextBoxVariedade = new TextBox();
            TextBoxNome = new TextBox();
            BotaoCancelar = new Button();
            BotaoConfirmar = new Button();
            LabelTempoControlado = new Label();
            MaskedTextBoxTempoControlado = new MaskedTextBox();
            PanelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelCadastrarCultivo);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(358, 41);
            PanelHeader.TabIndex = 51;
            // 
            // LabelCadastrarCultivo
            // 
            LabelCadastrarCultivo.AutoSize = true;
            LabelCadastrarCultivo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarCultivo.ForeColor = SystemColors.ButtonHighlight;
            LabelCadastrarCultivo.Location = new Point(86, 9);
            LabelCadastrarCultivo.Name = "LabelCadastrarCultivo";
            LabelCadastrarCultivo.Size = new Size(165, 25);
            LabelCadastrarCultivo.TabIndex = 55;
            LabelCadastrarCultivo.Text = "Cadastrar Cultivo";
            // 
            // ComboBoxCategoria
            // 
            ComboBoxCategoria.FormattingEnabled = true;
            ComboBoxCategoria.Items.AddRange(new object[] { "Verdura", "Legume", "Fruta", "Outro" });
            ComboBoxCategoria.Location = new Point(151, 116);
            ComboBoxCategoria.Name = "ComboBoxCategoria";
            ComboBoxCategoria.Size = new Size(138, 23);
            ComboBoxCategoria.TabIndex = 2;
            // 
            // LabelTempoTradicional
            // 
            LabelTempoTradicional.AutoSize = true;
            LabelTempoTradicional.Location = new Point(30, 148);
            LabelTempoTradicional.Name = "LabelTempoTradicional";
            LabelTempoTradicional.Size = new Size(106, 15);
            LabelTempoTradicional.TabIndex = 63;
            LabelTempoTradicional.Text = "Tempo Tradicional:";
            // 
            // LabelCategoria
            // 
            LabelCategoria.AutoSize = true;
            LabelCategoria.Location = new Point(81, 119);
            LabelCategoria.Name = "LabelCategoria";
            LabelCategoria.Size = new Size(61, 15);
            LabelCategoria.TabIndex = 62;
            LabelCategoria.Text = "Categoria:";
            // 
            // LabelVariedade
            // 
            LabelVariedade.AutoSize = true;
            LabelVariedade.Location = new Point(80, 90);
            LabelVariedade.Name = "LabelVariedade";
            LabelVariedade.Size = new Size(61, 15);
            LabelVariedade.TabIndex = 61;
            LabelVariedade.Text = "Variedade:";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(102, 61);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(43, 15);
            LabelNome.TabIndex = 60;
            LabelNome.Text = "Nome:";
            // 
            // MaskedTextBoxTempoTradicional
            // 
            MaskedTextBoxTempoTradicional.Culture = new System.Globalization.CultureInfo("");
            MaskedTextBoxTempoTradicional.Location = new Point(151, 145);
            MaskedTextBoxTempoTradicional.Mask = "000";
            MaskedTextBoxTempoTradicional.Name = "MaskedTextBoxTempoTradicional";
            MaskedTextBoxTempoTradicional.Size = new Size(70, 23);
            MaskedTextBoxTempoTradicional.TabIndex = 3;
            // 
            // TextBoxVariedade
            // 
            TextBoxVariedade.Location = new Point(151, 87);
            TextBoxVariedade.Name = "TextBoxVariedade";
            TextBoxVariedade.Size = new Size(138, 23);
            TextBoxVariedade.TabIndex = 1;
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(151, 58);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(138, 23);
            TextBoxNome.TabIndex = 0;
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(255, 100, 100);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(224, 212);
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
            BotaoConfirmar.Location = new Point(52, 212);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(90, 30);
            BotaoConfirmar.TabIndex = 5;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            BotaoConfirmar.Click += BotaoConfirmar_Click;
            // 
            // LabelTempoControlado
            // 
            LabelTempoControlado.AutoSize = true;
            LabelTempoControlado.Location = new Point(27, 177);
            LabelTempoControlado.Name = "LabelTempoControlado";
            LabelTempoControlado.Size = new Size(109, 15);
            LabelTempoControlado.TabIndex = 67;
            LabelTempoControlado.Text = "Tempo Controlado:";
            // 
            // MaskedTextBoxTempoControlado
            // 
            MaskedTextBoxTempoControlado.Culture = new System.Globalization.CultureInfo("");
            MaskedTextBoxTempoControlado.Location = new Point(151, 174);
            MaskedTextBoxTempoControlado.Mask = "000";
            MaskedTextBoxTempoControlado.Name = "MaskedTextBoxTempoControlado";
            MaskedTextBoxTempoControlado.Size = new Size(70, 23);
            MaskedTextBoxTempoControlado.TabIndex = 4;
            // 
            // TelaCadastrarCultivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 252);
            Controls.Add(MaskedTextBoxTempoControlado);
            Controls.Add(LabelTempoControlado);
            Controls.Add(ComboBoxCategoria);
            Controls.Add(LabelTempoTradicional);
            Controls.Add(LabelCategoria);
            Controls.Add(LabelVariedade);
            Controls.Add(LabelNome);
            Controls.Add(MaskedTextBoxTempoTradicional);
            Controls.Add(TextBoxVariedade);
            Controls.Add(TextBoxNome);
            Controls.Add(BotaoCancelar);
            Controls.Add(BotaoConfirmar);
            Controls.Add(PanelHeader);
            Name = "TelaCadastrarCultivo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Cultivo";
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelHeader;
        private Label LabelCadastrarCultivo;
        private ComboBox ComboBoxCategoria;
        private Label LabelTempoTradicional;
        private Label LabelCategoria;
        private Label LabelVariedade;
        private Label LabelNome;
        private MaskedTextBox MaskedTextBoxTempoTradicional;
        private TextBox TextBoxVariedade;
        private TextBox TextBoxNome;
        private Button BotaoCancelar;
        private Button BotaoConfirmar;
        private Label LabelTempoControlado;
        private MaskedTextBox MaskedTextBoxTempoControlado;
    }
}