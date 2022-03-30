using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {

        private List<Series> listaSerie = new List<Series>();

        public void Atualizar(int id, Series objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornoPorId(int id)
        {
            return listaSerie[id];
        }
    }
}