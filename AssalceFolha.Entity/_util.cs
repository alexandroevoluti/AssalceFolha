using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
using System.Net;

namespace AssalceFolha.Entity
{
    public static class _util
    {
        #region Funções de Manipulação de Data

        public static DateTime PrimeiroDiaMes(DateTime _data)
        {
            return _data.AddDays((-1 * _data.Day) + 1);
        }

        public static DateTime PrimeiroDiaMes()
        {
            return PrimeiroDiaMes(DateTime.Now);
        }

        public static DateTime PrimeiroDiaMes(int _nrCompetencia)
        {
            int _ano = int.Parse(_nrCompetencia.ToString().Substring(0, 4));
            int _mes = int.Parse(_nrCompetencia.ToString().Substring(4, 2));
            int _dia = 1;
            DateTime _data = new DateTime(_ano, _mes, _dia);

            return PrimeiroDiaMes(_data);
        }

        public static DateTime UltimoDiaMes(int _nrCompetencia)
        {
            int _ano = int.Parse(_nrCompetencia.ToString().Substring(0, 4));
            int _mes = int.Parse(_nrCompetencia.ToString().Substring(4, 2));
            int _dia = 1;
            DateTime _data = new DateTime(_ano, _mes, _dia);
            return UltimoDiaMes(_data);
        }

        public static DateTime UltimoDiaMes(DateTime _data)
        {
            var ultimoDia = DateTime.DaysInMonth(_data.Year, _data.Month);
            var dataUltimoDia = new DateTime(_data.Year, _data.Month, ultimoDia);

            return dataUltimoDia;
        }

        public static DateTime UltimoDiaMes()
        {
            return UltimoDiaMes(DateTime.Now);
        }

        public static DateTime Hoje()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public static string FormatarCompetencia(int _competencia)
        {
            string _strCompetencia = _competencia.ToString("000000");
            _strCompetencia = _strCompetencia.Substring(4, 2) + "/" + _strCompetencia.Substring(0, 4);
            return _strCompetencia;
        }

        public static string FormataDiaMes(int _diaMes)
        {
            string _texto = _diaMes.ToString();

            _texto = PreencherString(_texto, "0", enumDirecao.Esquerda, 4);
            _texto = _texto.Substring(0, 2) + "/" + _texto.Substring(2, 2);

            return _texto;
        }

        public static string FormatarData(object _objeto, enumFormatoData _formato)
        {
            string _retorno = "";
            if (_objeto == null) return "";

            if (!ValidaData(_objeto.ToString())) return "";

            DateTime _data = Convert.ToDateTime(_objeto.ToString());

            if (_formato.Equals(enumFormatoData.Data))
                _retorno = _data.ToShortDateString();
            if (_formato.Equals(enumFormatoData.Hora))
                _retorno = _data.ToShortTimeString();
            if (_formato.Equals(enumFormatoData.DataHora))
                _retorno = _data.ToString("dd/MM/yyyy HH:mm");
            if (_formato.Equals(enumFormatoData.Competencia))
                _retorno = _data.ToString("MM/yyyy");
            if (_formato.Equals(enumFormatoData.AnoMes))
                _retorno = _data.ToString("yyyyMM");
            if (_formato.Equals(enumFormatoData.DiaMes))
                _retorno = _data.ToString("dd/MM");

            return _retorno;
        }

        public static double DateDiff(enumIntervalo _intervalo, DateTime _dataInicial, DateTime _dataFinal)
        {
            TimeSpan _ts = _dataFinal.Subtract(_dataInicial);
            if (_intervalo.Equals(enumIntervalo.Hora))
            {
                return _ts.TotalHours;
            }
            else if (_intervalo.Equals(enumIntervalo.Minuto))
            {
                return _ts.Minutes;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Funções de Manipulação de String


        public static string FormatarCnpjCpf(string _cnpjCpf)
        {
            try
            {
                if (_cnpjCpf.Trim().Length < 12)
                    return FormatarCpf(_cnpjCpf);
                else
                    return FormatarCnpj(_cnpjCpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string FormatarCnpj(string cnpj)
        {
            if (cnpj == null) return "";
            string _cnpj = cnpj.Replace("-", "").Replace("/", "").Replace(".", "");
            return Formatar(_cnpj, "##.###.###/####-##");
        }

        public static string FormatarCpf(string cpf)
        {
            if (cpf == null) return "";

            string _cpf = PreencherString(SomenteNumeros(cpf), "0", enumDirecao.Esquerda, 11);
            return Formatar(_cpf, "###.###.###-##");
        }

        public static string Formatar(string valor, string mascara)
        {
            StringBuilder dado = new StringBuilder();
            // remove caracteres nao numericos
            foreach (char c in valor)
            {
                if (Char.IsNumber(c))
                    dado.Append(c);
            }
            int indMascara = mascara.Length;
            int indCampo = dado.Length;
            for (; indCampo > 0 && indMascara > 0;)
            {
                if (mascara[--indMascara] == '#')
                    indCampo -= 1;
            }
            StringBuilder saida = new StringBuilder();
            for (; indMascara < mascara.Length; indMascara++)
            {
                saida.Append((mascara[indMascara] == '#') ? dado[indCampo++] : mascara[indMascara]);
            }
            return saida.ToString();
        }

        public static string FormatarMoeda(object _obj, int _decimais)
        {
            try
            {
                if (_obj == null) return "";

                string _mascara = "#,##0." + "0".PadRight(_decimais, '0');

                double _valor = ConvertDouble(_obj);
                return _valor.ToString(_mascara);
            }
            catch { return "0,00"; }
        }

        public static string FormatarString(string _texto, int _tamanho)
        {
            return _texto.PadRight(_tamanho, ' ');
        }

        public static string PreencherString(object _obj, string _caracter, enumDirecao _direcao, int _tamanho)
        {
            string _retorno = "";
            if (_obj != null) _retorno = _obj.ToString().Trim();

            for (int i = _retorno.Length; i < _tamanho; i++)
            {
                if (_direcao.Equals(enumDirecao.Direita)) _retorno += _caracter;
                else _retorno = _caracter + _retorno;
            }

            return _retorno;
        }

        public static string PreencherMatricula(object _texto)
        {
            string _retorno = _texto.ToString().Trim();
            return PreencherString(_retorno, "0", enumDirecao.Esquerda, 6);
        }

        public static string PreencherFolha(object _texto)
        {
            string _retorno = _texto.ToString().Trim();
            return PreencherString(_retorno, "0", enumDirecao.Esquerda, 2);
        }

        public static string PreencherConvenio(object _texto)
        {
            string _retorno = _texto.ToString().Trim();
            return PreencherString(_retorno, "0", enumDirecao.Esquerda, 3);
        }

        public static string SomenteNumeros(string Texto)
        {
            string numeros = "";
            try
            {
                for (int i = 0; i < Texto.Length; i++)
                {
                    if (char.IsNumber(Texto, i))
                    {
                        numeros += Texto.Substring(i, 1);
                    }
                }
                return numeros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções de Validação

        public static bool ValidaData(string _data)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(_data, out resultado))
            {
                if (resultado.Equals(DateTime.MinValue))
                {
                    return false;
                }
                else if (resultado == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool ValidaData(object _data)
        {
            DateTime resultado = DateTime.MinValue;

            string _texto = Convert.ToString(_data);

            if (DateTime.TryParse(_texto, out resultado))
            {
                if (resultado.Equals(DateTime.MinValue))
                {
                    return false;
                }
                else if (resultado == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool ValidaCompetencia(int _competencia)
        {
            DateTime resultado = DateTime.MinValue;

            //if (!_competencia.ToString().Length.Equals(6)) return false;

            return ValidaData("01/" + FormatarCompetencia(_competencia));
        }
        public static bool ValidaCompetencia(string _competencia)
        {
            DateTime resultado = DateTime.MinValue;
            return ValidaData("01/" + _competencia);
        }

        public static bool ValidaFloat(string _valor)
        {
            if (_valor.Trim().Equals("")) return false;

            float _resultado = 0;
            if (float.TryParse(_valor, out _resultado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidaDouble(string _valor)
        {
            if (_valor.Trim().Equals("")) return false;

            double _resultado = 0;
            if (double.TryParse(_valor, out _resultado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidaInt(string _valor)
        {
            if (_valor.Trim().Equals("")) return false;

            int _resultado = 0;
            if (int.TryParse(_valor, out _resultado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ValidarPeriodo(string _inicio, string _fim, bool _exigirDataFim)
        {
            try
            {
                if (!ValidaData(_inicio))
                    throw new Exception("Data inicial inválida !");

                if (_exigirDataFim)
                    if (!ValidaData(_fim))
                        throw new Exception("Data final inválida !");

                if (ValidaData(_fim))
                    if (DateTime.Parse(_inicio) > DateTime.Parse(_fim))
                        throw new Exception("Data final menor que a data inicial!");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidaCnpjCPF(string _cnpjCpf)
        {
            try
            {
                if (_cnpjCpf.Trim().Length < 12)
                    return ValidaCPF(_cnpjCpf);
                else
                    return ValidaCnpj(_cnpjCpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool ValidaCnpj(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14) cnpj = PreencherString(cnpj, "0", enumDirecao.Esquerda, 14);

            if (cnpj.Replace("0", "").Trim().Equals("")) return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool ValidaCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static string GeraPISAleatorio()
        {
            Random _r = new Random();
            int _num = 0;
            String _numero = "";
            for (int i = 0; i < 9; i++)
            {
                _num = _r.Next(9);
                _numero += _num.ToString().Trim();
            }

            string _pis = _numero;

            for (int i = 0; i < 100; i++)
            {
                _pis = _numero + ((i < 10 ? "0" : "") + i.ToString());
                if (ValidaPIS(_pis)) break;
            }

            while (!ValidaPIS(_pis)) GeraPISAleatorio();
            return _pis;
        }

        public static string GeraCPFAleatorio()
        {
            Random _r = new Random();
            int _num = 0;
            String _numero = "";
            for (int i = 0; i < 9; i++)
            {
                _num = _r.Next(9);
                _numero += _num.ToString().Trim();
            }

            string _cpf = _numero;

            for (int i = 0; i < 100; i++)
            {
                _cpf = _numero + ((i < 10 ? "0" : "") + i.ToString());
                if (ValidaCPF(_cpf)) break;
            }

            while (!ValidaCPF(_cpf)) GeraCPFAleatorio();

            return _cpf;
        }

        public static bool ValidaPIS(string pis)
        {

            pis = SomenteNumeros(pis);

            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = SomenteNumeros(pis);

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return pis.EndsWith(resto.ToString());
        }

        public static void VerificaSenhaForte(string senha, int _tamanhoMinimo, int _tamanhoMaximo, int _qtdeGrupos, bool _permiteCaracteresRepetidos)
        {
            int _contGrupos = 0;

            //TAMANHA MÍNIMO E MÁXIMO
            if (senha.Length < _tamanhoMinimo || senha.Length > _tamanhoMaximo) throw new Exception("A senha deve conter de " + _tamanhoMinimo.ToString() + " a " + _tamanhoMaximo.ToString() + "caracteres! ");

            //CONTÉM NÚMERO
            if (senha.Any(c => char.IsDigit(c))) _contGrupos++; ;

            //CONTÉM LETRAS MAIUSCULAS
            if (senha.Any(c => char.IsUpper(c))) _contGrupos++; ;

            //CONTÉM LETRAS MINUSCULOS
            if (senha.Any(c => char.IsLower(c))) _contGrupos++; ;

            //CONTÉM CARACTERES ESPECIAIS
            if (senha.Any(c => char.IsSymbol(c))) _contGrupos++;

            if (_contGrupos < _qtdeGrupos) throw new Exception("A senha deve conter pelo menos " + _qtdeGrupos.ToString() + " tipos de caracteres entre letras maiúsculas, letras minúsculas, números e caracteres especiais !");

            if (!_permiteCaracteresRepetidos)
            {
                //CONTÉM CARACTERES REPETIDOS
                var contadorRepetido = 0;
                var ultimoCaracter = '\0';
                foreach (var c in senha)
                {
                    if (c == ultimoCaracter)
                        contadorRepetido++;
                    else
                        contadorRepetido = 0;
                    if (contadorRepetido == 2) throw new Exception("A senha não pode conter caracteres repetidos ! ");

                    ultimoCaracter = c;
                }
            }
        }
        #endregion

        #region Funções de Conversão

        public static Image ByteToImage(byte[] blob)
        {
            if (blob == null) return null;

            MemoryStream ms = new MemoryStream(blob);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByte(string _file, int _maxLenghtKB = 0)
        {
            using (System.IO.FileStream fs = new FileStream(_file, FileMode.Open))
            {
                try
                {
                    Image _imagem;
                    int _reducao = 0;
                    System.IO.BufferedStream bf = new BufferedStream(fs);
                    byte[] buffer = new byte[bf.Length];
                    byte[] bufferReduzido = new byte[bf.Length];
                    int _lenght = buffer.Length;

                    bf.Read(buffer, 0, _lenght);

                    _reducao = (_lenght / _maxLenghtKB > 2 ? 50 : 0);

                    if (_maxLenghtKB > 0)
                    {
                        while (_lenght > (_maxLenghtKB * 1000))
                        {
                            _reducao += (_lenght / _maxLenghtKB > 2 ? 10 : 5);

                            _imagem = CompressImage(ByteToImage(buffer), _reducao);

                            bufferReduzido = ImageToByte(_imagem);
                            _lenght = bufferReduzido.Length;

                            if (_lenght <= (_maxLenghtKB * 1000)) buffer = bufferReduzido;
                        }
                    }

                    return buffer;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static Stream GetStream(Image img, ImageFormat format)
        {
            var ms = new MemoryStream();
            img.Save(ms, format);
            return ms;
        }

        public static byte[] ImageToByte(Image _imagem, int _maxLenghtKB = 0)
        {
            try
            {
                Image _imagemReduzida = _imagem;
                int _reducao = 0;

                byte[] buffer = _util.ImageToByte(_imagem);
                byte[] bufferReduzido = _util.ImageToByte(_imagemReduzida);
                int _lenght = buffer.Length;
                
                _reducao = (_lenght / _maxLenghtKB > 2 ? 50 : 0);

                if (_maxLenghtKB > 0)
                {
                    while (_lenght > (_maxLenghtKB * 1000))
                    {
                        _reducao += (_lenght / _maxLenghtKB > 2 ? 10 : 5);

                        _imagemReduzida = CompressImage(ByteToImage(buffer), _reducao);

                        bufferReduzido = ImageToByte(_imagemReduzida);
                        _lenght = bufferReduzido.Length;

                        if (_lenght <= (_maxLenghtKB * 1000)) buffer = bufferReduzido;
                    }
                }

                return buffer;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static byte[] ImageToByte(Image _image)
        {
            try
            {
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    _image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arr = ms.ToArray();
                }

                return arr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Image CompressImage(Image img, long _percentualReducao)
        {
            try
            {
                var newWidth = (int)(img.Width * (1 - (_percentualReducao / 100.00)));
                var newHeight = (int)(img.Height * (1 - (_percentualReducao / 100.00)));

                Image srcImage = img;
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight));
                }

                return newImage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


        public static float ConvertFloat(object _obj)
        {
            float _valor = 0;
            float.TryParse(_obj.ToString(), out _valor);

            return _valor;
        }

        public static double ConvertDouble(object _obj)
        {
            try
            {
                double _valor = 0;
                double.TryParse(TratarTextoParaDouble(_obj.ToString()), out _valor);

                return _valor;
            }
            catch { return 0; }
        }

        public static double? ConvertDoubleNullable(object _obj)
        {
            try
            {
                double _valor = 0;
                int posPonto = _obj.ToString().LastIndexOf(".");
                int posVirgula = _obj.ToString().LastIndexOf(".");

                string _texto = _obj.ToString();


                if (!posPonto.Equals(0) && !posVirgula.Equals(0)) _texto = _texto.Replace(".", "");

                if (double.TryParse(_texto.ToString().Replace(".", ","), out _valor))
                    return _valor;
                else
                    return null;
            }
            catch { return 0; }
        }

        public static decimal ConvertDecimal(object _obj)
        {
            decimal _valor = 0;
            decimal.TryParse(_obj.ToString(), out _valor);

            return _valor;
        }

        public static int ConvertInt(object _obj)
        {
            int _valor = 0;
            if (_obj == null) return 0;
            try
            {
                int.TryParse(_obj.ToString(), out _valor);
                return _valor;
            }
            catch
            {
                return 0;
            }
        }

        public static int? ConvertIntNullable(object _obj)
        {
            int _valor = 0;
            try
            {
                if (int.TryParse(_obj.ToString(), out _valor))
                    return _valor;
                else
                    return null;
            }
            catch
            {
                return 0;
            }
        }

        public static TimeSpan ConvertTimeSpan(string _texto)
        {
            try
            {
                return TimeSpan.Parse(_texto);
            }
            catch
            {
                return new TimeSpan();
            }
        }

        public static DateTime ConvertDateTime(object _obj)
        {
            DateTime _valor = DateTime.MinValue;

            DateTime.TryParse(_obj.ToString(), out _valor);

            return _valor;
        }

        public static DateTime ConvertDate(object _obj)
        {
            DateTime _valor = DateTime.MinValue;

            DateTime.TryParse(_obj.ToString(), out _valor);

            return new DateTime(_valor.Year, _valor.Month, _valor.Day);
        }

        public static DateTime? ConvertDateTimeNullable(object _obj)
        {
            DateTime _valor = DateTime.MinValue;
            DateTime? _return = null;
            DateTime.TryParse(_obj.ToString(), out _valor);

            if (!_valor.Equals(DateTime.MinValue))
            {
                _return = _valor;
            }

            return _return;

        }

        public static int ConvertCompetenciaParaInteiro(string _competencia)
        {

            if (!_competencia.Length.Equals(7)) return 0;
            if (!ValidaData("01/" + _competencia)) return 0;

            int _intCompetencia = 0;
            string _texto = _competencia.Substring(3, 4) + _competencia.Substring(0, 2);

            int.TryParse(_texto, out _intCompetencia);

            return _intCompetencia;
        }

        public static int ConvertDataParaCompetencia(DateTime _data)
        {
            DateTime _dt = _util.ConvertDateTime(_data);

            return (_dt.Year * 100) + _dt.Month;
        }

        public static string ConvertInteiroParaCompetencia(int _competencia)
        {
            int _ano = _util.ConvertInt(_competencia.ToString().Substring(0, 4));
            int _mes = _util.ConvertInt(_competencia.ToString().Substring(4, 2));

            DateTime _dt = new DateTime(_ano, _mes, 1);

            return _dt.ToString("MM/yyyy");
        }

        public static string ConvertString(object _obj, enumMascara _mascara)
        {
            string _valor;
            try
            {
                _valor = _obj.ToString();


                if (_mascara.Equals(enumMascara.Data))
                {
                    if (DateTime.Parse(_valor).Equals(DateTime.MinValue)) return "";

                    _valor = DateTime.Parse(_valor).ToString("dd/MM/yyyy");
                }
                else if (_mascara.Equals(enumMascara.Inteiro))
                {
                    if (int.Parse(_valor).Equals(0)) return "";

                    _valor = int.Parse(_valor).ToString("#,##0");
                }
                else if (_mascara.Equals(enumMascara.Moeda))
                {
                    if (float.Parse(_valor).Equals(0)) return "";

                    _valor = float.Parse(_valor).ToString("#,##0.00");
                }
                else if (_mascara.Equals(enumMascara.CEP))
                {
                    if (int.Parse(_valor).Equals(0)) return "";

                    _valor = Regex.Replace(int.Parse(_valor).ToString(), @"(\d{2})(\d{3})(\d{3})", "$1.$2-$3");
                }
            }
            catch (Exception) { return ""; }

            return _valor;
        }


        #endregion

        #region Outras Funções

        public static double ParcelaFinanciamento(double _valorFinanceiramento, double _taxa, int _periodo)
        {
            try
            {
                if (_taxa >= 1) _taxa = _taxa / 100;

                double E, cont;
                E = 1;
                cont = 1;

                for (int k = 1; k <= _periodo; k++)
                {
                    cont = cont * (1 + _taxa);
                    E = E + cont;
                }
                E = E - cont;
                _valorFinanceiramento = _valorFinanceiramento * cont;

                return _valorFinanceiramento / E;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string NomeServidor()
        {
            string connectString = ConfigurationManager.ConnectionStrings["STRConexao"].ToString();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectString);
            // Retrieve the DataSource property.    
            return builder.Server;
        }

        public static string NomeBanco()
        {
            string connectString = ConfigurationManager.ConnectionStrings["STRConexao"].ToString();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectString);
            // Retrieve the DataSource property.    
            return builder.Database;
        }

        private static string TratarTextoParaDouble(string _valor)
        {
            _valor = _valor.Replace(".", ",");

            int _posUltmaVirgula = _valor.LastIndexOf(",");

            if (_posUltmaVirgula > -1)
            {
                string _inteiro = _valor.Substring(0, _posUltmaVirgula);

                return _inteiro.Replace(",", "") + _valor.Substring(_posUltmaVirgula);
            }
            else
            {
                return _valor;
            }
        }

        /// <summary>
        /// Retorna o login do usuário logado
        /// </summary>
        public static string UsuarioLogado()
        {
            //return System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            string nome = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            if (nome.Contains("\\"))
            {
                nome = nome.Substring(nome.IndexOf("\\") + 1);
            }
            return nome.ToLower();
        }

        public static string ConverterMinutoParaHora(int _minutos)
        {
            string _sinal = (_minutos < 0 ? "-" : "");
            int _absMinutos = (_minutos * (_minutos < 0 ? -1 : 1));

            return _sinal + (_absMinutos / 60).ToString("00") + ":" + (_absMinutos % 60).ToString("00");
        }

        public static int IncrementaCompetencia(int _nrCompetencia, int _nrMeses)
        {
            try
            {
                int _ano = int.Parse(_nrCompetencia.ToString().Substring(0, 4));
                int _mes = int.Parse(_nrCompetencia.ToString().Substring(4, 2));
                int _dia = 1;

                DateTime _data = new DateTime(_ano, _mes, _dia);
                _data = _data.AddMonths(_nrMeses);

                return _data.Year * 100 + _data.Month;
            }
            catch (Exception ex) { throw ex; }
        }

        private static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");

            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }

            return output.ToString();
        }

        public static string geraHash(string _senha)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA1Managed oSha = new SHA1Managed();
            byte[] hashBytes = oSha.ComputeHash(encoder.GetBytes(_senha));
            return byteArrayToString(hashBytes);
        }

        public static int CalcularIdade(DateTime _dataNascimento, DateTime _dataReferencia)
        {
            int anos = _dataReferencia.Year - _dataNascimento.Year;

            if (_dataReferencia.Month < _dataNascimento.Month || (_dataReferencia.Month == _dataNascimento.Month && _dataReferencia.Day < _dataNascimento.Day))
                anos--;

            return anos;
        }

        public static bool EnviarEnailGoogle(string paraqualemail, string assunto, string mensagem)
        {
            try
            {
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("alexandrosilveira@gmail.com");
                //objEmail.ReplyTo = "";
                objEmail.To.Add(paraqualemail);
                //objEmail.Bcc.Add("Email oculto");
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = assunto;
                objEmail.Body = mensagem;
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.EnableSsl = true;
                objSmtp.Port = 587;
                objSmtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                objSmtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas
                objSmtp.Credentials = new NetworkCredential("alexandrosilveira@gmail.com", "@rosabruno0810");
                objSmtp.Send(objEmail);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EnviarEmail(string _de, string _para, string _CC, string _assunto, string _mensagem, string _anexo)
        {
            string[] _emails;
            string[] _anexos;

            string _emailHomologacao = _util.AppSettings("EMAILHOMOLOGACAO");
            string _servidorCorreio = _util.AppSettings("SERVIDORCORREIO");
            string _contaCorreio = _util.AppSettings("CONTACORREIO");
            string _senhaCorreio = _util.AppSettings("SENHACORREIO");
            int _portaCorreio = _util.ConvertInt(_util.AppSettings("PORTACORREIO"));

            if (!_emailHomologacao.Trim().Equals("")) _para = _emailHomologacao;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_de);

            _emails = _para.Split(';');
            foreach (string _email in _emails)
            {
                msg.To.Add(new MailAddress(_email));
            }

            if (_CC != "")
            {
                _emails = _CC.Split(';');
                foreach (string _email in _emails)
                {
                    msg.CC.Add(new MailAddress(_email));
                }
            }
            msg.Subject = _assunto;
            msg.Body = _mensagem;
            msg.IsBodyHtml = true;
            if (_anexo.Trim() != "")
            {
                _anexos = _anexo.Split(';');
                foreach (string _arquivo in _anexos)
                {
                    msg.Attachments.Add(new Attachment(_arquivo));
                }
            }

            SmtpClient clienteSmtp = new SmtpClient(_servidorCorreio);
            clienteSmtp.Port = _portaCorreio;
            clienteSmtp.EnableSsl = false;
            clienteSmtp.DeliveryMethod = 0;
            clienteSmtp.Credentials = new System.Net.NetworkCredential(_contaCorreio, _senhaCorreio);
            clienteSmtp.UseDefaultCredentials = false;

            //SmtpDeliveryMethod.Network  
            try
            {
                clienteSmtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EmailValido(string email)
        {
            // instancia um regex com a expressão desejada         
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return rg.IsMatch(email);
        }

        public static string AppSettings(string _chave)
        {
            try
            {
                if (ConfigurationManager.AppSettings[_chave] == null) throw new Exception("Chave " + _chave + " não encontrada no arquivo de configuração !");

                return ConfigurationManager.AppSettings[_chave];
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Enumerators

        public enum enumMascara
        {
            SemMascara = 0,
            Data = 1,
            Inteiro = 2,
            Moeda = 3,
            CEP = 4
        }

        public enum enumDirecao
        {
            Esquerda = 1,
            Direita = 2
        }

        public enum enumTipoParametro
        {
            Data = 1,
            Inteiro = 2,
            Float = 3,
            String = 4,
            Bool = 5,
            Decimal = 6,
            Hora = 7,
            Double = 8
        }

        public enum enumFormatoData
        {
            Data = 1,
            Hora = 2,
            DataHora = 3,
            Competencia = 4,
            AnoMes = 5,
            DiaMes = 6
        }

        public enum enumIntervalo
        {
            Minuto = 1,
            Hora = 2
        }

        public enum enumOperacaoLista
        {
            SemOperacao,
            Incluir,
            Alterar,
            Excluir
        }

        #endregion

    }
}
