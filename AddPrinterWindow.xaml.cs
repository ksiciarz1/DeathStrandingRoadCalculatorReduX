using System;
using System.Windows;
using System.Windows.Controls;

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

        // Option to subtract inside a textbox
        private void ValueTextBoxLostFocusEvent(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;
            if (sender == NameTextBox) return;
            if (sender is TextBox)
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text.Contains('-'))
                {
                    string[] values = textBox.Text.Split('-');
                    int calculatedValue = int.Parse(values[0]) - int.Parse(values[1]);
                    textBox.Text = calculatedValue.ToString();
                    Console.WriteLine($"Calculated {calculatedValue}");
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.AddPrinter(NameTextBox.Text, Convert.ToInt32(MetalTextBox.Text), Convert.ToInt32(CeramicsTextBox.Text));
                NameTextBox.Clear();
                MetalTextBox.Clear();
                CeramicsTextBox.Clear();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) { Close(); }

    }
}
