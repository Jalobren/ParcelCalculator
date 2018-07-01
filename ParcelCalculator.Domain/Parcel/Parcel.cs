using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;
using System;

namespace ParcelCalculator.Domain.Parcel
{
    public abstract class Parcel : IParcel
    {
        private IDeliveryCostCalculator _calculator;

        public ParcelDimension Dimension { get; set; }

        public decimal DeliveryCost
        {
            get
            {
                return _calculator.Calculate(this);
            }
        }
        
       
        public abstract decimal DeliveryUnitCost { get; }
        public abstract ParcelCategoryEnum Category { get; }

        public Parcel(IDeliveryCostCalculator calculator, ParcelDimension dimension)
        {
            _calculator = calculator;
            Dimension = dimension;
        }

    }
}
