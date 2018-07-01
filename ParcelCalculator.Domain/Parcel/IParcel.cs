using ParcelCalculator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Parcel
{
    public interface IParcel
    {
        ParcelDimension Dimension { get; set; }

        decimal DeliveryCost { get; }
        decimal DeliveryUnitCost { get; }
        ParcelCategoryEnum Category { get; }
    }
}
