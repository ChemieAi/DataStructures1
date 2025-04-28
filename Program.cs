using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    class Program
    {
        static double uzaklıkhesap(double x1, double y1, double x2, double y2)
        {
            double hesap = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            hesap = Math.Truncate(hesap * 10) / 10;
            return hesap;
        }

        static Random random = new Random();


        static void Main(string[] args)
        {

            var n = "";
            Console.Write("Input the n value: ");


            n = Console.ReadLine();



            double[,] noktalar = new double[int.Parse(n), 2];
            double[,] uzaklıklar = new double[int.Parse(n), int.Parse(n)];

            Console.Write("Input the width value: ");
            var width = Console.ReadLine();
            Console.Write("Input the heigth value: ");
            var height = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < int.Parse(n); i++)
            {
                double pointHeight = Math.Truncate(random.NextDouble() * int.Parse(height) * 100) / 100;
                double pointWidth = Math.Truncate(random.NextDouble() * int.Parse(width) * 100) / 100;
                noktalar[i, 0] = pointWidth;
                noktalar[i, 1] = pointHeight;
                Console.WriteLine("x: " + pointWidth + " " + "y: " + pointHeight);
            }
            Console.WriteLine();
            for (int i = 0; i < int.Parse(n); i++)
            {
                for (int j = 0; j < int.Parse(n); j++)
                {
                    double temp = uzaklıkhesap(noktalar[i, 0], noktalar[i, 1], noktalar[j, 0], noktalar[j, 1]);
                    uzaklıklar[i, j] = temp;
                    string tempStr = String.Format("{0:000.00}", temp);
                    Console.Write(tempStr + " | ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 10; i++)
            {
                int başlangıç = random.Next(0, int.Parse(n));
                Console.WriteLine((i + 1) + ". tur");
                Console.Write("Uğradığı noktalar: " + başlangıç);
                double totalUzaklık = 0;
                List<int> gezilmisler = new List<int>();
                gezilmisler.Add(başlangıç);
                for (int j = 0; j < int.Parse(n) - 1; j++)
                {

                    var uzaklik = (double)int.MaxValue;

                    int node = 0;
                    for (int k = 0; k < int.Parse(n); k++)
                    {
                        if (uzaklıklar[başlangıç, k] < uzaklik && !gezilmisler.Contains(k))
                        {
                            uzaklik = uzaklıklar[başlangıç, k];
                            node = k;
                        }

                    }
                    Console.Write("-" + node);
                    gezilmisler.Add(node);
                    başlangıç = node;
                    totalUzaklık += uzaklik;


                }
                Console.WriteLine("\nUzaklıklar toplamı; " + Math.Truncate(totalUzaklık * 100) / 100);
            }

            Neuron neuron = new Neuron();
            neuron.Train();
            neuron.Test();
        }


    }
}
