namespace exemplos
{
    public abstract class Veiculo
    {
        protected string Nome { get; set; }
        protected string Fabricante { get; set; }
        public int QuantidadeCavalos { get; set; }
        public int QuantidadeRodas { get; set; }
    }
}
