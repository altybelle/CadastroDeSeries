using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    public class Serie: EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }
        public int GetId()
        {
            return Id;
        }
        public string GetTitulo()
        {
            return Titulo;
        }
        public bool GetExcluido()
        {
            return Excluido;
        }
        public void Excluir()
        {
            Excluido = true;
        }

        public override string ToString()
        {
            return 
                $"Gênero: {Genero}\n" +
                $"Título: {Titulo}\n" +
                $"Descrição: {Descricao}\n" +
                $"Ano de Início: {Ano}"; 
        }
    }
}
