using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public class LargeParcel : Parcel
    {
        public override ParcelCategoryEnum Category { get { return ParcelCategoryEnum.Large; } }

        public LargeParcel(IDeliveryCostCalculator calculator, ParcelDimension dimension) : base(calculator, dimension)
        {
        }

        public override decimal DeliveryUnitCost { get { return 0.03m; } }
    }
}
