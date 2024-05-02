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
            pnlFooter = new Panel();
            label1 = new Label();
            label10 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lb_funcionarios = new Label();
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
            panel1 = new Panel();
            lb_sair = new Label();
            pictureBox1 = new PictureBox();
            label9 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Transacoes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Inventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Produtos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Categorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Clientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Fornecedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Usuarios).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.LightGoldenrodYellow;
            pnlFooter.Controls.Add(label1);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 714);
            pnlFooter.Margin = new Padding(5);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(922, 35);
            pnlFooter.TabIndex = 0;
            pnlFooter.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(606, 5);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(263, 25);
            label1.TabIndex = 0;
            label1.Text = "FARM SYSTEM | VERSÃO 1.0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(272, 44);
            label10.Name = "label10";
            label10.Size = new Size(77, 13);
            label10.TabIndex = 15;
            label10.Text = "Fornecedores";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(626, 42);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 13;
            label7.Text = "Transações";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(542, 43);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 12;
            label6.Text = "Inventário";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(458, 43);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 11;
            label5.Text = "Produtos";
            // 
            // lb_funcionarios
            // 
            lb_funcionarios.AutoSize = true;
            lb_funcionarios.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_funcionarios.ForeColor = SystemColors.ControlLightLight;
            lb_funcionarios.Location = new Point(368, 44);
            lb_funcionarios.Name = "lb_funcionarios";
            lb_funcionarios.Size = new Size(62, 13);
            lb_funcionarios.TabIndex = 10;
            lb_funcionarios.Text = "Categorias";
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
            Fornecedores.Location = new Point(292, 4);
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
            Usuarios.Location = new Point(118, 4);
            Usuarios.Name = "Usuarios";
            Usuarios.Size = new Size(40, 37);
            Usuarios.SizeMode = PictureBoxSizeMode.StretchImage;
            Usuarios.TabIndex = 2;
            Usuarios.TabStop = false;
            Usuarios.Click += Usuarios_Click;
            Usuarios.MouseHover += Usuarios_MouseHover;
            // 
            // panel1
            // 
            panel1.BackColor = Color.ForestGreen;
            panel1.Controls.Add(lb_sair);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(Transacoes);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(Inventario);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(Produtos);
            panel1.Controls.Add(lb_funcionarios);
            panel1.Controls.Add(Categorias);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(Fornecedores);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(Clientes);
            panel1.Controls.Add(Usuarios);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(922, 60);
            panel1.TabIndex = 1;
            // 
            // lb_sair
            // 
            lb_sair.AutoSize = true;
            lb_sair.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_sair.ForeColor = SystemColors.ActiveCaptionText;
            lb_sair.Location = new Point(34, 43);
            lb_sair.Name = "lb_sair";
            lb_sair.Size = new Size(26, 13);
            lb_sair.TabIndex = 18;
            lb_sair.Text = "Sair";
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleDescription = "Usuarios";
            pictureBox1.AccessibleName = "Usuarios";
            pictureBox1.AccessibleRole = AccessibleRole.TitleBar;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(26, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(201, 44);
            label9.Name = "label9";
            label9.Size = new Size(48, 13);
            label9.TabIndex = 14;
            label9.Text = "Clientes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(102, 44);
            label4.Name = "label4";
            label4.Size = new Size(74, 13);
            label4.TabIndex = 2;
            label4.Text = "Funcionarios";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(606, 248);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(248, 183);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 749);
            Controls.Add(pictureBox2);
            Controls.Add(pnlFooter);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "TelaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Farm System";
            WindowState = FormWindowState.Maximized;
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Transacoes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Inventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)Produtos).EndInit();
            ((System.ComponentModel.ISupportInitialize)Categorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)Clientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Fornecedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)Usuarios).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFooter;
        private Label label1;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip7;
        private Label label5;
        private Label lb_funcionarios;
        private Label label10;
        private Label label7;
        private Label label6;
        private PictureBox Transacoes;
        private PictureBox Inventario;
        private PictureBox Produtos;
        private PictureBox Categorias;
        private PictureBox Clientes;
        private PictureBox Fornecedores;
        private PictureBox Usuarios;
        private Panel panel1;
        private Label label9;
        private Label label4;
        private PictureBox pictureBox2;
        private Label lb_sair;
        private PictureBox pictureBox1;
    }
}
