using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _13.WPF_Canvas.MVVM.View;
using BIMSoftLib;
using BIMSoftLib.MVVM;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;
using System.Windows.Controls;
using System.Drawing;
using Rectangle = System.Windows.Shapes.Rectangle;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Shapes;

namespace _13.WPF_Canvas.MVVM.ViewModel
{
    public class MainViewModel: PropertyChangedBase
    {
        public static Canvas canvas = new Canvas();

        private int _beamWidth = 200;
        public int BeamWidth
        {
            get
            {
                return _beamWidth;
            }
            set
            {
                _beamWidth = value;
                OnPropertyChanged("BeamWidth");
            }
        }

        private int _beamHeight = 300;
        public int BeamHeight
        {
            get 
            {   
                
                return _beamHeight;
            }
            set
            {
                _beamHeight = value;
                OnPropertyChanged("BeamHeight");
            }
        }

        private int _rebarNumberTop = 2;
        public int RebarNumberTop 
        { 
            get => _rebarNumberTop; 
          set
            {
                _rebarNumberTop = value;
                OnPropertyChanged("RebarNumberTop");
            } 
        }

        private int _rebarNumberBot = 2;
        public int RebarNumberBot
        {
            get => _rebarNumberBot;
            set
            {
                _rebarNumberBot = value;
                OnPropertyChanged("RebarNumberBot");
            }
        }

        public void DrawBeamSetion(Canvas viewCanvas)
        {
            viewCanvas.Children.Clear();
            //int v = viewCanvas.Children.Count;
            //if (v > 0)
            //{
            //    for (int i = 0; i < v;)
            //    {
            //        viewCanvas.Children.RemoveAt(i);
            //        i++;
            //    }
            //}

            if (BeamWidth != 0 && BeamHeight != 0)
            {
                //Vẽ tiết diện dầm
                Rectangle rectangle = new Rectangle
                {
                    Width = BeamWidth,
                    Height = BeamHeight,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(rectangle, viewCanvas.ActualWidth / 2 - BeamWidth / 2);
                Canvas.SetTop(rectangle, viewCanvas.ActualHeight / 2 - BeamHeight / 2);
                viewCanvas.Children.Add(rectangle);

                //Vẽ thép đai
                //Path path = new Path();
                
                //Polyline polyline = new Polyline();
                System.Windows.Point point = new System.Windows.Point(0,50);
                System.Windows.Size size = new System.Windows.Size(5, 10);
                SweepDirection sweepDirection = SweepDirection.Clockwise;
                ArcSegment arcSeg = new ArcSegment(point, size, Math.PI / 2, false, sweepDirection, true);
                PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
                myPathSegmentCollection.Add(arcSeg);
                PathFigure pthFigure = new PathFigure();
                pthFigure.Segments = myPathSegmentCollection;

                PathFigureCollection pthFigureCollection = new PathFigureCollection();
                pthFigureCollection.Add(pthFigure);

                PathGeometry pthGeometry = new PathGeometry();
                pthGeometry.Figures = pthFigureCollection;

                Path arcPath = new Path();
                arcPath.Stroke = new SolidColorBrush(Colors.Black);
                arcPath.StrokeThickness = 1;
                arcPath.Data = pthGeometry;
                viewCanvas.Children.Add(arcPath);
                //Vẽ thép lớp trên 1
                for (int i = 0; i < RebarNumberTop; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberTop - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16);
                    viewCanvas.Children.Add(ellipse);
                }

                //Vẽ thép lớp dưới 1
                for (int i = 0; i < RebarNumberBot; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberBot - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + BeamHeight - 32);
                    viewCanvas.Children.Add(ellipse);
                }
            }
        } 
    }
}
