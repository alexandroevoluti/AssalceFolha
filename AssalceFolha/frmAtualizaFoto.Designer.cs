namespace AssalceFolha
{
    partial class frmAtualizaFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtualizaFoto));
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.btnCapturaFoto = new System.Windows.Forms.Button();
            this.btnSeleiconarArquivo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ucAssociado1 = new AssalceFolha.ucAssociado();
            this.btnExcluirFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(12, 81);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(120, 169);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 77;
            this.picFoto.TabStop = false;
            this.picFoto.Click += new System.EventHandler(this.picFoto_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvar,
            this.toolStripSeparator1,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(565, 25);
            this.toolStrip1.TabIndex = 79;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 22);
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnAtualizaFoto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = false;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 22);
            this.btnSair.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCapturaFoto
            // 
            this.btnCapturaFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnCapturaFoto.Image")));
            this.btnCapturaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapturaFoto.Location = new System.Drawing.Point(158, 81);
            this.btnCapturaFoto.Name = "btnCapturaFoto";
            this.btnCapturaFoto.Size = new System.Drawing.Size(151, 31);
            this.btnCapturaFoto.TabIndex = 82;
            this.btnCapturaFoto.Text = "Captura Foto";
            this.btnCapturaFoto.UseVisualStyleBackColor = true;
            this.btnCapturaFoto.Click += new System.EventHandler(this.btnCapturaFoto_Click);
            // 
            // btnSeleiconarArquivo
            // 
            this.btnSeleiconarArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleiconarArquivo.Image")));
            this.btnSeleiconarArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleiconarArquivo.Location = new System.Drawing.Point(158, 118);
            this.btnSeleiconarArquivo.Name = "btnSeleiconarArquivo";
            this.btnSeleiconarArquivo.Size = new System.Drawing.Size(151, 31);
            this.btnSeleiconarArquivo.TabIndex = 83;
            this.btnSeleiconarArquivo.Text = "Selecionar Arquivo";
            this.btnSeleiconarArquivo.UseVisualStyleBackColor = true;
            this.btnSeleiconarArquivo.Click += new System.EventHandler(this.btnSeleiconarArquivo_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(336, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 31);
            this.button1.TabIndex = 84;
            this.button1.Text = "Teste envio email google";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucAssociado1
            // 
            this.ucAssociado1.Associado = null;
            this.ucAssociado1.Location = new System.Drawing.Point(12, 37);
            this.ucAssociado1.Name = "ucAssociado1";
            this.ucAssociado1.Size = new System.Drawing.Size(532, 32);
            this.ucAssociado1.TabIndex = 78;
            // 
            // btnExcluirFoto
            // 
            this.btnExcluirFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirFoto.Image")));
            this.btnExcluirFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirFoto.Location = new System.Drawing.Point(158, 219);
            this.btnExcluirFoto.Name = "btnExcluirFoto";
            this.btnExcluirFoto.Size = new System.Drawing.Size(151, 31);
            this.btnExcluirFoto.TabIndex = 85;
            this.btnExcluirFoto.Text = "Excluir Foto";
            this.btnExcluirFoto.UseVisualStyleBackColor = true;
            this.btnExcluirFoto.Click += new System.EventHandler(this.btnExcluirFoto_Click);
            // 
            // frmAtualizaFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 286);
            this.Controls.Add(this.btnExcluirFoto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSeleiconarArquivo);
            this.Controls.Add(this.btnCapturaFoto);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ucAssociado1);
            this.Controls.Add(this.picFoto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAtualizaFoto";
            this.Text = "Atualiza Foto";
            this.Load += new System.EventHandler(this.frmAtualizaFoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picFoto;
        private ucAssociado ucAssociado1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Button btnCapturaFoto;
        private System.Windows.Forms.Button btnSeleiconarArquivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExcluirFoto;
    }
}