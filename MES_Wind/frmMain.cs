﻿using System;
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
        public frmMain()
        {
            InitializeComponent();
            if (DesignMode) return;
            Shell = this;
            appManager1.LoadExtensions();
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
                if (map1.GetRasterLayers().Count() == 1)
                {
                    MessageBox.Show("Please add a raster layer");
                    return;
                }

                //use the first raster layer in the map
                u_rasterLayer = map1.GetRasterLayers()[0];
                v_rasterLayer = map1.GetRasterLayers()[1];

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
                foreach (IFeature feature in pwlineSet.Features)
                {

                    LineString linestr = feature.BasicGeometry as LineString;
                    if (linestr != null)
                    { // case if powerline consists of one line
                        // get coordinates list
                        IList<Coordinate> points = linestr.Coordinates;
                        IFeature brklineFeature = brklineSet.AddFeature(linestr);
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
        public double X;
        public double Y;
        public double Distance;
        public double RstValue;
    }

}
