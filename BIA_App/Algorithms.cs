using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIA_App
{
    public class Algorithms
    {
        public List<Algorithm> All { get; private set; }

        public Algorithms()
        {
            All = new List<Algorithm>();
            Init();
        }

        public void Init()
        {
            All.Add(new BlindSearch());
            All.Add(new DifferentialEvolution());
            All.Add(new SimulatedAnnealing());
            All.Add(new SOMA());
            //All.Add(new EvolutionalStrategy());
        }

    }

    public class Algorithm
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public virtual Individuals Run(Individuals p, Function f, bool _integer, float? min = null, float? max = null) { return null; }
    }

    // F 0 to 2, better 0.5 (0.8)

    public class BlindSearch : Algorithm
    {
        public BlindSearch()
        {
            Name = "Blind Search";
            Id = 1;
        }

        public override Individuals Run(Individuals p, Function f, bool _integer, float? min = null, float? max = null)
        {
            if (min == null)
                min = f.GetMin();
            if (max == null)
                max = f.GetMax();

            Individual best = p.GetBest();

            var result = new Individuals();
            result.Population.Add(best);
            result.GeneratePopulation(p.Population.Count - 1, f, _integer, min, max);
            return result;
        }
    }

    public class DifferentialEvolution : Algorithm
    {
        private float F, CR;

        public DifferentialEvolution()
        {
            Name = "Differential Evolution";
            Id = 2;
            F = 0.8f;
            CR = 0.5f;
        }

        public override Individuals Run(Individuals p, Function f, bool integer, float? min = null, float? max = null)
        {
            if (min == null)
                min = f.GetMin();
            if (max == null)
                max = f.GetMax();

            if (p.Population.Count < 4) // too small
                return p;

            Random r = new Random();
            Individuals result = new Individuals();

            for (int i = 0; i < p.Population.Count; i++) //for each element
            {
                //get 3 different elements in interval
                int[] rands = new int[3];
                Individual[] parents = new Individual[4];
                Individual diff = new Individual(); 
                Individual noisy = new Individual();
                Individual trial = new Individual();

                while (true) //until child in interval is found
                {
                    do { rands[0] = r.Next(p.Population.Count); } while (rands[0] == i);
                    do { rands[1] = r.Next(p.Population.Count); } while (rands[1] == i || rands[1] == rands[0]);
                    do { rands[2] = r.Next(p.Population.Count); } while (rands[2] == i || rands[2] == rands[0] || rands[2] == rands[1]);

                    parents[0] = p.Population[i];
                    parents[0].Fitness = f.EvaluateFitness(f.Id, parents[0].Dimension);
                    parents[1] = p.Population[rands[0]];
                    parents[2] = p.Population[rands[1]];
                    parents[3] = p.Population[rands[2]];

                    //get noisy vector (mutation)
                    diff = new Individual();
                    diff.Dimension = new float[] { parents[1].Dimension[0] - parents[2].Dimension[1], parents[1].Dimension[0] - parents[2].Dimension[1], 0 };


                    noisy = new Individual();
                    noisy.Dimension = new float[] { parents[3].Dimension[0] + F * diff.Dimension[0], parents[3].Dimension[1] + F * diff.Dimension[1], 0 };

                    //get trial element (intersection)
                    trial = new Individual();
                    trial.Dimension = new float[] { (r.NextDouble() < CR ? noisy.Dimension[0] : parents[0].Dimension[0]),
                    (r.NextDouble() < CR ? noisy.Dimension[1] : parents[0].Dimension[1]), 0};

                    trial.Z = f.EvaluateFitness(f.Id, trial.Dimension);
                    trial.Fitness = f.EvaluateFitness(f.Id, trial.Dimension);


                    if (trial.IsOK((float)min, (float)max))
                        break;

                }
                //use parent or trial, whichever is better
                if (trial.Z < parents[0].Z)
                    result.Population.Add(trial);
                else
                    result.Population.Add(parents[0]);
            }
            return result;
        }
    }


    public class SimulatedAnnealing : Algorithm
    {
        private float T0, T, Tf, nT, alpha;

        public SimulatedAnnealing()
        {
            Name = "Simulated Annealing";
            Id = 3;
            Tf = 0.05f;
            alpha = 0.95f;
            nT = 10f;
            T = 1f;
            T0 = 1f;
        }

        public override Individuals Run(Individuals population, Function f, bool integer, float? min = null, float? max = null)
        {
            if (min == null)
                min = f.GetMin();
            if (max == null)
                max = f.GetMax();

            Random r = new Random();
            Individuals result = new Individuals();
            result.Population.AddRange(population.Population);

            if (T >= Tf)
            {
                for (int i = 0; i < result.Population.Count; i++) // for each element
                {
                    for (int j = 0; j < nT; j++) // reps
                    {

                        //generate list of neighbors
                        Individuals neighbors = new Individuals();
                        float tempMax = ((float)max - (float)min) / 2;
                        Individual parent = result.Population[i];
                        for (int k = 0; k < nT; k++) //number of neighbors often same as number of Metropolis repetitions
                        {
                            float x = parent.Dimension[0] + T * (float)(r.NextDouble() * tempMax - tempMax / 2);
                            float y = parent.Dimension[1] + T * (float)(r.NextDouble() * tempMax - tempMax / 2);

                            if (x < min)
                                x = (float)min;
                            else if (x > max)
                                x = (float)max;

                            if (y < min)
                                y = (float)min;
                            else if (y > max)
                                y = (float)max;
                            neighbors.Population.Add(new Individual() { Dimension = new float[]{ x, y}, Z = f.EvaluateFitness(f.Id, new float[] { x, y }) });
                        }

                        //choose randomly
                        Individual choose = neighbors.Population[r.Next(neighbors.Population.Count - 1)];
                        // If better use it
                        if (choose.Z < parent.Z)
                            result.Population[i] = choose;
                        else
                        //If worse, rng might still choose it
                        {
                            float chance = (float)r.NextDouble();
                            float exp = (float)Math.Pow(Math.E, -(choose.Z - parent.Z) / T);
                            if (chance < exp)
                                result.Population[i] = choose;
                        }
                    }
                }
                T *= alpha;
            }
            return result;
        }
    }

    public class SOMA : Algorithm
    {
        private float PathLength, Step, PRT, MinDiv;
        private int Migrations, Migration;

        public SOMA()
        {
            Name = "Self-Organizing Migrating Algorithm";
            Id = 4;
            PathLength = 1.4f;
            Step = 0.11f;
            PRT = 0.8f;
            Migrations = 10;
            MinDiv = 0.001f;
            Migration = 30;
        }
        private List<int> GetPRTVector(int size, Random r)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < size; i++)
                result.Add((r.NextDouble() < PRT) ? 1 : 0);
            return result;
        }
        public override Individuals Run(Individuals population, Function f, bool integer, float? min = null, float? max = null)
        {
            if (min == null)
                min = f.GetMin();
            if (max == null)
                max = f.GetMax();


            if (Migration <= 0)
                return population;

            Individual leader = population.Population[0];
            Individual worst = population.Population[0];

            foreach (var e in population.Population)
            {
                if (e.Z < leader.Z)
                    leader = e;
                if (e.Z > worst.Z)
                    worst = e;
            }
            if (worst.Z - leader.Z < MinDiv)
                return population;

            Random r = new Random();
            Individuals result = new Individuals();
            for (int k = 0; k < population.Population.Count; k++)
            {
                var e = population.Population[k];
                if (e == leader)
                {
                    result.Population.Add(e);
                    continue;
                }
                var jumps = new Individuals();
                for (int i = 0; i < PathLength / Step; i++)
                {
                    var prtv = GetPRTVector(2, r);
                    var leaderdiff = new Individual { Dimension = new float[] { leader.Dimension[0] - e.Dimension[0], leader.Dimension[1] - e.Dimension[1]}, Z = 0 };
                    var onejump = new Individual { Dimension = new float[] { e.Dimension[0] + leaderdiff.Dimension[0] * i * Step * prtv[0],
                        e.Dimension[1] + leaderdiff.Dimension[1] * i * Step * prtv[1]},
                        Z = f.EvaluateFitness(f.Id, new float[] { e.Dimension[0] + leaderdiff.Dimension[0] * i * Step * prtv[0], e.Dimension[1] + leaderdiff.Dimension[1] * i * Step * prtv[1]})
                    };
                    if (onejump.IsOK((float)min, (float)max))
                        jumps.Population.Add(onejump);
                }
                int bestindex = -1;
                for (int j = 0; j < jumps.Population.Count; j++)
                {
                    if (jumps.Population[j].Z < e.Z)
                        bestindex = j;
                }
                result.Population.Add((bestindex == -1) ? population.Population[k] : jumps.Population[bestindex]);
            }
            Migration--;
            return result;
        }
    }

    /* TODO
    public class EvolutionalStrategy : Algorithm
    {
        private float Elitism, Range, FV, Children;
        private int Iterations, Iteration;

        public EvolutionalStrategy()
        {
            Name = "Evolutional Strategy";
            Id = 5;
            Elitism = 1f;
            Range = 0.1f;
            FV = 0.9999f;
            Children = 4f;
            Iterations = 30;
            Iteration = 0;
        }

        public override Individuals Run(Individuals population, Function f, bool integer, float? min = null, float? max = null)
        {
            if (min == null)
                min = f.GetMin();
            if (max == null)
                max = f.GetMax();

            if (Iteration >= Iterations)
                return population;
            Random r = new Random();
            Individuals result = new Individuals();
            Individual best = population.Population[0];
            foreach (var e in population.Population)
                if (e.Fitness > best.Fitness)
                    best = e;
            if (best.Fitness > FV)
                return population;
            Individuals children = new Individuals();


            foreach (var e in population.Population)
            {
                for (int i = 0; i < Children; i++)
                {
                    Individual newIndividual = null;
                    while (newIndividual == null || !newIndividual.IsOK((float)min,(float)max))
                    {
                        float newx = e.Dimension[0] + (float)(r.NextDouble() * ((float)max - (float)min) + (float)min) * Range;
                        float newy = e.Dimension[1] + (float)(r.NextDouble() * ((float)max - (float)min) + (float)min) * Range;
                        newIndividual = new Individual { Dimension = new float[] {newx, newy }, Z = f.EvaluateFitness(f.Id, new float[] { newx, newy}) };
                    }
                    children.Population.Add(newIndividual);
                }
            }

            result.Population.AddRange(children.Population);
            if (Elitism == 1)
                result.Population.AddRange(population.Population);

            result.Population.Sort(new IndividualComparer());
            while (result.Population.Count > population.Population.Count)
                result.Population.RemoveAt(population.Population.Count);

            Iteration++;

            //(fmax-fmin)*range;
            return result;
        }
    }*/
}

