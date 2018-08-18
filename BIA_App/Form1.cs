using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Threading;

namespace BIA_App
{
    public partial class Form1 : Form
    {
        private BenchmarkFSet _benchmark;
        private Algorithms _algorithms;
        private int LENGTH = 200;
        private ILScene _scene;
        private bool _integer;
        private int _numberOfGenerations;

        private void Initialize(object sender, System.EventArgs e)
        {
            PopulateComboFunctions();
            PopulateAlgorithms();

            genMin.Minimum = Decimal.MinValue;
            genMax.Maximum = Decimal.MaxValue;
            comboFunctions_SelectedIndexChanged(sender, e);
            _integer = false;
            _numberOfGenerations = 5;
            prgBar.Maximum = _numberOfGenerations;
            numberOfGenerationsUpDown.Value = _numberOfGenerations;


        }

        public Form1()
        {
            InitializeComponent();
            _benchmark = new BenchmarkFSet();
            _algorithms = new Algorithms();
            Initialize(this, null);
        }

        private void PopulateAlgorithms()
        {
            BindingSource bindingSource = new BindingSource() { DataSource = _algorithms.All };
            comboAlgorithms.DataSource = bindingSource.DataSource;
            comboAlgorithms.DisplayMember = "Name";
            comboAlgorithms.ValueMember = "Id";
        }

        private void PopulateComboFunctions()
        {
            BindingSource bindingSource = new BindingSource() { DataSource = _benchmark.Functions };
            comboFunctions.DataSource = bindingSource.DataSource;
            comboFunctions.DisplayMember = "Name";
            comboFunctions.ValueMember = "Id";
        }

        // Initial plot setup, modify this as needed
        private void ilPanel1_Load(object sender, EventArgs e)
        {

            // create some test data, using our private computation module as inner class
            //ILArray<float> Pos = Computation.CreateData(4, 300);

            // setup the plot (modify as needed)
            /*ilPanel1.Scene.Add(new ILPlotCube(twoDMode: false) {
                new ILLinePlot(Pos, tag: "mylineplot") {
                    Line = {
                        Width = 2,
                        Color = Color.Red,
                        Antialiasing = true,
                        DashStyle = DashStyle.Dotted
                    }
                }
            });*/
            // register event handler for allowing updates on right mouse click:
            /*ilPanel1.Scene.First<ILLinePlot>().MouseClick += (_s, _a) =>
            {
                if (_a.Button == MouseButtons.Right)
                    Update(ILMath.rand(3, 30));
            };*/
        }


        /// <summary>
        /// Example update function used for dynamic updates to the plot
        /// </summary>
        /// <param name="A">New data, matching the requirements of your plot</param>
        public void Update(ILInArray<double> A)
        {
            using (ILScope.Enter(A))
            {

                // fetch a reference to the plot
                var plot = ilPanel1.Scene.First<ILLinePlot>(tag: "mylineplot");
                if (plot != null)
                {
                    // make sure, to convert elements to float
                    // !!!
                    //plot.Update(ILMath.tosingle(A));
                    //
                    // ... do more manipulations here ...

                    // finished with updates? -> Call Configure() on the changes 
                    plot.Configure();

                    // cause immediate redraw of the scene
                    ilPanel1.Refresh();
                }

            }
        }

        //Calls corresponding function by given index
        private float CallFunction(int id, float[] dimension)
        {
            return _benchmark.GetById(id).EvaluateFitness(id, dimension);
        }

        private void Plot2D(int selectedFuncId)
        {
            var range = 7000;
            float[][] points = _benchmark.GeneratePoints(range);
            ILArray<float> A = ILMath.zeros<float>(3, points.GetLength(0));

            for (int i = 0; i < points.GetLength(0); i++)
            {
                A[0, i] = points[i][0];
                A[1, i] = CallFunction(selectedFuncId, points[i]);
            }


            _scene = new ILScene();
            _scene.Add(new ILPlotCube(twoDMode: true) {
                    new ILPoints
                    {
                        Positions = ILMath.tosingle(A)
                    }

                    });

            ilPanel1.Scene = _scene;
            ilPanel1.Refresh();

            return;
        }

        /// <summary>
        /// Example computing module as private class 
        /// </summary>
        /// 
        /*
        private class Computation : ILMath
        {
            /// <summary>
            /// Create some test data for plotting
            /// </summary>
            /// <param name="ang">end angle for a spiral</param>
            /// <param name="resolution">number of points to plot</param>
            /// <returns>3d data matrix for plotting, points in columns</returns>
            public static ILRetArray<float> CreateData(int ang, int resolution)
            {
                using (ILScope.Enter())
                {
                    ILArray<float> A = linspace<float>(0, ang * pi, resolution);
                    ILArray<float> Pos = zeros<float>(3, A.S[1]);
                    Pos["0;:"] = sin(A);
                    Pos["1;:"] = cos(A);
                    Pos["2;:"] = A;
                    return Pos;
                }
            }

        }*/


        /// <summary>
        /// Plot only function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlot_Click_1(object sender, EventArgs e)
        {
            var selectedFuncId = (int)comboFunctions.SelectedValue;
            if (selectedFuncId == 22)
            {
                Plot2D(selectedFuncId);
                return;
            }

            var dim = _benchmark.GetById((int)comboFunctions.SelectedValue).Dimension;

            _scene = new ILScene() {
              new ILPlotCube(twoDMode: false) {
                new ILSurface((x, y) => CallFunction(selectedFuncId, new float[] {x, y}),
                            xmin: dim[0], xmax: dim[1], xlen: LENGTH,
                            ymin: dim[0], ymax: dim[1], ylen: LENGTH,
                            colormap: Colormaps.Cool) {new ILColorbar()}
              }
            };
            //scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(.8f, .5f, 0), .3f);
            ilPanel1.Scene = _scene;
            ilPanel1.Refresh();
        }


        /// <summary>
        /// Save scene as *.png to desired location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportPng_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var selected = (Function)comboFunctions.SelectedItem;

                    var path = dialog.SelectedPath + "\\" + selected.Name + ".png";

                    using (var fileStream = File.Create(path))
                    {
                        var gdi = new ILGDIDriver(ilPanel1.Width, ilPanel1.Height,
                        scene: ilPanel1.GetCurrentScene(),
                        BackColor: ilPanel1.BackColor);
                        gdi.Render();
                        gdi.BackBuffer.Bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);

                    }
                }
            }
        }

        private void btnPopulation_Click(object sender, EventArgs e)
        {
            if (popSize.Value == 0) return;
            var population = new Individuals();

            population.GeneratePopulation((int)popSize.Value, _benchmark.GetById((int)comboFunctions.SelectedValue), _integer, (float)genMin.Value, (float)genMax.Value);
            //population.ComputeFitness();
            PlotGeneration((int)comboFunctions.SelectedValue, population);
        }

        /// <summary>
        /// Plot function with generation of individuals.
        /// </summary>
        /// <param name="selectedFuncId"></param>
        /// <param name="population"></param>
        private void PlotGeneration(int selectedFuncId, Individuals population)
        {
            ILArray<float> A = ILMath.zeros<float>(3, population.Population.Count - 1);
            ILArray<float> B = ILMath.zeros<float>(3, 0);
            var dim = _benchmark.GetById(selectedFuncId).Dimension;

            var best = population.GetBest();

            int c = 0;
            foreach (var i in population.Population)
            {
                if (i == best) continue;
                A[0, c] = i.Dimension[0];
                A[1, c] = i.Dimension[1];
                A[2, c] = i.Z;

                c += 1;
            }

            // Best individual
            B[0, 0] = best.Dimension[0];
            B[1, 0] = best.Dimension[1];
            B[2, 0] = best.Z;


            _scene = new ILScene() {
              new ILPlotCube(twoDMode: false) {
                new ILSurface((x, y) => CallFunction(selectedFuncId, new float[] {x, y}),
                            xmin: (float)genMin.Value, xmax: (float)genMax.Value, xlen: LENGTH,
                            ymin: (float)genMin.Value, ymax: (float)genMax.Value, ylen: LENGTH,
                            colormap: Colormaps.Hsv) {new ILColorbar()},
                  new ILPoints{ Positions = ILMath.tosingle(B), Color = Color.Blue},
                  new ILPoints{ Positions = ILMath.tosingle(A), Color = Color.DarkSlateGray}
            }
            };

            ilPanel1.Scene = _scene;
            ilPanel1.Refresh();

            return;
        }

        private void comboFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var func = _benchmark.GetById((int)comboFunctions.SelectedValue);
            genMin.Value = (decimal)func.Dimension[0];
            genMax.Value = (decimal)func.Dimension[1];
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _integer = checkBox1.Checked;
        }

        private void numberOfGenerationsUpDown_ValueChanged(object sender, EventArgs e)
        {
            _numberOfGenerations = (int)numberOfGenerationsUpDown.Value;
            prgBar.Maximum = _numberOfGenerations;
        }

        private void comboAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            if (popSize.Value == 0) return;
            var population = new Individuals();

            population.GeneratePopulation((int)popSize.Value, _benchmark.GetById((int)comboFunctions.SelectedValue), _integer, (float)genMin.Value, (float)genMax.Value);
            population.ComputeFitness();

            for (int i = 0; i < (int)numberOfGenerationsUpDown.Value; i++)
            {
                population = _algorithms.All.FirstOrDefault(a => a.Id == (int)comboAlgorithms.SelectedValue).Run(population, _benchmark.GetById((int)comboFunctions.SelectedValue), _integer, (float)genMin.Value, (float)genMax.Value);
                population.ComputeFitness();
                PlotGeneration((int)comboFunctions.SelectedValue, population);

                await UpdateProgress(i);
            }
        }

        private Task UpdateProgress(int value)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (prgBar.InvokeRequired)
                    {
                        prgBar.Invoke(new MethodInvoker(delegate { prgBar.Value = value + 1; }));
                        Thread.Sleep(100);
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
        }

        private void grpScene_Enter(object sender, EventArgs e)
        {

        }
    }
}
