using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssalceFolha.DataLayer;
using AssalceFolha.Entity;

namespace AssalceFolha.BusinessLayer
{
    public class UsuarioFAC
    {
        UsuarioDAO _usuarioDAO = new UsuarioDAO();

        public Usuario Selecionar(int _id)
        {
            try
            {
                return _usuarioDAO.Selecionar(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Selecionar(string _login)
        {
            try
            {
                return _usuarioDAO.Selecionar(_login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _usuarioDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> Listar(string _filtro)
        {
            try
            {
                string _sql = " SELECT * FROM USUARIOS ";
                _sql += " WHERE (USUARIO LIKE '%" + _filtro.Trim().Replace(" ", "%") + "%' OR LOGIN LIKE '%" + _filtro.Trim().Replace(" ", "%") + "%' )";
                _sql = " ORDER BY USUARIO ";

                return _usuarioDAO.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Usuario Salvar(Usuario _usuario)
        {
            try
            {
                Usuario _retorno = _usuario;
                int _id = _util.ConvertInt(_usuario.ID);

                if (_id.Equals(0))
                {
                    _retorno = _usuarioDAO.Incluir(_usuario);
                }
                else
                {
                    _usuarioDAO.Alterar(_usuario);
                }

                return _retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Usuario _usuario)
        {
            try
            {
                _usuarioDAO.Excluir(_usuario);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ValidarLogin(string _login, string _senha)
        {
            try
            {
                Usuario _usuario = Selecionar(_login);
                if (_usuario == null) throw new Exception("Usuário ou Senha inválida !");

                string _senhaBanco = Descriptografa(_usuario.Senha);

                if (!_senha.ToUpper().Equals(_senhaBanco.ToUpper())) throw new Exception("Usuário ou Senha inválida !");

                return _usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AcessoAdministrativo(Usuario _usuario)
        {
            return (_usuario.NivelSeguranca.Equals("ADM"));
        }

        public string Criptografa(string _texto)
        {
            string _retorno = "";
            char _letra;
            int _nrLetra;

            _letra = _texto[0];
            _nrLetra = (int)_letra;
            _retorno  += (char)(_nrLetra + 1 * 2);
            
            for (int i = 1; i < _texto.Length; i++)
            {
                _retorno += (char)((int)(_texto[i]) + ((i+1) * 2) - 30);
            }

            return _retorno;
        }

        public string Descriptografa(string _texto)
        {
            string _retorno = "";
            char _letra;
            int _nrLetra;

            _letra = _texto[0];
            _nrLetra = (int)_letra;
            _retorno += (char)(_nrLetra  - 2);

            for (int i = 1; i < _texto.Length; i++)
            {
                _retorno += (char)((int)(_texto[i]) - ((i+1) * 2) + 30);
            }

            return _retorno;
        }
    }
}
