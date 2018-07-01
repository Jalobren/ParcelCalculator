using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCalculator.AppLayer
{
    public interface IValidator
    {
        ValidatorResult CheckValues(string weight, string height, string width, string depth);
    }

    public class Validator : IValidator
    {
        public ValidatorResult CheckValues(string weight, string height, string width, string depth)
        {
            int intValue = -1;
            var errorMsg = new StringBuilder();
            var hasError = false;
            errorMsg.Append("The following values are invalid:");
            if (!int.TryParse(weight, out intValue) || intValue < 0)
            {
                errorMsg.Append(" Weight,");
                hasError = true;
            }
            if (!int.TryParse(height, out intValue) || intValue < 0)
            {
                errorMsg.Append(" Height,");
                hasError = true;
            }
            if (!int.TryParse(width, out intValue) || intValue < 0)
            {
                errorMsg.Append(" Width,");
                hasError = true;
            }
            if (!int.TryParse(depth, out intValue) || intValue < 0)
            {
                errorMsg.Append(" Depth,");
                hasError = true;
            }
            if (hasError)
            {
                return new ValidatorResult { IsValid = false, Error = errorMsg.ToString().TrimEnd(',') };
            }
            return new ValidatorResult { IsValid = true };
        }
    }
}
