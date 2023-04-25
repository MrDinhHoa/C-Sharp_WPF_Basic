using DevExpress.Mvvm;
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
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rectangle = System.Windows.Shapes.Rectangle;
using Brushes = System.Windows.Media.Brushes;
using DevExpress.Xpf.Core;

namespace _13.WPF_Canvas.MVVM.ViewModel
{
    public class MainViewModel: PropertyChangedBase
    {
        public static Canvas canvas = new Canvas();

        private int _beamWidth;
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

        private int _beamHeight;
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
        private int _rebarNumberTop;

        public int RebarNumberTop 
        { 
            get => _rebarNumberTop; 
          set
            {
                _rebarNumberTop = value;
                OnPropertyChanged("RebarNumberTop");
            } 
        }

        private int _rebarNumberBot;

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

                for (int i = 0; i < RebarNumberTop; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberTop - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };

                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16);
                    viewCanvas.Children.Add(ellipse);
                }

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

        //public void DrawRebarTop(Canvas viewCanvas)
        //{
        //    for (int i = 0; i < RebarNumberTop; i++)
        //    {
        //        int kcThep = (BeamWidth - 50) / (RebarNumberTop- 1);
        //        Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };

        //        Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 +  16 + kcThep *i);
        //        Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16);
        //        viewCanvas.Children.Add(ellipse);
        //    }
            

        //}

      
        
    }
}
