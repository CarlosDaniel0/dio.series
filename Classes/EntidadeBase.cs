namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id {get; protected set;}
        protected Genero Genero { get; set; }
        protected string Titulo { get; set; }
        protected string Descricao { get; set; }
        protected bool Excluido { get; set; }
    }
}