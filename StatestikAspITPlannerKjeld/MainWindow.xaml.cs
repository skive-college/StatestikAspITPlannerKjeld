using StatestikAspITPlannerKjeld.Helpers;
using StatestikAspITPlannerKjeld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatestikAspITPlannerKjeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DB db = new DB();
            cbSElev.DataContext = db.getAllStudents();
            
        }

        private void CbSElev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbSElev.SelectedIndex != -1)
            {
                Student student = (cbSElev.SelectedItem as Student);
                mcChart.Title = student.Name;
                List<ChartValues> li = DB.getData(student.ID);
                mcChart.Palette = Util.MakePalette(li);
                ((PieSeries)mcChart.Series[0]).ItemsSource = li;

                frChart.Title = student.Name;

                List<ChartValues> fr = DB.GetDifrences(student.ID);
                ((ColumnSeries)frChart.Series[0]).ItemsSource = fr;

            }
            
        }
        
    }
}
