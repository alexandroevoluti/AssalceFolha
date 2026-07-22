namespace AssalceFolha
{
    partial class frmAtualizaFolhaEmMassa
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.Progresso = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(40, 38);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(513, 20);
            this.txtArquivo.TabIndex = 1;
            this.txtArquivo.Text = "D:\\temp\\Assalce\\SERVIDORES ALECE.XLS";
            // 
            // Progresso
            // 
            this.Progresso.Location = new System.Drawing.Point(40, 64);
            this.Progresso.Name = "Progresso";
            this.Progresso.Size = new System.Drawing.Size(513, 21);
            this.Progresso.TabIndex = 34;
            this.Progresso.Visible = false;
            // 
            // frmAtualizaFolhaEmMassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 261);
            this.Controls.Add(this.Progresso);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.button1);
            this.Name = "frmAtualizaFolhaEmMassa";
            this.Text = "frmAtualizaFolhaEmMassa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.ProgressBar Progresso;
    }
}