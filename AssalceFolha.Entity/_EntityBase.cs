using System.Reflection;
using AssalceFolha.ScriptGenerator;
using System;
using AssalceFolha.Entity;

namespace AssalceFolha.Entity
{
    public class EntityBase<T>
    {
        #region IEntity Members

        public void SetIdentity(int _identity)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (((TableField)attr).IsTableField&&((TableField)attr).IsKey&&((TableField)attr).IsIdentity)
                    {
                        property.SetValue(this, _identity, null);
                    }
                }
            }
        }
        #endregion

        #region IEntity Members

        public bool ContainSetIdentity()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType()==typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && ((TableField)attr).IsKey && ((TableField)attr).IsIdentity)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region IEntity Members


        public object GetKeyValue()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                foreach (object attr in property.GetCustomAttributes(true))
                {
                    if (attr.GetType() == typeof(TableField))
                    {
                        if (((TableField)attr).IsTableField && ((TableField)attr).IsKey)
                        {
                            return property.GetValue(this,null);
                        }
                    }
                }
            }

            throw new Exception(string.Format("Valor chave não encontrado na entidade {0}",this.GetType().Name));
        }

        #endregion

        #region IEntity Members

        public string GetTableName()
        {
            foreach (object attr in this.GetType().GetCustomAttributes(true))
            {
                if (attr.GetType() == typeof(TableName))
                {
                    return ((TableName)attr).NmTable;
                }
            }

            throw new Exception(string.Format("A Entidade {0} não contém definição do atributo TableName.",this.GetType().Name));
        }

        #endregion
    }
}

