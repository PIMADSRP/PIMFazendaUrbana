namespace PIMFazendaUrbana
{
    partial class TelaIndicarPlantio
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
            txtBox_Data = new MaskedTextBox();
            lb_dataPlantio = new Label();
            pn_indicacoes = new Panel();
            lb_indicacoes = new Label();
            btnRecomendar = new Button();
            label3 = new Label();
            BotaoCancelar = new Button();
            cb_Regiao = new ComboBox();
            label2 = new Label();
            panel2 = new Panel();
            pn_indicacoes.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtBox_Data
            // 
            txtBox_Data.Culture = new System.Globalization.CultureInfo("");
            txtBox_Data.Location = new Point(142, 117);
            txtBox_Data.Mask = "00/00/0000";
            txtBox_Data.Name = "txtBox_Data";
            txtBox_Data.Size = new Size(92, 23);
            txtBox_Data.TabIndex = 57;
            txtBox_Data.ValidatingType = typeof(DateTime);
            txtBox_Data.MaskInputRejected += txtBox_Data_MaskInputRejected;
            // 
            // lb_dataPlantio
            // 
            lb_dataPlantio.AutoSize = true;
            lb_dataPlantio.Location = new Point(42, 120);
            lb_dataPlantio.Name = "lb_dataPlantio";
            lb_dataPlantio.Size = new Size(94, 15);
            lb_dataPlantio.TabIndex = 56;
            lb_dataPlantio.Text = "Data do plantio :";
            // 
            // pn_indicacoes
            // 
            pn_indicacoes.BackColor = Color.FromArgb(55, 185, 65);
            pn_indicacoes.Controls.Add(lb_indicacoes);
            pn_indicacoes.Dock = DockStyle.Top;
            pn_indicacoes.Location = new Point(0, 0);
            pn_indicacoes.Name = "pn_indicacoes";
            pn_indicacoes.Size = new Size(279, 65);
            pn_indicacoes.TabIndex = 55;
            // 
            // lb_indicacoes
            // 
            lb_indicacoes.Anchor = AnchorStyles.None;
            lb_indicacoes.AutoSize = true;
            lb_indicacoes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_indicacoes.ForeColor = SystemColors.ButtonHighlight;
            lb_indicacoes.Location = new Point(61, 20);
            lb_indicacoes.Name = "lb_indicacoes";
            lb_indicacoes.Size = new Size(173, 25);
            lb_indicacoes.TabIndex = 23;
            lb_indicacoes.Text = "Indicações Plantio";
            lb_indicacoes.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnRecomendar
            // 
            btnRecomendar.BackColor = Color.FromArgb(80, 200, 85);
            btnRecomendar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecomendar.ForeColor = Color.White;
            btnRecomendar.Location = new Point(3, 147);
            btnRecomendar.Name = "btnRecomendar";
            btnRecomendar.Size = new Size(104, 30);
            btnRecomendar.TabIndex = 50;
            btnRecomendar.Text = "Recomendar";
            btnRecomendar.UseVisualStyleBackColor = false;
            btnRecomendar.Click += btnRecomendar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 6);
            label3.Name = "label3";
            label3.Size = new Size(156, 15);
            label3.TabIndex = 55;
            label3.Text = "Insira as informações abaixo";
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(220, 190, 70);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(117, 147);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(104, 30);
            BotaoCancelar.TabIndex = 56;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // cb_Regiao
            // 
            cb_Regiao.FormattingEnabled = true;
            cb_Regiao.Items.AddRange(new object[] { "Norte", "Nordeste", "Sul", "Sudeste", "Centro-oeste" });
            cb_Regiao.Location = new Point(113, 66);
            cb_Regiao.Name = "cb_Regiao";
            cb_Regiao.Size = new Size(92, 23);
            cb_Regiao.TabIndex = 61;
            cb_Regiao.SelectedIndexChanged += cb_Regiao_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 70);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 60;
            label2.Text = "Região : ";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cb_Regiao);
            panel2.Controls.Add(BotaoCancelar);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnRecomendar);
            panel2.Location = new Point(29, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(224, 180);
            panel2.TabIndex = 62;
            // 
            // IndicarPlantio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 281);
            Controls.Add(txtBox_Data);
            Controls.Add(lb_dataPlantio);
            Controls.Add(pn_indicacoes);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IndicarPlantio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IndicarPlantio";
            pn_indicacoes.ResumeLayout(false);
            pn_indicacoes.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaskedTextBox txtBox_Data;
        private Label lb_dataPlantio;
        private Panel pn_indicacoes;
        private Label lb_indicacoes;
        private Button btnRecomendar;
        private Label label3;
        private Button BotaoCancelar;
        private ComboBox cb_Regiao;
        private Label label2;
        private Panel panel2;
    }
}