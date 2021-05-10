namespace DIO.Series
{
    public class Serie:EntidadeBase
    {
        // Atributos
        private int AnoInicio { get; set; }
        private string AnoFinal { get; set; }
        public Serie(int id, Genero genero, string titulo, string descricao, int anoInicio, string anoFinal)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoInicio = anoInicio;
            this.AnoFinal = anoFinal;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = $"Gênero: \t{this.Genero.ToString()}\nTítulo: \t{this.Titulo}\nDescrição: \t{this.Descricao}\nDuração: \t{this.AnoInicio} - {this.AnoFinal}\nExcluída: \t{this.Excluido}\n";

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

        public string retornoData()
        {
            return $"{this.AnoInicio} - {this.AnoFinal}";
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
                this.AnoInicio = int.Parse(valor);
                break;
                case 5:
                this.AnoFinal = valor;
                break;
            }
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}