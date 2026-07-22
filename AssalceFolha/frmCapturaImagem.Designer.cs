namespace AssalceFolha
{
    partial class frmCapturaImagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturaImagem));
            this.picWebCam = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCaptura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // picWebCam
            // 
            this.picWebCam.BackColor = System.Drawing.Color.White;
            this.picWebCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWebCam.Dock = System.Windows.Forms.DockStyle.Top;
            this.picWebCam.Location = new System.Drawing.Point(0, 0);
            this.picWebCam.Margin = new System.Windows.Forms.Padding(4);
            this.picWebCam.Name = "picWebCam";
            this.picWebCam.Size = new System.Drawing.Size(250, 198);
            this.picWebCam.TabIndex = 3;
            this.picWebCam.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 261);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 55);
            this.button1.TabIndex = 7;
            this.button1.Text = "Limpar Foto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCaptura
            // 
            this.btnCaptura.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCaptura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptura.Image = ((System.Drawing.Image)(resources.GetObject("btnCaptura.Image")));
            this.btnCaptura.Location = new System.Drawing.Point(0, 206);
            this.btnCaptura.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(250, 55);
            this.btnCaptura.TabIndex = 8;
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // frmCapturaImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 316);
            this.Controls.Add(this.btnCaptura);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picWebCam);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapturaImagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Captura Foto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCapturaImagem_FormClosed);
            this.Load += new System.EventHandler(this.frmCapturaImagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWebCam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCaptura;
    }
}