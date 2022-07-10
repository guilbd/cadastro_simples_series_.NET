using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio.Series.Interfaces;

namespace Dio.Series.Classes
{
  public class SerieRepositorio : IRepositorio<Series>
  {
    private List<Series> listaSerie = new List<Series>();
    public void Adiciona(Series entidade)
    {
      listaSerie.Add(entidade);
    }

    public void Atualiza(int id, Series entidade)
    {
      listaSerie[id] = entidade;
    }

    public List<Series> Lista()
    {
      return listaSerie;
    }

    public int ProximoId()
    {
      return this.listaSerie.Count() + 1;
    }

    public void Remove(int id)
    {
      listaSerie[id].Excluir();
    }

    public Series RetornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}