using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Parcel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.AppLayer
{
    public class ParcelFactory
    {
        public static IParcel GetParcel(int weight, int height, int width, int depth)
        {
            var dimension = new ParcelDimension(weight,height, width, depth);
            if (weight > 50)
            {
                return new RejectParcel();
            }
            else if (weight > 10)
            {
                return new HeavyParcel(new CostByWeightCalculator(), dimension);
            }
            else if (dimension.Volumn < 1500)
            {
                return new SmallParcel(new CostByVolumnCalculator(), dimension);
            }
            else if (dimension.Volumn < 2500)
            {
                return new MediumParcel(new CostByVolumnCalculator(), dimension);
            }

            return new LargeParcel(new CostByVolumnCalculator(), dimension);
        }
    }
}
