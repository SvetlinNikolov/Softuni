using System;


namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int objValue = Convert.ToInt32(obj);

            if (objValue >= minValue && objValue <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
