using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio.Series.Enum;

namespace Dio.Series.Classes
{
    public class Series : EntidadeBase
    {
        public Series(int id, Genero genero, string? titulo, string? descricao, int ano)
        {
        Id = id;
        Genero = genero;
        Titulo = titulo;
        Descricao = descricao;
        Ano = ano;
        }

        //atributos
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Métodos
        public void Serie (int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero +Environment.NewLine;
            retorno += "Titulo: " + this.Titulo +Environment.NewLine;
            retorno += "Descricao: " + this.Descricao +Environment.NewLine;
            retorno += "Ano: " + this.Ano +Environment.NewLine;
            retorno += "Excluido: " + this.Excluido +Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        internal int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluir()
        {
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }
    }
}