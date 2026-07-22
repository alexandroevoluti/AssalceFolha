using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using AssalceFolha.Entity;
using AssalceFolha.ScriptGenerator;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace AssalceFolha.DataLayer
{
    public abstract class EntidadeDAO<T> : _BaseDAO, IEntidadeUtilsDAO<T> where T : EntityBase<T>, new()
    {


        public T ObjectPersist { get; set; }

        #region IEntidadeDAO<T> Members
        public virtual T Incluir(T entidade)
        {
            try
            {
                PreencherInformacoesResponsavel(entidade);

                ValidaEntidade(entidade);

                string SQl = GeneratorScript<T>.ScriptInsert();
                List<MySqlParameter> parametros = GetListaParametrosInsert(entidade);
                ExecutarSQL(SQl, parametros);

                if (entidade.ContainSetIdentity())
                {
                    entidade = SelecionarMaxIdentity();
                }
                else
                {

                }

                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual T Incluir(T entidade, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                PreencherInformacoesResponsavel(entidade);

                ValidaEntidade(entidade);

                string SQl = GeneratorScript<T>.ScriptInsert();
                List<MySqlParameter> parametros = GetListaParametrosInsert(entidade);
                ExecutarSQL(SQl, parametros, con, tran);

                if (entidade.ContainSetIdentity())
                {
                    entidade = SelecionarMaxIdentity();
                }
                else
                {

                }

                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual void Alterar(T entidade)
        {
            try
            {
                if (entidade == null)
                {
                    throw new Exception("Não existe registro para ser alterado.");
                }

                PreencherInformacoesResponsavel(entidade);

                ValidaEntidade(entidade);

                string SQl = GeneratorScript<T>.ScriptUpdate();
                List<MySqlParameter> parametros = GetListaParametrosUpdate(entidade);

                ExecutarSQL(SQl, parametros);

            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual void Alterar(T entidade, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                if (entidade == null)
                {
                    throw new Exception("Não existe registro para ser alterado.");
                }

                PreencherInformacoesResponsavel(entidade);

                ValidaEntidade(entidade);

                string SQl = GeneratorScript<T>.ScriptUpdate();
                List<MySqlParameter> parametros = GetListaParametrosUpdate(entidade);

                //GravaLog(entidade, enumTipoOperacaoLog.Alteracao, con, tran);

                ExecutarSQL(SQl, parametros, con, tran);
            }
            catch (Exception ERRO)
            {
                ROLLBACK();

                throw ERRO;
            }
        }

        public virtual void Excluir(int id)
        {
            try
            {
                T entidade = Selecionar(id);
                Excluir(entidade);
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual void Excluir(int id, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                T entidade = Selecionar(id);
                Excluir(entidade, con, tran);
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual void Excluir(T entidade)
        {
            try
            {
                if (entidade == null)
                {
                    throw new Exception("Não existe registro para ser removido.");
                }

                string SQl = GeneratorScript<T>.ScriptDelete();
                List<MySqlParameter> parametros = GetListaParametrosDelete(entidade);

                ExecutarSQL(SQl, parametros);

            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual void Excluir(T entidade, MySqlConnection con, MySqlTransaction tran)
        {
            try
            {
                if (entidade == null) throw new Exception("Não existe registro para ser removido.");


                //GravaLog(entidade, enumTipoOperacaoLog.Exclusao, con, tran);

                string SQl = GeneratorScript<T>.ScriptDelete();
                List<MySqlParameter> parametros = GetListaParametrosDelete(entidade);

                ExecutarSQL(SQl, parametros, con, tran);
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public List<T> Listar()
        {
            try
            {
                string SQl = GeneratorScript<T>.ScriptSelect();
                List<T> lista = new List<T>();

                using (DataSet DS = ExecutarSELECT(SQl))
                {
                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        lista.Add(Montar(row));
                    }
                }
                return lista;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual T Selecionar(int id)
        {
            try
            {
                string SQl = GeneratorScript<T>.ScriptSelect(id);
                T entidade = new T();
                using (DataSet DS = ExecutarSELECT(SQl))
                {
                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        entidade = Montar(row);
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public virtual T SelecionarMaxIdentity()
        {
            try
            {
                string SQl = GeneratorScript<T>.ScriptMaxIdentity();
                T entidade = new T();
                using (DataSet DS = ExecutarSELECT(SQl))
                {
                    if (DS.Tables[0].Rows.Count == 0)
                    {
                        return null;
                    }

                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        entidade = Montar(row);
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public List<T> RetornarListaDe(string scriptselect, bool _lower = true)
        {
            try
            {
                List<T> lista = null;

                using (DataSet DS = ExecutarSELECT(scriptselect, _lower))
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        lista = new List<T>();

                        foreach (DataRow row in DS.Tables[0].Rows)
                        {
                            lista.Add(Montar(row));
                        }
                    }
                }

                return lista;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public List<T> RetornarListaDe(DataSet _ds)
        {
            try
            {
                List<T> lista = null;

                if (_ds.Tables[0].Rows.Count > 0)
                {
                    lista = new List<T>();

                    foreach (DataRow row in _ds.Tables[0].Rows)
                    {
                        lista.Add(Montar(row));
                    }
                }

                return lista;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public List<T> RetornarListaDePrimeiroNivel(string scriptselect)
        {
            try
            {
                List<T> lista = null;

                using (DataSet DS = ExecutarSELECT(scriptselect))
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        lista = new List<T>();

                        foreach (DataRow row in DS.Tables[0].Rows)
                        {
                            lista.Add(MontarPrimeiroNivel(row));
                        }
                    }
                }

                return lista;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public T RetornarEntidadeDe(string scriptselect)
        {
            try
            {
                T entidade = default(T);

                using (DataSet DS = ExecutarSELECT(scriptselect))
                {
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        entidade = Montar(row);
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public T RetornarEntidadeDePrimeiroNivel(string scriptselect)
        {
            try
            {
                T entidade = default(T);

                using (DataSet DS = ExecutarSELECT(scriptselect))
                {
                    foreach (DataRow row in DS.Tables[0].Rows)
                    {
                        entidade = MontarPrimeiroNivel(row);
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public bool ExistirRegistro(int id)
        {
            try
            {
                string SQl = GeneratorScript<T>.ScriptSelect(id);
                using (DataSet DS = ExecutarSELECT(SQl))
                {
                    return (DS.Tables[0].Rows.Count > 0);
                }
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        public bool ExistirRegistro(string _sql)
        {
            try
            {
                using (DataSet DS = ExecutarSELECT(_sql))
                {
                    return (DS.Tables[0].Rows.Count > 0);
                }
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }
        #endregion

        #region EntidadeDAO Utilidades
        private void SetIdentityEntidade(ref T entidade, object identity)
        {
            try
            {
                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsIdentity)
                            {
                                property.SetValue(entidade, int.Parse(identity.ToString()), null);
                            }
                        }
                    }
                }
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }


        protected virtual T Montar(DataRow row)
        {
            try
            {
                T entidade = new T();

                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField)
                            {
                                string _nmCampo = ((TableField)attr).NameField;
                                if (row[_nmCampo] != DBNull.Value)
                                {
                                    property.SetValue(entidade, Convert.ChangeType(row[_nmCampo], GetTypeConvert(property)), null);
                                }
                            }
                        }
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        protected virtual T MontarPrimeiroNivel(DataRow row)
        {
            try
            {
                T entidade = new T();

                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField)
                            {
                                string _nmCampo = ((TableField)attr).NameField;
                                if (row[_nmCampo] != DBNull.Value)
                                {
                                    property.SetValue(entidade, Convert.ChangeType(row[_nmCampo], GetTypeConvert(property)), null);
                                }
                            }
                        }
                    }
                }
                return entidade;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }
        private Type GetTypeConvert(PropertyInfo property)
        {
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                return Nullable.GetUnderlyingType(property.PropertyType);
            }
            else
            {
                return property.PropertyType;
            }
        }

        #region Get Lista de Parametros
        protected List<MySqlParameter> GetListaParametrosInsert(T entidade)
        {
            try
            {
                List<MySqlParameter> parametros = new List<MySqlParameter>();
                parametros = GetListaParametros(entidade);

                return parametros;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        private List<MySqlParameter> GetListaParametrosUpdate(T entidade)
        {
            try
            {
                List<MySqlParameter> parametros = new List<MySqlParameter>();
                parametros = GetListaParametros(entidade);

                #region Incluindo campos Identity
                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsKey && ((TableField)attr).IsIdentity)
                            {
                                parametros.Add(new MySqlParameter() { ParameterName = "@" + ((TableField)attr).NameField, Value = GetValueProperty(entidade, property) });
                            }
                        }
                    }
                }
                #endregion

                return parametros;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        private List<MySqlParameter> GetListaParametrosDelete(T entidade)
        {
            try
            {
                List<MySqlParameter> parametros = new List<MySqlParameter>();
                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                            {
                                parametros.Add(new MySqlParameter() { ParameterName = "@" + ((TableField)attr).NameField, Value = GetValueProperty(entidade, property) });
                            }
                        }
                    }
                }
                return parametros;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        private List<MySqlParameter> GetListaParametros(T entidade)
        {
            try
            {
                List<MySqlParameter> parametros = new List<MySqlParameter>();

                TableField _attrTableField = null;
                GeneratorKey _attrGeneratorKey = null;

                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            _attrTableField = (TableField)attr;
                        }
                        else if (attr.GetType() == typeof(GeneratorKey))
                        {
                            _attrGeneratorKey = (GeneratorKey)attr;
                        }
                    }

                    #region Seleção e definição de campos
                    if (_attrTableField != null)
                    {
                        if (_attrTableField.IsTableField)
                        {
                            if (!_attrTableField.IsKey)
                            {
                                parametros.Add(new MySqlParameter() { ParameterName = "@" + _attrTableField.NameField.ToLower(), Value = GetValueProperty(entidade, property) });
                            }
                            else
                            {
                                if (!_attrTableField.IsIdentity)
                                {
                                    if (_attrGeneratorKey != null)
                                    {
                                        if (_attrGeneratorKey.TypeGeneratorKey == TypeGeneratorKey.AutoIncrement)
                                        {
                                            parametros.Add(new MySqlParameter() { ParameterName = "@" + _attrTableField.NameField.ToLower(), Value = GetNextValue(property) });
                                        }
                                        else if (_attrGeneratorKey.TypeGeneratorKey == TypeGeneratorKey.Natural)
                                        {
                                            parametros.Add(new MySqlParameter() { ParameterName = "@" + _attrTableField.NameField.ToLower(), Value = GetValueProperty(entidade, property) });
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Campo chave definido sem gerador.");
                                    }
                                }
                            }

                        }
                    }
                    #endregion
                }
                return parametros;
            }
            catch (Exception ERRO)
            {
                throw ERRO;
            }
        }

        private object GetValueProperty(T entidade, PropertyInfo property)
        {
            return property.GetValue(entidade, null);
        }

        private object GetNextValue(PropertyInfo property)
        {
            try
            {
                object _value = null;
                string SQl = GeneratorScript<T>.ScriptKeyAutoIncrement();

                _value = ExecutarSELECT_Escalar(SQl);

                if (_value == null)
                {
                    throw new Exception("Próximo valor da chave não definido.");
                }
                return _value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void PreencherInformacoesResponsavel(T entidade)
        {
            foreach (PropertyInfo property in entidade.GetType().GetProperties())
            {
                if (property.Name.Equals("DataInformacao")) property.SetValue(entidade, DateTime.Now, null);
                if (property.Name.Equals("LoginResponsavelInformacao")) property.SetValue(entidade, _ambiente.UsuarioLogado.Login, null);
            }
        }

        private void ValidaEntidade(T entidade)
        {
            bool _isRequired = true;
            bool _allowZero = false;
            string _fillCritical = "";
            object Value;

            try
            {

                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    _fillCritical = "";
                    _isRequired = false;
                    _allowZero = true;

                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            _isRequired = ((TableField)attr).IsRequired;
                            _allowZero = ((TableField)attr).AllowZero;
                            if (((TableField)attr).FillCritical != null) _fillCritical = ((TableField)attr).FillCritical;
                        }



                        if (_isRequired || !_fillCritical.Equals(""))
                        {
                            Value = GetValueProperty(entidade, property);

                            if (Value == null)
                            {
                                throw new Exception(_fillCritical);

                            }

                            if (Value.GetType() == typeof(String))
                            {
                                if (Value.ToString().Trim() == "")
                                {
                                    throw new Exception(_fillCritical);

                                }
                            }
                            else if (Value.GetType() == typeof(DateTime))
                            {
                                if (DateTime.Parse(Value.ToString()) == DateTime.MinValue)
                                {
                                    throw new Exception(_fillCritical);

                                }
                            }
                            else if (Value.GetType() == typeof(int))
                            {
                                if (int.Parse(Value.ToString()) == 0 && !_allowZero)
                                {
                                    throw new Exception(_fillCritical);

                                }
                            }
                            else if (Value.GetType() == typeof(double))
                            {
                                if (double.Parse(Value.ToString()) == 0 && !_allowZero)
                                {
                                    throw new Exception(_fillCritical);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }

}