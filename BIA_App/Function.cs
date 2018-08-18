using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIA_App
{
    public class Function
    {
        public int Id { get; set; }
        public float[] Dimension { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Create Function with given parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="dim"></param>
        public Function(int id, string name, float[] dim)
        {
            Id = id;
            Dimension = dim;
            Name = name;
        }

        public float GetMin()
        {
            return Dimension[0];
        }

        public float GetMax()
        {
            return Dimension[Dimension.Length - 1];
        }

        /// <summary>
        /// Evaluates fitness
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public float EvaluateFitness(int id, float[] dim)
        {

            switch (id)
            {
                case 1:
                    return F1(dim);
                case 2:
                    return F2(dim);
                case 3:
                    return F3(dim);
                case 4:
                    return F4(dim);
                case 5:
                    return F5(dim);
                case 6:
                    return F6(dim);
                case 7:
                    return F7(dim);
                case 8:
                    return F8(dim);
                case 9:
                    return F9(dim);
                case 10:
                    return F10(dim);
                case 11:
                    return F11(dim);
                case 12:
                    return F12(dim);
                case 13:
                    return -1;
                case 14:
                    return -1;
                case 15:
                    return -1;
                case 16:
                    return F16(dim);
                case 17:
                    return F17(dim);
                case 18:
                    return F18(dim);
                case 19:
                    return -1;
                case 20:
                    return -1;
                case 21:
                    return -1;
                case 22:
                    return Pareto(dim);
                default:
                    return -1;
            }
        }

        /// <summary>
        /// F1 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        private float F1(float[] dim)
        {
            float result = 0;
            for (var i = 0; i < dim.Length; i++)
            {
                result += (float)Math.Pow(dim[i], 2);
            }

            return result;
        }

        /// <summary>
        /// F2 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F2(float[] dim)
        {
            float result = 0;
            float tmpSum = 0;
            float tmpPro = 0;
            for (var i = 0; i < dim.Length; i++)
            {
                tmpSum += Math.Abs(dim[i]);
                tmpPro *= Math.Abs(dim[i]);
            }

            result = tmpSum + tmpPro;

            return result;
        }


        /// <summary>
        /// F3 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F3(float[] dim)
        {
            float result = 0;
            float tmpSum = 0;

            for (var i = 0; i < dim.Length; i++)
            {

                for (var j = 0; j < i; j++)
                {
                    tmpSum += dim[j];

                }
                result += tmpSum;
            }

            return result;
        }

        /// <summary>
        /// F4 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F4(float[] dim)
        {
            float result = 0;

            for (var i = 1; i < dim.Length; i++)
            {
                result = Math.Max(Math.Abs(dim[i]), Math.Abs(dim[i - 1]));
            }

            return result;
        }


        /// <summary>
        /// F5 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F5(float[] dim)
        {
            float result = 0;

            for (var i = 0; i < dim.Length - 1; i++)
            {
                result += 100 * (float)Math.Pow((dim[i + 1] - (float)Math.Pow(dim[i], 2)), 2) + (float)Math.Pow((dim[i] - 1), 2);

            }

            return result;
        }

        /// <summary>
        /// F6 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F6(float[] dim)
        {
            float result = 0;

            for (var i = 0; i < dim.Length; i++)
            {
                result += (float)Math.Pow(dim[i] + 0.5f, 2);
            }

            return result;
        }

        /// <summary>
        /// F7 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F7(float[] dim)
        {
            float result = 0;
            var rnd = new Random();

            for (var i = 0; i < dim.Length; i++)
            {
                result += i * (float)Math.Pow(dim[i], 4) + (float)rnd.NextDouble();
            }

            return result;
        }

        /// <summary>
        /// F8 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F8(float[] dim)
        {
            float result = 0;
            for (var i = 0; i < dim.Length; i++)
            {
                result += -dim[i] * (float)Math.Sin(Math.Sqrt(Math.Abs(dim[i])));
            }

            return result;
        }


        /// <summary>
        /// F9 Function from Yao Benchmark Set 1
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private float F9(float[] dim)
        {
            float result = 0;
            for (var i = 0; i < dim.Length; i++)
            {
                result += -dim[i] * (float)Math.Sin(Math.Sqrt(Math.Abs(dim[i])));
            }

            return result;
        }

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


        private float F10(float[] dim)
        {
            float result = 0;

            float temp_0 = 0;
            float temp_1 = 0;

            for (var i = 0; i < dim.Length; i++)
            {
                temp_0 += (float)Math.Pow(dim[i], 2);
            }

            for (var i = 0; i < dim.Length; i++)
            {
                temp_1 += (float)Math.Cos(2 * Math.PI * dim[i]);
            }


            result = (float)(-20 * Math.Exp(-0.2 * Math.Sqrt(temp_0 / dim.Length)) - Math.Exp(temp_1 / dim.Length) + 20 + Math.E);

            return result;
        }

        private float F11(float[] dim)
        {
            float result = 0;

            float temp_0 = 0;
            float temp_1 = 1;

            for (var i = 0; i < dim.Length; i++)
            {
                temp_0 += (float)Math.Pow(dim[i], 2);
            }

            for (var i = 0; i < dim.Length; i++)
            {
                temp_1 *= (float)Math.Cos(dim[i] / Math.Sqrt(i + 1));
            }


            result = 1f / 4000f * temp_0 - temp_1 + 1;

            return result;
        }

        private float F12(float[] dim)
        {
            float result = 0;

            float temp_0 = 0;
            float temp_1 = 1;

            float sumDim = 0;

            for (var i = 0; i < dim.Length - 1; i++)
            {
                sumDim += dim[i];
            }

            for (var i = 0; i < dim.Length - 1; i++)
            {
                temp_0 += (float)(Math.Pow(1 + 1 / 4 * (dim[i] + 1) - 1, 2) * (1 + Math.Pow(Math.Sin(3 * Math.PI * dim[i + 1]), 2)));
            }
            for (var i = 0; i < dim.Length; i++)
            {
                var a = 10;
                var k = 100;
                var m = 4;

                if (dim[i] > a)
                {
                    temp_1 += (float)(k * Math.Pow((dim[i] - a), m));
                }
                if (-a <= dim[i] && dim[i] <= a)
                {
                    temp_1 += 0;
                }
                if (dim[i] < -a)
                {
                    temp_1 += (float)(k * Math.Pow((-dim[i] - a), m));
                }

                temp_1 += (float)(Math.Cos(dim[i] / Math.Sqrt(i + 1)));
            }


            result =(float)(Math.PI / dim.Length * (10 * Math.Pow(Math.Sin(Math.PI * (1 + 1 / 4 * (sumDim + 1))), 2)) +
                temp_0 + (1 + 1 / 4 * (dim.Length + 1)) + temp_1);

            return result;
        }


        private float F16(float[] dim)
        {
            float result = 0;
            if (dim.Length == 2)
            {
                result = (float)(4 * Math.Pow(dim[0], 2) - 2.1f * Math.Pow(dim[0] + dim[1], 4) + 1f / 3f * Math.Pow(dim[0], 6) + dim[0] * dim[1]
                    - 4 * Math.Pow(dim[1], 2) + 4 * Math.Pow(dim[1], 4));
            }
            return result;
        }

        
        public float F17(float[] dimPos)
        {
        /*
        Random rnd = new Random();
        var a = rnd.Next(0, 1);
        if (a == 0)
        {
            FMM[16][0] = -5;
            FMM[16][1] = 10;
        }
        else
        {
            FMM[16][0] = 0;
            FMM[16][1] = 15;
        }
        */
        
        double result = 0;

            if (dimPos.Length == 2)
            {

                result = Math.Pow(dimPos[1] - 5.1f / 4 * Math.Pow(Math.PI, 4) * Math.Pow(dimPos[0], 2) + 5 / Math.PI * dimPos[0] - 6, 2)
                + 10 * (1 - 1 / 8 * Math.PI) * Math.Cos(dimPos[0]) + 10;
            }

            return (float)(result);
        }


        private float F18(float[] dim)
        {
            float result = 0;

            if (dim.Length == 2)
            {

                result = (float)((1 + Math.Pow(dim[0] + dim[1] + 1, 2) * (10 - 14 * dim[0] + 3 * Math.Pow(dim[0], 2) - 14 * dim[1]
                + 6 * dim[0] * dim[1] + 3 * Math.Pow(dim[1], 2))) *
                (30 + Math.Pow(2 * dim[0] - 3 * dim[1], 2) * (18 - 32 * dim[0] + 12 * Math.Pow(dim[1], 2) + 48 * dim[1] - 36
                * dim[0] * dim[1] + 27 * Math.Pow(dim[1], 2))));
            }

            return result;
        }

        /*
        public float s18(float[] dimPos)
        {
            double result = 0;

            double temp_1 = 0;
            double temp_2 = 0;

            double[] c = { 0.806f, 0.517f, 0.1f, 0.908f, 0.965f, 0.669f, 0.524f, 0.902f, 0.531f, 0.876f, 0.462f, 0.491f, 0.463f, 0.714f, 0.352f, 0.869f, 0.813f, 0.811f,
            0.828f, 0.964f, 0.789f, 0.360f, 0.369f, 0.992f, 0.332f, 0.817f, 0.632f, 0.883f, 0.608f, 0.326f };

            double[,] a = new double[,]{
                { 9.681f, 0.667f, 4.783f, 9.095f, 3.517f, 9.325f, 6.544f, 0.211f, 5.122f, 2.020f},
                { 9.400f, 2.041f, 3.788f, 7.931f, 2.882f, 2.672f, 3.568f, 1.284f, 7.033f, 7.374f},
                { 8.025f, 9.152f, 5.114f, 7.621f, 4.564f, 4.711f, 2.996f, 6.126f, 0.734f, 4.982f},
                { 2.196f, 0.415f, 5.649f, 6.979f, 9.510f, 9.166f, 6.304f, 6.054f, 9.377f, 1.426f},
                { 8.074f, 8.777f, 3.467f, 1.863f, 6.708f, 6.349f, 4.534f, 0.276f, 7.633f, 1.567f},
                { 7.650f, 5.658f, 0.720f, 2.764f, 3.278f, 5.283f, 7.474f, 6.274f, 1.409f, 8.208f},
                { 1.256f, 3.605f, 8.623f, 6.905f, 4.584f, 8.133f, 6.071f, 6.888f, 4.187f, 5.448f},
                { 8.314f, 2.261f, 4.224f, 1.781f, 4.124f, 0.932f, 8.129f, 8.658f, 1.208f, 5.762f},
                { 0.226f, 8.858f, 1.420f, 0.945f, 1.622f, 4.698f, 6.228f, 9.096f, 0.972f, 7.637f},
                { 7.305f, 2.228f, 1.242f, 5.928f, 9.133f, 1.826f, 4.060f, 5.204f, 8.713f, 8.247f},
                { 0.652f, 7.027f, 0.508f, 4.876f, 8.807f, 4.632f, 5.808f, 6.937f, 3.291f, 7.016f},
                { 2.699f, 3.516f, 5.874f, 4.119f, 4.461f, 7.496f, 8.817f, 0.690f, 6.593f, 9.789f},
                { 8.327f, 3.897f, 2.017f, 9.570f, 9.825f, 1.150f, 1.395f, 3.885f, 6.354f, 0.109f},
                { 2.132f, 7.006f, 7.136f, 2.641f, 1.882f, 5.943f, 7.273f, 7.691f, 2.880f, 0.564f},
                { 4.707f, 5.579f, 4.080f, 0.581f, 9.698f, 8.542f, 8.077f, 8.515f, 9.231f, 4.670f},
                { 8.304f, 7.559f, 8.567f, 0.322f, 7.128f, 8.392f, 1.472f, 8.524f, 2.277f, 7.826f},
                { 8.632f, 4.409f, 4.832f, 5.768f, 7.050f, 6.715f, 1.711f, 4.323f, 4.405f, 4.591f},
                { 4.887f, 9.112f, 0.170f, 8.967f, 9.693f, 9.867f, 7.508f, 7.770f, 8.382f, 6.740f},
                { 2.440f, 6.686f, 4.299f, 1.007f, 7.008f, 1.427f, 9.398f, 8.480f, 9.950f, 1.675f},
                { 6.306f, 8.583f, 6.084f, 1.138f, 4.350f, 3.134f, 7.853f, 6.061f, 7.457f, 2.258f},
                { 0.652f, 2.343f, 1.370f, 0.821f, 1.310f, 1.063f, 0.689f, 8.819f, 8.833f, 9.070f},
                { 5.558f, 1.272f, 5.756f, 9.857f, 2.279f, 2.764f, 1.284f, 1.677f, 1.244f, 1.234f},
                { 3.352f, 7.549f, 9.817f, 9.437f, 8.687f, 4.167f, 2.570f, 6.540f, 0.228f, 0.027f},
                { 8.798f, 0.880f, 2.370f, 0.168f, 1.701f, 3.680f, 1.231f, 2.390f, 2.499f, 0.064f},
                { 1.460f, 8.057f, 1.336f, 7.217f, 7.914f, 3.615f, 9.981f, 9.198f, 5.292f, 1.224f},
                { 0.432f, 8.645f, 8.774f, 0.249f, 8.081f, 7.461f, 4.416f, 0.652f, 4.002f, 4.644f},
                { 0.679f, 2.800f, 5.523f, 3.049f, 2.968f, 7.225f, 6.730f, 4.199f, 9.614f, 9.229f},
                { 4.263f, 1.074f, 7.286f, 5.599f, 8.291f, 5.200f, 9.214f, 8.272f, 4.398f, 4.506f},
                { 9.496f, 4.830f, 3.150f, 8.270f, 5.079f, 1.231f, 5.731f, 9.494f, 1.883f, 9.732f},
                { 4.138f, 2.562f, 2.532f, 9.661f, 5.611f, 5.500f, 6.886f, 2.341f, 9.699f, 6.500f}
            };



            for (var j = 1; j <= 30; j++)
            {
                temp_2 = 0;
                for (var i = 1; i <= dimPos.Length; i++)
                {
                    temp_2 += Math.Pow((dimPos[i - 1] - a[j - 1, i - 1]), 2);
                }

                temp_1 += 1f / (c[j - 1] + temp_2);
            }

            result = -1 * temp_1;

            return (float)(result);
        }
        */


        private float Pareto(float[] dim)
        {
            float F = 0.5f;
            float result = 0;

            float f = dim[0];
            float g = 10f + dim[1];

            float g_s = 11f;
            float g_s_s = 12f;

            float alpha = (float)(0.25 + 3.75 * (g - g_s_s) / (g_s - g_s_s));

            float h = (float)(Math.Pow((f / g), alpha) - (f / g) * Math.Sin(Math.PI * F * f * g));

            result += h;


            return result;
        }

    }
}
