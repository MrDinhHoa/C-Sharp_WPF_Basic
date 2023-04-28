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
        private int _frameWidth = 400;
        public int FrameWidth
        {
            get
            {
                return _frameWidth;
            }
            set
            {
                _frameWidth = value;
                OnPropertyChanged("FrameWidth");
            }
        }

        private int _frameHeight = 700;
        public int FrameHeight
        {
            get
            {
                return _frameHeight;
            }
            set
            {
                _frameHeight = value;
                OnPropertyChanged("FrameHeight");
            }
        }

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

        private int _rebarNumberTop1 = 2;
        public int RebarNumberTop1 
        { 
            get => _rebarNumberTop1; 
          set
            {
                _rebarNumberTop1 = value;
                OnPropertyChanged("RebarNumberTop1");
            } 
        }

        private bool _isTop2Check = false;
        public bool IsTop2Check
        {
            get => _isTop2Check;
            set
            {
                _isTop2Check = value;
                OnPropertyChanged("IsTop2Check");
            }
        }    

        private int _rebarNumberTop2;
        public int RebarNumberTop2
        {
            get => _rebarNumberTop2;
            set
            {
                _rebarNumberTop2 = value;
                OnPropertyChanged("RebarNumberTop2");
            }
        }

        private int _rebarNumberBot1 = 2;
        public int RebarNumberBot1
        {
            get => _rebarNumberBot1;
            set
            {
                _rebarNumberBot1 = value;
                OnPropertyChanged("RebarNumberBot");
            }
        }

        private bool _isBot2Check = false;
        public bool IsBot2Check
        {
            get => _isBot2Check;
            set
            {
                _isBot2Check = value;
                OnPropertyChanged("IsBot2Check");
            }
        }

        private int _rebarNumberBot2 = 2;
        public int RebarNumberBot2
        {
            get => _rebarNumberBot2;
            set
            {
                _rebarNumberBot2 = value;
                OnPropertyChanged("RebarNumberBot2");
            }
        }

        private int _rebarDiaTop1 = 22;
        public int RebarDiaTop1
        {
            get => _rebarDiaTop1;
            set
            {
                _rebarDiaTop1 = value;
                OnPropertyChanged("RebarDiaTop1");
            }
        }

        private int _rebarDiaTop2 = 20;
        public int RebarDiaTop2
        {
            get => _rebarDiaTop2;
            set
            {
                _rebarDiaTop2 = value;
                OnPropertyChanged("RebarDiaTop2");
            }
        }


        private int _rebarDiaBot1 = 18;
        public int RebarDiaBot1
        {
            get => _rebarDiaBot1;
            set
            {
                _rebarDiaBot1 = value;
                OnPropertyChanged("RebarDiaBot1");
            }
        }

        private int _rebarDiaBot2 = 16;
        public int RebarDiaBot2
        {
            get => _rebarDiaBot2;
            set
            {
                _rebarDiaBot2 = value;
                OnPropertyChanged("RebarDiaBot2");
            }
        }



        public void DrawBeamSetion(Canvas viewCanvas)
        {
            viewCanvas.Children.Clear();
            if (BeamWidth != 0 && BeamHeight != 0)
            {

                #region Vẽ khung 
                Rectangle rectangleBeamNote = new Rectangle
                {
                    Width = FrameWidth,
                    Height = FrameHeight,
                    StrokeThickness = 0.5,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(rectangleBeamNote, viewCanvas.ActualWidth / 2 - FrameWidth / 2);
                Canvas.SetTop(rectangleBeamNote, viewCanvas.ActualHeight / 2 - FrameHeight / 2);
                viewCanvas.Children.Add(rectangleBeamNote);

                for (int i = 1; i<4; i++)
                {
                    Rectangle rectangleBeamFrame = new Rectangle
                    {
                        Width = FrameWidth,
                        Height = 35,
                        StrokeThickness = 0.5,
                        Stroke = Brushes.Black
                    };
                    Canvas.SetLeft(rectangleBeamFrame, viewCanvas.ActualWidth / 2 - FrameWidth / 2);
                    Canvas.SetBottom(rectangleBeamFrame, viewCanvas.ActualHeight / 2 - FrameHeight / 2 + 35*i);
                    viewCanvas.Children.Add(rectangleBeamFrame);
                }
                #endregion

                #region Vẽ tiết diện dầm
                Rectangle rectangle = new Rectangle
                {
                    Width = BeamWidth,
                    Height = BeamHeight,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(rectangle, viewCanvas.ActualWidth / 2 - BeamWidth / 2);
                Canvas.SetTop(rectangle, viewCanvas.ActualHeight / 2 - BeamHeight / 2 - 80);

                viewCanvas.Children.Add(rectangle);
                #endregion

                #region Vẽ thép đai 2 nhánh dầm
                PathGeometry pthGeometry = MainModel.GetStirrupPath(BeamWidth - 25, BeamHeight - 25, 15);
                Path arcPath = new Path();
                arcPath.Stroke = new SolidColorBrush(Colors.Black);
                arcPath.StrokeThickness = 3;
                arcPath.Data = pthGeometry;
                Canvas.SetLeft(arcPath, viewCanvas.ActualWidth / 2 - (BeamWidth - 25)/ 2);
                Canvas.SetTop(arcPath, viewCanvas.ActualHeight / 2 - (BeamHeight - 25) / 2 - 80);
                viewCanvas.Children.Add(arcPath);
                #endregion

                #region Vẽ thép lớp trên 1
                for (int i = 0; i < RebarNumberTop1; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberTop1 - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16 - 80);
                    viewCanvas.Children.Add(ellipse);
                }
                #endregion

                #region Vẽ thép lớp trên 2
                if(IsTop2Check)
                {
                    if(RebarNumberTop2 >= 2)
                    {
                        for (int i = 0; i < RebarNumberTop2; i++)
                        {
                            int kcThep = (BeamWidth - 50) / (RebarNumberTop2 - 1);
                            Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                            Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                            Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + 16 + 30 - 80);
                            viewCanvas.Children.Add(ellipse);
                        }
                    }    
                }

                #endregion

                #region Vẽ thép lớp dưới 1
                for (int i = 0; i < RebarNumberBot1; i++)
                {
                    int kcThep = (BeamWidth - 50) / (RebarNumberBot1 - 1);
                    Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                    Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                    Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + BeamHeight - 32 - 80);
                    viewCanvas.Children.Add(ellipse);
                }
                #endregion

                #region Vẽ thép lớp dưới 2

                if(IsBot2Check)
                {
                    if(RebarNumberBot2 >= 2)
                    {
                        for (int i = 0; i < RebarNumberBot2; i++)
                        {
                            int kcThep = (BeamWidth - 50) / (RebarNumberBot2 - 1);
                            Ellipse ellipse = new Ellipse { Height = 16, Width = 16, StrokeThickness = 1, Stroke = Brushes.Black, Fill = Brushes.Black };
                            Canvas.SetLeft(ellipse, viewCanvas.ActualWidth / 2 - BeamWidth / 2 + 16 + kcThep * i);
                            Canvas.SetTop(ellipse, viewCanvas.ActualHeight / 2 - BeamHeight / 2 + BeamHeight - 32 - 30 - 80);
                            viewCanvas.Children.Add(ellipse);
                        }
                    }    
                }
                
                #endregion

                #region Ghi chú thép lớp trên
                TextBlock noteThepTop = new TextBlock();
                noteThepTop.Width = viewCanvas.ActualWidth;
                noteThepTop.Height = 30;
                noteThepTop.TextAlignment = TextAlignment.Center;
                noteThepTop.FontFamily = new FontFamily("Arial Narrow");
                noteThepTop.FontSize = 20;
                if(IsTop2Check)
                {
                    if (RebarNumberTop2 >= 2)
                    { noteThepTop.Text = RebarNumberTop1.ToString() + "T" + RebarDiaTop1.ToString() + "+" + RebarNumberTop2.ToString() + "T" + RebarDiaTop2.ToString(); }
                    else { noteThepTop.Text = RebarNumberTop1.ToString() + "T" + RebarDiaTop1.ToString(); }
                }
                else
                {
                    noteThepTop.Text = RebarNumberTop1.ToString() + "T" + RebarDiaTop1.ToString();
                }

                Canvas.SetBottom(noteThepTop, viewCanvas.ActualHeight / 2 - FrameHeight / 2 + 35 * 3);
                viewCanvas.Children.Add(noteThepTop);
                #endregion

                #region Ghi chú thép lớp dưới
                TextBlock noteThepBot = new TextBlock();
                noteThepBot.Width = viewCanvas.ActualWidth;
                noteThepBot.Height = 30;
                noteThepBot.TextAlignment = TextAlignment.Center;
                noteThepBot.FontFamily = new FontFamily("Arial Narrow");
                noteThepBot.FontSize = 20;
                noteThepBot.Text = RebarNumberBot1.ToString() + "T" + RebarDiaBot1.ToString();
                Canvas.SetBottom(noteThepBot, viewCanvas.ActualHeight / 2 - FrameHeight / 2 + 35 * 2);
                viewCanvas.Children.Add(noteThepBot);
                #endregion

                #region Vẽ dim Width
                PathGeometry dimWidthGeometry = MainModel.GetWidthDimRectangle(BeamWidth);
                Path dimWidthPath = new Path();
                dimWidthPath.Stroke = new SolidColorBrush(Colors.Black);
                dimWidthPath.StrokeThickness = 1;
                dimWidthPath.Data = dimWidthGeometry;
                Canvas.SetLeft(dimWidthPath, viewCanvas.ActualWidth / 2 - BeamWidth  / 2);
                Canvas.SetTop(dimWidthPath, viewCanvas.ActualHeight / 2 + BeamHeight / 2 + 50 - 80);
                viewCanvas.Children.Add(dimWidthPath);
                TextBlock dimWidth = new TextBlock();
                dimWidth.Width = viewCanvas.ActualWidth;
                dimWidth.TextAlignment = TextAlignment.Center;
                dimWidth.FontFamily = new FontFamily("Arial Narrow");
                dimWidth.FontSize = 25;
                dimWidth.Text = BeamWidth.ToString();
                Canvas.SetTop(dimWidth, viewCanvas.ActualHeight / 2 + BeamHeight / 2 + 20 - 80);
                viewCanvas.Children.Add(dimWidth);
                #endregion

                #region Vẽ dim Height
                PathGeometry dimHeightGeometry = MainModel.GetHeightDimRectangle(BeamHeight);
                Path dimHeightPath = new Path();
                dimHeightPath.Stroke = new SolidColorBrush(Colors.Black);
                dimHeightPath.StrokeThickness = 1;
                dimHeightPath.Data = dimHeightGeometry;
                Canvas.SetLeft(dimHeightPath, viewCanvas.ActualWidth / 2 - BeamWidth / 2-50);
                Canvas.SetTop(dimHeightPath, viewCanvas.ActualHeight / 2 - BeamHeight / 2 - 80);
                viewCanvas.Children.Add(dimHeightPath);
                TextBlock dimHeight = new TextBlock();
                dimHeight.Height = viewCanvas.ActualHeight;
                dimHeight.TextAlignment = TextAlignment.Center;
                dimHeight.FontFamily = new FontFamily("Arial Narrow");
                dimHeight.FontSize = 25;
                dimHeight.LayoutTransform = new RotateTransform(-90,0,0);
                dimHeight.Text = BeamHeight.ToString();
                Canvas.SetTop(dimHeight, viewCanvas.ActualHeight / 2 - 80);
                Canvas.SetLeft(dimHeight, viewCanvas.ActualWidth/2 - BeamWidth/2 - 80);
                viewCanvas.Children.Add(dimHeight);
                #endregion
            }
        }
    }
}
