namespace AssalceFolha.Componentes
{
    partial class ucConvenio
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
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEvento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtConvenio
            // 
            this.txtConvenio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenio.Location = new System.Drawing.Point(0, 0);
            this.txtConvenio.MaxLength = 6;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(59, 23);
            this.txtConvenio.TabIndex = 80;
            this.txtConvenio.TextChanged += new System.EventHandler(this.txtConvenio_TextChanged);
            this.txtConvenio.Leave += new System.EventHandler(this.txtConvenio_Leave);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(453, 0);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(30, 23);
            this.btnConsultar.TabIndex = 81;
            this.btnConsultar.TabStop = false;
            this.btnConsultar.Text = "...";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(112, 0);
            this.txtNome.MaxLength = 6;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(335, 23);
            this.txtNome.TabIndex = 83;
            this.txtNome.TabStop = false;
            // 
            // txtEvento
            // 
            this.txtEvento.BackColor = System.Drawing.SystemColors.Control;
            this.txtEvento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvento.Location = new System.Drawing.Point(65, 0);
            this.txtEvento.MaxLength = 6;
            this.txtEvento.Name = "txtEvento";
            this.txtEvento.ReadOnly = true;
            this.txtEvento.Size = new System.Drawing.Size(40, 23);
            this.txtEvento.TabIndex = 84;
            this.txtEvento.TabStop = false;
            // 
            // ucConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEvento);
            this.Controls.Add(this.txtConvenio);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtNome);
            this.Name = "ucConvenio";
            this.Size = new System.Drawing.Size(486, 27);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucConvenio_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEvento;
    }
}
