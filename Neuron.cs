using System;
using System.Collections.Generic;
namespace Application
{

    public class Neuron
    {
        double[,] dataSet = { { .6, .5, 1 }, { .2, .4, 1 }, { -.3, -.5, -1 }, { -.1, -.1, -1 }, { .1, .1, 1 }, { -.2, .7, 1 }, { -.4, -.2, -1 }, { -.6, .3, -1 } };
        double[,] dataTest = { { .3, .1, -1 }, { -.5, .4, 1 }, { -.4, -.2, 1 }, { .3, -.7, 1 }, { -.2, .3, -1 } };
        double[] weights;
        static readonly double lambda = 0.05;

        public Neuron()//rastgele weightler atanır
        {
            weights = new double[4];
            Random random = new Random();
            weights[0] = random.NextDouble() * 2 - 1;
            weights[1] = random.NextDouble() * 2 - 1;
            weights[2] = random.NextDouble() * 2 - 1;
            weights[3] = random.NextDouble() * 2 - 1;

        }

        public void Train()
        {
            double accurate = 0;
            Console.WriteLine("Eğitim aşaması");

            for (int i = 0; i < 100; i++)
            {
                accurate = 0;

                for (int j = 0; j < dataSet.GetLength(0); j++)
                {
                    double v = dataSet[j, 0] * weights[0] + dataSet[j, 1] * weights[1];
                    int y = 1;

                    if (v < 0.5)
                    {
                        y = -1;
                    }
                    if (y == -1 && dataSet[j, 2] == 1)//hedefe ulaşılıp ulaşılamama durumuna göre weight üzerinde oynama yapılır ya da accurate olanlara eklenir
                    {
                        weights[0] += lambda * 2 * dataSet[j, 0];
                        weights[1] += lambda * 2 * dataSet[j, 1];
                    }
                    else if (y == 1 && dataSet[j, 2] == -1)
                    {
                        weights[0] -= lambda * 2 * dataSet[j, 0];
                        weights[1] -= lambda * 2 * dataSet[j, 1];
                    }
                    else
                    {
                        accurate += 1;
                    }

                }

                if (i == 9)//10.epokta yazdırılması gerekeni yazdırır
                {
                    Console.WriteLine("10 epok sonu accuracy değeri: %" + (accurate / dataSet.GetLength(0) * 100));
                }

            }
            Console.WriteLine("100 epok sonu accuracy değeri: %" + (accurate / dataSet.GetLength(0) * 100));

        }

        public void Test()
        {
            double accurate = 0;
            Console.WriteLine("Test aşaması");

            for (int i = 0; i < 100; i++)
            {
                accurate = 0;

                for (int j = 0; j < dataTest.GetLength(0); j++)
                {
                    double v = dataTest[j, 0] * weights[2] + dataTest[j, 1] * weights[3];
                    int y = 1;

                    if (v < 0.5)
                    {
                        y = -1;
                    }
                    if (y == -1 && dataTest[j, 2] == 1)
                    {
                        weights[2] += lambda * 2 * dataTest[j, 0];
                        weights[3] += lambda * 2 * dataTest[j, 1];
                    }
                    else if (y == 1 && dataTest[j, 2] == -1)
                    {
                        weights[2] -= lambda * 2 * dataTest[j, 0];
                        weights[3] -= lambda * 2 * dataTest[j, 1];
                    }
                    else
                    {
                        accurate += 1;
                    }

                }

                if (i == 9)
                {
                    Console.WriteLine("10 epok sonu accuracy değeri: %" + (accurate / dataTest.GetLength(0) * 100));
                }

            }
            Console.WriteLine("100 epok sonu accuracy değeri: %" + (accurate / dataTest.GetLength(0) * 100));

        }
    }
}
