namespace DIO.Series
{
    public class Filme: EntidadeBase
    {
        // Atributos
        private int AnoLancamento { get; set; }
        public Filme(int id, Genero genero, string titulo, string descricao, int AnoLancamento)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = AnoLancamento;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = $"Gênero: \t{this.Genero}\nTítulo: \t{this.Titulo}\nDescrição: \t{this.Descricao}\nLançamento: \t{this.AnoLancamento}\nExcluída: \t{this.Excluido}";

            return retorno;
        }

        public string retornoTitulo()
        {
            return this.Titulo;
        }

        public int retornoId()
        {
            return this.Id;
        }

        public int retornoAno()
        {
            return this.AnoLancamento;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void AtualizarPorItem(int item, string valor)
        {
            switch(item)
            {
                case 1:
                this.Genero = (Genero)int.Parse(valor);
                break;
                case 2:
                this.Titulo = valor;
                break;
                case 3:
                this.Descricao = valor;
                break;
                case 4:
                this.AnoLancamento = int.Parse(valor);
                break;
            }
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}