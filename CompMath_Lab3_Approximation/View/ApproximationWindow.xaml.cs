using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using CompMath_Lab3_Approximation.ViewModel;

namespace CompMath_Lab3_Approximation.View
{
    /// <summary>
    /// Логика взаимодействия для ApproximationWindow.xaml
    /// </summary>
    public partial class ApproximationWindow : Window
    {
        public ApproximationWindow()
        {
            InitializeComponent();
            DataContext = new ApproximationVM();
        }

        private void ScotPlotStyle()
        {
            Graphics.Plot.Add.VerticalLine(0, 1, ScottPlot.Color.FromHex("#000000"));
            Graphics.Plot.Add.HorizontalLine(0,1, ScottPlot.Color.FromHex("#000000"));
            Graphics.Plot.XLabel("X");
            Graphics.Plot.YLabel("Y");
            Graphics.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ScotPlotStyle();
        }
    }
}
