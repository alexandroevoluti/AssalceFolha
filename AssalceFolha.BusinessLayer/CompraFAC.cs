using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;
using AssalceFolha.ErrorHandling;
using MySql.Data.MySqlClient;

namespace AssalceFolha.BusinessLayer
{
    public class CompraFAC
    {
        CompraDAO _CompraDAO = new CompraDAO();


        public Compra Selecionar(int _id)
        {
            try
            {
                return _CompraDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Compra _compra)
        {
            try
            {
                _CompraDAO.ExcluirAlone(_compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Compra> Listar(Associado _associado, int _ano, int _mes, bool _somenteIncluidos)
        {
            try
            {
                List<Compra> _lista = new List<Compra>();
                return _CompraDAO.Listar(_associado, _ano, _mes, _somenteIncluidos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Compra> IncluirAlone(List<Compra> _movimentos)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        return _CompraDAO.Incluir(_movimentos, con, tran);                        
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ex, ""); throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra SalvarAlone(Compra _compra)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["STRConexao"].ConnectionString))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    MySqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        Compra entidade = _compra;
                        if (entidade.ID.Equals(0))
                        {
                            entidade = _CompraDAO.Incluir(entidade, con, tran);
                        }
                        else
                        {
                            _CompraDAO.Alterar(entidade, con, tran);
                        }

                        return entidade;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        ErrorHandle oTratarErro = ErrorHandle.Instancia();
                        oTratarErro.Erro(this, ex, ""); throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Compra> IncluirAlone(List<Compra> _movimentos, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                return _CompraDAO.Incluir(_movimentos, con, tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Compra> Montar(int _competencia, List<RegistroFarmacia> _registrosFarmacia)
        {
            try
            {
                List<Compra> _lista = new List<Compra>();
                foreach (var item in _registrosFarmacia)
                {
                    _lista.Add(Montar(_competencia, item));
                }

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Compra Montar(int _competencia, RegistroFarmacia _registroFarmacia)
        {
            try
            {

                //faltando o associado
                //competencia
                //referencia
                //

                Compra _Compra = new Compra();

                int _ano = _util.ConvertInt(_competencia.ToString().Substring(0, 4));
                int _mes = _util.ConvertInt(_competencia.ToString().Substring(4, 2));

                string _usuario = _competencia.ToString();

                switch (_util.ConvertInt(_registroFarmacia.Convenio.ID))
                {
                    case 200:
                        _usuario = "SNTB" + _competencia.ToString();
                        break;
                    case 321:
                        _usuario = "DOCE" + _competencia.ToString();
                        break;
                    case 79:
                        _usuario = "TEJU" + _competencia.ToString();
                        break;
                    case 4:
                        _usuario = "MJES" + _competencia.ToString();
                        break;
                    case 1:
                        _usuario = "PORT" + _competencia.ToString();
                        break;
                    default:
                        break;
                }

                _Compra.Matricula = _util.PreencherMatricula(_registroFarmacia.Matricula);
                _Compra.Folha = (_registroFarmacia.Associado == null ? "" : _registroFarmacia.Associado.Folha);
                _Compra.Data = _registroFarmacia.Data;
                _Compra.Valor = _util.ConvertDouble(_registroFarmacia.Valor);
                _Compra.ID_Convenio = _registroFarmacia.Convenio.ID;
                _Compra.DE_Convenio = _registroFarmacia.Convenio.Nome;
                _Compra.Evento = _registroFarmacia.Convenio.Evento;
                _Compra.Referencia = _registroFarmacia.Referencia;
                _Compra.Mes = _mes;
                _Compra.Ano = _ano;
                _Compra.Status = "I";
                _Compra.DataCadastro = DateTime.Now;
                _Compra.Usuario = _usuario;

                return _Compra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra Incluir(Compra _Compra)
        {
            try
            {
                if (_Compra == null) throw new Exception("Nenhum registro informado para importação !");

                return _CompraDAO.Incluir(_Compra);
            }
            catch (Exception ex)
            {
                ErrorHandle oTratarErro = ErrorHandle.Instancia();
                oTratarErro.Erro(this, ex, ""); throw ex;
            }
        }

    }
}
