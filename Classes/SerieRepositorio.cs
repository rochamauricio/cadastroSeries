using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series {
  /* Implementa uma interface Irepositorio de Séries
     Estamos reaproveitando a interface, poderiamos fazer
     um repositório de filmes, de documentarios, etc */

  public class SerieRepositorio : IRepositorio<Serie> { // implementa interface

    private List<Serie> listaSerie = new List<Serie>();
    public void Atualiza(int id, Serie objeto) {
      listaSerie[id] = objeto;
    }

    public void Exclui(int id) {
      listaSerie[id].Excluir(); //nao usaremos o listaSerie.RemoveAt(id)      
    }

    public void Insere(Serie objeto) {
      listaSerie.Add(objeto);
    }

    public List<Serie> Lista() {
      return listaSerie;
    }

    public int ProximoId() {
      return listaSerie.Count; // num de elementos == id do prox elem
    }

    public Serie RetornaPorId(int id) {
      return listaSerie[id];
    }
  }
}