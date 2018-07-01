using System;
using System.Collections.Generic;
using System.Text;
using ParcelCalculator.Domain.Parcel;

namespace ParcelCalculator.Domain.Calculator
{
    public class CostByWeightCalculator : IDeliveryCostCalculator
    {
        public decimal Calculate(IParcel parcel)
        {
            return parcel.DeliveryUnitCost * parcel.Dimension.Weight;
        }
    }
}
