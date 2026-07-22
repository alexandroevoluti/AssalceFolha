namespace AssalceFolha
{
    partial class frmTrataArquivoFolha
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
            this.dgArquivo = new System.Windows.Forms.DataGridView();
            this.btnCarga = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.mskCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCritica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgArquivo
            // 
            this.dgArquivo.AllowUserToAddRows = false;
            this.dgArquivo.AllowUserToDeleteRows = false;
            this.dgArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArquivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatricula,
            this.colFolha,
            this.colEvento,
            this.colValor,
            this.colReferencia,
            this.colCritica});
            this.dgArquivo.Location = new System.Drawing.Point(6, 94);
            this.dgArquivo.Name = "dgArquivo";
            this.dgArquivo.ReadOnly = true;
            this.dgArquivo.Size = new System.Drawing.Size(850, 203);
            this.dgArquivo.TabIndex = 29;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(6, 48);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 28;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Arquivo";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(6, 22);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(537, 20);
            this.txtArquivo.TabIndex = 26;
            this.txtArquivo.Text = "D:\\temp\\Assalce\\ASS052021.TXT";
            // 
            // mskCompetencia
            // 
            this.mskCompetencia.Location = new System.Drawing.Point(549, 22);
            this.mskCompetencia.Mask = "##/####";
            this.mskCompetencia.Name = "mskCompetencia";
            this.mskCompetencia.Size = new System.Drawing.Size(74, 20);
            this.mskCompetencia.TabIndex = 31;
            this.mskCompetencia.Text = "062021";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Competência";
            // 
            // colMatricula
            // 
            this.colMatricula.HeaderText = "Matricula";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.ReadOnly = true;
            // 
            // colFolha
            // 
            this.colFolha.HeaderText = "Folha";
            this.colFolha.Name = "colFolha";
            this.colFolha.ReadOnly = true;
            this.colFolha.Width = 80;
            // 
            // colEvento
            // 
            this.colEvento.HeaderText = "Evento";
            this.colEvento.Name = "colEvento";
            this.colEvento.ReadOnly = true;
            this.colEvento.Width = 270;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 150;
            // 
            // colReferencia
            // 
            this.colReferencia.HeaderText = "Referência";
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.ReadOnly = true;
            this.colReferencia.Width = 80;
            // 
            // colCritica
            // 
            this.colCritica.HeaderText = "Crítica";
            this.colCritica.Name = "colCritica";
            this.colCritica.ReadOnly = true;
            // 
            // frmTrataArquivoFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 308);
            this.Controls.Add(this.mskCompetencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgArquivo);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArquivo);
            this.Name = "frmTrataArquivoFolha";
            this.Text = "Trata Arquivo Folha";
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgArquivo;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.MaskedTextBox mskCompetencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCritica;
    }
}