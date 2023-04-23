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

namespace _13.WPF_Canvas.MVVM.ViewModel
{
    class MainViewModel: PropertyChangedBase
    {
        public static MainView CanvasVM = new MainView();

        private double _beamWidth;
        public double BeamWidth
        {
            get
            {
                return Convert.ToDouble(BeamWidthText);
            }
            set
            {
                _beamWidth = value;
                OnPropertyChanged("BeamWidth");
                OnPropertyChanged("BeamWidthText");
            }
        }

        private double _beamHeight;
        public double BeamHeight
        {
            get 
            {   
                
                return Convert.ToDouble(BeamHeightText);
            }
            set
            {
                _beamHeight = value;
                OnPropertyChanged("BeamHeight");
                OnPropertyChanged("BeamHeightText");
            }
        }

       

        private string _beamWidthText;
        public string BeamWidthText
        {
            get
            {
                return _beamWidthText;
            }
            set
            {
                _beamWidthText = value;
                OnPropertyChanged("BeamWidthText");
            }
        }


        private string _beamHeightText;
        public string BeamHeightText
        {
            get
            {
                return _beamHeightText;
            }
            set
            {
                _beamHeightText = value;
                OnPropertyChanged("BeamHeightText");
            }
        }

    }
}
