using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio.Series.Enum;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T>Lista();
        T RetornaPorId(int id);
        void Adiciona(T entidade);
        void Atualiza(int id, T entidade);
        void Remove(int id);
        int ProximoId();
    }
}