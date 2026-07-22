using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class ConvenioFAC
    {
        ConvenioDAO _convenioDAO = new ConvenioDAO();

        public Convenio Selecionar(string _id)
        {
            try
            {
                return _convenioDAO.Selecionar(_id);
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
                return _convenioDAO.ProximoID();
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
                return _convenioDAO.Selecionar(_id, _tipoConvenio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Convenio> Listar()
        {
            try
            {
                return _convenioDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Convenio> Listar(string _filtro)
        {
            try
            {
                return _convenioDAO.Listar(_filtro, null);
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
                return _convenioDAO.Listar(_filtro, _tipoConvenio);
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
                return _convenioDAO.ListarCarga();
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
                return _convenioDAO.ListarCargaBanco();
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
                return _convenioDAO.ListarResumoCarga(_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
