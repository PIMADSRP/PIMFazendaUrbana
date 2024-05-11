using PIMFazendaUrbanaLib;

namespace PIMFazendaUrbanaForms
{
    partial class TelaClientes
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaClientes));
            DataGridViewListaClientes = new DataGridView();
            clienteServiceBindingSource = new BindingSource(components);
            PictureBoxAtualizar = new PictureBox();
            LabelAtualizar = new Label();
            LabelDeletar = new Label();
            LabelEditar = new Label();
            LabelIncluir = new Label();
            PictureBoxIncluir = new PictureBox();
            PictureBoxDeletar = new PictureBox();
            PictureBoxEditar = new PictureBox();
            PanelHeader = new Panel();
            PictureBoxHome = new PictureBox();
            LabelHome = new Label();
            TextBoxPesquisar = new TextBox();
            LabelPesquisarClientes = new Label();
            PanelFooter = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteServiceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).BeginInit();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).BeginInit();
            PanelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridViewListaClientes
            // 
            DataGridViewListaClientes.AllowUserToAddRows = false;
            DataGridViewListaClientes.AllowUserToDeleteRows = false;
            DataGridViewListaClientes.BackgroundColor = SystemColors.Menu;
            DataGridViewListaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewListaClientes.Location = new Point(120, 126);
            DataGridViewListaClientes.Name = "DataGridViewListaClientes";
            DataGridViewListaClientes.ReadOnly = true;
            DataGridViewListaClientes.Size = new Size(1235, 565);
            DataGridViewListaClientes.TabIndex = 0;
            DataGridViewListaClientes.VirtualMode = true;
            // 
            // clienteServiceBindingSource
            // 
            clienteServiceBindingSource.DataSource = typeof(ClienteService);
            // 
            // PictureBoxAtualizar
            // 
            PictureBoxAtualizar.Image = (Image)resources.GetObject("PictureBoxAtualizar.Image");
            PictureBoxAtualizar.Location = new Point(735, 78);
            PictureBoxAtualizar.Name = "PictureBoxAtualizar";
            PictureBoxAtualizar.Size = new Size(29, 25);
            PictureBoxAtualizar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxAtualizar.TabIndex = 51;
            PictureBoxAtualizar.TabStop = false;
            PictureBoxAtualizar.Click += PictureBoxAtualizar_Click;
            // 
            // LabelAtualizar
            // 
            LabelAtualizar.AutoSize = true;
            LabelAtualizar.Location = new Point(725, 102);
            LabelAtualizar.Name = "LabelAtualizar";
            LabelAtualizar.Size = new Size(53, 15);
            LabelAtualizar.TabIndex = 50;
            LabelAtualizar.Text = "Atualizar";
            // 
            // LabelDeletar
            // 
            LabelDeletar.AutoSize = true;
            LabelDeletar.Location = new Point(673, 103);
            LabelDeletar.Name = "LabelDeletar";
            LabelDeletar.Size = new Size(44, 15);
            LabelDeletar.TabIndex = 49;
            LabelDeletar.Text = "Deletar";
            // 
            // LabelEditar
            // 
            LabelEditar.AutoSize = true;
            LabelEditar.Location = new Point(622, 103);
            LabelEditar.Name = "LabelEditar";
            LabelEditar.Size = new Size(37, 15);
            LabelEditar.TabIndex = 48;
            LabelEditar.Text = "Editar";
            // 
            // LabelIncluir
            // 
            LabelIncluir.AutoSize = true;
            LabelIncluir.Location = new Point(567, 103);
            LabelIncluir.Name = "LabelIncluir";
            LabelIncluir.Size = new Size(40, 15);
            LabelIncluir.TabIndex = 47;
            LabelIncluir.Text = "Incluir";
            // 
            // PictureBoxIncluir
            // 
            PictureBoxIncluir.Image = (Image)resources.GetObject("PictureBoxIncluir.Image");
            PictureBoxIncluir.Location = new Point(573, 78);
            PictureBoxIncluir.Name = "PictureBoxIncluir";
            PictureBoxIncluir.Size = new Size(29, 25);
            PictureBoxIncluir.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxIncluir.TabIndex = 46;
            PictureBoxIncluir.TabStop = false;
            PictureBoxIncluir.Click += PictureBoxIncluir_Click;
            // 
            // PictureBoxDeletar
            // 
            PictureBoxDeletar.Image = (Image)resources.GetObject("PictureBoxDeletar.Image");
            PictureBoxDeletar.Location = new Point(681, 78);
            PictureBoxDeletar.Name = "PictureBoxDeletar";
            PictureBoxDeletar.Size = new Size(29, 25);
            PictureBoxDeletar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxDeletar.TabIndex = 45;
            PictureBoxDeletar.TabStop = false;
            PictureBoxDeletar.Click += PictureBoxDeletar_Click;
            // 
            // PictureBoxEditar
            // 
            PictureBoxEditar.Image = (Image)resources.GetObject("PictureBoxEditar.Image");
            PictureBoxEditar.Location = new Point(627, 78);
            PictureBoxEditar.Name = "PictureBoxEditar";
            PictureBoxEditar.Size = new Size(29, 25);
            PictureBoxEditar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxEditar.TabIndex = 44;
            PictureBoxEditar.TabStop = false;
            PictureBoxEditar.Click += PictureBoxEditar_Click;
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(PictureBoxHome);
            PanelHeader.Controls.Add(LabelHome);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(1370, 60);
            PanelHeader.TabIndex = 52;
            // 
            // PictureBoxHome
            // 
            PictureBoxHome.AccessibleDescription = "Usuarios";
            PictureBoxHome.AccessibleName = "Usuarios";
            PictureBoxHome.AccessibleRole = AccessibleRole.TitleBar;
            PictureBoxHome.Image = (Image)resources.GetObject("PictureBoxHome.Image");
            PictureBoxHome.Location = new Point(12, 4);
            PictureBoxHome.Name = "PictureBoxHome";
            PictureBoxHome.Size = new Size(40, 37);
            PictureBoxHome.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxHome.TabIndex = 18;
            PictureBoxHome.TabStop = false;
            PictureBoxHome.Click += PictureBoxHome_Click;
            // 
            // LabelHome
            // 
            LabelHome.AutoSize = true;
            LabelHome.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelHome.ForeColor = SystemColors.ControlLightLight;
            LabelHome.Location = new Point(14, 44);
            LabelHome.Name = "LabelHome";
            LabelHome.Size = new Size(38, 13);
            LabelHome.TabIndex = 19;
            LabelHome.Text = "Home";
            // 
            // TextBoxPesquisar
            // 
            TextBoxPesquisar.Enabled = false;
            TextBoxPesquisar.Location = new Point(122, 82);
            TextBoxPesquisar.Name = "TextBoxPesquisar";
            TextBoxPesquisar.Size = new Size(421, 23);
            TextBoxPesquisar.TabIndex = 54;
            // 
            // LabelPesquisarClientes
            // 
            LabelPesquisarClientes.AutoSize = true;
            LabelPesquisarClientes.Location = new Point(2, 86);
            LabelPesquisarClientes.Name = "LabelPesquisarClientes";
            LabelPesquisarClientes.Size = new Size(105, 15);
            LabelPesquisarClientes.TabIndex = 53;
            LabelPesquisarClientes.Text = "Pesquisar Clientes:";
            // 
            // PanelFooter
            // 
            PanelFooter.BackColor = Color.FromArgb(120, 220, 120);
            PanelFooter.Controls.Add(label1);
            PanelFooter.Dock = DockStyle.Bottom;
            PanelFooter.ForeColor = Color.White;
            PanelFooter.Location = new Point(0, 714);
            PanelFooter.Margin = new Padding(5);
            PanelFooter.Name = "PanelFooter";
            PanelFooter.Size = new Size(1370, 35);
            PanelFooter.TabIndex = 55;
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
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TelaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(PanelFooter);
            Controls.Add(TextBoxPesquisar);
            Controls.Add(LabelPesquisarClientes);
            Controls.Add(PanelHeader);
            Controls.Add(PictureBoxAtualizar);
            Controls.Add(LabelAtualizar);
            Controls.Add(LabelDeletar);
            Controls.Add(LabelEditar);
            Controls.Add(LabelIncluir);
            Controls.Add(PictureBoxIncluir);
            Controls.Add(PictureBoxDeletar);
            Controls.Add(PictureBoxEditar);
            Controls.Add(DataGridViewListaClientes);
            Name = "TelaClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Clientes";
            WindowState = FormWindowState.Maximized;
            Load += TelaListarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteServiceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).EndInit();
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).EndInit();
            PanelFooter.ResumeLayout(false);
            PanelFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridViewListaClientes;
        private BindingSource clienteServiceBindingSource;
        private PictureBox PictureBoxAtualizar;
        private Label LabelAtualizar;
        private Label LabelDeletar;
        private Label LabelEditar;
        private Label LabelIncluir;
        private PictureBox PictureBoxIncluir;
        private PictureBox PictureBoxDeletar;
        private PictureBox PictureBoxEditar;
        private Panel PanelHeader;
        private PictureBox PictureBoxHome;
        private Label LabelHome;
        private TextBox TextBoxPesquisar;
        private Label LabelPesquisarClientes;
        private Panel PanelFooter;
        private Label label1;
    }
}