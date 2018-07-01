using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public class SmallParcel : Parcel
    {
        public override ParcelCategoryEnum Category { get { return ParcelCategoryEnum.Small; } }

        public SmallParcel(IDeliveryCostCalculator calculator, ParcelDimension dimension) : base(calculator, dimension)
        {
        }

        public override decimal DeliveryUnitCost { get { return 0.05m; } }
    }
}
