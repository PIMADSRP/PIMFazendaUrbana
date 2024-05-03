namespace PIMFazendaUrbana
{
    partial class TelaFuncionarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaFuncionarios));
            PanelFooter = new Panel();
            label1 = new Label();
            TextBoxPesquisar = new TextBox();
            LabelPesquisarUsuarios = new Label();
            DataGridViewListaFuncionarios = new DataGridView();
            PictureBoxEditar = new PictureBox();
            PictureBoxDeletar = new PictureBox();
            PictureBoxIncluir = new PictureBox();
            LabelIncluir = new Label();
            LabelEditar = new Label();
            LabelDeletar = new Label();
            PanelHeader = new Panel();
            PictureBoxHome = new PictureBox();
            LabelHome = new Label();
            LabelAtualizar = new Label();
            PictureBoxAtualizar = new PictureBox();
            PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaFuncionarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).BeginInit();
            PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).BeginInit();
            SuspendLayout();
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
            PanelFooter.TabIndex = 1;
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
            // TextBoxPesquisar
            // 
            TextBoxPesquisar.Enabled = false;
            TextBoxPesquisar.Location = new Point(120, 83);
            TextBoxPesquisar.Name = "TextBoxPesquisar";
            TextBoxPesquisar.Size = new Size(421, 23);
            TextBoxPesquisar.TabIndex = 31;
            // 
            // LabelPesquisarUsuarios
            // 
            LabelPesquisarUsuarios.AutoSize = true;
            LabelPesquisarUsuarios.Location = new Point(0, 87);
            LabelPesquisarUsuarios.Name = "LabelPesquisarUsuarios";
            LabelPesquisarUsuarios.Size = new Size(108, 15);
            LabelPesquisarUsuarios.TabIndex = 30;
            LabelPesquisarUsuarios.Text = "Pesquisar Usuários:";
            // 
            // DataGridViewListaFuncionarios
            // 
            DataGridViewListaFuncionarios.AllowUserToAddRows = false;
            DataGridViewListaFuncionarios.AllowUserToDeleteRows = false;
            DataGridViewListaFuncionarios.BackgroundColor = SystemColors.Menu;
            DataGridViewListaFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewListaFuncionarios.Location = new Point(120, 126);
            DataGridViewListaFuncionarios.Name = "DataGridViewListaFuncionarios";
            DataGridViewListaFuncionarios.Size = new Size(1235, 565);
            DataGridViewListaFuncionarios.TabIndex = 33;
            // 
            // PictureBoxEditar
            // 
            PictureBoxEditar.Image = (Image)resources.GetObject("PictureBoxEditar.Image");
            PictureBoxEditar.Location = new Point(628, 79);
            PictureBoxEditar.Name = "PictureBoxEditar";
            PictureBoxEditar.Size = new Size(27, 23);
            PictureBoxEditar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxEditar.TabIndex = 35;
            PictureBoxEditar.TabStop = false;
            PictureBoxEditar.Click += PictureBoxEditar_Click;
            // 
            // PictureBoxDeletar
            // 
            PictureBoxDeletar.Image = (Image)resources.GetObject("PictureBoxDeletar.Image");
            PictureBoxDeletar.Location = new Point(682, 79);
            PictureBoxDeletar.Name = "PictureBoxDeletar";
            PictureBoxDeletar.Size = new Size(27, 23);
            PictureBoxDeletar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxDeletar.TabIndex = 36;
            PictureBoxDeletar.TabStop = false;
            PictureBoxDeletar.Click += PictureBoxDeletar_Click;
            // 
            // PictureBoxIncluir
            // 
            PictureBoxIncluir.Image = (Image)resources.GetObject("PictureBoxIncluir.Image");
            PictureBoxIncluir.Location = new Point(574, 79);
            PictureBoxIncluir.Name = "PictureBoxIncluir";
            PictureBoxIncluir.Size = new Size(27, 23);
            PictureBoxIncluir.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxIncluir.TabIndex = 37;
            PictureBoxIncluir.TabStop = false;
            PictureBoxIncluir.Click += PictureBoxIncluir_Click;
            // 
            // LabelIncluir
            // 
            LabelIncluir.AutoSize = true;
            LabelIncluir.Location = new Point(568, 104);
            LabelIncluir.Name = "LabelIncluir";
            LabelIncluir.Size = new Size(40, 15);
            LabelIncluir.TabIndex = 38;
            LabelIncluir.Text = "Incluir";
            // 
            // LabelEditar
            // 
            LabelEditar.AutoSize = true;
            LabelEditar.Location = new Point(623, 104);
            LabelEditar.Name = "LabelEditar";
            LabelEditar.Size = new Size(37, 15);
            LabelEditar.TabIndex = 39;
            LabelEditar.Text = "Editar";
            // 
            // LabelDeletar
            // 
            LabelDeletar.AutoSize = true;
            LabelDeletar.Location = new Point(674, 104);
            LabelDeletar.Name = "LabelDeletar";
            LabelDeletar.Size = new Size(44, 15);
            LabelDeletar.TabIndex = 40;
            LabelDeletar.Text = "Deletar";
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
            PanelHeader.TabIndex = 41;
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
            // LabelAtualizar
            // 
            LabelAtualizar.AutoSize = true;
            LabelAtualizar.Location = new Point(726, 103);
            LabelAtualizar.Name = "LabelAtualizar";
            LabelAtualizar.Size = new Size(53, 15);
            LabelAtualizar.TabIndex = 42;
            LabelAtualizar.Text = "Atualizar";
            // 
            // PictureBoxAtualizar
            // 
            PictureBoxAtualizar.Image = (Image)resources.GetObject("PictureBoxAtualizar.Image");
            PictureBoxAtualizar.Location = new Point(736, 79);
            PictureBoxAtualizar.Name = "PictureBoxAtualizar";
            PictureBoxAtualizar.Size = new Size(27, 23);
            PictureBoxAtualizar.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxAtualizar.TabIndex = 43;
            PictureBoxAtualizar.TabStop = false;
            PictureBoxAtualizar.Click += PictureBoxAtualizar_Click;
            // 
            // TelaFuncionarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(PictureBoxAtualizar);
            Controls.Add(LabelAtualizar);
            Controls.Add(PanelHeader);
            Controls.Add(LabelDeletar);
            Controls.Add(LabelEditar);
            Controls.Add(LabelIncluir);
            Controls.Add(PictureBoxIncluir);
            Controls.Add(PictureBoxDeletar);
            Controls.Add(PictureBoxEditar);
            Controls.Add(DataGridViewListaFuncionarios);
            Controls.Add(TextBoxPesquisar);
            Controls.Add(PanelFooter);
            Controls.Add(LabelPesquisarUsuarios);
            Name = "TelaFuncionarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            WindowState = FormWindowState.Maximized;
            Load += TelaFuncionarios_Load;
            PanelFooter.ResumeLayout(false);
            PanelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewListaFuncionarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEditar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxDeletar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxIncluir).EndInit();
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxAtualizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelFooter;
        private Label label1;
        private TextBox TextBoxPesquisar;
        private Label LabelPesquisarUsuarios;
        private DataGridView DataGridViewListaFuncionarios;
        private PictureBox PictureBoxEditar;
        private PictureBox PictureBoxDeletar;
        private PictureBox PictureBoxIncluir;
        private Label LabelIncluir;
        private Label LabelEditar;
        private Label LabelDeletar;
        private Panel PanelHeader;
        private PictureBox PictureBoxHome;
        private Label LabelHome;
        private Label LabelAtualizar;
        private PictureBox PictureBoxAtualizar;
    }
}