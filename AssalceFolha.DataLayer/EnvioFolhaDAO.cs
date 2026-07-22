using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;
using System.Configuration;
using System.IO;

namespace AssalceFolha.DataLayer
{
    public class EnvioFolhaDAO : EntidadeDAO<EnvioFolha>
    {
        public List<EnvioFolha> Listar(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT * FROM TB_ENVIO_FOLHA WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes.ToString();
                _sql += " ORDER BY NR_ANO, NR_MES, NR_MATRICULA, NR_FOLHA, CD_EVENTO ";

                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteEnvio(int _ano, int _mes)
        {
            try
            {
                string _sql = " SELECT COUNT(*) FROM TB_ENVIO_FOLHA WHERE NR_ANO = " + _ano.ToString() + " AND NR_MES = " + _mes.ToString();
                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql)) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string FechamentoMes(int _ano, int _mes)
        {
            try
            {
                string _sql = " CALL PR_FECHAMENTO_MES(" + _mes.ToString() + ", " + _ano.ToString() + "); ";
                List<EnvioFolha> _registros = RetornarListaDe(_sql);

                return null; // GerarArquivo(_ano, _mes, _registros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string PastaEnvio(int _competencia)
        {
            try
            {
                String _pasta = ConfigurationManager.AppSettings["FolderArquivosFolha"];
                int _ano = _util.ConvertInt(_competencia.ToString().Trim().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Trim().Substring(4, 2));

                //_ano = _ano.ToString().Substring(3, 4);
                _pasta += @"\" + _ano.ToString();
                if (!Directory.Exists(_pasta)) Directory.CreateDirectory(_pasta);

                _pasta += @"\" + _ano.ToString() + _mes.ToString("00") + "_";
                switch (_mes)
                {
                    case 1:
                        _pasta += "Janeiro";
                        break;
                    case 2:
                        _pasta += "Fevereiro";
                        break;
                    case 3:
                        _pasta += "Marco";
                        break;
                    case 4:
                        _pasta += "Abril";
                        break;
                    case 5:
                        _pasta += "Maio";
                        break;
                    case 6:
                        _pasta += "Junho";
                        break;
                    case 7:
                        _pasta += "Julho";
                        break;
                    case 8:
                        _pasta += "Agosto";
                        break;
                    case 9:
                        _pasta += "Setembro";
                        break;
                    case 10:
                        _pasta += "Outubro";
                        break;
                    case 11:
                        _pasta += "Novembro";
                        break;
                    case 12:
                        _pasta += "Dezembro";
                        break;
                    default:
                        break;
                }

                if (!Directory.Exists(_pasta)) Directory.CreateDirectory(_pasta);

                _pasta += @"\Envio";
                if (!Directory.Exists(_pasta)) Directory.CreateDirectory(_pasta);

                return _pasta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void MarcarForaFolha(int _ano, int _mes)
        {
            try
            {
                string _sql = " UPDATE TB_ENVIO_FOLHA E ";
                _sql += " JOIN ASSOCIADOS A ON E.NR_MATRICULA = A.MATR ";
                _sql += " SET E.ST_FORA_FOLHA = 1 ";
                _sql += " WHERE NR_ANO = " + _ano.ToString();
                _sql += " AND NR_MES = " + _mes.ToString();
                _sql += " AND A.SITUACAO = 'FORA DE FOLHA' ";

                ExecutarSQL(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GerarArquivo(int _ano, int _mes, List<EnvioFolha> _registros)
        {
            try
            {
                AssociadoDAO _associadoDAO = new AssociadoDAO();

                string _pasta = PastaEnvio(_ano * 100 + _mes);

                string _arquivo = _pasta + @"\ASS" + _ano.ToString("0000") + _mes.ToString("00") + ".txt";
                string _arquivo627 = _pasta + @"\ASS_627_" + _ano.ToString("0000") + _mes.ToString("00") + ".txt";


                int _cont = 0;
                while (File.Exists(_arquivo))
                {
                    _cont++;
                    _arquivo = _pasta + @"\ASS" + _ano.ToString("0000") + _mes.ToString("00") + "_" + _cont.ToString("00") + ".txt";
                }
                _cont = 0;
                while (File.Exists(_arquivo627))
                {
                    _cont++;
                    _arquivo627 = _pasta + @"\ASS_627_" + _ano.ToString("0000") + _mes.ToString("00") + "_" + _cont.ToString("00") + ".txt";
                }
                string _linha = "";

                StringBuilder sConteudo = new StringBuilder();
                StringBuilder sConteudo627 = new StringBuilder();

                string _usuario = "FF_" + _ano.ToString() + _mes.ToString("00");

                ExcluirSN(_ano, _mes, _usuario);
                _cont = 0;

                foreach (EnvioFolha item in _registros)
                {
                    _cont++;
                    //if (item.Matricula.Equals(641)) _linha = "";

                    if (item.ForaFolha)
                    {
                        GravarSN(item.ID, item.Matricula, item.Folha, item.Valor, item.Ano, item.Mes, _usuario);
                    }
                    else
                    {
                        _linha = _util.PreencherString(item.Matricula, "0", _util.enumDirecao.Esquerda, 6);
                        _linha += " ";
                        _linha += _util.PreencherString(item.Folha, "0", _util.enumDirecao.Esquerda, 2);
                        _linha += " ";
                        _linha += _util.PreencherString(item.Evento, "0", _util.enumDirecao.Esquerda, 3);
                        _linha += " ";
                        _linha += _util.PreencherString(item.Valor.ToString("0.00"), "0", _util.enumDirecao.Esquerda, 10);
                        _linha += " ";
                        _linha += _util.PreencherString(item.Referencia, " ", _util.enumDirecao.Esquerda, 13);

                        if (item.Evento.Equals(627))
                        {
                            sConteudo627.AppendLine(_linha);
                        }
                        else
                        {
                            sConteudo.AppendLine(_linha);
                        }


                    }
                }

                System.IO.File.WriteAllText(_arquivo, sConteudo.ToString());
                System.IO.File.WriteAllText(_arquivo627, sConteudo627.ToString());

                return _arquivo + Environment.NewLine + _arquivo627;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirSN(int _ano, int _mes, string _usuario)
        {
            try
            {
                int _competencia = _ano * 100 + _mes;
                DateTime _dtAuxiliar = _util.PrimeiroDiaMes(_competencia).AddMonths(1);

                int _anoSN = _dtAuxiliar.Year;
                int _mesSN = _dtAuxiliar.Month;

                string _sql = " DELETE FROM SCAMOV WHERE MES = {0} AND ANO = {1} AND CONVENI = UPPER('S.N.') AND USUARIO = '{2}'";
                _sql = String.Format(_sql,
                                        _mesSN.ToString(),
                                        _anoSN.ToString(),
                                        _usuario
                                    );

                base.ExecutarSQL(_sql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GravarSN(int _envioID, int _matricula, int _folha, double _valor, int _ano, int _mes, string _usuario)
        {
            try
            {
                int _competencia = _ano * 100 + _mes;
                DateTime _dtAuxiliar = _util.PrimeiroDiaMes(_competencia).AddMonths(1);

                int _anoSN = _dtAuxiliar.Year;
                int _mesSN = _dtAuxiliar.Month;

                string _sql = " INSERT INTO SCAMOV(MATRI, FOLHA, CODCONV, EVENTO, VALORDES, MES, ANO, CONVENI, ST, USUARIO, DTCAD, DATA) ";
                _sql += "select '{0}' MATRI, '{1}' FOLHA, '685' CODCONV, '913' EVENTO, {2} VALORDES, {3} MES, {4} ANO, UPPER('S.N.') CONVENI, UPPER('I') ST, UPPER('{5}') USUARIO, NOW() DTCAD, DATE(NOW()) DATA ";

                _sql = String.Format(_sql,
                                        _matricula.ToString("000000"),
                                        _folha.ToString("00"),
                                        _valor.ToString("###0.00").Replace(",", "."),
                                        _mesSN.ToString(),
                                        _anoSN.ToString(),
                                        _usuario
                                    );

                base.ExecutarSQL(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
