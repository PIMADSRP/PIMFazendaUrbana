namespace PIMFazendaUrbanaForms
{
    partial class TelaInsumo
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
            PictureBoxHome = new PictureBox();
            TextBoxPesquisar = new TextBox();
            LabelHome = new Label();
            LabelPesquisarClientes = new Label();
            PictureBoxAtualizar = new PictureBox();
            PictureBoxEditar = new PictureBox();
            PictureBoxDeletar = new PictureBox();
            LabelAtualizar = new Label();
            PictureBoxIncluir = new PictureBox();
            LabelDeletar = new Label();
            LabelIncluir = new Label();
            LabelEditar = new Label();
            DataGridViewListaInsumos = new DataGridView();
            PanelFooter = new Panel();
            label1 = new Label();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaInsumos).BeginInit();
            PanelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // PanelHeader
            // 
            PanelHeader.BackColor = Color.FromArgb(55, 185, 65);
            PanelHeader.Controls.Add(PictureBoxHome);
            PanelHeader.Controls.Add(TextBoxPesquisar);
            PanelHeader.Controls.Add(LabelHome);
            PanelHeader.Controls.Add(LabelPesquisarClientes);
            PanelHeader.Controls.Add(PictureBoxAtualizar);
            PanelHeader.Controls.Add(PictureBoxEditar);
            PanelHeader.Controls.Add(PictureBoxDeletar);
            PanelHeader.Controls.Add(LabelAtualizar);
            PanelHeader.Controls.Add(PictureBoxIncluir);
            PanelHeader.Controls.Add(LabelDeletar);
            PanelHeader.Controls.Add(LabelIncluir);
            PanelHeader.Controls.Add(LabelEditar);
            PanelHeader.Dock = DockStyle.Top;
            PanelHeader.Location = new Point(0, 0);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(1370, 60);
            PanelHeader.TabIndex = 53;
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
            TextBoxPesquisar.Location = new Point(201, 19);
            TextBoxPesquisar.Name = "TextBoxPesquisar";
            TextBoxPesquisar.PlaceholderText = "Digite o nome do insumo";
            TextBoxPesquisar.Size = new Size(407, 23);
            TextBoxPesquisar.TabIndex = 54;
            TextBoxPesquisar.TextChanged += TextBoxPesquisar_TextChanged;
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
            // LabelPesquisarClientes
            // 
            LabelPesquisarClientes.AutoSize = true;
            LabelPesquisarClientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelPesquisarClientes.ForeColor = Color.White;
            LabelPesquisarClientes.Location = new Point(72, 21);
            LabelPesquisarClientes.Name = "LabelPesquisarClientes";
            LabelPesquisarClientes.Size = new Size(127, 17);
            LabelPesquisarClientes.TabIndex = 53;
            LabelPesquisarClientes.Text = "Pesquisar Insumos:";
            // 
            // PictureBoxAtualizar
            // 
            PictureBoxAtualizar.Image = Properties.Resources.Atualizar;
            PictureBoxAtualizar.Location = new Point(809, 12);
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
            PictureBoxEditar.Location = new Point(693, 12);
            PictureBoxEditar.Name = "PictureBoxEditar";
            PictureBoxEditar.Size = new Size(29, 25);
            PictureBoxEditar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxEditar.TabIndex = 44;
            PictureBoxEditar.TabStop = false;
            PictureBoxEditar.Click += PictureBoxEditar_Click;
            // 
            // PictureBoxDeletar
            // 
            PictureBoxDeletar.Image = Properties.Resources.Deletar;
            PictureBoxDeletar.Location = new Point(751, 12);
            PictureBoxDeletar.Name = "PictureBoxDeletar";
            PictureBoxDeletar.Size = new Size(29, 25);
            PictureBoxDeletar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxDeletar.TabIndex = 45;
            PictureBoxDeletar.TabStop = false;
            PictureBoxDeletar.Click += PictureBoxDeletar_Click;
            // 
            // LabelAtualizar
            // 
            LabelAtualizar.AutoSize = true;
            LabelAtualizar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelAtualizar.ForeColor = Color.White;
            LabelAtualizar.Location = new Point(795, 37);
            LabelAtualizar.Name = "LabelAtualizar";
            LabelAtualizar.Size = new Size(61, 17);
            LabelAtualizar.TabIndex = 50;
            LabelAtualizar.Text = "Atualizar";
            // 
            // PictureBoxIncluir
            // 
            PictureBoxIncluir.Image = Properties.Resources.Incluir;
            PictureBoxIncluir.Location = new Point(637, 12);
            PictureBoxIncluir.Name = "PictureBoxIncluir";
            PictureBoxIncluir.Size = new Size(29, 25);
            PictureBoxIncluir.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxIncluir.TabIndex = 46;
            PictureBoxIncluir.TabStop = false;
            PictureBoxIncluir.Click += PictureBoxIncluir_Click;
            // 
            // LabelDeletar
            // 
            LabelDeletar.AutoSize = true;
            LabelDeletar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelDeletar.ForeColor = Color.White;
            LabelDeletar.Location = new Point(742, 37);
            LabelDeletar.Name = "LabelDeletar";
            LabelDeletar.Size = new Size(51, 17);
            LabelDeletar.TabIndex = 49;
            LabelDeletar.Text = "Deletar";
            // 
            // LabelIncluir
            // 
            LabelIncluir.AutoSize = true;
            LabelIncluir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelIncluir.ForeColor = Color.White;
            LabelIncluir.Location = new Point(630, 37);
            LabelIncluir.Name = "LabelIncluir";
            LabelIncluir.Size = new Size(45, 17);
            LabelIncluir.TabIndex = 47;
            LabelIncluir.Text = "Incluir";
            // 
            // LabelEditar
            // 
            LabelEditar.AutoSize = true;
            LabelEditar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            LabelEditar.ForeColor = Color.White;
            LabelEditar.Location = new Point(688, 37);
            LabelEditar.Name = "LabelEditar";
            LabelEditar.Size = new Size(43, 17);
            LabelEditar.TabIndex = 48;
            LabelEditar.Text = "Editar";
            // 
            // DataGridViewListaInsumos
            // 
            DataGridViewListaInsumos.AllowUserToAddRows = false;
            DataGridViewListaInsumos.AllowUserToDeleteRows = false;
            DataGridViewListaInsumos.BackgroundColor = SystemColors.Menu;
            DataGridViewListaInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewListaInsumos.Location = new Point(51, 85);
            DataGridViewListaInsumos.Name = "DataGridViewListaInsumos";
            DataGridViewListaInsumos.ReadOnly = true;
            DataGridViewListaInsumos.Size = new Size(1307, 621);
            DataGridViewListaInsumos.TabIndex = 54;
            DataGridViewListaInsumos.VirtualMode = true;
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
            PanelFooter.TabIndex = 56;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(615, 5);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(263, 25);
            label1.TabIndex = 0;
            label1.Text = "FARM SYSTEM | VERSÃO 1.0";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TelaInsumo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(PanelFooter);
            Controls.Add(DataGridViewListaInsumos);
            Controls.Add(PanelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TelaInsumo";
            Text = "Insumos";
            WindowState = FormWindowState.Maximized;
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaInsumos).EndInit();
            PanelFooter.ResumeLayout(false);
            PanelFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelHeader;
        private PictureBox PictureBoxHome;
        private TextBox TextBoxPesquisar;
        private Label LabelHome;
        private Label LabelPesquisarClientes;
        private PictureBox PictureBoxAtualizar;
        private PictureBox PictureBoxEditar;
        private PictureBox PictureBoxDeletar;
        private Label LabelAtualizar;
        private PictureBox PictureBoxIncluir;
        private Label LabelDeletar;
        private Label LabelIncluir;
        private Label LabelEditar;
        private DataGridView DataGridViewListaInsumos;
        private Panel PanelFooter;
        private Label label1;
    }
}