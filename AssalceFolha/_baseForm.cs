using AssalceFolha.Entity;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AssalceFolha
{
    public class _baseForm : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_baseForm));
            this.SuspendLayout();
            // 
            // _baseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_baseForm";
            this.ResumeLayout(false);

        }
    }
}