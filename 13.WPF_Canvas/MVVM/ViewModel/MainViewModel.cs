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
using System.Windows;
using Microsoft.Xaml.Behaviors.Core;

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
                return _beamWidth;
            }
            set
            {
                _beamWidth = value;
                OnPropertyChanged("BeamWidth");
            }
        }

        private double _beamHeight;
        public double BeamHeight
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

        private ActionCommand _cmdUpdateBWidth;

        public ICommand CmdUpdateBWidth
        {
            get
            {
                if (_cmdUpdateBWidth == null)
                {
                    _cmdUpdateBWidth = new ActionCommand(PerformCmdUpdateBWidth);
                }

                return _cmdUpdateBWidth;
            }
        }

        private void PerformCmdUpdateBWidth(object par)
        {
            var kq = par;
            MessageBox.Show("Text");

        }

    }
}
