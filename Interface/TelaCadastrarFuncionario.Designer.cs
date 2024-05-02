namespace PIMFazendaUrbana
{
    partial class TelaCadastrarFuncionario
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
            LabelCadastrarUsuarios = new Label();
            LabelNome = new Label();
            LabelEmail = new Label();
            TextBoxUsuario = new TextBox();
            LabelUsuario = new Label();
            TextBoxSenha1 = new TextBox();
            LabelSenha = new Label();
            LabelContato = new Label();
            LabelUF = new Label();
            TextBoxCodigo = new TextBox();
            LabelCodigo = new Label();
            LabelCidade = new Label();
            LabelLogradouro = new Label();
            LabelNumero = new Label();
            LabelComplemento = new Label();
            LabelSexo = new Label();
            ComboBoxSexo = new ComboBox();
            ComboBoxCargo = new ComboBox();
            LabelCargo = new Label();
            LabelBairro = new Label();
            LabelCEP = new Label();
            LabelDDD = new Label();
            BotaoConfirmar = new Button();
            BotaoCancelar = new Button();
            TextBoxNome = new TextBox();
            TextBoxEmail = new TextBox();
            TextBoxDDD = new MaskedTextBox();
            TextBoxTelefone = new TextBox();
            TextBoxLogradouro = new TextBox();
            TextBoxNumero = new TextBox();
            TextBoxComplemento = new TextBox();
            TextBoxBairro = new TextBox();
            TextBoxCidade = new TextBox();
            TextBoxCEP = new MaskedTextBox();
            TextBoxSenha2 = new TextBox();
            LabelSenha2 = new Label();
            ComboBoxUF = new ComboBox();
            PanelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.ForestGreen;
            PanelHeader.Controls.Add(LabelCadastrarUsuarios);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(433, 41);
            PanelHeader.TabIndex = 0;
            // 
            // LabelCadastrarUsuarios
            // 
            LabelCadastrarUsuarios.AutoSize = true;
            LabelCadastrarUsuarios.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarUsuarios.ForeColor = SystemColors.ControlText;
            LabelCadastrarUsuarios.Location = new Point(141, 9);
            LabelCadastrarUsuarios.Name = "LabelCadastrarUsuarios";
            LabelCadastrarUsuarios.Size = new Size(171, 25);
            LabelCadastrarUsuarios.TabIndex = 0;
            LabelCadastrarUsuarios.Text = "Cadastrar Usuário";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(65, 86);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(46, 15);
            LabelNome.TabIndex = 1;
            LabelNome.Text = "Nome: ";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(64, 115);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(47, 15);
            LabelEmail.TabIndex = 3;
            LabelEmail.Text = "E-mail: ";
            // 
            // TextBoxUsuario
            // 
            TextBoxUsuario.Location = new Point(112, 140);
            TextBoxUsuario.Name = "TextBoxUsuario";
            TextBoxUsuario.Size = new Size(200, 23);
            TextBoxUsuario.TabIndex = 4;
            TextBoxUsuario.Validating += TextBoxUsuario_Validating;
            // 
            // LabelUsuario
            // 
            LabelUsuario.AutoSize = true;
            LabelUsuario.Location = new Point(59, 144);
            LabelUsuario.Name = "LabelUsuario";
            LabelUsuario.Size = new Size(53, 15);
            LabelUsuario.TabIndex = 5;
            LabelUsuario.Text = "Usuário: ";
            // 
            // TextBoxSenha1
            // 
            TextBoxSenha1.Location = new Point(112, 170);
            TextBoxSenha1.Name = "TextBoxSenha1";
            TextBoxSenha1.Size = new Size(139, 23);
            TextBoxSenha1.TabIndex = 5;
            // 
            // LabelSenha
            // 
            LabelSenha.AutoSize = true;
            LabelSenha.Location = new Point(67, 173);
            LabelSenha.Name = "LabelSenha";
            LabelSenha.Size = new Size(45, 15);
            LabelSenha.TabIndex = 7;
            LabelSenha.Text = "Senha: ";
            // 
            // LabelContato
            // 
            LabelContato.AutoSize = true;
            LabelContato.Location = new Point(146, 289);
            LabelContato.Name = "LabelContato";
            LabelContato.Size = new Size(57, 15);
            LabelContato.TabIndex = 9;
            LabelContato.Text = "Telefone: ";
            // 
            // LabelUF
            // 
            LabelUF.AutoSize = true;
            LabelUF.Location = new Point(86, 461);
            LabelUF.Name = "LabelUF";
            LabelUF.Size = new Size(27, 15);
            LabelUF.TabIndex = 11;
            LabelUF.Text = "UF: ";
            // 
            // TextBoxCodigo
            // 
            TextBoxCodigo.Enabled = false;
            TextBoxCodigo.Location = new Point(112, 53);
            TextBoxCodigo.Name = "TextBoxCodigo";
            TextBoxCodigo.Size = new Size(55, 23);
            TextBoxCodigo.TabIndex = 1;
            // 
            // LabelCodigo
            // 
            LabelCodigo.AutoSize = true;
            LabelCodigo.Location = new Point(59, 57);
            LabelCodigo.Name = "LabelCodigo";
            LabelCodigo.Size = new Size(52, 15);
            LabelCodigo.TabIndex = 13;
            LabelCodigo.Text = "Código: ";
            // 
            // LabelCidade
            // 
            LabelCidade.AutoSize = true;
            LabelCidade.Location = new Point(63, 432);
            LabelCidade.Name = "LabelCidade";
            LabelCidade.Size = new Size(50, 15);
            LabelCidade.TabIndex = 15;
            LabelCidade.Text = "Cidade: ";
            // 
            // LabelLogradouro
            // 
            LabelLogradouro.AutoSize = true;
            LabelLogradouro.Location = new Point(38, 317);
            LabelLogradouro.Name = "LabelLogradouro";
            LabelLogradouro.Size = new Size(75, 15);
            LabelLogradouro.TabIndex = 17;
            LabelLogradouro.Text = "Logradouro: ";
            // 
            // LabelNumero
            // 
            LabelNumero.AutoSize = true;
            LabelNumero.Location = new Point(55, 346);
            LabelNumero.Name = "LabelNumero";
            LabelNumero.Size = new Size(57, 15);
            LabelNumero.TabIndex = 19;
            LabelNumero.Text = "Número: ";
            // 
            // LabelComplemento
            // 
            LabelComplemento.AutoSize = true;
            LabelComplemento.Location = new Point(23, 375);
            LabelComplemento.Name = "LabelComplemento";
            LabelComplemento.Size = new Size(90, 15);
            LabelComplemento.TabIndex = 21;
            LabelComplemento.Text = "Complemento: ";
            // 
            // LabelSexo
            // 
            LabelSexo.AutoSize = true;
            LabelSexo.Location = new Point(75, 230);
            LabelSexo.Name = "LabelSexo";
            LabelSexo.Size = new Size(38, 15);
            LabelSexo.TabIndex = 23;
            LabelSexo.Text = "Sexo: ";
            // 
            // ComboBoxSexo
            // 
            ComboBoxSexo.FormattingEnabled = true;
            ComboBoxSexo.Items.AddRange(new object[] { "M", "F", "-" });
            ComboBoxSexo.Location = new Point(112, 227);
            ComboBoxSexo.Name = "ComboBoxSexo";
            ComboBoxSexo.Size = new Size(55, 23);
            ComboBoxSexo.TabIndex = 7;
            ComboBoxSexo.Validating += ComboBoxSexo_Validating;
            // 
            // ComboBoxCargo
            // 
            ComboBoxCargo.FormattingEnabled = true;
            ComboBoxCargo.Items.AddRange(new object[] { "Funcionário", "Gerente" });
            ComboBoxCargo.Location = new Point(112, 256);
            ComboBoxCargo.Name = "ComboBoxCargo";
            ComboBoxCargo.Size = new Size(121, 23);
            ComboBoxCargo.TabIndex = 8;
            ComboBoxCargo.Validating += ComboBoxCargo_Validating;
            // 
            // LabelCargo
            // 
            LabelCargo.AutoSize = true;
            LabelCargo.Location = new Point(25, 261);
            LabelCargo.Name = "LabelCargo";
            LabelCargo.Size = new Size(88, 15);
            LabelCargo.TabIndex = 25;
            LabelCargo.Text = "Cargo Usuário: ";
            // 
            // LabelBairro
            // 
            LabelBairro.AutoSize = true;
            LabelBairro.Location = new Point(68, 403);
            LabelBairro.Name = "LabelBairro";
            LabelBairro.Size = new Size(44, 15);
            LabelBairro.TabIndex = 40;
            LabelBairro.Text = "Bairro: ";
            // 
            // LabelCEP
            // 
            LabelCEP.AutoSize = true;
            LabelCEP.Location = new Point(79, 491);
            LabelCEP.Name = "LabelCEP";
            LabelCEP.Size = new Size(34, 15);
            LabelCEP.TabIndex = 42;
            LabelCEP.Text = "CEP: ";
            // 
            // LabelDDD
            // 
            LabelDDD.AutoSize = true;
            LabelDDD.Location = new Point(74, 290);
            LabelDDD.Name = "LabelDDD";
            LabelDDD.Size = new Size(37, 15);
            LabelDDD.TabIndex = 45;
            LabelDDD.Text = "DDD: ";
            // 
            // BotaoConfirmar
            // 
            BotaoConfirmar.BackColor = Color.ForestGreen;
            BotaoConfirmar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoConfirmar.ForeColor = SystemColors.ControlText;
            BotaoConfirmar.Location = new Point(109, 529);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(96, 37);
            BotaoConfirmar.TabIndex = 18;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            BotaoConfirmar.Click += BotaoConfirmar_Click;
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.Yellow;
            BotaoCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.Location = new Point(279, 529);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(96, 37);
            BotaoCancelar.TabIndex = 19;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(112, 82);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(263, 23);
            TextBoxNome.TabIndex = 2;
            TextBoxNome.Validating += TextBoxNome_Validating;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(112, 112);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(262, 23);
            TextBoxEmail.TabIndex = 3;
            TextBoxEmail.Validating += TextBoxEmail_Validating;
            // 
            // TextBoxDDD
            // 
            TextBoxDDD.Location = new Point(112, 285);
            TextBoxDDD.Mask = "00";
            TextBoxDDD.Name = "TextBoxDDD";
            TextBoxDDD.Size = new Size(31, 23);
            TextBoxDDD.TabIndex = 9;
            TextBoxDDD.Validating += TextBoxDDD_Validating;
            // 
            // TextBoxTelefone
            // 
            TextBoxTelefone.Location = new Point(201, 285);
            TextBoxTelefone.Name = "TextBoxTelefone";
            TextBoxTelefone.Size = new Size(111, 23);
            TextBoxTelefone.TabIndex = 10;
            TextBoxTelefone.Validating += TextBoxTelefone_Validating;
            // 
            // TextBoxLogradouro
            // 
            TextBoxLogradouro.Location = new Point(112, 314);
            TextBoxLogradouro.Name = "TextBoxLogradouro";
            TextBoxLogradouro.Size = new Size(262, 23);
            TextBoxLogradouro.TabIndex = 11;
            TextBoxLogradouro.Validating += TextBoxLogradouro_Validating;
            // 
            // TextBoxNumero
            // 
            TextBoxNumero.Location = new Point(112, 343);
            TextBoxNumero.Name = "TextBoxNumero";
            TextBoxNumero.Size = new Size(55, 23);
            TextBoxNumero.TabIndex = 12;
            TextBoxNumero.Validating += TextBoxNumero_Validating;
            // 
            // TextBoxComplemento
            // 
            TextBoxComplemento.Location = new Point(112, 372);
            TextBoxComplemento.Name = "TextBoxComplemento";
            TextBoxComplemento.Size = new Size(139, 23);
            TextBoxComplemento.TabIndex = 13;
            // 
            // TextBoxBairro
            // 
            TextBoxBairro.Location = new Point(112, 400);
            TextBoxBairro.Name = "TextBoxBairro";
            TextBoxBairro.Size = new Size(139, 23);
            TextBoxBairro.TabIndex = 14;
            TextBoxBairro.Validating += TextBoxBairro_Validating;
            // 
            // TextBoxCidade
            // 
            TextBoxCidade.Location = new Point(112, 429);
            TextBoxCidade.Name = "TextBoxCidade";
            TextBoxCidade.Size = new Size(262, 23);
            TextBoxCidade.TabIndex = 15;
            TextBoxCidade.Validating += TextBoxCidade_Validating;
            // 
            // TextBoxCEP
            // 
            TextBoxCEP.Culture = new System.Globalization.CultureInfo("");
            TextBoxCEP.Location = new Point(112, 488);
            TextBoxCEP.Mask = "00000-000";
            TextBoxCEP.Name = "TextBoxCEP";
            TextBoxCEP.Size = new Size(96, 23);
            TextBoxCEP.TabIndex = 17;
            TextBoxCEP.Validating += TextBoxCEP_Validating;
            // 
            // TextBoxSenha2
            // 
            TextBoxSenha2.Location = new Point(112, 198);
            TextBoxSenha2.Name = "TextBoxSenha2";
            TextBoxSenha2.Size = new Size(139, 23);
            TextBoxSenha2.TabIndex = 6;
            TextBoxSenha2.Validating += TextBoxSenha2_Validating;
            // 
            // LabelSenha2
            // 
            LabelSenha2.AutoSize = true;
            LabelSenha2.Location = new Point(6, 201);
            LabelSenha2.Name = "LabelSenha2";
            LabelSenha2.Size = new Size(106, 15);
            LabelSenha2.TabIndex = 47;
            LabelSenha2.Text = "Confirme a senha: ";
            // 
            // ComboBoxUF
            // 
            ComboBoxUF.FormattingEnabled = true;
            ComboBoxUF.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            ComboBoxUF.Location = new Point(112, 458);
            ComboBoxUF.Name = "ComboBoxUF";
            ComboBoxUF.Size = new Size(55, 23);
            ComboBoxUF.TabIndex = 16;
            ComboBoxUF.Validating += ComboBoxUF_Validating;
            // 
            // TelaCadastrarFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(433, 575);
            Controls.Add(ComboBoxUF);
            Controls.Add(LabelSenha2);
            Controls.Add(TextBoxSenha2);
            Controls.Add(TextBoxCEP);
            Controls.Add(TextBoxCidade);
            Controls.Add(TextBoxBairro);
            Controls.Add(TextBoxComplemento);
            Controls.Add(TextBoxNumero);
            Controls.Add(TextBoxLogradouro);
            Controls.Add(TextBoxTelefone);
            Controls.Add(TextBoxDDD);
            Controls.Add(TextBoxEmail);
            Controls.Add(TextBoxNome);
            Controls.Add(BotaoCancelar);
            Controls.Add(BotaoConfirmar);
            Controls.Add(LabelDDD);
            Controls.Add(LabelCEP);
            Controls.Add(LabelBairro);
            Controls.Add(ComboBoxCargo);
            Controls.Add(LabelCargo);
            Controls.Add(ComboBoxSexo);
            Controls.Add(LabelSexo);
            Controls.Add(LabelComplemento);
            Controls.Add(LabelNumero);
            Controls.Add(LabelLogradouro);
            Controls.Add(LabelCidade);
            Controls.Add(TextBoxCodigo);
            Controls.Add(LabelCodigo);
            Controls.Add(LabelUF);
            Controls.Add(LabelContato);
            Controls.Add(TextBoxSenha1);
            Controls.Add(LabelSenha);
            Controls.Add(TextBoxUsuario);
            Controls.Add(LabelUsuario);
            Controls.Add(LabelEmail);
            Controls.Add(LabelNome);
            Controls.Add(PanelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TelaCadastrarFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Usuários";
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelHeader;
        private Label LabelCadastrarUsuarios;
        private Label LabelNome;
        private Label LabelEmail;
        private TextBox TextBoxUsuario;
        private Label LabelUsuario;
        private TextBox TextBoxSenha1;
        private Label LabelSenha;
        private Label LabelContato;
        private Label LabelUF;
        private TextBox TextBoxCodigo;
        private Label LabelCodigo;
        private Label LabelCidade;
        private Label LabelLogradouro;
        private Label LabelNumero;
        private Label LabelComplemento;
        private Label LabelSexo;
        private ComboBox ComboBoxSexo;
        private ComboBox ComboBoxCargo;
        private Label LabelCargo;
        private Label LabelBairro;
        private Label LabelCEP;
        private Label LabelDDD;
        private Button BotaoConfirmar;
        private Button BotaoCancelar;
        private TextBox TextBoxNome;
        private TextBox TextBoxEmail;
        private MaskedTextBox TextBoxDDD;
        private TextBox TextBoxTelefone;
        private TextBox TextBoxLogradouro;
        private TextBox TextBoxNumero;
        private TextBox TextBoxComplemento;
        private TextBox TextBoxBairro;
        private TextBox TextBoxCidade;
        private MaskedTextBox TextBoxCEP;
        private TextBox TextBoxSenha2;
        private Label LabelSenha2;
        private ComboBox ComboBoxUF;
    }
}