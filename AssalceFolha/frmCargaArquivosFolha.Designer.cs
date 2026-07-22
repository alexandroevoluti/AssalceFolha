namespace AssalceFolha
{
    partial class frmCargaArquivosFolha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaArquivosFolha));
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSelecionarPasta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboConvenio = new System.Windows.Forms.ComboBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgResumo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.mskCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.dgCompra = new System.Windows.Forms.DataGridView();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbExcel = new System.Windows.Forms.RadioButton();
            this.btnConferencia = new System.Windows.Forms.Button();
            this.btCargaResumo = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgResumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 110);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(578, 108);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(12, 71);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(537, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnSelecionarPasta
            // 
            this.btnSelecionarPasta.Location = new System.Drawing.Point(555, 68);
            this.btnSelecionarPasta.Name = "btnSelecionarPasta";
            this.btnSelecionarPasta.Size = new System.Drawing.Size(35, 23);
            this.btnSelecionarPasta.TabIndex = 2;
            this.btnSelecionarPasta.Text = "...";
            this.btnSelecionarPasta.UseVisualStyleBackColor = true;
            this.btnSelecionarPasta.Click += new System.EventHandler(this.btnSelecionarPasta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Arquivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Convênio";
            // 
            // cboConvenio
            // 
            this.cboConvenio.FormattingEnabled = true;
            this.cboConvenio.Location = new System.Drawing.Point(15, 25);
            this.cboConvenio.Name = "cboConvenio";
            this.cboConvenio.Size = new System.Drawing.Size(244, 21);
            this.cboConvenio.TabIndex = 6;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(12, 229);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 7;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(404, 229);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(186, 40);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dgResumo
            // 
            this.dgResumo.AllowUserToAddRows = false;
            this.dgResumo.AllowUserToDeleteRows = false;
            this.dgResumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResumo.Location = new System.Drawing.Point(596, 68);
            this.dgResumo.Name = "dgResumo";
            this.dgResumo.ReadOnly = true;
            this.dgResumo.Size = new System.Drawing.Size(625, 201);
            this.dgResumo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Competência";
            // 
            // mskCompetencia
            // 
            this.mskCompetencia.Location = new System.Drawing.Point(265, 26);
            this.mskCompetencia.Mask = "##/####";
            this.mskCompetencia.Name = "mskCompetencia";
            this.mskCompetencia.Size = new System.Drawing.Size(74, 20);
            this.mskCompetencia.TabIndex = 12;
            // 
            // dgCompra
            // 
            this.dgCompra.AllowUserToAddRows = false;
            this.dgCompra.AllowUserToDeleteRows = false;
            this.dgCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompra.Location = new System.Drawing.Point(12, 275);
            this.dgCompra.Name = "dgCompra";
            this.dgCompra.ReadOnly = true;
            this.dgCompra.Size = new System.Drawing.Size(1209, 300);
            this.dgCompra.TabIndex = 13;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Checked = true;
            this.rbText.Location = new System.Drawing.Point(387, 28);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 17);
            this.rbText.TabIndex = 16;
            this.rbText.TabStop = true;
            this.rbText.Text = "TXT";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbExcel
            // 
            this.rbExcel.AutoSize = true;
            this.rbExcel.Location = new System.Drawing.Point(464, 27);
            this.rbExcel.Name = "rbExcel";
            this.rbExcel.Size = new System.Drawing.Size(51, 17);
            this.rbExcel.TabIndex = 17;
            this.rbExcel.TabStop = true;
            this.rbExcel.Text = "Excel";
            this.rbExcel.UseVisualStyleBackColor = true;
            this.rbExcel.CheckedChanged += new System.EventHandler(this.rbExcel_CheckedChanged);
            // 
            // btnConferencia
            // 
            this.btnConferencia.Location = new System.Drawing.Point(208, 229);
            this.btnConferencia.Name = "btnConferencia";
            this.btnConferencia.Size = new System.Drawing.Size(186, 40);
            this.btnConferencia.TabIndex = 18;
            this.btnConferencia.Text = "Conferência";
            this.btnConferencia.UseVisualStyleBackColor = true;
            this.btnConferencia.Click += new System.EventHandler(this.btnConferencia_Click);
            // 
            // btCargaResumo
            // 
            this.btCargaResumo.Location = new System.Drawing.Point(596, 5);
            this.btCargaResumo.Name = "btCargaResumo";
            this.btCargaResumo.Size = new System.Drawing.Size(186, 40);
            this.btCargaResumo.TabIndex = 19;
            this.btCargaResumo.Text = "Carregar Resumo";
            this.btCargaResumo.UseVisualStyleBackColor = true;
            this.btCargaResumo.Click += new System.EventHandler(this.btCargaResumo_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 574);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1209, 20);
            this.progressBar.TabIndex = 32;
            this.progressBar.Visible = false;
            // 
            // frmCargaArquivosFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 606);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btCargaResumo);
            this.Controls.Add(this.btnConferencia);
            this.Controls.Add(this.rbExcel);
            this.Controls.Add(this.rbText);
            this.Controls.Add(this.dgCompra);
            this.Controls.Add(this.mskCompetencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgResumo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.cboConvenio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelecionarPasta);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lstFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargaArquivosFolha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Arquivos Folha";
            ((System.ComponentModel.ISupportInitialize)(this.dgResumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSelecionarPasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboConvenio;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgResumo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskCompetencia;
        private System.Windows.Forms.DataGridView dgCompra;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbExcel;
        private System.Windows.Forms.Button btnConferencia;
        private System.Windows.Forms.Button btCargaResumo;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

