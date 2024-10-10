namespace PIMFazendaUrbanaForms
{
    partial class TelaSplash
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
            SuspendLayout();
            // 
            // TelaSplash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Logo;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(489, 450);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaSplash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Splash";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion
    }
}