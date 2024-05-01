namespace PIMFazendaUrbana
{
    partial class TelaListarClientes
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
            dataGridViewListaClientes = new DataGridView();
            clienteServiceBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteServiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewListaClientes
            // 
            dataGridViewListaClientes.AllowUserToAddRows = false;
            dataGridViewListaClientes.AllowUserToDeleteRows = false;
            dataGridViewListaClientes.BackgroundColor = SystemColors.Menu;
            dataGridViewListaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListaClientes.Location = new Point(32, 59);
            dataGridViewListaClientes.Name = "dataGridViewListaClientes";
            dataGridViewListaClientes.ReadOnly = true;
            dataGridViewListaClientes.Size = new Size(736, 289);
            dataGridViewListaClientes.TabIndex = 0;
            dataGridViewListaClientes.VirtualMode = true;
            // 
            // clienteServiceBindingSource
            // 
            clienteServiceBindingSource.DataSource = typeof(ClienteService);
            // 
            // TelaListarClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewListaClientes);
            Name = "TelaListarClientes";
            Text = "Listar Clientes";
            Load += TelaListarClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteServiceBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewListaClientes;
        private BindingSource clienteServiceBindingSource;
    }
}