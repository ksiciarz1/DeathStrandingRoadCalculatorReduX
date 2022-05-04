using System;
using System.Collections.Generic;
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

namespace DeathStrandingRoadCalculatorReduX
{
    /// <summary>
    /// Interaction logic for AddPrinterWindow.xaml
    /// </summary>
    public partial class AddPrinterWindow : Window
    {
        MainWindow mainWindow;

        public AddPrinterWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.AddPrinter(NameTextBox.Text, Convert.ToInt32(MetalTextBox.Text), Convert.ToInt32(CeramicsTextBox.Text));
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
