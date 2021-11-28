using System;
using System.Collections.Generic;
using System.Text;

namespace exemplos
{
    internal class Caminhao : Veiculo
    {
        public int QtdVagao { get; set; }
        public Caminhao(int qtdvagao, int quantidaderodas)
        {
            QuantidadeRodas = quantidaderodas;
            QtdVagao = qtdvagao;
        }

        public void  QuantidadeDeVagao()
        {
            Console.WriteLine($"Quantidade de Vagões {QtdVagao}");
        }


       // public int QuantidadeDeVagao() => new Random().Next(2, int.MaxValue); 

    }
}
