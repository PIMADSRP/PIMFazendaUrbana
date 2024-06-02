namespace PIMFazendaUrbanaForms.Interface
{
    partial class TelaCadastrarVenda
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
            BotaoCancelar = new Button();
            BotaoConfirmar = new Button();
            ComboBoxUnidade = new ComboBox();
            LabelUnidade = new Label();
            ComboBoxCategoria = new ComboBox();
            LabelCategoria = new Label();
            LabelNome = new Label();
            PanelHeader = new Panel();
            LabelCadastrarProdutos = new Label();
            label1 = new Label();
            comboBoxProduto = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            TextBoxQuantidade = new TextBox();
            textBoxValor = new TextBox();
            textBoxValorTotal = new TextBox();
            label4 = new Label();
            comboBoxCliente = new ComboBox();
            PanelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(255, 100, 100);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(212, 295);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(80, 30);
            BotaoCancelar.TabIndex = 61;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // BotaoConfirmar
            // 
            BotaoConfirmar.BackColor = Color.FromArgb(80, 200, 85);
            BotaoConfirmar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoConfirmar.ForeColor = Color.White;
            BotaoConfirmar.Location = new Point(52, 294);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(90, 30);
            BotaoConfirmar.TabIndex = 60;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            // 
            // ComboBoxUnidade
            // 
            ComboBoxUnidade.FormattingEnabled = true;
            ComboBoxUnidade.Items.AddRange(new object[] { "kg", "g", "l", "ml", "m", "cm", "mm", "unidade", "caixa", "tambor" });
            ComboBoxUnidade.Location = new Point(101, 166);
            ComboBoxUnidade.Name = "ComboBoxUnidade";
            ComboBoxUnidade.Size = new Size(86, 23);
            ComboBoxUnidade.TabIndex = 59;
            // 
            // LabelUnidade
            // 
            LabelUnidade.AutoSize = true;
            LabelUnidade.Location = new Point(43, 170);
            LabelUnidade.Name = "LabelUnidade";
            LabelUnidade.Size = new Size(54, 15);
            LabelUnidade.TabIndex = 65;
            LabelUnidade.Text = "Unidade:";
            // 
            // ComboBoxCategoria
            // 
            ComboBoxCategoria.FormattingEnabled = true;
            ComboBoxCategoria.Items.AddRange(new object[] { "Sementes", "Fertilizantes" });
            ComboBoxCategoria.Location = new Point(101, 137);
            ComboBoxCategoria.Name = "ComboBoxCategoria";
            ComboBoxCategoria.Size = new Size(86, 23);
            ComboBoxCategoria.TabIndex = 58;
            // 
            // LabelCategoria
            // 
            LabelCategoria.AutoSize = true;
            LabelCategoria.Location = new Point(36, 141);
            LabelCategoria.Name = "LabelCategoria";
            LabelCategoria.Size = new Size(61, 15);
            LabelCategoria.TabIndex = 64;
            LabelCategoria.Text = "Categoria:";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(44, 112);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(53, 15);
            LabelNome.TabIndex = 63;
            LabelNome.Text = "Produto:";
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelCadastrarProdutos);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(360, 41);
            PanelHeader.TabIndex = 62;
            // 
            // LabelCadastrarProdutos
            // 
            LabelCadastrarProdutos.AutoSize = true;
            LabelCadastrarProdutos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarProdutos.ForeColor = SystemColors.ButtonHighlight;
            LabelCadastrarProdutos.Location = new Point(85, 8);
            LabelCadastrarProdutos.Name = "LabelCadastrarProdutos";
            LabelCadastrarProdutos.Size = new Size(158, 25);
            LabelCadastrarProdutos.TabIndex = 52;
            LabelCadastrarProdutos.Text = "Cadastrar Venda";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 83);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 67;
            label1.Text = "Cliente:";
            // 
            // comboBoxProduto
            // 
            comboBoxProduto.FormattingEnabled = true;
            comboBoxProduto.Items.AddRange(new object[] { "Sementes", "Fertilizantes" });
            comboBoxProduto.Location = new Point(101, 108);
            comboBoxProduto.Name = "comboBoxProduto";
            comboBoxProduto.Size = new Size(182, 23);
            comboBoxProduto.TabIndex = 69;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 227);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 70;
            label2.Text = "Valor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 198);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 71;
            label3.Text = "Quantidade:";
            // 
            // TextBoxQuantidade
            // 
            TextBoxQuantidade.Location = new Point(101, 195);
            TextBoxQuantidade.Name = "TextBoxQuantidade";
            TextBoxQuantidade.Size = new Size(86, 23);
            TextBoxQuantidade.TabIndex = 72;
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(101, 224);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(86, 23);
            textBoxValor.TabIndex = 73;
            // 
            // textBoxValorTotal
            // 
            textBoxValorTotal.Location = new Point(101, 253);
            textBoxValorTotal.Name = "textBoxValorTotal";
            textBoxValorTotal.Size = new Size(86, 23);
            textBoxValorTotal.TabIndex = 75;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 256);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 74;
            label4.Text = "Valor Total:";
            // 
            // comboBoxCliente
            // 
            comboBoxCliente.FormattingEnabled = true;
            comboBoxCliente.Location = new Point(101, 79);
            comboBoxCliente.Name = "comboBoxCliente";
            comboBoxCliente.Size = new Size(182, 23);
            comboBoxCliente.TabIndex = 68;
            // 
            // TelaCadastrarVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 341);
            Controls.Add(textBoxValorTotal);
            Controls.Add(label4);
            Controls.Add(textBoxValor);
            Controls.Add(TextBoxQuantidade);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxProduto);
            Controls.Add(comboBoxCliente);
            Controls.Add(label1);
            Controls.Add(BotaoCancelar);
            Controls.Add(BotaoConfirmar);
            Controls.Add(ComboBoxUnidade);
            Controls.Add(LabelUnidade);
            Controls.Add(ComboBoxCategoria);
            Controls.Add(LabelCategoria);
            Controls.Add(LabelNome);
            Controls.Add(PanelHeader);
            Name = "TelaCadastrarVenda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Venda";
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotaoCancelar;
        private Button BotaoConfirmar;
        private ComboBox ComboBoxUnidade;
        private Label LabelUnidade;
        private ComboBox ComboBoxCategoria;
        private Label LabelCategoria;
        private Label LabelNome;
        private Panel PanelHeader;
        private Label LabelCadastrarProdutos;
        private Label label1;
        private ComboBox comboBoxProduto;
        private Label label2;
        private Label label3;
        private TextBox TextBoxQuantidade;
        private TextBox textBoxValor;
        private TextBox textBoxValorTotal;
        private Label label4;
        private ComboBox comboBoxCliente;
    }
}