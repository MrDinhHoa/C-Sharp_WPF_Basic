using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _21A.WPF_ComboboxInDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DbOption
        {
            public int OptionId { get; set; }
            public string TeamName { get; set; }
        }

        public class SportSelection : INotifyPropertyChanged
        {
            public string SportName { get; set; }

            int _selectedOption;
            public int SelectedOption
            {
                get
                {
                    return _selectedOption;
                }
                set
                {
                    if (_selectedOption != value)   //  <--- put breakpoint here to prove it is updating source
                    {
                        _selectedOption = value;
                    }
                }
            }

            public List<DbOption> Options { get; set; }

            void OnPropertyChanged(string prop)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
            public event PropertyChangedEventHandler PropertyChanged;

        }

        public List<SportSelection> Sports { get; set; }

        public MainWindow()
        {
            Sports = new List<SportSelection>
            {
                new SportSelection { SportName="Football", Options = new List<DbOption> { new DbOption { TeamName = "Team A", OptionId=1}, new DbOption{TeamName="Losers", OptionId=2} }},
                new SportSelection { SportName="Baseball", SelectedOption =2, Options = new List<DbOption> { new DbOption { TeamName = "Team 1", OptionId=1}, new DbOption{TeamName="Team 2", OptionId=2} }},
            };

            DataContext = this;
        }
    }
}
