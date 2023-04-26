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
        public MainViewModel _mainviewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();
            DataContext = _mainviewModel;
        }

        private void MoveLeave_beamSection(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //    var textBox = sender as System.Windows.Controls.TextBox;
            _mainviewModel.DrawBeamSetion(viewCanvas);
        }
    }
}
