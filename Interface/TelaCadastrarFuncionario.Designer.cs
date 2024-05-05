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
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelCadastrarUsuarios);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(434, 41);
            PanelHeader.TabIndex = 0;
            // 
            // LabelCadastrarUsuarios
            // 
            LabelCadastrarUsuarios.AutoSize = true;
            LabelCadastrarUsuarios.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarUsuarios.ForeColor = SystemColors.ButtonHighlight;
            LabelCadastrarUsuarios.Location = new Point(127, 7);
            LabelCadastrarUsuarios.Name = "LabelCadastrarUsuarios";
            LabelCadastrarUsuarios.Size = new Size(171, 25);
            LabelCadastrarUsuarios.TabIndex = 0;
            LabelCadastrarUsuarios.Text = "Cadastrar Usuário";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(74, 63);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(46, 15);
            LabelNome.TabIndex = 1;
            LabelNome.Text = "Nome: ";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(74, 92);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(47, 15);
            LabelEmail.TabIndex = 3;
            LabelEmail.Text = "E-mail: ";
            // 
            // TextBoxUsuario
            // 
            TextBoxUsuario.Location = new Point(127, 117);
            TextBoxUsuario.Name = "TextBoxUsuario";
            TextBoxUsuario.Size = new Size(200, 23);
            TextBoxUsuario.TabIndex = 4;
            TextBoxUsuario.Validating += TextBoxUsuario_Validating;
            // 
            // LabelUsuario
            // 
            LabelUsuario.AutoSize = true;
            LabelUsuario.Location = new Point(68, 121);
            LabelUsuario.Name = "LabelUsuario";
            LabelUsuario.Size = new Size(53, 15);
            LabelUsuario.TabIndex = 5;
            LabelUsuario.Text = "Usuário: ";
            // 
            // TextBoxSenha1
            // 
            TextBoxSenha1.Location = new Point(127, 147);
            TextBoxSenha1.Name = "TextBoxSenha1";
            TextBoxSenha1.Size = new Size(139, 23);
            TextBoxSenha1.TabIndex = 5;
            // 
            // LabelSenha
            // 
            LabelSenha.AutoSize = true;
            LabelSenha.Location = new Point(77, 150);
            LabelSenha.Name = "LabelSenha";
            LabelSenha.Size = new Size(45, 15);
            LabelSenha.TabIndex = 7;
            LabelSenha.Text = "Senha: ";
            // 
            // LabelContato
            // 
            LabelContato.AutoSize = true;
            LabelContato.Location = new Point(164, 266);
            LabelContato.Name = "LabelContato";
            LabelContato.Size = new Size(54, 15);
            LabelContato.TabIndex = 9;
            LabelContato.Text = "Telefone:";
            // 
            // LabelUF
            // 
            LabelUF.AutoSize = true;
            LabelUF.Location = new Point(95, 438);
            LabelUF.Name = "LabelUF";
            LabelUF.Size = new Size(27, 15);
            LabelUF.TabIndex = 11;
            LabelUF.Text = "UF: ";
            // 
            // LabelCidade
            // 
            LabelCidade.AutoSize = true;
            LabelCidade.Location = new Point(73, 409);
            LabelCidade.Name = "LabelCidade";
            LabelCidade.Size = new Size(50, 15);
            LabelCidade.TabIndex = 15;
            LabelCidade.Text = "Cidade: ";
            // 
            // LabelLogradouro
            // 
            LabelLogradouro.AutoSize = true;
            LabelLogradouro.Location = new Point(47, 294);
            LabelLogradouro.Name = "LabelLogradouro";
            LabelLogradouro.Size = new Size(75, 15);
            LabelLogradouro.TabIndex = 17;
            LabelLogradouro.Text = "Logradouro: ";
            // 
            // LabelNumero
            // 
            LabelNumero.AutoSize = true;
            LabelNumero.Location = new Point(65, 323);
            LabelNumero.Name = "LabelNumero";
            LabelNumero.Size = new Size(57, 15);
            LabelNumero.TabIndex = 19;
            LabelNumero.Text = "Número: ";
            // 
            // LabelComplemento
            // 
            LabelComplemento.AutoSize = true;
            LabelComplemento.Location = new Point(32, 352);
            LabelComplemento.Name = "LabelComplemento";
            LabelComplemento.Size = new Size(90, 15);
            LabelComplemento.TabIndex = 21;
            LabelComplemento.Text = "Complemento: ";
            // 
            // LabelSexo
            // 
            LabelSexo.AutoSize = true;
            LabelSexo.Location = new Point(85, 207);
            LabelSexo.Name = "LabelSexo";
            LabelSexo.Size = new Size(38, 15);
            LabelSexo.TabIndex = 23;
            LabelSexo.Text = "Sexo: ";
            // 
            // ComboBoxSexo
            // 
            ComboBoxSexo.FormattingEnabled = true;
            ComboBoxSexo.Items.AddRange(new object[] { "M", "F", "-" });
            ComboBoxSexo.Location = new Point(127, 204);
            ComboBoxSexo.Name = "ComboBoxSexo";
            ComboBoxSexo.Size = new Size(55, 23);
            ComboBoxSexo.TabIndex = 7;
            ComboBoxSexo.Validating += ComboBoxSexo_Validating;
            // 
            // ComboBoxCargo
            // 
            ComboBoxCargo.FormattingEnabled = true;
            ComboBoxCargo.Items.AddRange(new object[] { "Funcionário", "Gerente" });
            ComboBoxCargo.Location = new Point(127, 233);
            ComboBoxCargo.Name = "ComboBoxCargo";
            ComboBoxCargo.Size = new Size(121, 23);
            ComboBoxCargo.TabIndex = 8;
            ComboBoxCargo.Validating += ComboBoxCargo_Validating;
            // 
            // LabelCargo
            // 
            LabelCargo.AutoSize = true;
            LabelCargo.Location = new Point(35, 238);
            LabelCargo.Name = "LabelCargo";
            LabelCargo.Size = new Size(88, 15);
            LabelCargo.TabIndex = 25;
            LabelCargo.Text = "Cargo Usuário: ";
            // 
            // LabelBairro
            // 
            LabelBairro.AutoSize = true;
            LabelBairro.Location = new Point(78, 380);
            LabelBairro.Name = "LabelBairro";
            LabelBairro.Size = new Size(44, 15);
            LabelBairro.TabIndex = 40;
            LabelBairro.Text = "Bairro: ";
            // 
            // LabelCEP
            // 
            LabelCEP.AutoSize = true;
            LabelCEP.Location = new Point(88, 468);
            LabelCEP.Name = "LabelCEP";
            LabelCEP.Size = new Size(34, 15);
            LabelCEP.TabIndex = 42;
            LabelCEP.Text = "CEP: ";
            // 
            // LabelDDD
            // 
            LabelDDD.AutoSize = true;
            LabelDDD.Location = new Point(84, 267);
            LabelDDD.Name = "LabelDDD";
            LabelDDD.Size = new Size(37, 15);
            LabelDDD.TabIndex = 45;
            LabelDDD.Text = "DDD: ";
            // 
            // BotaoConfirmar
            // 
            BotaoConfirmar.BackColor = Color.FromArgb(80, 200, 85);
            BotaoConfirmar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoConfirmar.ForeColor = Color.White;
            BotaoConfirmar.Location = new Point(76, 507);
            BotaoConfirmar.Name = "BotaoConfirmar";
            BotaoConfirmar.Size = new Size(90, 30);
            BotaoConfirmar.TabIndex = 18;
            BotaoConfirmar.Text = "Confirmar";
            BotaoConfirmar.UseVisualStyleBackColor = false;
            BotaoConfirmar.Click += BotaoConfirmar_Click;
            // 
            // BotaoCancelar
            // 
            BotaoCancelar.BackColor = Color.FromArgb(220, 190, 70);
            BotaoCancelar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoCancelar.ForeColor = Color.White;
            BotaoCancelar.Location = new Point(282, 507);
            BotaoCancelar.Name = "BotaoCancelar";
            BotaoCancelar.Size = new Size(80, 30);
            BotaoCancelar.TabIndex = 19;
            BotaoCancelar.Text = "Cancelar";
            BotaoCancelar.UseVisualStyleBackColor = false;
            BotaoCancelar.Click += BotaoCancelar_Click;
            // 
            // TextBoxNome
            // 
            TextBoxNome.Location = new Point(127, 59);
            TextBoxNome.Name = "TextBoxNome";
            TextBoxNome.Size = new Size(263, 23);
            TextBoxNome.TabIndex = 2;
            TextBoxNome.Validating += TextBoxNome_Validating;
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(127, 89);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(262, 23);
            TextBoxEmail.TabIndex = 3;
            TextBoxEmail.Validating += TextBoxEmail_Validating;
            // 
            // TextBoxDDD
            // 
            TextBoxDDD.Location = new Point(127, 262);
            TextBoxDDD.Mask = "00";
            TextBoxDDD.Name = "TextBoxDDD";
            TextBoxDDD.Size = new Size(31, 23);
            TextBoxDDD.TabIndex = 9;
            TextBoxDDD.Validating += TextBoxDDD_Validating;
            // 
            // TextBoxTelefone
            // 
            TextBoxTelefone.Location = new Point(230, 263);
            TextBoxTelefone.Name = "TextBoxTelefone";
            TextBoxTelefone.Size = new Size(111, 23);
            TextBoxTelefone.TabIndex = 10;
            TextBoxTelefone.KeyPress += TextBoxTelefone_KeyPress;
            TextBoxTelefone.Validating += TextBoxTelefone_Validating;
            // 
            // TextBoxLogradouro
            // 
            TextBoxLogradouro.Location = new Point(127, 291);
            TextBoxLogradouro.Name = "TextBoxLogradouro";
            TextBoxLogradouro.Size = new Size(262, 23);
            TextBoxLogradouro.TabIndex = 11;
            TextBoxLogradouro.Validating += TextBoxLogradouro_Validating;
            // 
            // TextBoxNumero
            // 
            TextBoxNumero.Location = new Point(127, 320);
            TextBoxNumero.Name = "TextBoxNumero";
            TextBoxNumero.Size = new Size(55, 23);
            TextBoxNumero.TabIndex = 12;
            TextBoxNumero.Validating += TextBoxNumero_Validating;
            // 
            // TextBoxComplemento
            // 
            TextBoxComplemento.Location = new Point(127, 349);
            TextBoxComplemento.Name = "TextBoxComplemento";
            TextBoxComplemento.Size = new Size(139, 23);
            TextBoxComplemento.TabIndex = 13;
            // 
            // TextBoxBairro
            // 
            TextBoxBairro.Location = new Point(127, 377);
            TextBoxBairro.Name = "TextBoxBairro";
            TextBoxBairro.Size = new Size(139, 23);
            TextBoxBairro.TabIndex = 14;
            TextBoxBairro.Validating += TextBoxBairro_Validating;
            // 
            // TextBoxCidade
            // 
            TextBoxCidade.Location = new Point(127, 406);
            TextBoxCidade.Name = "TextBoxCidade";
            TextBoxCidade.Size = new Size(262, 23);
            TextBoxCidade.TabIndex = 15;
            TextBoxCidade.Validating += TextBoxCidade_Validating;
            // 
            // TextBoxCEP
            // 
            TextBoxCEP.Culture = new System.Globalization.CultureInfo("");
            TextBoxCEP.Location = new Point(127, 465);
            TextBoxCEP.Mask = "00000-000";
            TextBoxCEP.Name = "TextBoxCEP";
            TextBoxCEP.Size = new Size(96, 23);
            TextBoxCEP.TabIndex = 17;
            TextBoxCEP.Validating += TextBoxCEP_Validating;
            // 
            // TextBoxSenha2
            // 
            TextBoxSenha2.Location = new Point(127, 175);
            TextBoxSenha2.Name = "TextBoxSenha2";
            TextBoxSenha2.Size = new Size(139, 23);
            TextBoxSenha2.TabIndex = 6;
            TextBoxSenha2.Validating += TextBoxSenha2_Validating;
            // 
            // LabelSenha2
            // 
            LabelSenha2.AutoSize = true;
            LabelSenha2.Location = new Point(10, 177);
            LabelSenha2.Name = "LabelSenha2";
            LabelSenha2.Size = new Size(103, 15);
            LabelSenha2.TabIndex = 47;
            LabelSenha2.Text = "Confirme a senha:";
            // 
            // ComboBoxUF
            // 
            ComboBoxUF.FormattingEnabled = true;
            ComboBoxUF.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            ComboBoxUF.Location = new Point(127, 435);
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
            BackColor = SystemColors.Control;
            ClientSize = new Size(434, 551);
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