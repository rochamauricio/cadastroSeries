using System.Collections.Generic;

namespace Series.Interfaces {
  /* quem implementar a interface estará implementando 
  um repositório dessa classe T */
  public interface IRepositorio<T> {
    List<T> Lista(); // T == tipo genérico, List<T> == lista de T, T pode ser a Classe Serie

    T RetornaPorId(int id); // retorna um T
    void Insere(T objeto);
    void Exclui(int id);
    void Atualiza(int id, T objeto);
    int ProximoId(); // retorna o proximo Id

    // metodos que quem implementar a interface tera que implementar
  }
}