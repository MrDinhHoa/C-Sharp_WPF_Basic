using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;
using SharpDX.Direct2D1.Effects;

namespace _13A.WPF_Canvas
{
    class ViewModel: PropertyChangedBase
    {
        public ObservableCollection<MyLine> Lines { get; set; }
        this.PropertyChanged += this.ViewModel_PropertyChanged;
        this.Scale = 1;
        this.TranslateX = 0;
        this.TranslateY = 0;
        DrawCanvas=new Canvas();
            var line = new Line();
            line.X1= 1;
        line.Y1 = 1;
        line.X2 = 100;
        line.Y2 = 10;
        line.Stroke=new SolidColorBrush(Colors.Green);
            line.StrokeThickness = 2;
        line.Visibility=Visibility.Visible;
        DrawCanvas.Children.Add(line);
    }
}
