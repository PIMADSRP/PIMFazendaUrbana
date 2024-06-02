namespace PIMFazendaUrbanaForms
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            PanelFooter = new Panel();
            LabelFarmSystem = new Label();
            LabelFornecedores = new Label();
            LabelTransacoes = new Label();
            LabelInventario = new Label();
            LabelProducao = new Label();
            LabelCategorias = new Label();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            toolTip6 = new ToolTip(components);
            toolTip7 = new ToolTip(components);
            pictureBoxCompras = new PictureBox();
            PictureBoxInventario = new PictureBox();
            PictureBoxProducao = new PictureBox();
            PictureBoxInsumos = new PictureBox();
            PictureBoxClientes = new PictureBox();
            PictureBoxFornecedores = new PictureBox();
            PictureBoxFuncionarios = new PictureBox();
            PanelHeader = new Panel();
            label1 = new Label();
            pictureBoxVendas = new PictureBox();
            pictureBoxRecomendarPlantio = new PictureBox();
            lbRecomendarPlantio = new Label();
            PictureBoxLogoff = new PictureBox();
            LabelLogoff = new Label();
            LabelBemVindo = new Label();
            BotaoAbrirTelaDeTeste = new Button();
            LabelClientes = new Label();
            LabelFuncionarios = new Label();
            PictureBoxLogoFundo = new PictureBox();
            RichTextBoxNotas = new RichTextBox();
            LabelNotas = new Label();
            PictureBoxSlideShow = new PictureBox();
            TimerSlideShow = new System.Windows.Forms.Timer(components);
            TimerFade = new System.Windows.Forms.Timer(components);
            ListBoxNoticias = new ListBox();
            LabelNoticias = new Label();
            ListBoxNoticiasInternas = new ListBox();
            LabelNoticiasInternas = new Label();
            toolTip8 = new ToolTip(components);
            toolTip9 = new ToolTip(components);
            toolTipCompra = new ToolTip(components);
            toolTipVenda = new ToolTip(components);
            toolTip10 = new ToolTip(components);
            PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxProducao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxInsumos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxFornecedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxFuncionarios).BeginInit();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVendas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecomendarPlantio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoff).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoFundo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSlideShow).BeginInit();
            SuspendLayout();
            // 
            // PanelFooter
            // 
            PanelFooter.BackColor = Color.FromArgb(120, 220, 120);
            PanelFooter.Controls.Add(LabelFarmSystem);
            PanelFooter.Dock = DockStyle.Bottom;
            PanelFooter.ForeColor = Color.White;
            PanelFooter.Location = new Point(0, 694);
            PanelFooter.Margin = new Padding(5);
            PanelFooter.Name = "PanelFooter";
            PanelFooter.Size = new Size(1370, 35);
            PanelFooter.TabIndex = 0;
            // 
            // LabelFarmSystem
            // 
            LabelFarmSystem.AutoSize = true;
            LabelFarmSystem.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelFarmSystem.Location = new Point(623, 5);
            LabelFarmSystem.Margin = new Padding(5, 0, 5, 0);
            LabelFarmSystem.Name = "LabelFarmSystem";
            LabelFarmSystem.Size = new Size(263, 25);
            LabelFarmSystem.TabIndex = 0;
            LabelFarmSystem.Text = "FARM SYSTEM | VERSÃO 1.0";
            // 
            // LabelFornecedores
            // 
            LabelFornecedores.AutoSize = true;
            LabelFornecedores.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelFornecedores.ForeColor = SystemColors.ControlLightLight;
            LabelFornecedores.Location = new Point(191, 46);
            LabelFornecedores.Name = "LabelFornecedores";
            LabelFornecedores.Size = new Size(77, 13);
            LabelFornecedores.TabIndex = 15;
            LabelFornecedores.Text = "Fornecedores";
            // 
            // LabelTransacoes
            // 
            LabelTransacoes.AutoSize = true;
            LabelTransacoes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelTransacoes.ForeColor = SystemColors.ControlLightLight;
            LabelTransacoes.Location = new Point(548, 44);
            LabelTransacoes.Name = "LabelTransacoes";
            LabelTransacoes.Size = new Size(50, 15);
            LabelTransacoes.TabIndex = 13;
            LabelTransacoes.Text = "Compra";
            // 
            // LabelInventario
            // 
            LabelInventario.AutoSize = true;
            LabelInventario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelInventario.ForeColor = SystemColors.ControlLightLight;
            LabelInventario.Location = new Point(458, 45);
            LabelInventario.Name = "LabelInventario";
            LabelInventario.Size = new Size(65, 15);
            LabelInventario.TabIndex = 12;
            LabelInventario.Text = "Inventário";
            // 
            // LabelProducao
            // 
            LabelProducao.AutoSize = true;
            LabelProducao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelProducao.ForeColor = SystemColors.ControlLightLight;
            LabelProducao.Location = new Point(374, 45);
            LabelProducao.Name = "LabelProducao";
            LabelProducao.Size = new Size(59, 15);
            LabelProducao.TabIndex = 11;
            LabelProducao.Text = "Produção";
            // 
            // LabelCategorias
            // 
            LabelCategorias.AutoSize = true;
            LabelCategorias.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCategorias.ForeColor = SystemColors.ControlLightLight;
            LabelCategorias.Location = new Point(290, 46);
            LabelCategorias.Name = "LabelCategorias";
            LabelCategorias.Size = new Size(51, 13);
            LabelCategorias.TabIndex = 10;
            LabelCategorias.Text = "Insumos";
            // 
            // pictureBoxCompras
            // 
            pictureBoxCompras.Image = (Image)resources.GetObject("pictureBoxCompras.Image");
            pictureBoxCompras.Location = new Point(553, 6);
            pictureBoxCompras.Name = "pictureBoxCompras";
            pictureBoxCompras.Size = new Size(40, 37);
            pictureBoxCompras.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCompras.TabIndex = 5;
            pictureBoxCompras.TabStop = false;
            pictureBoxCompras.Click += pictureBoxCompras_Click;
            pictureBoxCompras.MouseHover += pictureBoxCompras_MouseHover_1;
            // 
            // PictureBoxInventario
            // 
            PictureBoxInventario.Image = Properties.Resources.Inventario;
            PictureBoxInventario.Location = new Point(469, 6);
            PictureBoxInventario.Name = "PictureBoxInventario";
            PictureBoxInventario.Size = new Size(40, 37);
            PictureBoxInventario.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxInventario.TabIndex = 4;
            PictureBoxInventario.TabStop = false;
            PictureBoxInventario.MouseHover += PictureBoxInventario_MouseHover;
            // 
            // PictureBoxProducao
            // 
            PictureBoxProducao.Image = Properties.Resources.Produtos;
            PictureBoxProducao.Location = new Point(382, 6);
            PictureBoxProducao.Name = "PictureBoxProducao";
            PictureBoxProducao.Size = new Size(40, 37);
            PictureBoxProducao.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxProducao.TabIndex = 3;
            PictureBoxProducao.TabStop = false;
            PictureBoxProducao.Click += PictureBoxProducao_Click;
            PictureBoxProducao.MouseHover += PictureBoxProducao_MouseHover;
            // 
            // PictureBoxInsumos
            // 
            PictureBoxInsumos.Image = Properties.Resources.Insumos;
            PictureBoxInsumos.Location = new Point(295, 6);
            PictureBoxInsumos.Name = "PictureBoxInsumos";
            PictureBoxInsumos.Size = new Size(40, 37);
            PictureBoxInsumos.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxInsumos.TabIndex = 7;
            PictureBoxInsumos.TabStop = false;
            PictureBoxInsumos.Click += PictureBoxInsumos_Click;
            PictureBoxInsumos.MouseHover += PictureBoxInsumos_MouseHover;
            // 
            // PictureBoxClientes
            // 
            PictureBoxClientes.Image = Properties.Resources.Clientes;
            PictureBoxClientes.Location = new Point(121, 6);
            PictureBoxClientes.Name = "PictureBoxClientes";
            PictureBoxClientes.Size = new Size(40, 37);
            PictureBoxClientes.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxClientes.TabIndex = 2;
            PictureBoxClientes.TabStop = false;
            PictureBoxClientes.Click += PictureBoxClientes_Click;
            PictureBoxClientes.MouseHover += PictureBoxClientes_MouseHover;
            // 
            // PictureBoxFornecedores
            // 
            PictureBoxFornecedores.Image = Properties.Resources.Fornecedores;
            PictureBoxFornecedores.Location = new Point(209, 6);
            PictureBoxFornecedores.Name = "PictureBoxFornecedores";
            PictureBoxFornecedores.Size = new Size(40, 37);
            PictureBoxFornecedores.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxFornecedores.TabIndex = 8;
            PictureBoxFornecedores.TabStop = false;
            PictureBoxFornecedores.Click += PictureBoxFornecedores_Click;
            PictureBoxFornecedores.MouseHover += PictureBoxFornecedores_MouseHover;
            // 
            // PictureBoxFuncionarios
            // 
            PictureBoxFuncionarios.AccessibleDescription = "Usuarios";
            PictureBoxFuncionarios.AccessibleName = "Usuarios";
            PictureBoxFuncionarios.AccessibleRole = AccessibleRole.TitleBar;
            PictureBoxFuncionarios.Image = Properties.Resources.Usuarios;
            PictureBoxFuncionarios.Location = new Point(35, 6);
            PictureBoxFuncionarios.Name = "PictureBoxFuncionarios";
            PictureBoxFuncionarios.Size = new Size(40, 37);
            PictureBoxFuncionarios.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxFuncionarios.TabIndex = 2;
            PictureBoxFuncionarios.TabStop = false;
            PictureBoxFuncionarios.Click += PictureBoxFuncionarios_Click;
            PictureBoxFuncionarios.MouseHover += PictureBoxFuncionarios_MouseHover;
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(label1);
            PanelHeader.Controls.Add(pictureBoxVendas);
            PanelHeader.Controls.Add(pictureBoxRecomendarPlantio);
            PanelHeader.Controls.Add(lbRecomendarPlantio);
            PanelHeader.Controls.Add(PictureBoxLogoff);
            PanelHeader.Controls.Add(LabelLogoff);
            PanelHeader.Controls.Add(LabelBemVindo);
            PanelHeader.Controls.Add(BotaoAbrirTelaDeTeste);
            PanelHeader.Controls.Add(LabelTransacoes);
            PanelHeader.Controls.Add(pictureBoxCompras);
            PanelHeader.Controls.Add(LabelInventario);
            PanelHeader.Controls.Add(PictureBoxInventario);
            PanelHeader.Controls.Add(LabelProducao);
            PanelHeader.Controls.Add(PictureBoxProducao);
            PanelHeader.Controls.Add(LabelCategorias);
            PanelHeader.Controls.Add(PictureBoxInsumos);
            PanelHeader.Controls.Add(LabelFornecedores);
            PanelHeader.Controls.Add(PictureBoxFornecedores);
            PanelHeader.Controls.Add(LabelClientes);
            PanelHeader.Controls.Add(PictureBoxClientes);
            PanelHeader.Controls.Add(PictureBoxFuncionarios);
            PanelHeader.Controls.Add(LabelFuncionarios);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(1370, 67);
            PanelHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(637, 45);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 27;
            label1.Text = "Venda";
            // 
            // pictureBoxVendas
            // 
            pictureBoxVendas.Image = (Image)resources.GetObject("pictureBoxVendas.Image");
            pictureBoxVendas.Location = new Point(637, 6);
            pictureBoxVendas.Name = "pictureBoxVendas";
            pictureBoxVendas.Size = new Size(40, 37);
            pictureBoxVendas.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxVendas.TabIndex = 26;
            pictureBoxVendas.TabStop = false;
            pictureBoxVendas.MouseHover += pictureBoxVendas_MouseHover;
            // 
            // pictureBoxRecomendarPlantio
            // 
            pictureBoxRecomendarPlantio.Image = (Image)resources.GetObject("pictureBoxRecomendarPlantio.Image");
            pictureBoxRecomendarPlantio.Location = new Point(730, 6);
            pictureBoxRecomendarPlantio.Name = "pictureBoxRecomendarPlantio";
            pictureBoxRecomendarPlantio.Size = new Size(40, 37);
            pictureBoxRecomendarPlantio.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecomendarPlantio.TabIndex = 25;
            pictureBoxRecomendarPlantio.TabStop = false;
            pictureBoxRecomendarPlantio.Click += pictureBoxRecomendarPlantio_Click;
            // 
            // lbRecomendarPlantio
            // 
            lbRecomendarPlantio.AutoSize = true;
            lbRecomendarPlantio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRecomendarPlantio.ForeColor = SystemColors.ControlLightLight;
            lbRecomendarPlantio.Location = new Point(696, 46);
            lbRecomendarPlantio.Name = "lbRecomendarPlantio";
            lbRecomendarPlantio.Size = new Size(119, 15);
            lbRecomendarPlantio.TabIndex = 24;
            lbRecomendarPlantio.Text = "Recomendar Plantio";
            // 
            // PictureBoxLogoff
            // 
            PictureBoxLogoff.Image = Properties.Resources.Sair;
            PictureBoxLogoff.Location = new Point(1459, 6);
            PictureBoxLogoff.Name = "PictureBoxLogoff";
            PictureBoxLogoff.Size = new Size(40, 37);
            PictureBoxLogoff.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxLogoff.TabIndex = 23;
            PictureBoxLogoff.TabStop = false;
            PictureBoxLogoff.Click += PictureBoxLogoff_Click;
            // 
            // LabelLogoff
            // 
            LabelLogoff.AutoSize = true;
            LabelLogoff.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelLogoff.ForeColor = Color.White;
            LabelLogoff.Location = new Point(1442, 44);
            LabelLogoff.Name = "LabelLogoff";
            LabelLogoff.Size = new Size(77, 15);
            LabelLogoff.TabIndex = 8;
            LabelLogoff.Text = "Fazer Logoff";
            // 
            // LabelBemVindo
            // 
            LabelBemVindo.AutoSize = true;
            LabelBemVindo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelBemVindo.ForeColor = Color.White;
            LabelBemVindo.Location = new Point(1324, 24);
            LabelBemVindo.Name = "LabelBemVindo";
            LabelBemVindo.Size = new Size(100, 17);
            LabelBemVindo.TabIndex = 22;
            LabelBemVindo.Text = "Bem-vindo(a), ";
            // 
            // BotaoAbrirTelaDeTeste
            // 
            BotaoAbrirTelaDeTeste.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoAbrirTelaDeTeste.Location = new Point(861, 18);
            BotaoAbrirTelaDeTeste.Name = "BotaoAbrirTelaDeTeste";
            BotaoAbrirTelaDeTeste.Size = new Size(138, 29);
            BotaoAbrirTelaDeTeste.TabIndex = 19;
            BotaoAbrirTelaDeTeste.Text = "Abrir Tela de Teste";
            BotaoAbrirTelaDeTeste.UseVisualStyleBackColor = true;
            BotaoAbrirTelaDeTeste.Click += BotaoAbrirTelaDeTeste_Click;
            // 
            // LabelClientes
            // 
            LabelClientes.AutoSize = true;
            LabelClientes.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelClientes.ForeColor = SystemColors.ControlLightLight;
            LabelClientes.Location = new Point(117, 46);
            LabelClientes.Name = "LabelClientes";
            LabelClientes.Size = new Size(48, 13);
            LabelClientes.TabIndex = 14;
            LabelClientes.Text = "Clientes";
            // 
            // LabelFuncionarios
            // 
            LabelFuncionarios.AutoSize = true;
            LabelFuncionarios.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelFuncionarios.ForeColor = SystemColors.ControlLightLight;
            LabelFuncionarios.Location = new Point(18, 46);
            LabelFuncionarios.Name = "LabelFuncionarios";
            LabelFuncionarios.Size = new Size(74, 13);
            LabelFuncionarios.TabIndex = 2;
            LabelFuncionarios.Text = "Funcionários";
            // 
            // PictureBoxLogoFundo
            // 
            PictureBoxLogoFundo.Image = Properties.Resources.Logo;
            PictureBoxLogoFundo.Location = new Point(592, 135);
            PictureBoxLogoFundo.Name = "PictureBoxLogoFundo";
            PictureBoxLogoFundo.Size = new Size(351, 539);
            PictureBoxLogoFundo.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxLogoFundo.TabIndex = 2;
            PictureBoxLogoFundo.TabStop = false;
            // 
            // RichTextBoxNotas
            // 
            RichTextBoxNotas.BackColor = Color.LightGreen;
            RichTextBoxNotas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RichTextBoxNotas.Location = new Point(1135, 140);
            RichTextBoxNotas.Name = "RichTextBoxNotas";
            RichTextBoxNotas.Size = new Size(357, 254);
            RichTextBoxNotas.TabIndex = 3;
            RichTextBoxNotas.Text = "";
            // 
            // LabelNotas
            // 
            LabelNotas.AutoSize = true;
            LabelNotas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNotas.ForeColor = Color.DarkGreen;
            LabelNotas.Location = new Point(1135, 116);
            LabelNotas.Name = "LabelNotas";
            LabelNotas.Size = new Size(199, 17);
            LabelNotas.TabIndex = 4;
            LabelNotas.Text = "Suas notas para a sessão atual:";
            // 
            // PictureBoxSlideShow
            // 
            PictureBoxSlideShow.Location = new Point(1135, 461);
            PictureBoxSlideShow.Name = "PictureBoxSlideShow";
            PictureBoxSlideShow.Size = new Size(357, 238);
            PictureBoxSlideShow.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxSlideShow.TabIndex = 5;
            PictureBoxSlideShow.TabStop = false;
            // 
            // TimerSlideShow
            // 
            TimerSlideShow.Enabled = true;
            TimerSlideShow.Interval = 7000;
            // 
            // TimerFade
            // 
            TimerFade.Interval = 1;
            // 
            // ListBoxNoticias
            // 
            ListBoxNoticias.BackColor = Color.WhiteSmoke;
            ListBoxNoticias.DrawMode = DrawMode.OwnerDrawVariable;
            ListBoxNoticias.ForeColor = Color.Green;
            ListBoxNoticias.FormattingEnabled = true;
            ListBoxNoticias.Location = new Point(51, 140);
            ListBoxNoticias.Name = "ListBoxNoticias";
            ListBoxNoticias.Size = new Size(352, 254);
            ListBoxNoticias.TabIndex = 6;
            ListBoxNoticias.DrawItem += ListBoxNoticias_DrawItem;
            ListBoxNoticias.MeasureItem += ListBoxNoticias_MeasureItem;
            // 
            // LabelNoticias
            // 
            LabelNoticias.AutoSize = true;
            LabelNoticias.ForeColor = Color.DarkGreen;
            LabelNoticias.Location = new Point(51, 110);
            LabelNoticias.Name = "LabelNoticias";
            LabelNoticias.Size = new Size(83, 25);
            LabelNoticias.TabIndex = 7;
            LabelNoticias.Text = "Notícias";
            // 
            // ListBoxNoticiasInternas
            // 
            ListBoxNoticiasInternas.BackColor = Color.WhiteSmoke;
            ListBoxNoticiasInternas.DrawMode = DrawMode.OwnerDrawVariable;
            ListBoxNoticiasInternas.ForeColor = Color.Green;
            ListBoxNoticiasInternas.FormattingEnabled = true;
            ListBoxNoticiasInternas.Location = new Point(51, 461);
            ListBoxNoticiasInternas.Name = "ListBoxNoticiasInternas";
            ListBoxNoticiasInternas.Size = new Size(352, 238);
            ListBoxNoticiasInternas.TabIndex = 8;
            ListBoxNoticiasInternas.DrawItem += ListBoxNoticiasInternas_DrawItem;
            ListBoxNoticiasInternas.MeasureItem += ListBoxNoticiasInternas_MeasureItem;
            // 
            // LabelNoticiasInternas
            // 
            LabelNoticiasInternas.AutoSize = true;
            LabelNoticiasInternas.ForeColor = Color.DarkGreen;
            LabelNoticiasInternas.Location = new Point(52, 431);
            LabelNoticiasInternas.Name = "LabelNoticiasInternas";
            LabelNoticiasInternas.Size = new Size(161, 25);
            LabelNoticiasInternas.TabIndex = 9;
            LabelNoticiasInternas.Text = "Notícias Internas";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1370, 729);
            Controls.Add(LabelNoticiasInternas);
            Controls.Add(ListBoxNoticiasInternas);
            Controls.Add(LabelNoticias);
            Controls.Add(ListBoxNoticias);
            Controls.Add(PictureBoxSlideShow);
            Controls.Add(LabelNotas);
            Controls.Add(RichTextBoxNotas);
            Controls.Add(PictureBoxLogoFundo);
            Controls.Add(PanelFooter);
            Controls.Add(PanelHeader);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "TelaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Farm System";
            WindowState = FormWindowState.Maximized;
            PanelFooter.ResumeLayout(false);
            PanelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxProducao).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxInsumos).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxFornecedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxFuncionarios).EndInit();
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVendas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecomendarPlantio).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoff).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoFundo).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSlideShow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelFooter;
        private Label LabelFarmSystem;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip7;
        private Label LabelProducao;
        private Label LabelCategorias;
        private Label LabelFornecedores;
        private Label LabelTransacoes;
        private Label LabelInventario;
        private PictureBox pictureBoxCompras;
        private PictureBox PictureBoxInventario;
        private PictureBox PictureBoxProducao;
        private PictureBox PictureBoxInsumos;
        private PictureBox PictureBoxClientes;
        private PictureBox PictureBoxFornecedores;
        private PictureBox PictureBoxFuncionarios;
        private Panel PanelHeader;
        private Label LabelClientes;
        private Label LabelFuncionarios;
        private PictureBox PictureBoxLogoFundo;
        private Button BotaoAbrirTelaDeTeste;
        private RichTextBox RichTextBoxNotas;
        private Label LabelNotas;
        private PictureBox PictureBoxSlideShow;
        private System.Windows.Forms.Timer TimerSlideShow;
        private System.Windows.Forms.Timer TimerFade;
        private ListBox ListBoxNoticias;
        private Label LabelNoticias;
        private Label LabelBemVindo;
        private PictureBox PictureBoxLogoff;
        private Label LabelLogoff;
        private ListBox ListBoxNoticiasInternas;
        private Label LabelNoticiasInternas;
        private PictureBox pictureBoxRecomendarPlantio;
        private Label lbRecomendarPlantio;
        private ToolTip toolTip8;
        private ToolTip toolTip9;
        private ToolTip toolTipCompra;
        private ToolTip toolTipVenda;
        private Label label1;
        private PictureBox pictureBoxVendas;
        private ToolTip toolTip10;
    }
}
