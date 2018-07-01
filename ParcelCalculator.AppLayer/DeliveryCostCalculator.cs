using System;

namespace ParcelCalculator.AppLayer
{
    public class DeliveryCostCalculator
    {
        public static Result Calculate(int weight, int height, int width, int depth)
        {
            var parcel = ParcelFactory.GetParcel(weight, height, width, depth);
            return new Result { Cost = parcel.DeliveryCost, Category = parcel.Category.ToString() };
        }

        public static Result Calculate(string weight, string height, string width, string depth)
        {
            var result = Validator.CheckValues(weight, height, width, depth);
            if (!result.IsValid)
            {
                return new Result { Error = result.Error };
            }

            return Calculate(int.Parse(weight), int.Parse(height), int.Parse(width), int.Parse(depth));
        }
    }
}
