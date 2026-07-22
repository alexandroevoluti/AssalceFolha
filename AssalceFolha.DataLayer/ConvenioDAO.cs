using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.Entity;

namespace AssalceFolha.DataLayer
{
    public class ConvenioDAO : EntidadeDAO<Convenio>
    {
        public Convenio Selecionar(string _id)
        {
            try
            {
                string _sql = " SELECT * FROM SCAVER WHERE FN_INT(VERCOD) = " + _util.ConvertInt(_id);
                return RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ProximoID()
        {
            try
            {
                string _sql = " SELECT MAX(CNVCOD) + 1 FROM SCACNV ";
                return _util.ConvertInt(ExecutarSELECT_Escalar(_sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Convenio Selecionar(string _id, TipoConvenio _tipoConvenio)
        {
            try
            {
                string _sql = " SELECT * FROM SCAVER C WHERE FN_INT(VERCOD) = " + _util.ConvertInt(_id);
                if (_tipoConvenio != null) _sql += " AND EXISTS (SELECT * FROM TB_CONVENIO_TIPO_CONVENIO WHERE CD_CONVENIO = FN_INT(C.VERCOD) AND CD_TIPO_CONVENIO = " + _tipoConvenio.ID.ToString() + ") ";
                return RetornarEntidadeDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Convenio> Listar(string _filtro, TipoConvenio _tipoConvenio)
        {
            try
            {
                string _sql = " SELECT * FROM SCAVER C WHERE VERRAZ like '%" + _filtro.Replace(" ", "%") + "%' ";
                if (_tipoConvenio != null) _sql += " AND EXISTS (SELECT * FROM TB_CONVENIO_TIPO_CONVENIO WHERE CD_CONVENIO = FN_INT(C.VERCOD) AND CD_TIPO_CONVENIO = " + _tipoConvenio.ID.ToString() + ") ";
                return RetornarListaDe(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarResumoCarga(string _usuario)
        {
            try
            {
                string _sql = " SELECT ANO, MES, CODCONV Cod, CONVENI Nome, COUNT(COUNT) QTDE, SUM(VALORDES) Valor, Usuario FROM SCAMOV ";
                _sql += " WHERE USUARIO LIKE '%" + _usuario + "%' ";
                _sql += " GROUP BY ANO, MES, CODCONV, CONVENI, USUARIO ";

                return ExecutarSELECT(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Convenio> ListarCarga()
        {
            try
            {
                List<Convenio> _lista = new List<Convenio>();
                _lista.Add(new Convenio() { ID = "079", Nome = "FARMÁCIA TELEJUCA", Evento = "911", UsuarioCarga = "TEJU" });
                _lista.Add(new Convenio() { ID = "004", Nome = "FARMÁCIA MENINO JESUS", Evento = "911", UsuarioCarga = "MJES" });
                _lista.Add(new Convenio() { ID = "001", Nome = "FARMÁCIA PORTUGAL", Evento = "911", UsuarioCarga = "PORT" });
                _lista.Add(new Convenio() { ID = "321", Nome = "FARMÁCIA DOSE CERTA", Evento = "911", UsuarioCarga = "DOCE" });
                _lista.Add(new Convenio() { ID = "200", Nome = "FARMACIA SANTA BRANCA", Evento = "911", UsuarioCarga = "SNTB" });


                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Convenio> ListarCargaBanco()
        {
            try
            {
                List<Convenio> _lista = new List<Convenio>();
                _lista.Add(new Convenio() { ID = "806", Nome = "MULTI7", Evento = "807", UsuarioCarga = "MULT" });

                return _lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
