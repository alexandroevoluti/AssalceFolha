namespace AssalceFolha
{
    partial class frmRetornoFolha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetornoFolha));
            this.btnConferencia = new System.Windows.Forms.Button();
            this.mskCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgArquivo = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnGravarSN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConferencia
            // 
            this.btnConferencia.Location = new System.Drawing.Point(214, 230);
            this.btnConferencia.Name = "btnConferencia";
            this.btnConferencia.Size = new System.Drawing.Size(186, 40);
            this.btnConferencia.TabIndex = 27;
            this.btnConferencia.Text = "Conferência";
            this.btnConferencia.UseVisualStyleBackColor = true;
            this.btnConferencia.Click += new System.EventHandler(this.btnConferencia_Click);
            // 
            // mskCompetencia
            // 
            this.mskCompetencia.Location = new System.Drawing.Point(25, 26);
            this.mskCompetencia.Mask = "##/####";
            this.mskCompetencia.Name = "mskCompetencia";
            this.mskCompetencia.Size = new System.Drawing.Size(74, 20);
            this.mskCompetencia.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Competência";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(597, 230);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(186, 40);
            this.btnFechar.TabIndex = 24;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(22, 230);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 23;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Arquivo";
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Location = new System.Drawing.Point(640, 69);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(35, 23);
            this.btnSelecionarPasta.TabIndex = 21;
            this.btnSelecionarPasta.Text = "...";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(25, 72);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(609, 20);
            this.txtFile.TabIndex = 20;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(22, 111);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(761, 108);
            this.lstFiles.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Pasta";
            // 
            // dgArquivo
            // 
            this.dgArquivo.AllowUserToAddRows = false;
            this.dgArquivo.AllowUserToDeleteRows = false;
            this.dgArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArquivo.Location = new System.Drawing.Point(22, 302);
            this.dgArquivo.Name = "dgArquivo";
            this.dgArquivo.ReadOnly = true;
            this.dgArquivo.Size = new System.Drawing.Size(843, 201);
            this.dgArquivo.TabIndex = 30;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 276);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(843, 20);
            this.progressBar.TabIndex = 31;
            this.progressBar.Visible = false;
            // 
            // btnGravarSN
            // 
            this.btnGravarSN.Location = new System.Drawing.Point(405, 230);
            this.btnGravarSN.Name = "btnGravarSN";
            this.btnGravarSN.Size = new System.Drawing.Size(186, 40);
            this.btnGravarSN.TabIndex = 33;
            this.btnGravarSN.Text = "Gravar SN";
            this.btnGravarSN.UseVisualStyleBackColor = true;
            this.btnGravarSN.Click += new System.EventHandler(this.btnGravarSN_Click);
            // 
            // frmRetornoFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 515);
            this.Controls.Add(this.btnGravarSN);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dgArquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConferencia);
            this.Controls.Add(this.mskCompetencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lstFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRetornoFolha";
            this.Text = "Retorno Folha";
            this.Load += new System.EventHandler(this.frmRetornoFolha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConferencia;
        private System.Windows.Forms.MaskedTextBox mskCompetencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dgArquivo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnGravarSN;
    }
}