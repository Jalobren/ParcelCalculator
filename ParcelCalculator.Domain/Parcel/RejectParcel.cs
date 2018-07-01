using System;
using System.Collections.Generic;
using System.Text;
using ParcelCalculator.Domain.Calculator;
using ParcelCalculator.Domain.Enum;

namespace ParcelCalculator.Domain.Parcel
{
    public class RejectParcel : IParcel
    {
        public ParcelDimension Dimension { get; set; }

        public ParcelCategoryEnum Category { get { return ParcelCategoryEnum.Rejected; } }

        public decimal DeliveryUnitCost
        {
            get { return -1; }
        }

        public decimal DeliveryCost
        {
            get
            {
                return -1;
            }
        }
    }
}
