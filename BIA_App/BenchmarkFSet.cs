using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIA_App
{
    public class BenchmarkFSet
    {
        /// <summary>
        /// Number of all functions
        /// </summary>
        private static int NUMFUNC = 22;

        public Function[] Functions = new Function[NUMFUNC];

        /// <summary>
        /// Creates all Yao Benchmark Set 1 Functions
        /// </summary>
        public BenchmarkFSet()
        {

            Functions[0] = new Function(1, "1st De Jong", new float[] { -100, 100 });
            Functions[1] = new Function(2, "f2", new float[] { -10, 10 });
            Functions[2] = new Function(3, "f3", new float[] { -100, 100 });
            Functions[3] = new Function(4, "f4", new float[] { -100, 100 });
            Functions[4] = new Function(5, "f5", new float[] { -30, 30 });
            Functions[5] = new Function(6, "f6", new float[] { -100, 100 });
            Functions[6] = new Function(7, "f7", new float[] { -1.28f, 1.28f });
            Functions[7] = new Function(8, "Schwefel function", new float[] { -500, 500 });
            Functions[8] = new Function(9, "f9", new float[] { -5.12f, 5.12f });
            Functions[9] = new Function(10, "f10", new float[] { -32, 32 });
            Functions[10] = new Function(11, "f11", new float[] { -600, 600 });
            Functions[11] = new Function(12, "f12", new float[] { -50, 50 });
            Functions[12] = new Function(13, "f13", new float[] { -50, 50 });
            Functions[13] = new Function(14, "f14", new float[] { -65.536f, 65.536f });
            Functions[14] = new Function(15, "f15", new float[] { -100, 100 });
            Functions[15] = new Function(16, "f16", new float[] { -5, 5 });
            Functions[16] = new Function(17, "f17", new float[] { -5, 10, 0, 15 });
            Functions[17] = new Function(18, "f18", new float[] { -2, 2 });
            Functions[18] = new Function(19, "f19", new float[] { -100, 100 });
            Functions[19] = new Function(20, "f20", new float[] { -100, 100 });
            Functions[20] = new Function(21, "f21", new float[] { -100, 100 });
            Functions[21] = new Function(22, "Pareto", new float[] { 0, 1 });
        }

        /// <summary>
        /// Generates random points in range from 0 to 1
        /// </summary>
        /// <param name="count">Number of points</param>
        /// <returns></returns>
        public float[][] GeneratePoints(int count)
        {
            float[][] result = new float[count][];
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                result[i] = new float[2];

                for (int j = 0; j < 2; j++)
                {
                    result[i][j] = (float)rnd.NextDouble();
                }

            }


            return result;
        }

        /// <summary>
        /// Returns function by given Id for example F1 ID == 1, F2 ID == 2 etc.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Function GetById(int id)
        {
            return Functions.FirstOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// Returns function by given Id for example F1 ID == 1, F2 ID == 2 etc.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Function GetFunction(int id)
        {
            return Functions.Where(f => f.Id == id).First();
        }

        /*
        public double GetMin(int index)
        {

            switch (index)
            {
                case 1:
                case 3:
                case 4:
                case 6:
                    return -100;
                case 12:
                case 13:
                    return -50;
                case 2:
                    return -10;
                case 5:
                    return -30;
                case 7:
                    return -1.28;
                case 8:
                    return -500;
                case 9:
                    return -5.12;
                case 10:
                    return -32;
                case 11:
                    return -600;
                case 14:
                    return -65.536;
                case 16:
                    return -5;
                case 17:
                    return -5;
                case 18:
                    return -2;
                default:
                    return -99;
            }
        }



        public double GetMax(int index)
        {

            switch (index)
            {
                case 1:
                case 3:
                case 4:
                case 6:
                    return 100;
                    break;
                case 12:
                case 13:
                    return 50;
                    break;
                case 2:
                    return 10;
                    break;
                case 5:
                    return 30;
                    break;
                case 7:
                    return 1.28;
                    break;
                case 8:
                    return 500;
                    break;
                case 9:
                    return 5.12;
                    break;
                case 10:
                    return 32;
                    break;
                case 11:
                    return 600;
                    break;
                case 14:
                    return 65.536;
                    break;
                case 16:
                    return 5;
                    break;
                case 17:
                    return 10;
                    break;
                case 18:
                    return 2;
                    break;
                default:
                    return -99;
                    break;
            }
        }
        */
    }
   
}
