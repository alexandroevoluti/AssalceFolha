using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssalceFolha.DataLayer
{
    public interface IEntidadeUtilsDAO<T> : IBaseDAO<T>
    {
        T Incluir(T entidade);
        void Alterar(T entidade);
        void Excluir(int id);
        void Excluir(T entidade);
        List<T> Listar();
        T Selecionar(int id);
        List<T> RetornarListaDe(string scriptselect, bool _lower);
        T RetornarEntidadeDe(string scriptselect);
        bool ExistirRegistro(int id);

        T ObjectPersist { get; set; }

    }
}
