using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace AssalceFolha.DataLayer
{
    public interface IBaseDAO<T>
    {
        void ExecutarSQL(string pSQL);
        //void ExecutarSQL(string pSQL, IList listaParametro);
        object ExecutarSELECT_Escalar(string pSQL);
        //object ExecutarSQLScopeIdentity(string pSQL, IList listaParametro);
        //DataSet ExecutarSELECT(string pSQL);        
        //void BEGIN_TRANSACTION();
        //void COMMIT();
        //void ROLLBACK();

    }
}
