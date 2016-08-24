using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Serialization;
using DotSpatial.Data;



namespace MES_Wind
{
    public partial class frmMain : Form
    {
       
        [Export("Shell", typeof(ContainerControl))]
        private static ContainerControl Shell;
        #region "Control variables"
         double distThreshold = 500;
        #endregion

        public frmMain()
        {

            InitializeComponent();
            if (DesignMode) return;
            Shell = this;
            appManager1.LoadExtensions();
        }
        #region
        /// <summary>
        /// This function is used to check if the segment of powerline is broken. 
        /// Based on the given line segment's start and endpoint, it divides the line on
        /// suitable subsegments defined by threshold length - dThreshold
        /// </summary>
        /// <param name="startX">Line segement's start X point</param>
        /// <param name="startY">Line segement's start Y point</param>
        /// <param name="endX">Line segement's end X point</param>
        /// <param name="endY">Line segement's end Y point</param>
        /// <param name="dThreshold">Line segment length threshold</param>
        /// <param name="Uwind_raster">Raster Layer for progmostic wind X coord</param>
        /// <param name="Vwind_raster">Raster Layer for progmostic wind Y coord</param>
        /// <returns>List of booleans with coordinates if any of them are true, line is broken</returns>
        /// <remarks></remarks>
#endregion
        public List<CheckPoint> CalcBrkPoint(double startX, double startY, double endX, double endY, double dThreshold, IMapRasterLayer Uwind_raster, IMapRasterLayer Vwind_raster, IMapRasterLayer clim_layer, double h)
        {
            List<CheckPoint> lineCheckPoint = new List<CheckPoint>();
            double uwind = 0;
            double vwind = 0;
            double umod = 0;
            double sinwind = 0;
            double climwind = 0;
            double distance = Math.Sqrt((endX - startX) * (endX - startX) + (endY - startY) * (endY - startY));
            double distpropD = distance / dThreshold;
            int distpropI = Convert.ToInt32(distpropD);
            double curX = startX;
            double curY = startY;
            CheckPoint chkpnt = new CheckPoint();
            if (distpropI > 1)
            {
                double constXdiff = (endX - startX) / distpropI;
                double constYdiff = (endY - startY) / distpropI;
                for (int j = 1; j < distpropI + 1; j++)
                {
                    if (j == 1)
                    {
                        curX = startX + constXdiff / 2;
                        curY = startY + constXdiff / 2; 
                    }
                    else
                    {
                        curX = curX + constXdiff;
                        curY = curY + constYdiff;
                    }
                    Coordinate coords = new Coordinate(curX,curY);
                    RcIndex rowColumnU = Uwind_raster.DataSet.Bounds.ProjToCell(coords);
                    uwind = Uwind_raster.DataSet.Value[rowColumnU.Row, rowColumnU.Column];
                    RcIndex rowColumnV = Vwind_raster.DataSet.Bounds.ProjToCell(coords);
                    vwind = Vwind_raster.DataSet.Value[rowColumnV.Row, rowColumnV.Column];
                    RcIndex rowColumnC = Vwind_raster.DataSet.Bounds.ProjToCell(coords);
                    climwind = Vwind_raster.DataSet.Value[rowColumnC.Row, rowColumnC.Column];
                    umod = Math.Sqrt(uwind*uwind + vwind*vwind);
                    sinwind = Math.Sin(Math.Atan2(uwind,vwind));
                    double C_height = 1.0;
                    if (umod < 20)
                    { //wind is too low 
                        chkpnt.Ifbroken = false;
                    }
                    else
                    {    // calculate prognostic and threshold windstress
                        double p1 = -0.00078501;
                        double p2 = 0.13431;
                        double p3 = -2.11112;
                        double p4 = 19.548;
                        double qpr = p1 * umod * umod * umod + p2 * umod * umod + p3 * umod + p4;
                        double qcl = p1 * climwind * climwind * climwind + p2 * climwind * climwind + p3 * climwind + p4;
                        double Ppr = qpr * C_height * sinwind * sinwind;
                        double Pcl = qcl * C_height * 1.0;
                        if (Ppr >= Pcl)
                        {
                            chkpnt.Ifbroken = true;
                        }
                        else
                        {
                            chkpnt.Ifbroken = false;
                        }
                    }
                    chkpnt.X = curX;
                    chkpnt.Y = curY;
                   
                    lineCheckPoint.Add(chkpnt);
                }
            }
            return lineCheckPoint;
        }


        private void bntLoadWindX_Click(object sender, EventArgs e)
        {
            map1.AddLayer();
            map1.ZoomToMaxExtent();

        }

        private void btnLoadWindY_Click(object sender, EventArgs e)
        {
            map1.AddLayer();
            map1.ZoomToMaxExtent();
        }

        private void btnViewAttributeTable_Click(object sender, EventArgs e)
        {
            //Declare a datatable
            DataTable dt = null;

            if (map1.GetLineLayers().Count() > 0)
            {
                MapLineLayer pwlLayer = default(MapLineLayer);

                pwlLayer = (MapLineLayer)map1.GetLineLayers()[0];

                if (pwlLayer == null)
                {
                    MessageBox.Show("The layer is not a line layer.");
                }
                else
                {
                    //Get the shapefile's attribute table to our datatable dt
                    dt = pwlLayer.DataSet.DataTable;

                    //Set the datagridview datasource from datatable dt
                    dgvAttributeTable.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map.");
            }

        

    }

        private void btnCalcStress_Click(object sender, EventArgs e)
        {
            try
            {
                //extract prognostic u layer
                IMapRasterLayer u_rasterLayer = default(IMapRasterLayer);
                IMapRasterLayer v_rasterLayer = default(IMapRasterLayer);
                IMapRasterLayer clim5_rasterLayer = default(IMapRasterLayer);
                IMapRasterLayer clim10_rasterLayer = default(IMapRasterLayer);
                if (map1.GetRasterLayers().Count() == 1)
                {
                    MessageBox.Show("Please add a raster layer");
                    return;
                }

                //use the first raster layer in the map
                u_rasterLayer = map1.GetRasterLayers()[0];
                v_rasterLayer = map1.GetRasterLayers()[1];
                clim5_rasterLayer = map1.GetRasterLayers()[3];
                clim10_rasterLayer = map1.GetRasterLayers()[4];

                //get the powerline  line layer
                IMapLineLayer pwlLayer = default(IMapLineLayer);
                if (map1.GetLineLayers().Count() == 0)
                {
                    MessageBox.Show("Please add powerline shapefile");
                    return;
                }
                pwlLayer = map1.GetLineLayers()[0];
                //copy line layer FeatureSet
                IFeatureSet pwlineSet = pwlLayer.DataSet;
                // new FeatureSet for resulting broken powerlines
                IFeatureSet brklineSet = new FeatureSet(FeatureType.Line);
                DataTable dt = pwlineSet.DataTable;
                List<CheckPoint> fullCheckList = new List<CheckPoint>();
                foreach (IFeature feature in pwlineSet.Features)
                {
                    List<CheckPoint> lineCheckList = new List<CheckPoint>();
                    LineString linestr = feature.BasicGeometry as LineString;
                    if (linestr != null)
                    { // case if powerline consists of one line
                        // get coordinates list
                        IList<Coordinate> points = linestr.Coordinates;
                        IFeature brklineFeature = brklineSet.AddFeature(linestr);
                        //get associated attributes
                        DataRow featureData = feature.DataRow;
                        int id = int.Parse(featureData["PW_ID"].ToString());
                        int year = int.Parse(featureData["Year"].ToString());
                        double height = double.Parse(featureData["height"].ToString());
                        int power = int.Parse(featureData["Year"].ToString());
                        // cycle throw all points in line
                        for (int i=1; i< points.Count; i++)
                        {
                            List<CheckPoint> segmentCheckList = new List<CheckPoint>();
                            double x1 = points[i - 1].X;
                            double y1 = points[i - 1].Y;
                            double x2 = points[i].X;
                            double y2 = points[i].Y;
                            if (power > 5 && power <330)
                            {
                                segmentCheckList = CalcBrkPoint(x1, y1, x2, y2, distThreshold, u_rasterLayer, v_rasterLayer, clim10_rasterLayer, height);
                            }
                            else
                            {
                                segmentCheckList = CalcBrkPoint(x1, y1, x2, y2, distThreshold, u_rasterLayer, v_rasterLayer, clim5_rasterLayer, height);
                            }
                            lineCheckList.AddRange(segmentCheckList);
                        }

                        fullCheckList.AddRange(lineCheckList);
                        brklineFeature.CopyAttributes(feature);
                    }
                    else
                    {//case if powerline is multiline
                        MultiLineString multiline = feature.BasicGeometry as MultiLineString;
                        if ( multiline != null){ 
                            foreach (IGeometry line in multiline.Geometries)
                            {
                                IList<Coordinate> points = line.Coordinates;
                            }
                            IFeature brklineFeature = brklineSet.AddFeature(multiline);
                            MessageBox.Show("Works");
                        }


                    }
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }

        }
    }
    public class PathPoint
    {
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        public double Distance;
        public double Uwind;
        public double Vwind;
        public int Year;
    }
    public class CheckPoint
    {
        public double X;
        public double Y;
        public bool Ifbroken;
    }

}
