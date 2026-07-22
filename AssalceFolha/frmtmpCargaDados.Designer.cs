namespace AssalceFolha
{
    partial class frmtmpCargaDados
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.dgArquivo = new System.Windows.Forms.DataGridView();
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arquivo";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(12, 36);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(537, 20);
            this.txtArquivo.TabIndex = 4;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(12, 62);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 40);
            this.btnCarga.TabIndex = 24;
            this.btnCarga.Text = "Ler Arquivos";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // dgArquivo
            // 
            this.dgArquivo.AllowUserToAddRows = false;
            this.dgArquivo.AllowUserToDeleteRows = false;
            this.dgArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArquivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatricula,
            this.colFolha,
            this.colNome,
            this.colTipo,
            this.colValor});
            this.dgArquivo.Location = new System.Drawing.Point(12, 108);
            this.dgArquivo.Name = "dgArquivo";
            this.dgArquivo.ReadOnly = true;
            this.dgArquivo.Size = new System.Drawing.Size(762, 203);
            this.dgArquivo.TabIndex = 25;
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
            // colNome
            // 
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 270;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 80;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 150;
            // 
            // frmtmpCargaDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 323);
            this.Controls.Add(this.dgArquivo);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArquivo);
            this.Name = "frmtmpCargaDados";
            this.Text = "frmtmpCargaDados";
            this.Load += new System.EventHandler(this.frmtmpCargaDados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgArquivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.DataGridView dgArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
    }
}