using System;

namespace ParcelCalculator.AppLayer
{
    public class DeliveryCostCalculator
    {
        private IParcelFactory _parcelFactory;
        private IValidator _validator;

        public DeliveryCostCalculator(IParcelFactory parcelFactory, IValidator validator)
        {
            _parcelFactory = parcelFactory;
            _validator = validator;
        }
        public Result Calculate(int weight, int height, int width, int depth)
        {
            var parcel = _parcelFactory.GetParcel(weight, height, width, depth);
            return new Result { Cost = parcel.DeliveryCost, Category = parcel.Category.ToString() };
        }

        public Result Calculate(string weight, string height, string width, string depth)
        {
            var result = _validator.CheckValues(weight, height, width, depth);
            if (!result.IsValid)
            {
                return new Result { Error = result.Error };
            }

            return Calculate(int.Parse(weight), int.Parse(height), int.Parse(width), int.Parse(depth));
        }
    }
}
