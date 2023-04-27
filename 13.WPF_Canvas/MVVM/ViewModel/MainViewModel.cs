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
using _13.WPF_Canvas.MVVM.Model;
using TextBox = System.Windows.Controls.TextBox;
using MessageBox = System.Windows.MessageBox;

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

        private int _rebarDiaTop = 16;
        public int RebarDiaTop
        {
            get => _rebarDiaTop;
            set
            {
                _rebarDiaTop = value;
                OnPropertyChanged("RebarDiaTop");
            }
        }

        private int _rebarDiaBot = 16;
        public int RebarDiaBot
        {
            get => _rebarDiaBot;
            set
            {
                _rebarDiaBot = value;
                OnPropertyChanged("RebarDiaBot");
            }
        }

        public void DrawBeamSetion(Canvas viewCanvas)
        {
            viewCanvas.Children.Clear();
            if (BeamWidth != 0 && BeamHeight != 0)
            {
                #region Vẽ tiết diện dầm
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
                #endregion

                #region Vẽ thép đai 2 nhánh dầm
                PathGeometry pthGeometry = MainModel.GetStirrupPath(BeamWidth - 20, BeamHeight - 20, 16);
                Path arcPath = new Path();
                arcPath.Stroke = new SolidColorBrush(Colors.Black);
                arcPath.StrokeThickness = 3;
                arcPath.Data = pthGeometry;
                Canvas.SetLeft(arcPath, viewCanvas.ActualWidth / 2 - (BeamWidth - 20)/ 2);
                Canvas.SetTop(arcPath, viewCanvas.ActualHeight / 2 - (BeamHeight - 20) / 2);
                viewCanvas.Children.Add(arcPath);
                #endregion

                #region Vẽ thép lớp trên 1
                for (int i = 0; i < RebarNumberTop; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberTop - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16);
                    viewCanvas.Children.Add(ellipse);
                }
                #endregion

                #region Vẽ thép lớp dưới 1
                for (int i = 0; i < RebarNumberBot; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberBot - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + BeamHeight - 32);
                    viewCanvas.Children.Add(ellipse);
                }
                #endregion

                #region Ghi chú thép lớp trên
                TextBlock noteThepTop = new TextBlock();
                noteThepTop.TextAlignment = TextAlignment.Center;
                noteThepTop.Text = RebarNumberTop.ToString() + "T" + RebarDiaTop.ToString();
                Canvas.SetLeft(noteThepTop, viewCanvas.ActualWidth / 2 - 20);
                Canvas.SetTop(noteThepTop, viewCanvas.ActualHeight / 2);
                viewCanvas.Children.Add(noteThepTop);
                #endregion

                #region Ghi chú thép lớp dưới
                TextBlock noteThepBot = new TextBlock();
                noteThepBot.TextAlignment = TextAlignment.Center;
                noteThepBot.Text = RebarNumberBot.ToString() + "T" + RebarDiaBot.ToString();
                Canvas.SetLeft(noteThepBot, viewCanvas.ActualWidth / 2);
                Canvas.SetTop(noteThepBot, viewCanvas.ActualHeight / 2 + 20);
                viewCanvas.Children.Add(noteThepBot);

                MessageBox.Show(noteThepBot.FontSize.ToString());   
                #endregion
            }
        } 
    }
}
