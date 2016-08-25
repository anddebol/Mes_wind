namespace MES_Wind
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.appManager1 = new DotSpatial.Controls.AppManager();
            this.sdmMapLegend = new DotSpatial.Controls.SpatialDockManager();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.map1 = new DotSpatial.Controls.Map();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sdmDataOperations = new DotSpatial.Controls.SpatialDockManager();
            this.gbOperations = new System.Windows.Forms.GroupBox();
            this.btnViewAttributeTable = new System.Windows.Forms.Button();
            this.dgvAttributeTable = new System.Windows.Forms.DataGridView();
            this.bntLoadWindX = new System.Windows.Forms.Button();
            this.btnLoadWindY = new System.Windows.Forms.Button();
            this.btnCalcStress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sdmMapLegend)).BeginInit();
            this.sdmMapLegend.Panel1.SuspendLayout();
            this.sdmMapLegend.Panel2.SuspendLayout();
            this.sdmMapLegend.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sdmDataOperations)).BeginInit();
            this.sdmDataOperations.Panel1.SuspendLayout();
            this.sdmDataOperations.Panel2.SuspendLayout();
            this.sdmDataOperations.SuspendLayout();
            this.gbOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // appManager1
            // 
            this.appManager1.Directories = ((System.Collections.Generic.List<string>)(resources.GetObject("appManager1.Directories")));
            this.appManager1.DockManager = this.sdmMapLegend;
            this.appManager1.HeaderControl = null;
            this.appManager1.Legend = this.legend1;
            this.appManager1.Map = this.map1;
            this.appManager1.ProgressHandler = null;
            this.appManager1.ShowExtensionsDialogMode = DotSpatial.Controls.ShowExtensionsDialogMode.Default;
            // 
            // sdmMapLegend
            // 
            this.sdmMapLegend.Dock = System.Windows.Forms.DockStyle.Top;
            this.sdmMapLegend.Location = new System.Drawing.Point(0, 0);
            this.sdmMapLegend.Name = "sdmMapLegend";
            // 
            // sdmMapLegend.Panel1
            // 
            this.sdmMapLegend.Panel1.Controls.Add(this.legend1);
            // 
            // sdmMapLegend.Panel2
            // 
            this.sdmMapLegend.Panel2.Controls.Add(this.map1);
            this.sdmMapLegend.Size = new System.Drawing.Size(782, 234);
            this.sdmMapLegend.SplitterDistance = 260;
            this.sdmMapLegend.TabControl1 = null;
            this.sdmMapLegend.TabControl2 = null;
            this.sdmMapLegend.TabIndex = 0;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 260, 234);
            this.legend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(0, 0);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(260, 234);
            this.legend1.TabIndex = 0;
            this.legend1.TabStop = false;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = this.legend1;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(518, 234);
            this.map1.TabIndex = 0;
            this.map1.ZoomOutFartherThanMaxExtent = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(114, 360);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sdmDataOperations);
            this.panel1.Controls.Add(this.sdmMapLegend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(114, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 360);
            this.panel1.TabIndex = 1;
            // 
            // sdmDataOperations
            // 
            this.sdmDataOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sdmDataOperations.Location = new System.Drawing.Point(0, 234);
            this.sdmDataOperations.Name = "sdmDataOperations";
            this.sdmDataOperations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sdmDataOperations.Panel1
            // 
            this.sdmDataOperations.Panel1.Controls.Add(this.gbOperations);
            // 
            // sdmDataOperations.Panel2
            // 
            this.sdmDataOperations.Panel2.Controls.Add(this.dgvAttributeTable);
            this.sdmDataOperations.Size = new System.Drawing.Size(782, 126);
            this.sdmDataOperations.SplitterDistance = 55;
            this.sdmDataOperations.TabControl1 = null;
            this.sdmDataOperations.TabControl2 = null;
            this.sdmDataOperations.TabIndex = 1;
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.btnViewAttributeTable);
            this.gbOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperations.Location = new System.Drawing.Point(0, 0);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Size = new System.Drawing.Size(782, 55);
            this.gbOperations.TabIndex = 0;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Operations";
            // 
            // btnViewAttributeTable
            // 
            this.btnViewAttributeTable.Location = new System.Drawing.Point(7, 22);
            this.btnViewAttributeTable.Name = "btnViewAttributeTable";
            this.btnViewAttributeTable.Size = new System.Drawing.Size(188, 23);
            this.btnViewAttributeTable.TabIndex = 0;
            this.btnViewAttributeTable.Text = "View Attribute table";
            this.btnViewAttributeTable.UseVisualStyleBackColor = true;
            this.btnViewAttributeTable.Click += new System.EventHandler(this.btnViewAttributeTable_Click);
            // 
            // dgvAttributeTable
            // 
            this.dgvAttributeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributeTable.Location = new System.Drawing.Point(0, 0);
            this.dgvAttributeTable.Name = "dgvAttributeTable";
            this.dgvAttributeTable.RowTemplate.Height = 24;
            this.dgvAttributeTable.Size = new System.Drawing.Size(782, 67);
            this.dgvAttributeTable.TabIndex = 0;
            // 
            // bntLoadWindX
            // 
            this.bntLoadWindX.Location = new System.Drawing.Point(12, 74);
            this.bntLoadWindX.Name = "bntLoadWindX";
            this.bntLoadWindX.Size = new System.Drawing.Size(96, 46);
            this.bntLoadWindX.TabIndex = 2;
            this.bntLoadWindX.Text = "Load Xwind";
            this.bntLoadWindX.UseVisualStyleBackColor = true;
            this.bntLoadWindX.Click += new System.EventHandler(this.bntLoadWindX_Click);
            // 
            // btnLoadWindY
            // 
            this.btnLoadWindY.Location = new System.Drawing.Point(12, 147);
            this.btnLoadWindY.Name = "btnLoadWindY";
            this.btnLoadWindY.Size = new System.Drawing.Size(96, 46);
            this.btnLoadWindY.TabIndex = 3;
            this.btnLoadWindY.Text = "Load test files";
            this.btnLoadWindY.UseVisualStyleBackColor = true;
            this.btnLoadWindY.Click += new System.EventHandler(this.btnLoadWindY_Click);
            // 
            // btnCalcStress
            // 
            this.btnCalcStress.Location = new System.Drawing.Point(12, 209);
            this.btnCalcStress.Name = "btnCalcStress";
            this.btnCalcStress.Size = new System.Drawing.Size(96, 42);
            this.btnCalcStress.TabIndex = 4;
            this.btnCalcStress.Text = "Calculate Wind Stress";
            this.btnCalcStress.UseVisualStyleBackColor = true;
            this.btnCalcStress.Click += new System.EventHandler(this.btnCalcStress_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 360);
            this.Controls.Add(this.btnCalcStress);
            this.Controls.Add(this.btnLoadWindY);
            this.Controls.Add(this.bntLoadWindX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.sdmMapLegend.Panel1.ResumeLayout(false);
            this.sdmMapLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sdmMapLegend)).EndInit();
            this.sdmMapLegend.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.sdmDataOperations.Panel1.ResumeLayout(false);
            this.sdmDataOperations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sdmDataOperations)).EndInit();
            this.sdmDataOperations.ResumeLayout(false);
            this.gbOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DotSpatial.Controls.AppManager appManager1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bntLoadWindX;
        private DotSpatial.Controls.SpatialDockManager sdmMapLegend;
        private DotSpatial.Controls.Legend legend1;
        private DotSpatial.Controls.Map map1;
        private System.Windows.Forms.Button btnLoadWindY;
        private System.Windows.Forms.Button btnCalcStress;
        private DotSpatial.Controls.SpatialDockManager sdmDataOperations;
        private System.Windows.Forms.GroupBox gbOperations;
        private System.Windows.Forms.DataGridView dgvAttributeTable;
        private System.Windows.Forms.Button btnViewAttributeTable;
    }
}