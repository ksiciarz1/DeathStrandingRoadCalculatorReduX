using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            #region HACK
            roadPrinterCollection.Add(new RoadPrinter(roadPrinterIndex, 550, 1600));
            roadPrinterIndex++;
            roadPrinterCollection.Add(new RoadPrinter(roadPrinterIndex, 1050, 1300));
            roadPrinterIndex++;
            roadPrinterCollection.Add(new RoadPrinter(roadPrinterIndex, 40, 880));
            roadPrinterIndex++;
            roadPrinterCollection.Add(new RoadPrinter(roadPrinterIndex, 650, 45));
            roadPrinterIndex++;
            #endregion

            RecalculateSum();

        }

        public void AddPrinter(string? name, int metal, int ceramics)
        {
            RoadPrinter temp;
            if (name == null || name == "")
                temp = new RoadPrinter(roadPrinterIndex, metal, ceramics);
            else
                temp = new RoadPrinter(name, metal, ceramics);

            roadPrinterCollection.Add(temp);
            RecalculateSum();
            roadPrinterIndex++;
        }

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
