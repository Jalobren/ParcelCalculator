using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public class HeavyParcel : Parcel
    {
        public override ParcelCategoryEnum Category { get { return ParcelCategoryEnum.Heavy; } }

        public HeavyParcel(IDeliveryCostCalculator calculator, ParcelDimension dimension) : base(calculator, dimension)
        {
        }

        public override decimal DeliveryUnitCost { get { return 15m; } }
    }
}
