using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIA_App
{
    public class Individual
    {
        public float[] Dimension { get; set; }
        public float Z { get; set; }
        public float Fitness { get; set; }

        public Individual()
        {
                
        }

        public Individual(float[] dim)
        {
            Dimension = new float[dim.Length];
        }

        public bool IsOK(float min, float max)
        {
            if (Dimension[0] < min || Dimension[1] < min)
                return false;
            if (Dimension[0] > max || Dimension[1] > max)
                return false;
            return true;
        }
    }

    public class IndividualComparer : IComparer<Individual>
    {

        public int Compare(Individual x, Individual y)
        {
            float diff = x.Z - y.Z;
            return Math.Sign(diff);
        }
    }


    public class Individuals
    {
        public List<Individual> Population { get; set; }

        public Individuals()
        {
            Population = new List<Individual>();
        }

        public Individual GetBest()
        {
            return Population.OrderByDescending(i => i.Z).FirstOrDefault();
        }

        public void GeneratePopulation(int popSize, Function f, bool _integer, float? _min = null, float? _max = null)
        {
            var r = new Random();

            float min, max = 0;

            min = (_min == null) ? f.GetMin() : (float)_min;
            max = (_max == null) ? f.GetMax() : (float)_max;

            for (int i = 0; i < popSize; i++)
            {
                var current = new Individual(f.Dimension);
                for(int j = 0; j < f.Dimension.Length; j++)
                {
                    current.Dimension[j] = _integer ? (float)Math.Round((min + (float)r.NextDouble() * (max - min))) : (min + (float)r.NextDouble() * (max - min));
                }

                current.Z = _integer ? f.EvaluateFitness(f.Id, current.Dimension) : (float)Math.Round(f.EvaluateFitness(f.Id, current.Dimension));
                Population.Add(current);

            }
        }

        // Whole population
        public void ComputeFitness()
        {
            float total = 0;
            float sum = 0;
            float best = Population[0].Z;

            foreach(var i in Population)
            {
                sum += i.Z;
                total += Math.Abs(i.Z);

                if (best > i.Z)
                    best = i.Z;
            }


            float avg = sum / Population.Count;

            foreach(var i in Population)
            {
                if (total == 0)
                    i.Fitness = 1;
                else
                    i.Fitness = 1 - Math.Abs((best - i.Z) / total) - Math.Abs((best - avg) / total);
            }
        }

    }
}
