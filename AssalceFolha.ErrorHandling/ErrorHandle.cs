using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AssalceFolha.ErrorHandling
{
    public class ErrorHandle
    {
        private static ErrorHandle _Instancia = null;
        private string _deMensagemErro = "";
        private string _deLocalErro = "";

        private ErrorHandle()
        {

        }
        public static ErrorHandle Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ErrorHandle();
            }
            return _Instancia;
        }
        public string LerErroFormatado()
        {
            string lMSG = "LOCAL: " + _deLocalErro + "<br>MENSAGEM: " + _deMensagemErro;
            LimparErro();
            return lMSG;
        }
        public void LerErro(out string pdeMensagemErro, out string pdeLocalErro)
        {
            pdeMensagemErro = _deMensagemErro;
            pdeLocalErro = _deLocalErro;
            LimparErro();
        }
        public void Erro(object pTHIS, Exception pERRO, string pComplemento)
        {
            if (_deMensagemErro.Equals(""))
            {
                _deMensagemErro = pERRO.Message.ToString() + ":::::" + pComplemento;
                StackFrame stack = new StackFrame(1);
                //_deLocalErro = pTHIS.ToString() + " - " + stack.GetMethod().ToString();
                _deLocalErro = pTHIS.ToString() + "." + stack.GetMethod().Name;
            }

           throw pERRO;
        }
        public void LimparErro()
        {
            _deMensagemErro = "";
            _deLocalErro = "";
        }
    }
}