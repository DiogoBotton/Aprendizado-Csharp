﻿using System;

namespace matrizesarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaração do array
            /*
            int[] numeros_loteria;

            //intanciando (alocando área na memória para que o array possa armazenar informações)

            numeros_loteria = new int[6];
            */
            //declarando e instanciando em apenas uma linha e na sequência(não obrigatório) acrescenta elementos dentro dele.
            int[] numeros_loteria = new int[6] {1, 2, 3, 4, 5, 6};
                                              //0, 1, 2, 3, 4, 5  
            int valor = 0;
            
            //dizendo para o usuário mudar o conteúdo de um elemento especificado 
            
            Console.Write("Digite um novo valor para o elemento 3: ");
            valor = Convert.ToInt32(Console.ReadLine());
            numeros_loteria[3] = valor;
            Console.WriteLine("O novo valor é: " + numeros_loteria[3]);
            

            

            


           /* 
           //O usuário diz qual será o tamanho do array
            int tamanho;

            tamanho = Convert.ToInt32(Console.ReadLine());
            int[] numeros_loteria2 = new int[tamanho]; declarando e instanciando (ao invés do número, a variavel)
            */
        }
    }
}
