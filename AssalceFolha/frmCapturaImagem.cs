using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssalceFolha.Entity;

namespace AssalceFolha
{
    public partial class frmCapturaImagem : Form
    {
        bool fecharFormulario = false;
        public DirectX.Capture.Filter Camera;
        public DirectX.Capture.Capture CaptureInfo;
        public DirectX.Capture.Filters CamContainer;

        public Image Foto { get; set; }
        public bool ExcluirFoto { get; set; }

        public frmCapturaImagem()
        {
            InitializeComponent();
        }

        private void frmCapturaImagem_Load(object sender, EventArgs e)
        {
            ExcluirFoto = false;

            CamContainer = new DirectX.Capture.Filters();
            try
            {
                int no_of_cam = CamContainer.VideoInputDevices.Count;

                for (int i = 0; i < no_of_cam; i++)
                {
                    try
                    {
                        // obtém o dispositivo de entrada do vídeo
                        Camera = CamContainer.VideoInputDevices[i];

                        // inicializa a Captura usando o dispositivo
                        CaptureInfo = new DirectX.Capture.Capture(Camera, null);

                        // Define a janela de visualização do vídeo
                        CaptureInfo.PreviewWindow = this.picWebCam;

                        // Capturando o tratamento de evento
                        CaptureInfo.FrameCaptureComplete += AtualizaImagem;

                        // Captura o frame do dispositivo
                        CaptureInfo.CaptureFrame();

                        // Se o dispositivo foi encontrado e inicializado então sai sem checar o resto
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        public void AtualizaImagem(PictureBox frame)
        {
            try
            {
                Foto = frame.Image;
                //frame.Image.Save(@"D:\Temp\foto.jpg", ImageFormat.Jpeg);

                if (fecharFormulario)
                {
                    CaptureInfo.PreviewWindow = null;

                    CaptureInfo.Stop();
                    CaptureInfo.Close();
                    CaptureInfo.Dispose();


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            try
            {
                fecharFormulario = true;
                CaptureInfo.CaptureFrame();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void frmCapturaImagem_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // CaptureInfo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Foto = null;
                ExcluirFoto = true;


                CaptureInfo.PreviewWindow = null;

                CaptureInfo.Stop();
                CaptureInfo.Close();
                CaptureInfo.Dispose();


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
}
    }
}
