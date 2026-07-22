namespace AssalceFolha
{
    partial class frmTmpCargaArquivoEnvio
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
            this.btnCarregar = new System.Windows.Forms.Button();
            this.dtpCompetencia = new System.Windows.Forms.DateTimePicker();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.txtArquivoRetorno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrega arquivo gerado para envio na tabela utilizada no sistema do Marcelo";
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(367, 72);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(122, 23);
            this.btnCarregar.TabIndex = 5;
            this.btnCarregar.Text = "Carregar Envio";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // dtpCompetencia
            // 
            this.dtpCompetencia.CustomFormat = "MM/yyyy";
            this.dtpCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetencia.Location = new System.Drawing.Point(99, 49);
            this.dtpCompetencia.Name = "dtpCompetencia";
            this.dtpCompetencia.ShowUpDown = true;
            this.dtpCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetencia.TabIndex = 4;
            // 
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(24, 49);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(69, 13);
            this.lbCompetencia.TabIndex = 3;
            this.lbCompetencia.Text = "Competência";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Arquivo de Envio  Para Carga";
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(367, 46);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(438, 20);
            this.txtArquivo.TabIndex = 7;
            this.txtArquivo.Text = "D:\\Projetos\\Assalce_Docs\\Arquivos Folha\\Maio2017\\Enviado\\ASS052017.TXT";
            // 
            // txtArquivoRetorno
            // 
            this.txtArquivoRetorno.Location = new System.Drawing.Point(367, 106);
            this.txtArquivoRetorno.Name = "txtArquivoRetorno";
            this.txtArquivoRetorno.Size = new System.Drawing.Size(438, 20);
            this.txtArquivoRetorno.TabIndex = 9;
            this.txtArquivoRetorno.Text = "D:\\Projetos\\Assalce_Docs\\Arquivos Folha\\Abril2017\\Retorno\\ASAL1657.TXT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Arquivo de Retorno Para Carga";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Carregar Retorno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTmpCargaArquivoEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArquivoRetorno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.dtpCompetencia);
            this.Controls.Add(this.lbCompetencia);
            this.Controls.Add(this.label1);
            this.Name = "frmTmpCargaArquivoEnvio";
            this.Text = "frmTmpCargaArquivoEnvio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.DateTimePicker dtpCompetencia;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.TextBox txtArquivoRetorno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}