namespace PIMFazendaUrbanaForms
{
    partial class TelaCadastrarCompra
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
            LabelCadastrarCompra = new Label();
            LabelCategoria = new Label();
            ComboBoxProduto = new ComboBox();
            LabelProduto = new Label();
            LabelFornecedor = new Label();
            BotaoCancelar = new Button();
            BotaoConfirmar = new Button();
            ComboBoxFornecedor = new ComboBox();
            LabelQuantidade = new Label();
            TextBoxQuantidade = new TextBox();
            LabelValorUnitario = new Label();
            TextBoxValor = new TextBox();
            LabelValorTotal = new Label();
            TextBoxValorTotal = new TextBox();
            LabelUnidade = new Label();
            TextBoxUnidade = new TextBox();
            TextBoxCategoria = new TextBox();
            PanelHeader.SuspendLayout();
            SuspendLayout();

            // CÓDIGO NOVO
            ComboBoxProduto.SelectedIndexChanged += ComboBoxProduto_SelectedIndexChanged;

            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelCadastrarCompra);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(351, 41);
            PanelHeader.TabIndex = 61;
            // 
            // LabelCadastrarCompra
            // 
            LabelCadastrarCompra.AutoSize = true;
            LabelCadastrarCompra.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarCompra.ForeColor = SystemColors.ButtonHighlight;
            LabelCadastrarCompra.Location = new Point(94, 9);
            LabelCadastrarCompra.Name = "LabelCadastrarCompra";
            LabelCadastrarCompra.Size = new Size(173, 25);
            LabelCadastrarCompra.TabIndex = 55;
            LabelCadastrarCompra.Text = "Cadastrar Compra";
            // 
            // LabelCategoria
            // 
            LabelCategoria.AutoSize = true;
            LabelCategoria.Location = new Point(55, 135);
            LabelCategoria.Name = "LabelCategoria";
            LabelCategoria.Size = new Size(61, 15);
            LabelCategoria.TabIndex = 71;
            LabelCategoria.Text = "Categoria:";
            // 
            // ComboBoxProduto
            // 
            ComboBoxProduto.FormattingEnabled = true;
            ComboBoxProduto.Location = new Point(124, 99);
            ComboBoxProduto.Name = "ComboBoxProduto";
            ComboBoxProduto.Size = new Size(182, 23);
            ComboBoxProduto.TabIndex = 1;
            // 
            // LabelProduto
            // 
            LabelProduto.AutoSize = true;
            LabelProduto.Location = new Point(62, 102);
            LabelProduto.Name = "LabelProduto";
            LabelProduto.Size = new Size(53, 15);
            LabelProduto.TabIndex = 70;
            LabelProduto.Text = "Produto:";
            // 
            // LabelFornecedor
            // 
            LabelFornecedor.AutoSize = true;
            LabelFornecedor.Location = new Point(46, 69);
            LabelFornecedor.Name = "LabelFornecedor";
            LabelFornecedor.Size = new Size(70, 15);
            LabelFornecedor.TabIndex = 69;
            LabelFornecedor.Text = "Fornecedor:";
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(255, 100, 100);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(210, 310);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(80, 30);
            BotaoCancelar.TabIndex = 8;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // BotaoConfirmar
            // 
            BotaoConfirmar.BackColor = Color.FromArgb(80, 200, 85);
            BotaoConfirmar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoConfirmar.ForeColor = Color.White;
            BotaoConfirmar.Location = new Point(54, 310);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(90, 30);
            BotaoConfirmar.TabIndex = 7;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            BotaoConfirmar.Click += BotaoConfirmar_Click;
            // 
            // ComboBoxFornecedor
            // 
            ComboBoxFornecedor.FormattingEnabled = true;
            ComboBoxFornecedor.Location = new Point(124, 66);
            ComboBoxFornecedor.Name = "ComboBoxFornecedor";
            ComboBoxFornecedor.Size = new Size(182, 23);
            ComboBoxFornecedor.TabIndex = 0;
            // 
            // LabelQuantidade
            // 
            LabelQuantidade.AutoSize = true;
            LabelQuantidade.Location = new Point(44, 197);
            LabelQuantidade.Name = "LabelQuantidade";
            LabelQuantidade.Size = new Size(72, 15);
            LabelQuantidade.TabIndex = 76;
            LabelQuantidade.Text = "Quantidade:";
            // 
            // TextBoxQuantidade
            // 
            TextBoxQuantidade.Location = new Point(124, 195);
            TextBoxQuantidade.Name = "TextBoxQuantidade";
            TextBoxQuantidade.Size = new Size(86, 23);
            TextBoxQuantidade.TabIndex = 4;
            TextBoxQuantidade.TextChanged += TextBoxQuantidade_TextChanged;
            // 
            // LabelValorUnitario
            // 
            LabelValorUnitario.AutoSize = true;
            LabelValorUnitario.Location = new Point(35, 232);
            LabelValorUnitario.Name = "LabelValorUnitario";
            LabelValorUnitario.Size = new Size(80, 15);
            LabelValorUnitario.TabIndex = 78;
            LabelValorUnitario.Text = "Valor unitário:";
            // 
            // TextBoxValor
            // 
            TextBoxValor.Location = new Point(124, 229);
            TextBoxValor.Name = "TextBoxValor";
            TextBoxValor.Size = new Size(86, 23);
            TextBoxValor.TabIndex = 5;
            TextBoxValor.TextChanged += TextBoxValorUnitario_TextChanged;
            // 
            // LabelValorTotal
            // 
            LabelValorTotal.AutoSize = true;
            LabelValorTotal.Location = new Point(51, 263);
            LabelValorTotal.Name = "LabelValorTotal";
            LabelValorTotal.Size = new Size(64, 15);
            LabelValorTotal.TabIndex = 80;
            LabelValorTotal.Text = "Valor Total:";
            // 
            // TextBoxValorTotal
            // 
            TextBoxValorTotal.BackColor = SystemColors.ControlLightLight;
            TextBoxValorTotal.Enabled = false;
            TextBoxValorTotal.Location = new Point(124, 263);
            TextBoxValorTotal.Name = "TextBoxValorTotal";
            TextBoxValorTotal.ReadOnly = true;
            TextBoxValorTotal.Size = new Size(86, 23);
            TextBoxValorTotal.TabIndex = 6;
            TextBoxValorTotal.TextChanged += TextBoxValorTotal_TextChanged;
            // 
            // LabelUnidade
            // 
            LabelUnidade.AutoSize = true;
            LabelUnidade.Location = new Point(55, 166);
            LabelUnidade.Name = "LabelUnidade";
            LabelUnidade.Size = new Size(54, 15);
            LabelUnidade.TabIndex = 82;
            LabelUnidade.Text = "Unidade:";
            // 
            // TextBoxUnidade
            // 
            TextBoxUnidade.BackColor = SystemColors.ControlLightLight;
            TextBoxUnidade.Enabled = false;
            TextBoxUnidade.Location = new Point(124, 161);
            TextBoxUnidade.Name = "TextBoxUnidade";
            TextBoxUnidade.ReadOnly = true;
            TextBoxUnidade.Size = new Size(86, 23);
            TextBoxUnidade.TabIndex = 3;
            TextBoxUnidade.TextChanged += TextBoxUnidade_TextChanged;
            // 
            // TextBoxCategoria
            // 
            TextBoxCategoria.BackColor = SystemColors.ControlLightLight;
            TextBoxCategoria.Enabled = false;
            TextBoxCategoria.Location = new Point(124, 132);
            TextBoxCategoria.Name = "TextBoxCategoria";
            TextBoxCategoria.ReadOnly = true;
            TextBoxCategoria.Size = new Size(86, 23);
            TextBoxCategoria.TabIndex = 2;
            // 
            // TelaCadastrarCompra
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(351, 352);
            Controls.Add(TextBoxCategoria);
            Controls.Add(TextBoxUnidade);
            Controls.Add(LabelUnidade);
            Controls.Add(LabelValorTotal);
            Controls.Add(TextBoxValorTotal);
            Controls.Add(LabelValorUnitario);
            Controls.Add(TextBoxValor);
            Controls.Add(LabelQuantidade);
            Controls.Add(TextBoxQuantidade);
            Controls.Add(ComboBoxFornecedor);
            Controls.Add(BotaoCancelar);
            Controls.Add(BotaoConfirmar);
            Controls.Add(PanelHeader);
            Controls.Add(LabelCategoria);
            Controls.Add(ComboBoxProduto);
            Controls.Add(LabelProduto);
            Controls.Add(LabelFornecedor);
            Name = "TelaCadastrarCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaCadastrarCompra";
            Load += TelaCadastrarCompra_Load;
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelHeader;
        private Label LabelCadastrarCompra;
        private Label LabelCategoria;
        private ComboBox ComboBoxProduto;
        private Label LabelProduto;
        private Label LabelFornecedor;
        private Button BotaoCancelar;
        private Button BotaoConfirmar;
        private ComboBox ComboBoxFornecedor;
        private Label LabelQuantidade;
        private TextBox TextBoxQuantidade;
        private Label LabelValorUnitario;
        private TextBox TextBoxValor;
        private Label LabelValorTotal;
        private TextBox TextBoxValorTotal;
        private Label LabelUnidade;
        private TextBox TextBoxUnidade;
        private TextBox TextBoxCategoria;
    }
}
