using System;
using System.Windows;

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
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) { Close(); }
    }
}
