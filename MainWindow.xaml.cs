using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DeathStrandingRoadCalculatorReduX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int roadPrinterIndex = 1;
        ObservableCollection<RoadPrinter> roadPrinterCollection;
        ObservableCollection<PrinterViewContext> printerSum;
        ObservableCollection<PrinterViewContext> selectedPrinterCalculated;

        public MainWindow()
        {
            roadPrinterCollection = new ObservableCollection<RoadPrinter>();
            printerSum = new ObservableCollection<PrinterViewContext>();
            selectedPrinterCalculated = new ObservableCollection<PrinterViewContext>();

            InitializeComponent();

            MainDataGrid.DataContext = roadPrinterCollection;
            CombinedDataGrid.DataContext = printerSum;
            SelectedDataGrid.DataContext = selectedPrinterCalculated;

            RecalculateSum();
        }

        public void AddPrinter(string? name, int metal, int ceramics)
        {
            RoadPrinter temp;
            if (name == null || name == "")
                temp = new RoadPrinter(roadPrinterIndex, metal, ceramics);
            else
            {
                if (name.Contains("$"))
                {
                    name = name.Replace("$", roadPrinterIndex.ToString());
                }
                temp = new RoadPrinter(name, metal, ceramics);

            }

            roadPrinterCollection.Add(temp);
            RecalculateSum();
            roadPrinterIndex++;
        }

        /// <summary>
        /// Recalculates and sets materials from all printers
        /// </summary>
        private void RecalculateSum()
        {
            printerSum.Clear();
            RoadPrinter sumPrinter = new RoadPrinter();
            foreach (var printer in roadPrinterCollection)
            {
                // Summing all printers
                for (int i = 0; i < printer.Metals.Length; i++)
                {
                    sumPrinter.Metals[i] += printer.Metals[i];
                }
                for (int i = 0; i < printer.Ceramics.Length; i++)
                {
                    sumPrinter.Ceramics[i] += printer.Ceramics[i];
                }
            }

            // Creating Printer View
            for (int i = 0; i < sumPrinter.Metals.Length; i++)
            {
                printerSum.Add(new PrinterViewContext(true, RoadPrinter.MetalsSizes[i], sumPrinter.Metals[i]));
            }
            for (int i = 0; i < sumPrinter.Ceramics.Length; i++)
            {
                printerSum.Add(new PrinterViewContext(false, RoadPrinter.CeramicsSizes[i], sumPrinter.Ceramics[i]));
            }
        }

        private void AddPrinterButton_Click(object sender, RoutedEventArgs e)
        {
            new AddPrinterWindow(this).ShowDialog();
        }

        private void DeletePrinterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainDataGrid.SelectedItem != null)
                    roadPrinterCollection.RemoveAt(MainDataGrid.SelectedIndex);
                RecalculateSum();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Shows materials required for selected printer
        /// </summary>
        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPrinterCalculated.Clear();
            RoadPrinter selectedPrinter = roadPrinterCollection[MainDataGrid.SelectedIndex];

            for (int i = 0; i < selectedPrinter.Metals.Length; i++)
            {
                selectedPrinterCalculated.Add(new PrinterViewContext(true, RoadPrinter.MetalsSizes[i], selectedPrinter.Metals[i]));
            }
            for (int i = 0; i < selectedPrinter.Ceramics.Length; i++)
            {
                selectedPrinterCalculated.Add(new PrinterViewContext(false, RoadPrinter.CeramicsSizes[i], selectedPrinter.Ceramics[i]));
            }
        }
    }
}
