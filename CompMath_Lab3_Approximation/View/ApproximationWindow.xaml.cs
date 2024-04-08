using System.Windows;
using CompMath_Lab3_Approximation.ViewModel;
using ScottPlot;

namespace CompMath_Lab3_Approximation.View
{
    /// <summary>
    /// Логика взаимодействия для ApproximationWindow.xaml
    /// </summary>
    public partial class ApproximationWindow : Window
    {
        private LinePattern[] _linePatterns = Enum.GetValues<LinePattern>().ToArray();
        public ApproximationWindow()
        {
            InitializeComponent();
            DataContext = new ApproximationVM();
            if (DataContext is ApproximationVM approximationVm)
            {
                approximationVm.DrowAction += ScotPlotDraw;
                approximationVm.DrowDerivativeAction += ScotPlotDerivativeDrow;
                approximationVm.ErrorProgram += OpenErrorWindow;
            }
        }
        /// <summary>
        /// Стандартные настройки для скотплота
        /// </summary>
        private void ScotPlotStyle()
        {
            Graphics.Plot.Add.VerticalLine(0, 1, ScottPlot.Color.FromHex("#000000"));
            Graphics.Plot.Add.HorizontalLine(0,1, ScottPlot.Color.FromHex("#000000"));
            Graphics.Plot.XLabel("X");
            Graphics.Plot.YLabel("Y");
            Graphics.Refresh();
        }
        
        private void OpenErrorWindow(int errorKey)
        {
            ErrorWindow errorWindow = new(errorKey);
            errorWindow.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ScotPlotStyle();
        }
        
        /// <summary>
        /// Отрисовка скотплота
        /// </summary>
        /// <param name="func"></param>
        private void ScotPlotDraw(Func<double, double> func,double[,] table)
        {
            Graphics.Plot.Add.Function(func);
            Graphics.Plot.Axes.SetLimits(table[0,0],table[0,table.GetLength(1)-1]);
            if(table!=null)
                for (int i = 0; i < table.GetUpperBound(1)+1; i++)
                    Graphics.Plot.Add.Marker(table[0, i], table[1, i]);
        }


        private void ScotPlotDerivativeDrow(double[] x,double[] y, double[,]table)
        {
            if(x!=null && y!=null)
            {
                var myScatter = Graphics.Plot.Add.Scatter(x, y);
                myScatter.MarkerSize = 1;
                Graphics.Refresh();
                if (table != null)
                {
                    for (int i = 0; i < table.GetUpperBound(1)+1; i++)
                        Graphics.Plot.Add.Marker(table[0, i], table[1, i]);
                }
                
            }
        }
        
        

        private void ScotPlotClear(object sender, RoutedEventArgs e)
        {
            Graphics.Plot.Clear();
            ScotPlotStyle();
        }
    }
}
