using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathStrandingRoadCalculatorReduX
{
    public class PrinterViewContext
    {
        public string Identifier { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public PrinterViewContext(bool isMetal, int size, int count)
        {
            Identifier = isMetal ? "Metal" : "Ceramics";
            Size = size;
            Count = count;
        }
    }
}
