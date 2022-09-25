using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using WSCAD.Models.Shapes;
using GrapeCity.Documents.Svg;
using JsonConverter = WSCAD.helpers.converter.JsonConverter;
using System.IO;
using System.Windows.Controls.Primitives;
using WSCAD.helpers;
using WSCAD.Business.Factory;
using WSCAD.Models.Entities;
using WSCAD.Models.CommonModels;

namespace WSCAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool dragStarted = false;

        private void Slider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            zoomlabel.Content = Convert.ToInt32(((Slider)sender).Value)+"%";
            //dear Milosava, here is for changing slider zoom 
            //it's for further developement
            dragStarted = false;
        }

        private void Slider_DragStarted(object sender, DragStartedEventArgs e)
        {
            dragStarted = true;
        }

        private void Slider_ValueChanged(
            object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {

                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".json";
            fileDialog.Filter = "JSON documents (.json)|*.json|XML documents (.xml)|*.xml|"
                + "All data documents|*.json;*.xml"; 


            if (fileDialog.ShowDialog().Value)
            {
                label.Content = Path.GetFileName(fileDialog.FileName);
                StreamReader sr = new StreamReader(fileDialog.FileName);

                var converter = new JsonConverter();
                var shapes = converter.ConvertToShape(sr.ReadToEnd());

                var svgDoc = new GcSvgDocument();

                svgDoc.RootSvg.Width = new SvgLength(250, SvgLengthUnits.Pixels);
                svgDoc.RootSvg.Height = new SvgLength(150, SvgLengthUnits.Pixels);


                var size = new ViewSize()
                {
                    MaxX = 0f,
                    MaxY = 0f,
                    MinX = 0f,
                    MinY = 0f,
                };


                foreach (var shape in shapes)
                {
                    var entity = HandleFactory(shape, svgDoc);
                    size = SetViewBoxSize.SetSize(entity, size);
                }


                SvgViewBox view = new SvgViewBox();
                view.MinX = size.MinX;
                view.MinY = size.MinY;
                view.Width = size.MaxX - size.MinX;
                view.Height = size.MaxY - size.MinY;

                svgDoc.RootSvg.ViewBox = view;

                svgDoc.Save(@".\Output\test\test.svg");

                Viewer.Source = new Uri(@"\output\test\test.svg",UriKind.Relative);

                sr.Close();
            }
        }

        public IBaseShapeEntity HandleFactory(BaseShape shape,GcSvgDocument doc)
        {
            Factory creator = null;
            if (shape.Type == "line")
            {
                creator = new LineFactory();
            }
            else if (shape.Type == "triangle")
            {
                creator = new TriangleFactory();                
            }
            else if (shape.Type == "circle")
            {
                creator = new CircleFactory();
            }
            creator.Draw(shape, doc);
            var test = creator.MakeShape(shape);
            return test;
        }
    }
}
