namespace AssalceFolha
{
    partial class frmCargaMargem
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
            this.dgCompra = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Progresso = new System.Windows.Forms.ProgressBar();
            this.dtpCompetencia = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCompra
            // 
            this.dgCompra.AllowUserToAddRows = false;
            this.dgCompra.AllowUserToDeleteRows = false;
            this.dgCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompra.Location = new System.Drawing.Point(10, 243);
            this.dgCompra.Name = "dgCompra";
            this.dgCompra.ReadOnly = true;
            this.dgCompra.Size = new System.Drawing.Size(902, 235);
            this.dgCompra.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Competência";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(202, 178);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(186, 40);
            this.btnFechar.TabIndex = 28;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(10, 178);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 27;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Arquivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pasta";
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Location = new System.Drawing.Point(553, 59);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(35, 23);
            this.btnSelecionarPasta.TabIndex = 22;
            this.btnSelecionarPasta.Text = "...";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(10, 62);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(537, 20);
            this.txtFile.TabIndex = 21;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(10, 101);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(578, 69);
            this.lstFiles.TabIndex = 20;
            // 
            // Progresso
            // 
            this.Progresso.Location = new System.Drawing.Point(10, 224);
            this.Progresso.Name = "Progresso";
            this.Progresso.Size = new System.Drawing.Size(902, 13);
            this.Progresso.TabIndex = 33;
            this.Progresso.Visible = false;
            // 
            // dtpCompetencia
            // 
            this.dtpCompetencia.CustomFormat = "MM/yyyy";
            this.dtpCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetencia.Location = new System.Drawing.Point(10, 21);
            this.dtpCompetencia.Name = "dtpCompetencia";
            this.dtpCompetencia.ShowUpDown = true;
            this.dtpCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetencia.TabIndex = 34;
            // 
            // frmCargaMargem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 488);
            this.Controls.Add(this.dtpCompetencia);
            this.Controls.Add(this.Progresso);
            this.Controls.Add(this.dgCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lstFiles);
            this.Name = "frmCargaMargem";
            this.Text = "Carga Margem";
            this.Load += new System.EventHandler(this.frmCargaMargem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar Progresso;
        private System.Windows.Forms.DateTimePicker dtpCompetencia;
    }
}