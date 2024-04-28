namespace PIM_FazendaUrbana
{
    partial class TelaCadastrarCliente
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
            TextBoxNome = new TextBox();
            TextBoxEmail = new TextBox();
            LabelNome = new Label();
            LabelCNPJ = new Label();
            LabelEmail = new Label();
            BotaoOK = new Button();
            BotaoVoltar = new Button();
            TextBoxCNPJ = new MaskedTextBox();
            TextBoxDDD = new MaskedTextBox();
            TextBoxTelefone = new TextBox();
            LabelDDD = new Label();
            LabelTelefone = new Label();
            TextBoxLogradouro = new TextBox();
            TextBoxNumero = new TextBox();
            TextBoxComplemento = new TextBox();
            TextBoxBairro = new TextBox();
            TextBoxCidade = new TextBox();
            TextBoxUF = new TextBox();
            TextBoxCEP = new MaskedTextBox();
            LabelLogradouro = new Label();
            LabelNumero = new Label();
            LabelComplemento = new Label();
            LabelBairro = new Label();
            LabelCidade = new Label();
            LabelUF = new Label();
            LabelCEP = new Label();
            SuspendLayout();
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(71, 56);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(190, 23);
            TextBoxNome.TabIndex = 0;
            TextBoxNome.Validating += TextBoxNome_Validating;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(71, 192);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(190, 23);
            TextBoxEmail.TabIndex = 3;
            TextBoxEmail.Validating += TextBoxEmail_Validating;
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(71, 38);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(40, 15);
            LabelNome.TabIndex = 3;
            LabelNome.Text = "Nome";
            // 
            // LabelCNPJ
            // 
            LabelCNPJ.AutoSize = true;
            LabelCNPJ.Location = new Point(71, 108);
            LabelCNPJ.Name = "LabelCNPJ";
            LabelCNPJ.Size = new Size(34, 15);
            LabelCNPJ.TabIndex = 4;
            LabelCNPJ.Text = "CNPJ";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(71, 174);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(41, 15);
            LabelEmail.TabIndex = 5;
            LabelEmail.Text = "E-mail";
            // 
            // BotaoOK
            // 
            BotaoOK.Location = new Point(617, 381);
            BotaoOK.Name = "BotaoOK";
            BotaoOK.Size = new Size(75, 23);
            BotaoOK.TabIndex = 14;
            BotaoOK.Text = "OK";
            BotaoOK.UseVisualStyleBackColor = true;
            BotaoOK.Click += BotaoOK_Click;
            // 
            // BotaoVoltar
            // 
            BotaoVoltar.Location = new Point(71, 381);
            BotaoVoltar.Name = "BotaoVoltar";
            BotaoVoltar.Size = new Size(75, 23);
            BotaoVoltar.TabIndex = 13;
            BotaoVoltar.Text = "Voltar";
            BotaoVoltar.UseVisualStyleBackColor = true;
            BotaoVoltar.Click += BotaoVoltar_Click;
            // 
            // TextBoxCNPJ
            // 
            TextBoxCNPJ.Culture = new System.Globalization.CultureInfo("");
            TextBoxCNPJ.Location = new Point(71, 126);
            TextBoxCNPJ.Mask = "00.000.000/0000-00";
            TextBoxCNPJ.Name = "TextBoxCNPJ";
            TextBoxCNPJ.Size = new Size(115, 23);
            TextBoxCNPJ.TabIndex = 2;
            TextBoxCNPJ.Validating += TextBoxCNPJ_Validating;
            // 
            // TextBoxDDD
            // 
            TextBoxDDD.Location = new Point(71, 264);
            TextBoxDDD.Mask = "00";
            TextBoxDDD.Name = "TextBoxDDD";
            TextBoxDDD.Size = new Size(31, 23);
            TextBoxDDD.TabIndex = 4;
            TextBoxDDD.Validating += TextBoxDDD_Validating;
            // 
            // TextBoxTelefone
            // 
            TextBoxTelefone.Location = new Point(108, 264);
            TextBoxTelefone.Name = "TextBoxTelefone";
            TextBoxTelefone.Size = new Size(111, 23);
            TextBoxTelefone.TabIndex = 5;
            TextBoxTelefone.Validating += TextBoxTelefone_Validating;
            // 
            // LabelDDD
            // 
            LabelDDD.AutoSize = true;
            LabelDDD.Location = new Point(71, 246);
            LabelDDD.Name = "LabelDDD";
            LabelDDD.Size = new Size(31, 15);
            LabelDDD.TabIndex = 10;
            LabelDDD.Text = "DDD";
            // 
            // LabelTelefone
            // 
            LabelTelefone.AutoSize = true;
            LabelTelefone.Location = new Point(108, 246);
            LabelTelefone.Name = "LabelTelefone";
            LabelTelefone.Size = new Size(51, 15);
            LabelTelefone.TabIndex = 11;
            LabelTelefone.Text = "Telefone";
            // 
            // TextBoxLogradouro
            // 
            TextBoxLogradouro.Location = new Point(347, 56);
            TextBoxLogradouro.Name = "TextBoxLogradouro";
            TextBoxLogradouro.Size = new Size(200, 23);
            TextBoxLogradouro.TabIndex = 6;
            // 
            // TextBoxNumero
            // 
            TextBoxNumero.Location = new Point(347, 117);
            TextBoxNumero.Name = "TextBoxNumero";
            TextBoxNumero.Size = new Size(55, 23);
            TextBoxNumero.TabIndex = 7;
            TextBoxNumero.Validating += TextBoxNumero_Validating;
            // 
            // TextBoxComplemento
            // 
            TextBoxComplemento.Location = new Point(408, 117);
            TextBoxComplemento.Name = "TextBoxComplemento";
            TextBoxComplemento.Size = new Size(139, 23);
            TextBoxComplemento.TabIndex = 8;
            // 
            // TextBoxBairro
            // 
            TextBoxBairro.Location = new Point(347, 181);
            TextBoxBairro.Name = "TextBoxBairro";
            TextBoxBairro.Size = new Size(139, 23);
            TextBoxBairro.TabIndex = 9;
            // 
            // TextBoxCidade
            // 
            TextBoxCidade.Location = new Point(347, 243);
            TextBoxCidade.Name = "TextBoxCidade";
            TextBoxCidade.Size = new Size(200, 23);
            TextBoxCidade.TabIndex = 10;
            // 
            // TextBoxUF
            // 
            TextBoxUF.Location = new Point(347, 307);
            TextBoxUF.Name = "TextBoxUF";
            TextBoxUF.Size = new Size(44, 23);
            TextBoxUF.TabIndex = 11;
            TextBoxUF.Validating += TextBoxUF_Validating;
            // 
            // TextBoxCEP
            // 
            TextBoxCEP.Culture = new System.Globalization.CultureInfo("");
            TextBoxCEP.Location = new Point(408, 307);
            TextBoxCEP.Mask = "00000-000";
            TextBoxCEP.Name = "TextBoxCEP";
            TextBoxCEP.Size = new Size(96, 23);
            TextBoxCEP.TabIndex = 12;
            TextBoxCEP.Validating += TextBoxCEP_Validating;
            // 
            // LabelLogradouro
            // 
            LabelLogradouro.AutoSize = true;
            LabelLogradouro.Location = new Point(347, 38);
            LabelLogradouro.Name = "LabelLogradouro";
            LabelLogradouro.Size = new Size(69, 15);
            LabelLogradouro.TabIndex = 19;
            LabelLogradouro.Text = "Logradouro";
            // 
            // LabelNumero
            // 
            LabelNumero.AutoSize = true;
            LabelNumero.Location = new Point(347, 99);
            LabelNumero.Name = "LabelNumero";
            LabelNumero.Size = new Size(51, 15);
            LabelNumero.TabIndex = 20;
            LabelNumero.Text = "Número";
            // 
            // LabelComplemento
            // 
            LabelComplemento.AutoSize = true;
            LabelComplemento.Location = new Point(408, 99);
            LabelComplemento.Name = "LabelComplemento";
            LabelComplemento.Size = new Size(84, 15);
            LabelComplemento.TabIndex = 21;
            LabelComplemento.Text = "Complemento";
            // 
            // LabelBairro
            // 
            LabelBairro.AutoSize = true;
            LabelBairro.Location = new Point(347, 163);
            LabelBairro.Name = "LabelBairro";
            LabelBairro.Size = new Size(38, 15);
            LabelBairro.TabIndex = 22;
            LabelBairro.Text = "Bairro";
            // 
            // LabelCidade
            // 
            LabelCidade.AutoSize = true;
            LabelCidade.Location = new Point(347, 225);
            LabelCidade.Name = "LabelCidade";
            LabelCidade.Size = new Size(44, 15);
            LabelCidade.TabIndex = 23;
            LabelCidade.Text = "Cidade";
            // 
            // LabelUF
            // 
            LabelUF.AutoSize = true;
            LabelUF.Location = new Point(347, 287);
            LabelUF.Name = "LabelUF";
            LabelUF.Size = new Size(21, 15);
            LabelUF.TabIndex = 24;
            LabelUF.Text = "UF";
            // 
            // LabelCEP
            // 
            LabelCEP.AutoSize = true;
            LabelCEP.Location = new Point(408, 289);
            LabelCEP.Name = "LabelCEP";
            LabelCEP.Size = new Size(28, 15);
            LabelCEP.TabIndex = 25;
            LabelCEP.Text = "CEP";
            // 
            // TelaCadastrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LabelCEP);
            Controls.Add(LabelUF);
            Controls.Add(LabelCidade);
            Controls.Add(LabelBairro);
            Controls.Add(LabelComplemento);
            Controls.Add(LabelNumero);
            Controls.Add(LabelLogradouro);
            Controls.Add(TextBoxCEP);
            Controls.Add(TextBoxUF);
            Controls.Add(TextBoxCidade);
            Controls.Add(TextBoxBairro);
            Controls.Add(TextBoxComplemento);
            Controls.Add(TextBoxNumero);
            Controls.Add(TextBoxLogradouro);
            Controls.Add(LabelTelefone);
            Controls.Add(LabelDDD);
            Controls.Add(TextBoxTelefone);
            Controls.Add(TextBoxDDD);
            Controls.Add(TextBoxCNPJ);
            Controls.Add(BotaoVoltar);
            Controls.Add(BotaoOK);
            Controls.Add(LabelNome);
            Controls.Add(LabelCNPJ);
            Controls.Add(LabelEmail);
            Controls.Add(TextBoxEmail);
            Controls.Add(TextBoxNome);
            Name = "TelaCadastrarCliente";
            Text = "CadastrarCliente";
            Load += TelaCadastrarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxNome;
        private TextBox TextBoxEmail;
        private Label LabelNome;
        private Label LabelCNPJ;
        private Label LabelEmail;
        private Button BotaoOK;
        private Button BotaoVoltar;
        private MaskedTextBox TextBoxCNPJ;
        private MaskedTextBox TextBoxDDD;
        private TextBox TextBoxTelefone;
        private Label LabelDDD;
        private Label LabelTelefone;
        private TextBox TextBoxLogradouro;
        private TextBox TextBoxNumero;
        private TextBox TextBoxComplemento;
        private TextBox TextBoxBairro;
        private TextBox TextBoxCidade;
        private TextBox TextBoxUF;
        private MaskedTextBox TextBoxCEP;
        private Label LabelLogradouro;
        private Label LabelNumero;
        private Label LabelComplemento;
        private Label LabelBairro;
        private Label LabelCidade;
        private Label LabelUF;
        private Label LabelCEP;
    }
}