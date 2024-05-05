namespace PIMFazendaUrbana
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
            LabelProdutos = new Label();
            LabelCategorias = new Label();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            toolTip6 = new ToolTip(components);
            toolTip7 = new ToolTip(components);
            Transacoes = new PictureBox();
            Inventario = new PictureBox();
            Produtos = new PictureBox();
            Categorias = new PictureBox();
            Clientes = new PictureBox();
            Fornecedores = new PictureBox();
            Usuarios = new PictureBox();
            PanelHeader = new Panel();
            LabelSair = new Label();
            PictureBoxSair = new PictureBox();
            LabelClientes = new Label();
            LabelFuncionarios = new Label();
            PictureBoxLogoFundo = new PictureBox();
            PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Transacoes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Inventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Produtos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Categorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Clientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Fornecedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Usuarios).BeginInit();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSair).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoFundo).BeginInit();
            SuspendLayout();
            // 
            // PanelFooter
            // 
            PanelFooter.BackColor = Color.FromArgb(120, 220, 120);
            PanelFooter.Controls.Add(LabelFarmSystem);
            PanelFooter.Dock = DockStyle.Bottom;
            PanelFooter.ForeColor = Color.White;
            PanelFooter.Location = new Point(0, 714);
            PanelFooter.Margin = new Padding(5);
            PanelFooter.Name = "PanelFooter";
            PanelFooter.Size = new Size(1106, 35);
            PanelFooter.TabIndex = 0;
            // 
            // LabelFarmSystem
            // 
            LabelFarmSystem.AutoSize = true;
            LabelFarmSystem.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelFarmSystem.Location = new Point(606, 5);
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
            LabelFornecedores.Location = new Point(275, 44);
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
            LabelTransacoes.Location = new Point(626, 42);
            LabelTransacoes.Name = "LabelTransacoes";
            LabelTransacoes.Size = new Size(67, 15);
            LabelTransacoes.TabIndex = 13;
            LabelTransacoes.Text = "Transações";
            // 
            // LabelInventario
            // 
            LabelInventario.AutoSize = true;
            LabelInventario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelInventario.ForeColor = SystemColors.ControlLightLight;
            LabelInventario.Location = new Point(542, 43);
            LabelInventario.Name = "LabelInventario";
            LabelInventario.Size = new Size(65, 15);
            LabelInventario.TabIndex = 12;
            LabelInventario.Text = "Inventário";
            // 
            // LabelProdutos
            // 
            LabelProdutos.AutoSize = true;
            LabelProdutos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelProdutos.ForeColor = SystemColors.ControlLightLight;
            LabelProdutos.Location = new Point(458, 43);
            LabelProdutos.Name = "LabelProdutos";
            LabelProdutos.Size = new Size(57, 15);
            LabelProdutos.TabIndex = 11;
            LabelProdutos.Text = "Produtos";
            // 
            // LabelCategorias
            // 
            LabelCategorias.AutoSize = true;
            LabelCategorias.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCategorias.ForeColor = SystemColors.ControlLightLight;
            LabelCategorias.Location = new Point(368, 44);
            LabelCategorias.Name = "LabelCategorias";
            LabelCategorias.Size = new Size(62, 13);
            LabelCategorias.TabIndex = 10;
            LabelCategorias.Text = "Categorias";
            // 
            // Transacoes
            // 
            Transacoes.Image = (Image)resources.GetObject("Transacoes.Image");
            Transacoes.Location = new Point(640, 4);
            Transacoes.Name = "Transacoes";
            Transacoes.Size = new Size(40, 37);
            Transacoes.SizeMode = PictureBoxSizeMode.StretchImage;
            Transacoes.TabIndex = 5;
            Transacoes.TabStop = false;
            Transacoes.MouseHover += Transacoes_MouseHover;
            // 
            // Inventario
            // 
            Inventario.Image = (Image)resources.GetObject("Inventario.Image");
            Inventario.Location = new Point(553, 4);
            Inventario.Name = "Inventario";
            Inventario.Size = new Size(40, 37);
            Inventario.SizeMode = PictureBoxSizeMode.StretchImage;
            Inventario.TabIndex = 4;
            Inventario.TabStop = false;
            Inventario.MouseHover += Inventario_MouseHover;
            // 
            // Produtos
            // 
            Produtos.Image = (Image)resources.GetObject("Produtos.Image");
            Produtos.Location = new Point(466, 4);
            Produtos.Name = "Produtos";
            Produtos.Size = new Size(40, 37);
            Produtos.SizeMode = PictureBoxSizeMode.StretchImage;
            Produtos.TabIndex = 3;
            Produtos.TabStop = false;
            Produtos.Click += Produtos_Click;
            Produtos.MouseHover += Produtos_MouseHover;
            // 
            // Categorias
            // 
            Categorias.Image = (Image)resources.GetObject("Categorias.Image");
            Categorias.Location = new Point(379, 4);
            Categorias.Name = "Categorias";
            Categorias.Size = new Size(40, 37);
            Categorias.SizeMode = PictureBoxSizeMode.StretchImage;
            Categorias.TabIndex = 7;
            Categorias.TabStop = false;
            Categorias.MouseHover += Categorias_MouseHover;
            // 
            // Clientes
            // 
            Clientes.Image = (Image)resources.GetObject("Clientes.Image");
            Clientes.Location = new Point(205, 4);
            Clientes.Name = "Clientes";
            Clientes.Size = new Size(40, 37);
            Clientes.SizeMode = PictureBoxSizeMode.StretchImage;
            Clientes.TabIndex = 2;
            Clientes.TabStop = false;
            Clientes.Click += Clientes_Click;
            Clientes.MouseHover += Clientes_MouseHover;
            // 
            // Fornecedores
            // 
            Fornecedores.Image = (Image)resources.GetObject("Fornecedores.Image");
            Fornecedores.Location = new Point(293, 4);
            Fornecedores.Name = "Fornecedores";
            Fornecedores.Size = new Size(40, 37);
            Fornecedores.SizeMode = PictureBoxSizeMode.StretchImage;
            Fornecedores.TabIndex = 8;
            Fornecedores.TabStop = false;
            Fornecedores.MouseHover += Fornecedores_MouseHover;
            // 
            // Usuarios
            // 
            Usuarios.AccessibleDescription = "Usuarios";
            Usuarios.AccessibleName = "Usuarios";
            Usuarios.AccessibleRole = AccessibleRole.TitleBar;
            Usuarios.Image = (Image)resources.GetObject("Usuarios.Image");
            Usuarios.Location = new Point(119, 4);
            Usuarios.Name = "Usuarios";
            Usuarios.Size = new Size(40, 37);
            Usuarios.SizeMode = PictureBoxSizeMode.StretchImage;
            Usuarios.TabIndex = 2;
            Usuarios.TabStop = false;
            Usuarios.Click += Usuarios_Click;
            Usuarios.MouseHover += Usuarios_MouseHover;
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(LabelSair);
            PanelHeader.Controls.Add(PictureBoxSair);
            PanelHeader.Controls.Add(LabelTransacoes);
            PanelHeader.Controls.Add(Transacoes);
            PanelHeader.Controls.Add(LabelInventario);
            PanelHeader.Controls.Add(Inventario);
            PanelHeader.Controls.Add(LabelProdutos);
            PanelHeader.Controls.Add(Produtos);
            PanelHeader.Controls.Add(LabelCategorias);
            PanelHeader.Controls.Add(Categorias);
            PanelHeader.Controls.Add(LabelFornecedores);
            PanelHeader.Controls.Add(Fornecedores);
            PanelHeader.Controls.Add(LabelClientes);
            PanelHeader.Controls.Add(Clientes);
            PanelHeader.Controls.Add(Usuarios);
            PanelHeader.Controls.Add(LabelFuncionarios);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(1106, 65);
            PanelHeader.TabIndex = 1;
            // 
            // LabelSair
            // 
            LabelSair.AutoSize = true;
            LabelSair.BackColor = Color.FromArgb(62, 181, 68);
            LabelSair.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelSair.ForeColor = SystemColors.ActiveCaptionText;
            LabelSair.Location = new Point(34, 43);
            LabelSair.Name = "LabelSair";
            LabelSair.Size = new Size(26, 13);
            LabelSair.TabIndex = 18;
            LabelSair.Text = "Sair";
            // 
            // PictureBoxSair
            // 
            PictureBoxSair.AccessibleDescription = "Usuarios";
            PictureBoxSair.AccessibleName = "Usuarios";
            PictureBoxSair.AccessibleRole = AccessibleRole.TitleBar;
            PictureBoxSair.Image = (Image)resources.GetObject("PictureBoxSair.Image");
            PictureBoxSair.Location = new Point(26, 4);
            PictureBoxSair.Name = "PictureBoxSair";
            PictureBoxSair.Size = new Size(40, 37);
            PictureBoxSair.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxSair.TabIndex = 16;
            PictureBoxSair.TabStop = false;
            PictureBoxSair.Click += PictureBoxSair_Click;
            // 
            // LabelClientes
            // 
            LabelClientes.AutoSize = true;
            LabelClientes.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelClientes.ForeColor = SystemColors.ControlLightLight;
            LabelClientes.Location = new Point(201, 44);
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
            LabelFuncionarios.Location = new Point(102, 44);
            LabelFuncionarios.Name = "LabelFuncionarios";
            LabelFuncionarios.Size = new Size(74, 13);
            LabelFuncionarios.TabIndex = 2;
            LabelFuncionarios.Text = "Funcionários";
            // 
            // PictureBoxLogoFundo
            // 
            PictureBoxLogoFundo.Image = (Image)resources.GetObject("PictureBoxLogoFundo.Image");
            PictureBoxLogoFundo.Location = new Point(562, 125);
            PictureBoxLogoFundo.Name = "PictureBoxLogoFundo";
            PictureBoxLogoFundo.Size = new Size(380, 575);
            PictureBoxLogoFundo.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxLogoFundo.TabIndex = 2;
            PictureBoxLogoFundo.TabStop = false;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 749);
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
            ((System.ComponentModel.ISupportInitialize)Transacoes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Inventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)Produtos).EndInit();
            ((System.ComponentModel.ISupportInitialize)Categorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)Clientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Fornecedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)Usuarios).EndInit();
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSair).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxLogoFundo).EndInit();
            ResumeLayout(false);
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
        private Label LabelProdutos;
        private Label LabelCategorias;
        private Label LabelFornecedores;
        private Label LabelTransacoes;
        private Label LabelInventario;
        private PictureBox Transacoes;
        private PictureBox Inventario;
        private PictureBox Produtos;
        private PictureBox Categorias;
        private PictureBox Clientes;
        private PictureBox Fornecedores;
        private PictureBox Usuarios;
        private Panel PanelHeader;
        private Label LabelClientes;
        private Label LabelFuncionarios;
        private Label LabelSair;
        private PictureBox PictureBoxSair;
        private PictureBox PictureBoxLogoFundo;
    }
}
