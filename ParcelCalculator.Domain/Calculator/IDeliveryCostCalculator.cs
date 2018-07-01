using ParcelCalculator.Domain.Parcel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.Domain.Calculator
{
    public interface IDeliveryCostCalculator
    {
        decimal Calculate(IParcel parcel);
    }
}
