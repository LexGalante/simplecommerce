using System;
using System.Collections.Generic;
using System.Text;

namespace exemplos
{
    public class Carro : Veiculo
    {        
        public string Categoria { get; set; }
        public bool TemArcondicionado { get; set; }
        public bool TemDirecaoHidraulica { get; set; }

        public Carro(string nome, string fabricante, string categoria)
        {
            Nome = nome;
            Fabricante = fabricante;
            Categoria = categoria;
        }

        public void Ligar()
        {
            Console.WriteLine($"Carro {Nome} começou a andar....");
        }

        public int QuilometragemRodada() => new Random().Next(11111, int.MaxValue);
    }
}
