namespace PIMFazendaUrbana
{
    partial class MenuPrincipal
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
            BotaoCadastrarCliente = new Button();
            SuspendLayout();
            // 
            // BotaoCadastrarCliente
            // 
            BotaoCadastrarCliente.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BotaoCadastrarCliente.Location = new Point(388, 244);
            BotaoCadastrarCliente.Name = "BotaoCadastrarCliente";
            BotaoCadastrarCliente.Size = new Size(211, 75);
            BotaoCadastrarCliente.TabIndex = 0;
            BotaoCadastrarCliente.Text = "Cadastrar Cliente";
            BotaoCadastrarCliente.UseVisualStyleBackColor = true;
            BotaoCadastrarCliente.Click += button1_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 677);
            Controls.Add(BotaoCadastrarCliente);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fazenda Urbana";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BotaoCadastrarCliente;
    }
}