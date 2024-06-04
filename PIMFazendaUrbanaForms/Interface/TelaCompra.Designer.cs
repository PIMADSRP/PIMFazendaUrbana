namespace PIMFazendaUrbanaForms
{
    partial class TelaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCompra));
            LabelEstoqueInsumos = new Label();
            DataGridViewListaInsumos = new DataGridView();
            PanelHeader = new Panel();
            maskedTextBox1 = new MaskedTextBox();
            PictureBoxHome = new PictureBox();
            TextBoxPesquisar = new TextBox();
            LabelA = new Label();
            LabelHome = new Label();
            LabelPesquisarVendas = new Label();
            maskedTextBox2 = new MaskedTextBox();
            PictureBoxAtualizar = new PictureBox();
            PictureBoxEditar = new PictureBox();
            LabelPeriodo = new Label();
            PictureBoxDeletar = new PictureBox();
            LabelAtualizar = new Label();
            pictureBox1 = new PictureBox();
            LabelDeletar = new Label();
            PictureBoxPesquisar = new PictureBox();
            labelRelatorio = new Label();
            LabelEditar = new Label();
            PictureBoxIncluir = new PictureBox();
            textBoxInsumoComprados = new TextBox();
            LabelCadastrarSaida = new Label();
            LabelIncluir = new Label();
            LabelPesquisarCompras = new Label();
            PanelFooter = new Panel();
            label3 = new Label();
            LabelEstoqueInsumo = new Label();
            LabelRegistroDeCompras = new Label();
            DataGridViewRegistroDeCompras = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaInsumos).BeginInit();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxPesquisar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).BeginInit();
            PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewRegistroDeCompras).BeginInit();
            SuspendLayout();
            // 
            // LabelEstoqueInsumos
            // 
            LabelEstoqueInsumos.AutoSize = true;
            LabelEstoqueInsumos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelEstoqueInsumos.ForeColor = Color.DarkGreen;
            LabelEstoqueInsumos.Location = new Point(94, -72);
            LabelEstoqueInsumos.Name = "LabelEstoqueInsumos";
            LabelEstoqueInsumos.Size = new Size(136, 17);
            LabelEstoqueInsumos.TabIndex = 60;
            LabelEstoqueInsumos.Text = "Estoque de Insumos:";
            // 
            // DataGridViewListaInsumos
            // 
            DataGridViewListaInsumos.AllowUserToAddRows = false;
            DataGridViewListaInsumos.AllowUserToDeleteRows = false;
            DataGridViewListaInsumos.BackgroundColor = SystemColors.Menu;
            DataGridViewListaInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewListaInsumos.Location = new Point(41, 91);
            DataGridViewListaInsumos.Name = "DataGridViewListaInsumos";
            DataGridViewListaInsumos.ReadOnly = true;
            DataGridViewListaInsumos.RowHeadersWidth = 27;
            DataGridViewListaInsumos.Size = new Size(573, 645);
            DataGridViewListaInsumos.TabIndex = 0;
            DataGridViewListaInsumos.VirtualMode = true;
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(maskedTextBox1);
            PanelHeader.Controls.Add(PictureBoxHome);
            PanelHeader.Controls.Add(TextBoxPesquisar);
            PanelHeader.Controls.Add(LabelA);
            PanelHeader.Controls.Add(LabelHome);
            PanelHeader.Controls.Add(LabelPesquisarVendas);
            PanelHeader.Controls.Add(maskedTextBox2);
            PanelHeader.Controls.Add(PictureBoxAtualizar);
            PanelHeader.Controls.Add(PictureBoxEditar);
            PanelHeader.Controls.Add(LabelPeriodo);
            PanelHeader.Controls.Add(PictureBoxDeletar);
            PanelHeader.Controls.Add(LabelAtualizar);
            PanelHeader.Controls.Add(pictureBox1);
            PanelHeader.Controls.Add(LabelDeletar);
            PanelHeader.Controls.Add(PictureBoxPesquisar);
            PanelHeader.Controls.Add(labelRelatorio);
            PanelHeader.Controls.Add(LabelEditar);
            PanelHeader.Controls.Add(PictureBoxIncluir);
            PanelHeader.Controls.Add(textBoxInsumoComprados);
            PanelHeader.Controls.Add(LabelCadastrarSaida);
            PanelHeader.Controls.Add(LabelIncluir);
            PanelHeader.Controls.Add(LabelPesquisarCompras);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(1370, 60);
            PanelHeader.TabIndex = 59;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Culture = new System.Globalization.CultureInfo("");
            maskedTextBox1.Location = new Point(906, 33);
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(96, 23);
            maskedTextBox1.TabIndex = 5;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            // 
            // PictureBoxHome
            // 
            PictureBoxHome.AccessibleDescription = "Usuarios";
            PictureBoxHome.AccessibleName = "Usuarios";
            PictureBoxHome.AccessibleRole = AccessibleRole.TitleBar;
            PictureBoxHome.Image = Properties.Resources.Home;
            PictureBoxHome.Location = new Point(12, 4);
            PictureBoxHome.Name = "PictureBoxHome";
            PictureBoxHome.Size = new Size(40, 37);
            PictureBoxHome.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxHome.TabIndex = 18;
            PictureBoxHome.TabStop = false;
            PictureBoxHome.Click += PictureBoxHome_Click;
            // 
            // TextBoxPesquisar
            // 
            TextBoxPesquisar.Location = new Point(272, 18);
            TextBoxPesquisar.Name = "TextBoxPesquisar";
            TextBoxPesquisar.PlaceholderText = "Digite o nome do insumo";
            TextBoxPesquisar.Size = new Size(246, 23);
            TextBoxPesquisar.TabIndex = 2;
            TextBoxPesquisar.TextChanged += TextBoxPesquisar_TextChanged;
            // 
            // LabelA
            // 
            LabelA.AutoSize = true;
            LabelA.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelA.ForeColor = Color.White;
            LabelA.Location = new Point(873, 36);
            LabelA.Name = "LabelA";
            LabelA.Size = new Size(15, 17);
            LabelA.TabIndex = 70;
            LabelA.Text = "a";
            // 
            // LabelHome
            // 
            LabelHome.AutoSize = true;
            LabelHome.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelHome.ForeColor = SystemColors.ControlLightLight;
            LabelHome.Location = new Point(14, 41);
            LabelHome.Name = "LabelHome";
            LabelHome.Size = new Size(38, 13);
            LabelHome.TabIndex = 19;
            LabelHome.Text = "Home";
            // 
            // LabelPesquisarVendas
            // 
            LabelPesquisarVendas.AutoSize = true;
            LabelPesquisarVendas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelPesquisarVendas.ForeColor = Color.White;
            LabelPesquisarVendas.Location = new Point(72, 19);
            LabelPesquisarVendas.Name = "LabelPesquisarVendas";
            LabelPesquisarVendas.Size = new Size(194, 17);
            LabelPesquisarVendas.TabIndex = 53;
            LabelPesquisarVendas.Text = "Pesquisar Insumo no Estoque:";
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Culture = new System.Globalization.CultureInfo("");
            maskedTextBox2.Location = new Point(756, 33);
            maskedTextBox2.Mask = "00/00/0000";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(96, 23);
            maskedTextBox2.TabIndex = 4;
            maskedTextBox2.ValidatingType = typeof(DateTime);
            // 
            // PictureBoxAtualizar
            // 
            PictureBoxAtualizar.Image = Properties.Resources.Atualizar;
            PictureBoxAtualizar.Location = new Point(1256, 13);
            PictureBoxAtualizar.Name = "PictureBoxAtualizar";
            PictureBoxAtualizar.Size = new Size(29, 25);
            PictureBoxAtualizar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxAtualizar.TabIndex = 51;
            PictureBoxAtualizar.TabStop = false;
            PictureBoxAtualizar.Click += PictureBoxAtualizar_Click;
            // 
            // PictureBoxEditar
            // 
            PictureBoxEditar.Image = Properties.Resources.editar;
            PictureBoxEditar.Location = new Point(1140, 13);
            PictureBoxEditar.Name = "PictureBoxEditar";
            PictureBoxEditar.Size = new Size(29, 25);
            PictureBoxEditar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxEditar.TabIndex = 44;
            PictureBoxEditar.TabStop = false;
            // 
            // LabelPeriodo
            // 
            LabelPeriodo.AutoSize = true;
            LabelPeriodo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelPeriodo.ForeColor = Color.White;
            LabelPeriodo.Location = new Point(696, 36);
            LabelPeriodo.Name = "LabelPeriodo";
            LabelPeriodo.Size = new Size(60, 17);
            LabelPeriodo.TabIndex = 68;
            LabelPeriodo.Text = "Periodo:";
            // 
            // PictureBoxDeletar
            // 
            PictureBoxDeletar.Image = Properties.Resources.Deletar;
            PictureBoxDeletar.Location = new Point(1198, 13);
            PictureBoxDeletar.Name = "PictureBoxDeletar";
            PictureBoxDeletar.Size = new Size(29, 25);
            PictureBoxDeletar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxDeletar.TabIndex = 45;
            PictureBoxDeletar.TabStop = false;
            // 
            // LabelAtualizar
            // 
            LabelAtualizar.AutoSize = true;
            LabelAtualizar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelAtualizar.ForeColor = Color.White;
            LabelAtualizar.Location = new Point(1241, 38);
            LabelAtualizar.Name = "LabelAtualizar";
            LabelAtualizar.Size = new Size(61, 17);
            LabelAtualizar.TabIndex = 50;
            LabelAtualizar.Text = "Atualizar";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1314, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // LabelDeletar
            // 
            LabelDeletar.AutoSize = true;
            LabelDeletar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelDeletar.ForeColor = Color.White;
            LabelDeletar.Location = new Point(1186, 38);
            LabelDeletar.Name = "LabelDeletar";
            LabelDeletar.Size = new Size(51, 17);
            LabelDeletar.TabIndex = 49;
            LabelDeletar.Text = "Deletar";
            // 
            // PictureBoxPesquisar
            // 
            PictureBoxPesquisar.Image = (Image)resources.GetObject("PictureBoxPesquisar.Image");
            PictureBoxPesquisar.Location = new Point(1024, 13);
            PictureBoxPesquisar.Name = "PictureBoxPesquisar";
            PictureBoxPesquisar.Size = new Size(29, 25);
            PictureBoxPesquisar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxPesquisar.TabIndex = 55;
            PictureBoxPesquisar.TabStop = false;
            // 
            // labelRelatorio
            // 
            labelRelatorio.AutoSize = true;
            labelRelatorio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRelatorio.ForeColor = Color.White;
            labelRelatorio.Location = new Point(1303, 38);
            labelRelatorio.Name = "labelRelatorio";
            labelRelatorio.Size = new Size(62, 17);
            labelRelatorio.TabIndex = 65;
            labelRelatorio.Text = "Relatório";
            // 
            // LabelEditar
            // 
            LabelEditar.AutoSize = true;
            LabelEditar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelEditar.ForeColor = Color.White;
            LabelEditar.Location = new Point(1133, 38);
            LabelEditar.Name = "LabelEditar";
            LabelEditar.Size = new Size(43, 17);
            LabelEditar.TabIndex = 48;
            LabelEditar.Text = "Editar";
            // 
            // PictureBoxIncluir
            // 
            PictureBoxIncluir.Image = Properties.Resources.Incluir;
            PictureBoxIncluir.Location = new Point(1082, 13);
            PictureBoxIncluir.Name = "PictureBoxIncluir";
            PictureBoxIncluir.Size = new Size(29, 25);
            PictureBoxIncluir.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxIncluir.TabIndex = 46;
            PictureBoxIncluir.TabStop = false;
            PictureBoxIncluir.Click += PictureBoxIncluir_Click;
            // 
            // textBoxInsumoComprados
            // 
            textBoxInsumoComprados.Location = new Point(756, 5);
            textBoxInsumoComprados.Name = "textBoxInsumoComprados";
            textBoxInsumoComprados.PlaceholderText = "Digite o nome do insumo";
            textBoxInsumoComprados.Size = new Size(246, 23);
            textBoxInsumoComprados.TabIndex = 3;
            // 
            // LabelCadastrarSaida
            // 
            LabelCadastrarSaida.AutoSize = true;
            LabelCadastrarSaida.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCadastrarSaida.ForeColor = Color.White;
            LabelCadastrarSaida.Location = new Point(1009, 38);
            LabelCadastrarSaida.Name = "LabelCadastrarSaida";
            LabelCadastrarSaida.Size = new Size(66, 17);
            LabelCadastrarSaida.TabIndex = 56;
            LabelCadastrarSaida.Text = "Pesquisar";
            // 
            // LabelIncluir
            // 
            LabelIncluir.AutoSize = true;
            LabelIncluir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelIncluir.ForeColor = Color.White;
            LabelIncluir.Location = new Point(1076, 38);
            LabelIncluir.Name = "LabelIncluir";
            LabelIncluir.Size = new Size(45, 17);
            LabelIncluir.TabIndex = 47;
            LabelIncluir.Text = "Incluir";
            // 
            // LabelPesquisarCompras
            // 
            LabelPesquisarCompras.AutoSize = true;
            LabelPesquisarCompras.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelPesquisarCompras.ForeColor = Color.White;
            LabelPesquisarCompras.Location = new Point(626, 8);
            LabelPesquisarCompras.Name = "LabelPesquisarCompras";
            LabelPesquisarCompras.Size = new Size(129, 17);
            LabelPesquisarCompras.TabIndex = 67;
            LabelPesquisarCompras.Text = "Pesquisar Compras:";
            // 
            // PanelFooter
            // 
            PanelFooter.BackColor = Color.FromArgb(120, 220, 120);
            PanelFooter.Controls.Add(label3);
            PanelFooter.Dock = DockStyle.Bottom;
            PanelFooter.ForeColor = Color.White;
            PanelFooter.Location = new Point(0, 714);
            PanelFooter.Margin = new Padding(5);
            PanelFooter.Name = "PanelFooter";
            PanelFooter.Size = new Size(1370, 35);
            PanelFooter.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(615, 5);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(263, 25);
            label3.TabIndex = 0;
            label3.Text = "FARM SYSTEM | VERSÃO 1.0";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LabelEstoqueInsumo
            // 
            LabelEstoqueInsumo.AutoSize = true;
            LabelEstoqueInsumo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelEstoqueInsumo.ForeColor = Color.DarkGreen;
            LabelEstoqueInsumo.Location = new Point(41, 71);
            LabelEstoqueInsumo.Name = "LabelEstoqueInsumo";
            LabelEstoqueInsumo.Size = new Size(136, 17);
            LabelEstoqueInsumo.TabIndex = 62;
            LabelEstoqueInsumo.Text = "Estoque de Insumos:";
            // 
            // LabelRegistroDeCompras
            // 
            LabelRegistroDeCompras.AutoSize = true;
            LabelRegistroDeCompras.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelRegistroDeCompras.ForeColor = Color.DarkGreen;
            LabelRegistroDeCompras.Location = new Point(656, 71);
            LabelRegistroDeCompras.Name = "LabelRegistroDeCompras";
            LabelRegistroDeCompras.Size = new Size(209, 17);
            LabelRegistroDeCompras.TabIndex = 64;
            LabelRegistroDeCompras.Text = "Registro de Compra de Insumos:";
            // 
            // DataGridViewRegistroDeCompras
            // 
            DataGridViewRegistroDeCompras.AllowUserToAddRows = false;
            DataGridViewRegistroDeCompras.AllowUserToDeleteRows = false;
            DataGridViewRegistroDeCompras.BackgroundColor = SystemColors.Menu;
            DataGridViewRegistroDeCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewRegistroDeCompras.Location = new Point(656, 91);
            DataGridViewRegistroDeCompras.Name = "DataGridViewRegistroDeCompras";
            DataGridViewRegistroDeCompras.ReadOnly = true;
            DataGridViewRegistroDeCompras.RowHeadersWidth = 27;
            DataGridViewRegistroDeCompras.Size = new Size(840, 645);
            DataGridViewRegistroDeCompras.TabIndex = 1;
            DataGridViewRegistroDeCompras.VirtualMode = true;
            // 
            // TelaCompra
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1370, 749);
            Controls.Add(PanelFooter);
            Controls.Add(LabelRegistroDeCompras);
            Controls.Add(DataGridViewRegistroDeCompras);
            Controls.Add(LabelEstoqueInsumo);
            Controls.Add(LabelEstoqueInsumos);
            Controls.Add(DataGridViewListaInsumos);
            Controls.Add(PanelHeader);
            Name = "TelaCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaCompra";
            WindowState = FormWindowState.Maximized;
            Load += TelaCompra_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaInsumos).EndInit();
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxPesquisar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).EndInit();
            PanelFooter.ResumeLayout(false);
            PanelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewRegistroDeCompras).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelEstoqueInsumos;
        private DataGridView DataGridViewListaInsumos;
        private Panel PanelHeader;
        private PictureBox PictureBoxPesquisar;
        private Label LabelCadastrarSaida;
        private PictureBox PictureBoxHome;
        private TextBox TextBoxPesquisar;
        private Label LabelHome;
        private Label LabelPesquisarVendas;
        private PictureBox PictureBoxAtualizar;
        private PictureBox PictureBoxEditar;
        private PictureBox PictureBoxDeletar;
        private Label LabelAtualizar;
        private PictureBox PictureBoxIncluir;
        private Label LabelDeletar;
        private Label LabelIncluir;
        private Label LabelEditar;
        private PictureBox pictureBox1;
        private Label labelRelatorio;
        private Panel PanelFooter;
        private Label label3;
        private MaskedTextBox maskedTextBox1;
        private Label LabelA;
        private MaskedTextBox maskedTextBox2;
        private Label LabelPeriodo;
        private TextBox textBoxInsumoComprados;
        private Label LabelPesquisarCompras;
        private Label LabelEstoqueInsumo;
        private Label LabelRegistroDeCompras;
        private DataGridView DataGridViewRegistroDeCompras;
    }
}