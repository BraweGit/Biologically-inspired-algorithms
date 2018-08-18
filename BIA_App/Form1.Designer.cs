using System.Windows.Forms;

namespace BIA_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPlot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPopulation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunAlgorithm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnExportPng = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboAlgorithms = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfGenerationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.genMax = new System.Windows.Forms.NumericUpDown();
            this.genMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.popSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFunctions = new System.Windows.Forms.ComboBox();
            this.grpScene = new System.Windows.Forms.GroupBox();
            this.ilPanel1 = new ILNumerics.Drawing.ILPanel();
            this.progressGrp = new System.Windows.Forms.GroupBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.toolStrip1.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGenerationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpScene.SuspendLayout();
            this.progressGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlot,
            this.toolStripSeparator1,
            this.btnPopulation,
            this.toolStripSeparator2,
            this.btnRunAlgorithm,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(990, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPlot
            // 
            this.btnPlot.Image = global::BIA_App.Properties.Resources.plotIcon;
            this.btnPlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(98, 22);
            this.btnPlot.Text = "Plot Function";
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPopulation
            // 
            this.btnPopulation.Image = global::BIA_App.Properties.Resources.populationIcon;
            this.btnPopulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPopulation.Name = "btnPopulation";
            this.btnPopulation.Size = new System.Drawing.Size(109, 22);
            this.btnPopulation.Text = "Plot Generation";
            this.btnPopulation.Click += new System.EventHandler(this.btnPopulation_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRunAlgorithm
            // 
            this.btnRunAlgorithm.Image = global::BIA_App.Properties.Resources.go_arrow_next_up_green_forward_256;
            this.btnRunAlgorithm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunAlgorithm.Name = "btnRunAlgorithm";
            this.btnRunAlgorithm.Size = new System.Drawing.Size(105, 22);
            this.btnRunAlgorithm.Text = "Run Algorithm";
            this.btnRunAlgorithm.ToolTipText = "Run selected algorithm.";
            this.btnRunAlgorithm.Click += new System.EventHandler(this.btnRunAlgorithm_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportPng});
            this.toolStripDropDownButton1.Image = global::BIA_App.Properties.Resources.exportIcon;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton1.Text = "Export";
            this.toolStripDropDownButton1.ToolTipText = "Export";
            // 
            // btnExportPng
            // 
            this.btnExportPng.Name = "btnExportPng";
            this.btnExportPng.Size = new System.Drawing.Size(98, 22);
            this.btnExportPng.Text = "PNG";
            this.btnExportPng.Click += new System.EventHandler(this.btnExportPng_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.groupBox3);
            this.grpSettings.Controls.Add(this.groupBox2);
            this.grpSettings.Controls.Add(this.groupBox1);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSettings.Location = new System.Drawing.Point(0, 25);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(990, 179);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboAlgorithms);
            this.groupBox3.Location = new System.Drawing.Point(437, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 154);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algorithms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Algorithm";
            // 
            // comboAlgorithms
            // 
            this.comboAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgorithms.FormattingEnabled = true;
            this.comboAlgorithms.Location = new System.Drawing.Point(7, 37);
            this.comboAlgorithms.Name = "comboAlgorithms";
            this.comboAlgorithms.Size = new System.Drawing.Size(187, 21);
            this.comboAlgorithms.TabIndex = 0;
            this.comboAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithms_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numberOfGenerationsUpDown);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.genMax);
            this.groupBox2.Controls.Add(this.genMin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.popSize);
            this.groupBox2.Location = new System.Drawing.Point(155, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 154);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of generations";
            // 
            // numberOfGenerationsUpDown
            // 
            this.numberOfGenerationsUpDown.Location = new System.Drawing.Point(144, 37);
            this.numberOfGenerationsUpDown.Name = "numberOfGenerationsUpDown";
            this.numberOfGenerationsUpDown.Size = new System.Drawing.Size(120, 20);
            this.numberOfGenerationsUpDown.TabIndex = 7;
            this.numberOfGenerationsUpDown.ValueChanged += new System.EventHandler(this.numberOfGenerationsUpDown_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(144, 116);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Integer only";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Maximum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum";
            // 
            // genMax
            // 
            this.genMax.Location = new System.Drawing.Point(6, 115);
            this.genMax.Name = "genMax";
            this.genMax.Size = new System.Drawing.Size(120, 20);
            this.genMax.TabIndex = 3;
            // 
            // genMin
            // 
            this.genMin.Location = new System.Drawing.Point(6, 76);
            this.genMin.Name = "genMin";
            this.genMin.Size = new System.Drawing.Size(120, 20);
            this.genMin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size of generation";
            // 
            // popSize
            // 
            this.popSize.Location = new System.Drawing.Point(6, 37);
            this.popSize.Name = "popSize";
            this.popSize.Size = new System.Drawing.Size(120, 20);
            this.popSize.TabIndex = 0;
            this.popSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboFunctions);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yao Set 1 Functions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Function";
            // 
            // comboFunctions
            // 
            this.comboFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunctions.FormattingEnabled = true;
            this.comboFunctions.Location = new System.Drawing.Point(6, 36);
            this.comboFunctions.Name = "comboFunctions";
            this.comboFunctions.Size = new System.Drawing.Size(121, 21);
            this.comboFunctions.TabIndex = 0;
            this.comboFunctions.SelectedIndexChanged += new System.EventHandler(this.comboFunctions_SelectedIndexChanged);
            // 
            // grpScene
            // 
            this.grpScene.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpScene.Controls.Add(this.ilPanel1);
            this.grpScene.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpScene.Location = new System.Drawing.Point(0, 266);
            this.grpScene.Name = "grpScene";
            this.grpScene.Size = new System.Drawing.Size(990, 436);
            this.grpScene.TabIndex = 2;
            this.grpScene.TabStop = false;
            this.grpScene.Text = "Scene";
            this.grpScene.Enter += new System.EventHandler(this.grpScene_Enter);
            // 
            // ilPanel1
            // 
            this.ilPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilPanel1.Driver = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilPanel1.Editor = null;
            this.ilPanel1.Location = new System.Drawing.Point(3, 16);
            this.ilPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel1.Name = "ilPanel1";
            this.ilPanel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel1.Rectangle")));
            this.ilPanel1.ShowUIControls = false;
            this.ilPanel1.Size = new System.Drawing.Size(984, 417);
            this.ilPanel1.TabIndex = 0;
            // 
            // progressGrp
            // 
            this.progressGrp.Controls.Add(this.prgBar);
            this.progressGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressGrp.Location = new System.Drawing.Point(0, 204);
            this.progressGrp.Name = "progressGrp";
            this.progressGrp.Size = new System.Drawing.Size(990, 56);
            this.progressGrp.TabIndex = 3;
            this.progressGrp.TabStop = false;
            this.progressGrp.Text = "Progress";
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(12, 19);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(966, 30);
            this.prgBar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 702);
            this.Controls.Add(this.progressGrp);
            this.Controls.Add(this.grpScene);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "BIA-App";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfGenerationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpScene.ResumeLayout(false);
            this.progressGrp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPlot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnExportPng;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboFunctions;
        private System.Windows.Forms.GroupBox grpScene;
        private ILNumerics.Drawing.ILPanel ilPanel1;
        private ToolStripButton btnPopulation;
        private ToolStripSeparator toolStripSeparator2;
        private Label label1;
        private NumericUpDown popSize;
        private GroupBox groupBox2;
        private Label label2;
        private Label label4;
        private Label label3;
        private NumericUpDown genMax;
        private NumericUpDown genMin;
        private CheckBox checkBox1;
        private Label label5;
        private NumericUpDown numberOfGenerationsUpDown;
        private GroupBox groupBox3;
        private Label label6;
        private ComboBox comboAlgorithms;
        private ToolStripButton btnRunAlgorithm;
        private ToolStripSeparator toolStripSeparator3;
        private GroupBox progressGrp;
        private ProgressBar prgBar;
    }
}

