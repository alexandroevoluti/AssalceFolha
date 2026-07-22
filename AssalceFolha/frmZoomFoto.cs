using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssalceFolha
{
    public partial class frmZoomFoto : Form
    {
        public frmZoomFoto(Image _foto)
        {
            InitializeComponent();

            picFoto.Image = _foto;
        }
    }
}
