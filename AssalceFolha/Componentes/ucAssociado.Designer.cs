namespace AssalceFolha
{
    partial class ucAssociado
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtFolha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(46, 3);
            this.txtMatricula.MaxLength = 6;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(59, 23);
            this.txtMatricula.TabIndex = 75;
            this.txtMatricula.Leave += new System.EventHandler(this.txtMatricula_Leave);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(498, 3);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(30, 23);
            this.btnConsultar.TabIndex = 76;
            this.btnConsultar.TabStop = false;
            this.btnConsultar.Text = "...";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(157, 3);
            this.txtNome.MaxLength = 6;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(335, 23);
            this.txtNome.TabIndex = 78;
            this.txtNome.TabStop = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(3, 6);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(41, 16);
            this.lblNome.TabIndex = 77;
            this.lblNome.Text = "Nome";
            // 
            // txtFolha
            // 
            this.txtFolha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFolha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolha.Location = new System.Drawing.Point(111, 3);
            this.txtFolha.MaxLength = 6;
            this.txtFolha.Name = "txtFolha";
            this.txtFolha.ReadOnly = true;
            this.txtFolha.Size = new System.Drawing.Size(40, 23);
            this.txtFolha.TabIndex = 79;
            this.txtFolha.TabStop = false;
            // 
            // ucAssociado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFolha);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Name = "ucAssociado";
            this.Size = new System.Drawing.Size(532, 32);
            this.Load += new System.EventHandler(this.ucAssociado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtFolha;
    }
}
