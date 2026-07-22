namespace AssalceFolha
{
    partial class frmCargaCobrancaHapVida
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
            this.btnConferencia = new System.Windows.Forms.Button();
            this.dgCompra = new System.Windows.Forms.DataGridView();
            this.mskCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.cboPlano = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConferencia
            // 
            this.btnConferencia.Location = new System.Drawing.Point(208, 226);
            this.btnConferencia.Name = "btnConferencia";
            this.btnConferencia.Size = new System.Drawing.Size(186, 40);
            this.btnConferencia.TabIndex = 35;
            this.btnConferencia.Text = "Conferência";
            this.btnConferencia.UseVisualStyleBackColor = true;
            // 
            // dgCompra
            // 
            this.dgCompra.AllowUserToAddRows = false;
            this.dgCompra.AllowUserToDeleteRows = false;
            this.dgCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompra.Location = new System.Drawing.Point(12, 272);
            this.dgCompra.Name = "dgCompra";
            this.dgCompra.ReadOnly = true;
            this.dgCompra.Size = new System.Drawing.Size(1209, 300);
            this.dgCompra.TabIndex = 32;
            // 
            // mskCompetencia
            // 
            this.mskCompetencia.Location = new System.Drawing.Point(265, 23);
            this.mskCompetencia.Mask = "##/####";
            this.mskCompetencia.Name = "mskCompetencia";
            this.mskCompetencia.Size = new System.Drawing.Size(74, 20);
            this.mskCompetencia.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Competência";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(404, 226);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(186, 40);
            this.btnFechar.TabIndex = 28;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(12, 226);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 27;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // cboPlano
            // 
            this.cboPlano.FormattingEnabled = true;
            this.cboPlano.Location = new System.Drawing.Point(15, 22);
            this.cboPlano.Name = "cboPlano";
            this.cboPlano.Size = new System.Drawing.Size(244, 21);
            this.cboPlano.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Plano Hap Vida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Arquivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pasta";
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Location = new System.Drawing.Point(555, 65);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(35, 23);
            this.btnSelecionarPasta.TabIndex = 22;
            this.btnSelecionarPasta.Text = "...";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click_1);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(12, 68);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(537, 20);
            this.txtFile.TabIndex = 21;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 107);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(1209, 108);
            this.lstFiles.TabIndex = 20;
            // 
            // frmCargaCobrancaHapVida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 577);
            this.Controls.Add(this.btnConferencia);
            this.Controls.Add(this.dgCompra);
            this.Controls.Add(this.mskCompetencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.cboPlano);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lstFiles);
            this.Name = "frmCargaCobrancaHapVida";
            this.Text = "frmCargaCobrancaHapVida";
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConferencia;
        private System.Windows.Forms.DataGridView dgCompra;
        private System.Windows.Forms.MaskedTextBox mskCompetencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.ComboBox cboPlano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}