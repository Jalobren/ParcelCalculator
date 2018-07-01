using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public class MediumParcel : Parcel
    {
        public override ParcelCategoryEnum Category { get { return ParcelCategoryEnum.Medium; } }

        public MediumParcel(IDeliveryCostCalculator calculator, ParcelDimension dimension) : base(calculator, dimension)
        {
        }

        public override decimal DeliveryUnitCost { get { return 0.04m; } }
    }
}
