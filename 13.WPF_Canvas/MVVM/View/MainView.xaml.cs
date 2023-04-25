using _13.WPF_Canvas.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace _13.WPF_Canvas.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainViewModel mainviewModel = new MainViewModel();
        private int _beamWidth;

        public int BeamWidth { get => _beamWidth; set => _beamWidth = value; }

        private int _beamHeight;
        public int BeamHeight { get => _beamHeight; set => _beamHeight = value; }

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        public void DrawRectange()
        {
            int v = viewCanvas.Children.Count;
            if (v > 0)
            {
                for (int i = 0; i < v;)
                {
                    viewCanvas.Children.RemoveAt(i);
                    i++;
                }
            }

            if (BeamWidth!=0 && BeamHeight!=0)
            {
                Rectangle rectangle = new Rectangle
                {
                    Width = BeamWidth,
                    Height = BeamHeight,
                    StrokeThickness = 3,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(rectangle, viewCanvas.ActualWidth / 2);
                Canvas.SetTop(rectangle, viewCanvas.ActualHeight / 2);
                viewCanvas.Children.Add(rectangle);
            }
            ////bool result = viewCanvas.Children.OfType<Rectangle>().Any<Rectangle>();
            //int v = ;
            //MessageBox.Show(v.ToString());
            ////if (result)
            //{
            //    //foreach (Rectangle rect in viewCanvas.Children())
            //    //{
            //    //    viewCanvas.Children.Remove(rect);
            //    //}    
            //}

            
        }

        private void MoveLeave_beamWidth(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            BeamWidth = int.Parse(textBox.Text);
            DrawRectange();

        }

        private void MoveLeave_beamHeight(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            BeamHeight = int.Parse(textBox.Text);
            DrawRectange();
        }
    }
}
