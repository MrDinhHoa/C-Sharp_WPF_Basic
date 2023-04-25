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



    }
}
