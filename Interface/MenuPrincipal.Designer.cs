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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(629, 244);
            button1.Name = "button1";
            button1.Size = new Size(211, 75);
            button1.TabIndex = 1;
            button1.Text = "Listar Clientes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(472, 424);
            button2.Name = "button2";
            button2.Size = new Size(211, 75);
            button2.TabIndex = 2;
            button2.Text = "TESTES";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(472, 76);
            button3.Name = "button3";
            button3.Size = new Size(211, 75);
            button3.TabIndex = 3;
            button3.Text = "Cadastrar Funcionario";
            button3.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 677);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Button button3;
    }
}