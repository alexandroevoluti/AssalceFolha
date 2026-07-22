using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AssalceFolha.Entity
{
    public static class _log
    {
        public static void GravaLog(Exception ex)
        {
            //Path do arquivo txt
            //C:\inetpub\wwwroot\nomedosite\App_Data\log-20111024.txt
            string strFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            strFile += @"\Log";
            if (!Directory.Exists(strFile)) Directory.CreateDirectory(strFile); 

            strFile += @"\log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            //Se arquivo não existir
            if (!File.Exists(strFile))
            {
                //Criar o arquivo, 
                //Estou usando o using para fazer o Dispose automático do arquivo após criá-lo.
                using (FileStream fs = File.Create(strFile)) { }
            }

            //Escreve o Erro no txt
            //Os erros são concatenados, ou seja, não são sobreescritos.
            using (StreamWriter w = File.AppendText(strFile))
            {
                string _msg = string.Empty;

                //Adicionar um separador
                _msg = "#############################################################\r\n";
                //Data do erro
                _msg += "Data:" + DateTime.Now.ToString("yyyyMMdd-HH:mm:ss") + "\r\n";
                //Adicionando a mensagem
                _msg += "Message --> " + ex.Message + "\r\n";
                //Adicionando a mensagem
                _msg += "StackTrace --> " + ex.StackTrace + "\r\n";
                //Adicionando a mensagem
                if (ex.InnerException != null) _msg += "InnerException --> " + ex.InnerException.Message + "\r\n";
                //quebra de lina e nova linha
                _msg += "\r\n\r\n";

                //Escreve no arquivo
                w.Write(_msg);
                //Fecha
                w.Close();
            }
        }

        public static void GravaRegistroFrequencia(string _texto)
        {
            //Path do arquivo txt
            //C:\inetpub\wwwroot\nomedosite\App_Data\log-20111024.txt
            string strFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            strFile += @"\Log";
            if (!Directory.Exists(strFile)) Directory.CreateDirectory(strFile); 

            strFile += @"\RegBio-" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            //Se arquivo não existir
            if (!File.Exists(strFile))
            {
                //Criar o arquivo, 
                //Estou usando o using para fazer o Dispose automático do arquivo após criá-lo.
                using (FileStream fs = File.Create(strFile)) { }
            }

            //Escreve o Erro no txt
            //Os erros são concatenados, ou seja, não são sobreescritos.
            using (StreamWriter w = File.AppendText(strFile))
            {
                string _msg = string.Empty;

                //Adicionar um separador
                _msg = "#############################################################\r\n";
                //Data do erro
                _msg += "Data:" + DateTime.Now.ToString("yyyyMMdd-HH:mm:ss") + "\r\n";

                _msg += _texto;

                //quebra de lina e nova linha
                _msg += "\r\n\r\n";

                //Escreve no arquivo
                w.Write(_msg);
                //Fecha
                w.Close();
            }
        }
    }
}
