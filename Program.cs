using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPythonConv
{
    class Program
    {
        private const string geneSet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!.";
        private const string target = "Hello World!";
        private static DateTime startTime = DateTime.Now;
        private static String bestParent = generate_Parent(target.Length); 
        private static int bestFitness = get_fitness(bestParent);

        static void Main(string[] args)
        {
            Console.WriteLine(display(bestParent));
            while (true)
            {
                string child = mutate(bestParent);
                int childFitness = get_fitness(child);
                if (bestFitness >= childFitness)
                    continue;
                Console.WriteLine(display(child));
                if (childFitness >= target.Length)
                    break;
                bestFitness = childFitness;
                bestParent = child;
            }
            Console.ReadLine();
        }

        static string display(string genes)
        {
            TimeSpan timediff = DateTime.Now - startTime;
            return timediff + " " + get_fitness(genes) + " " + genes;
        }

        static string generate_Parent(int length)
        {
            StringBuilder genes = new StringBuilder();
            for (int i = 0; i  < length; i++)
            {
                Random rnd = new Random();
                int RndIndex = rnd.Next(0,geneSet.Length);
                genes.Append(geneSet[RndIndex].ToString());
            }
            return genes.ToString();
        }

        static int get_fitness(string guess)
        {
            int i = 0;
            int fitness = 0;
            foreach (char c in guess)
            {
                if (target[i] == c)
                    fitness++;
                i++;
            }
            return fitness;
        }

        static String mutate(String genes)
        {
            Random rnd = new Random();
            int RndIndex = rnd.Next(0,genes.Length);
            int RndSampleIndex = rnd.Next(0,geneSet.Length);
            StringBuilder sb = new StringBuilder(genes);
            sb[RndIndex] = geneSet[RndSampleIndex];
            return sb.ToString();
        }
    }
}
