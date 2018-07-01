using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public class ParcelDimension
    {
        public ParcelDimension(int weight, int height, int width, int depth)
        {
            Weight = weight;
            Height = height;
            Width = width;
            Depth = depth;
        }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public int Volumn
        {
            get
            {
                return Height * Width * Depth;
            }
        }
    }
}
