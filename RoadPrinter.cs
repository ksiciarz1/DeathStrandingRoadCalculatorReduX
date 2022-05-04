using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathStrandingRoadCalculatorReduX
{
    public class RoadPrinter
    {
        public string? Name { get; set; }
        public int? MetalSum { get; set; }
        public int? CeramicSum { get; set; }

        public int[] Metals = new int[7];
        public int[] Ceramics = new int[7];

        public static readonly int[] MetalsSizes = { 50, 100, 200, 400, 600, 800, 1000 };
        public static readonly int[] CeramicsSizes = { 40, 80, 160, 320, 480, 640, 800 };


        public RoadPrinter() { }

        public RoadPrinter(int index, int metal, int ceramics) : this($"Road Printer {index}", metal, ceramics) { }


        public RoadPrinter(string name, int metal, int ceramics)
        {
            Name = name;
            MetalSum = metal;
            CeramicSum = ceramics;

            for (int i = 6; i >= 0; i--)
            {
                while (metal >= MetalsSizes[i])
                {
                    Metals[i]++;
                    metal -= MetalsSizes[i];
                }
                while (ceramics >= CeramicsSizes[i])
                {
                    Ceramics[i]++;
                    ceramics -= CeramicsSizes[i];
                }

                if (i == 0)
                {
                    while (metal > 0)
                    {
                        Metals[i]++;
                        metal -= MetalsSizes[i];
                    }
                    while (ceramics > 0)
                    {
                        Ceramics[i]++;
                        ceramics -= CeramicsSizes[i];
                    }
                }
            }
        }
    }
}
