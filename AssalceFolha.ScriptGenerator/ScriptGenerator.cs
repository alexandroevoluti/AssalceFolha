using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssalceFolha.ScriptGenerator
{
    public class GeneratorScript<T> where T : new()
    {
        public static string ScriptInsert()
        {
            try
            {
                ScriptInsertGenerator<T> generator = new ScriptInsertGenerator<T>();   
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public static string ScriptUpdate()
        {
            try
            {
                ScriptUpdateGenerator<T> generator = new ScriptUpdateGenerator<T>();
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ScriptDelete()
        {
            try
            {
                ScriptDeleteGenerator<T> generator = new ScriptDeleteGenerator<T>();
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ScriptSelect()
        {
            try
            {
                ScriptGeneratorSelect<T> generator = new ScriptGeneratorSelect<T>();
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ScriptKeyAutoIncrement()
        {
            try
            {
                ScriptGeneratorkeyAutoIncrement<T> generator = new ScriptGeneratorkeyAutoIncrement<T>();
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ScriptMaxIdentity()
        {
            try
            {
                ScriptGeneratorMaxIdentity<T> generator = new ScriptGeneratorMaxIdentity<T>();
                return generator.Script();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ScriptSelect(int identity)
        {
            try
            {
                ScriptGeneratorSelect<T> generator = new ScriptGeneratorSelect<T>();
                return generator.Script(identity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    abstract class ScriptGeneratorBase<T>
    {
        public abstract string Script();
        protected string GetTableName(T entidade)
        {
            string nmTable = "";
            bool existAttribute = false;

            foreach (object attr in entidade.GetType().GetCustomAttributes(true))
            {
                if (attr.GetType() == typeof(TableName))
                {
                    nmTable = ((TableName)attr).NmTable;
                    if (!nmTable.Trim().Equals(string.Empty))
                    {
                        existAttribute = true;
                    }
                }
            }
            if (!existAttribute)
            {
                throw new Exception("Não existe anotação para definir o atributo tabela.");
            }
            return nmTable;
        }
    }

    abstract class ScriptGeneratorDDLBase<T> : ScriptGeneratorBase<T>
    {
    }

    abstract class ScriptGeneratorUpdateDeleteBase<T> : ScriptGeneratorDDLBase<T>
    {
        protected string GetWhereFieldParameterdefinition(T entidade)
        {
            try
            {
                StringBuilder _wherefieldParameterDefinition = new StringBuilder();
                string _nomeCampo;
                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                            {
                                if (_wherefieldParameterDefinition.Length > 0)
                                {
                                    _wherefieldParameterDefinition.Append(" AND ");
                                }
                                _nomeCampo = ((TableField)attr).NameField;
                                _wherefieldParameterDefinition.Append(_nomeCampo.ToString().ToUpper() + "=@" + _nomeCampo.ToString().ToLower());
                            }
                        }
                    }
                }
                return _wherefieldParameterDefinition.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    abstract class ScriptGeneratorDMLBase<T> : ScriptGeneratorBase<T> where T:new()
    {
        T entidade=new T();
        public abstract string Script(int identity);

        protected string GetWhereIdentity(int identity)
        {
            try
            {
                StringBuilder _whereIdentity = new StringBuilder();

                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                            {
                                if (_whereIdentity.Length > 0)
                                {
                                    _whereIdentity.Append(" AND ");
                                }
                                _whereIdentity.Append(((TableField)attr).NameField.ToUpper() + "=" + identity.ToString());
                            }
                        }
                    }
                }
                return _whereIdentity.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string GetSelectMaxIdentity()
        {
            try
            {
                string _nomeID="";
                foreach (PropertyInfo property in entidade.GetType().GetProperties())
                {
                    foreach (object attr in property.GetCustomAttributes(true))
                    {
                        if (attr.GetType() == typeof(TableField))
                        {
                            if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                            {
                                _nomeID = ((TableField)attr).NameField.ToUpper();
                            }
                        }
                    }
                }

                StringBuilder _selectIdentity = new StringBuilder();
                _selectIdentity.Append("SELECT MAX(");
                _selectIdentity.Append(_nomeID);
                _selectIdentity.Append(") FROM ");
                _selectIdentity.Append(GetTableName(entidade));

                return _selectIdentity.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    class ScriptGeneratorSelect<T> : ScriptGeneratorDMLBase<T> where T:new()
    {
        //static T entidade = (T)entidade.GetType().Assembly.CreateInstance(entidade.GetType().Name);
        T entidade=new T();
        public override string Script()
        {
            try
            {
                StringBuilder script = new StringBuilder();

                script.Append("SELECT * FROM ");
                script.Append(GetTableName(entidade));

                return script.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public override string Script(int identity)
        {
            try
            {
                StringBuilder script = new StringBuilder();
                script.Append(Script());
                script.Append(" WHERE ");
                script.Append(GetWhereIdentity(identity));

                return script.ToString();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }

    class ScriptInsertGenerator<T> : ScriptGeneratorDDLBase<T> where T : new()
    {
        T entidade = new T();
        public override string Script()
        {
            try
            {
                StringBuilder script = new StringBuilder();

                script.Append("INSERT INTO ");
                script.Append(GetTableName(entidade));
                script.Append(GetFieldDefinition(entidade));
                script.Append(" VALUES ");
                script.Append(GetParameterDefinition(entidade));
                return script.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetFieldDefinition(T entidade)
        {
            StringBuilder _fieldDefinition = new StringBuilder();
            _fieldDefinition.Append("(");

            TableField _attrTableField=null;
            GeneratorKey _attrGeneratorKey=null;

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
                        if (_attrTableField.IsTableField && !_attrTableField.IsIdentity)
                        {

                            _fieldDefinition.Append(_attrTableField.NameField.ToUpper() + ",");
                        }
                    }
                #endregion                
            }
            _fieldDefinition = _fieldDefinition.Remove(_fieldDefinition.Length - 1, 1);
            _fieldDefinition.Append(")");

            return _fieldDefinition.ToString();
        }

        private string GetParameterDefinition(T entidade)
        {
            StringBuilder _parameterDefinition = new StringBuilder();
            _parameterDefinition.Append("(");

            foreach (PropertyInfo property in entidade.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType() == typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && !((TableField)attr).IsIdentity)
                        {
                            _parameterDefinition.Append("@" + ((TableField)attr).NameField.ToString().ToLower() + ",");
                        }
                    }
                }
            }
            _parameterDefinition = _parameterDefinition.Remove(_parameterDefinition.Length - 1, 1);
            _parameterDefinition.Append(")");

            return _parameterDefinition.ToString();
        }
    }

    class ScriptUpdateGenerator<T> : ScriptGeneratorUpdateDeleteBase<T> where T : new()
    {
        T entidade = new T();
        public override string Script()
        {
            try
            {
                StringBuilder script = new StringBuilder();

                script.Append("UPDATE ");
                script.Append(GetTableName(entidade));
                script.Append(" SET ");
                script.Append(GetFieldParameterDefinition(entidade));
                script.Append(" WHERE ");
                script.Append(GetWhereFieldParameterdefinition(entidade));
                return script.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetFieldParameterDefinition(T entidade)
        {
            StringBuilder _fieldParameterDefinition = new StringBuilder();
            string _nomeCampo;
            foreach (PropertyInfo property in entidade.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType() == typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && !((TableField)attr).IsKey)
                        {
                            if (_fieldParameterDefinition.Length>0)
                            {
                                _fieldParameterDefinition.Append(",");
                            }

                            _nomeCampo = ((TableField)attr).NameField;
                            _fieldParameterDefinition.Append(_nomeCampo.ToString().ToUpper() + "=@" + _nomeCampo.ToString().ToLower());
                        }
                    }
                }
            }
            return _fieldParameterDefinition.ToString();
        }
    }

    class ScriptDeleteGenerator<T> : ScriptGeneratorUpdateDeleteBase<T> where T : new()
    {
        T entidade = new T();
        public override string Script()
        {
            try
            {
                StringBuilder script = new StringBuilder();
                script.Append("DELETE FROM ");
                script.Append(GetTableName(entidade));
                script.Append(" WHERE ");
                script.Append(GetWhereFieldParameterdefinition(entidade));

                return script.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    abstract class ScriptGeneratorkeyBase<T>:ScriptGeneratorBase<T>
    {
        public abstract string Script(PropertyInfo _property);
    }

    class ScriptGeneratorkeyAutoIncrement<T>:ScriptGeneratorkeyBase<T> where T:new()
    {
        T entidade=new T();
        private PropertyInfo _property;

        public override string Script()
        {
            string _nomeCampo="";
            foreach (PropertyInfo property in entidade.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType() == typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                        {
                            _nomeCampo = ((TableField)attr).NameField;
                        }
                    }
                }
            }

            StringBuilder _script = new StringBuilder();
            string _nomeTabela = GetTableName(entidade);

            _script.Append("SELECT (IF(max(" + _nomeCampo + ") IS NULL, 0, max(" + _nomeCampo + ")) + 1) " + _nomeCampo + " FROM " + _nomeTabela);

            return _script.ToString();
        }
    
        public override string Script(PropertyInfo _property)
        {
            this._property = _property;
            return Script();
        }
    }

    class ScriptGeneratorMaxIdentity<T> : ScriptGeneratorkeyBase<T> where T : new()
    {
        T entidade = new T();
        private PropertyInfo _property;

        public override string Script()
        {
            string _nomeCampo = "";
            foreach (PropertyInfo property in entidade.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType() == typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && ((TableField)attr).IsIdentity)
                        {
                            _nomeCampo = ((TableField)attr).NameField;
                        }
                    }
                }
            }

            StringBuilder _script = new StringBuilder();
            string _nomeTabela = GetTableName(entidade);

            _script.Append("SELECT * FROM ");
            _script.Append(_nomeTabela);
            _script.Append(" WHERE ");
            _script.Append(_nomeCampo);
            _script.Append(" = (SELECT MAX(");
            _script.Append(_nomeCampo);
            _script.Append(") FROM ");
            _script.Append(_nomeTabela);
            _script.Append(")");

            return _script.ToString();
        }

        public override string Script(PropertyInfo _property)
        {
            this._property = _property;
            return Script();
        }
    }
}

