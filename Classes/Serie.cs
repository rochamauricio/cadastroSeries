using System;

namespace Series {
  public class Serie : EntidadeBase { // herança
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }

    public bool Excluido { get; set; } // marcar como excluido é melhor que excluir

    public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
      this.Id = id; // EntidadeBase
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = false;
    }

    public override string ToString() {
      string retorno = "";
      retorno += "Genero: " + this.Genero + Environment.NewLine; // Environment == nova linha para cada SO
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano: " + this.Ano;

      return retorno;
    }

    public string retornaTitulo() {
      return this.Titulo;
    }

    public int retornaId() {
      return this.Id;
    }

    public void Excluir() {
      this.Excluido = true;
    }
  }
}