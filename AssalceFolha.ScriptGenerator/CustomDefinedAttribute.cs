using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssalceFolha.ScriptGenerator
{ 
    #region Definição dos atributos das entidades
    public class TableField : System.Attribute
    {
        private bool _isTableField;
        private bool _iskey;
        private bool _isIdentity;
        private string _nameField;
        private bool _isRequired;
        private string _fillCritical;

        public bool IsTableField { get { return _isTableField; } }
        public bool IsKey
        {
           get { return _iskey; }
           set { _iskey = value; }
        }
        public bool IsIdentity
        {
           get { return _isIdentity; }
           set { _isIdentity = value; }
        }
        public TableField(bool _isTableField)
        {
           this._isTableField = _isTableField;
        }
        public string NameField
        {
            get { return _nameField; }
            set { _nameField = value; }
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        public string FillCritical
        {
            get { return _fillCritical; }
            set { _fillCritical = value; }
        }

        private bool _allowZero;

        public bool AllowZero
        {
            get { return _allowZero; }
            set { _allowZero = value; }
        }
        
    }
    
    public class GeneratorKey : System.Attribute
    {
        private TypeGeneratorKey _typeGeneratorKey;

        public TypeGeneratorKey TypeGeneratorKey
        {
           get { return _typeGeneratorKey; }
           set { _typeGeneratorKey = value; }
        }

        public GeneratorKey(TypeGeneratorKey _typeGeneratorKey)
        {
           this._typeGeneratorKey = _typeGeneratorKey;
        }
    }

    public class TableName : System.Attribute
    {
    private string _nmTable;

    public string NmTable
    {
       get { return _nmTable; }
    }

    public TableName(string _nmTable)
    {
       this._nmTable = _nmTable;
    }
}
    public enum TypeGeneratorKey
    {
       Identity, AutoIncrement, Natural
    }
  #endregion
}

