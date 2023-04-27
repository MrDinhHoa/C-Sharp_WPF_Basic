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
using FontFamily = System.Windows.Media.FontFamily;

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
                PathGeometry pthGeometry = MainModel.GetStirrupPath(BeamWidth - 25, BeamHeight - 25, 15);
                Path arcPath = new Path();
                arcPath.Stroke = new SolidColorBrush(Colors.Black);
                arcPath.StrokeThickness = 3;
                arcPath.Data = pthGeometry;
                Canvas.SetLeft(arcPath, viewCanvas.ActualWidth / 2 - (BeamWidth - 25)/ 2);
                Canvas.SetTop(arcPath, viewCanvas.ActualHeight / 2 - (BeamHeight - 25) / 2);
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
                noteThepTop.Width = viewCanvas.ActualWidth;
                noteThepTop.TextAlignment = TextAlignment.Center;
                noteThepTop.FontFamily = new FontFamily("Arial Narrow");
                noteThepTop.FontSize = 20;
                noteThepTop.Text = RebarNumberTop.ToString() + "T" + RebarDiaTop.ToString();
                Canvas.SetTop(noteThepTop, viewCanvas.ActualHeight / 2);
                viewCanvas.Children.Add(noteThepTop);
                #endregion

                #region Ghi chú thép lớp dưới
                TextBlock noteThepBot = new TextBlock();
                noteThepBot.Width = viewCanvas.ActualWidth;
                noteThepBot.TextAlignment = TextAlignment.Center;
                noteThepBot.FontFamily = new FontFamily("Arial Narrow");
                noteThepBot.FontSize = 20;
                noteThepBot.Text = RebarNumberBot.ToString() + "T" + RebarDiaBot.ToString();
                Canvas.SetTop(noteThepBot, viewCanvas.ActualHeight / 2 + 25);
                viewCanvas.Children.Add(noteThepBot);
                #endregion

                #region Vẽ dim Width
                PathGeometry dimWidthGeometry = MainModel.GetWidthDimRectangle(BeamWidth);
                Path dimWidthPath = new Path();
                dimWidthPath.Stroke = new SolidColorBrush(Colors.Black);
                dimWidthPath.StrokeThickness = 1;
                dimWidthPath.Data = dimWidthGeometry;
                Canvas.SetLeft(dimWidthPath, viewCanvas.ActualWidth / 2 - BeamWidth  / 2);
                Canvas.SetTop(dimWidthPath, viewCanvas.ActualHeight / 2 + BeamHeight / 2 + 50 );
                viewCanvas.Children.Add(dimWidthPath);
                TextBlock dimWidth = new TextBlock();
                dimWidth.Width = viewCanvas.ActualWidth;
                dimWidth.TextAlignment = TextAlignment.Center;
                dimWidth.FontFamily = new FontFamily("Arial Narrow");
                dimWidth.FontSize = 25;
                dimWidth.Text = BeamWidth.ToString();
                Canvas.SetTop(dimWidth, viewCanvas.ActualHeight / 2 + BeamHeight / 2 + 20);
                viewCanvas.Children.Add(dimWidth);
                #endregion

                #region Vẽ dim Height
                PathGeometry dimHeightGeometry = MainModel.GetHeightDimRectangle(BeamHeight);
                Path dimHeightPath = new Path();
                dimHeightPath.Stroke = new SolidColorBrush(Colors.Black);
                dimHeightPath.StrokeThickness = 1;
                dimHeightPath.Data = dimHeightGeometry;
                Canvas.SetLeft(dimHeightPath, viewCanvas.ActualWidth / 2 - BeamWidth / 2-50);
                Canvas.SetTop(dimHeightPath, viewCanvas.ActualHeight / 2 - BeamHeight / 2);
                viewCanvas.Children.Add(dimHeightPath);
                TextBlock dimHeight = new TextBlock();
                dimHeight.Height = viewCanvas.ActualHeight;
                dimHeight.TextAlignment = TextAlignment.Center;
                dimHeight.FontFamily = new FontFamily("Arial Narrow");
                dimHeight.FontSize = 25;
                dimHeight.LayoutTransform = new RotateTransform(-90,0,0);
                dimHeight.Text = BeamHeight.ToString();
                Canvas.SetTop(dimHeight, viewCanvas.ActualHeight / 2);
                Canvas.SetLeft(dimHeight, viewCanvas.ActualWidth/2 - BeamWidth/2 - 80);
                viewCanvas.Children.Add(dimHeight);
                #endregion
            }
        } 
    }
}
