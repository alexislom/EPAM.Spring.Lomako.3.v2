using System;
using System.Globalization;


namespace Task2Logic
{
    public class HexFormatter : ICustomFormatter, IFormatProvider
    {
        private readonly IFormatProvider parent;

        public HexFormatter() : this(CultureInfo.CurrentCulture) { }

        public HexFormatter(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format.ToUpperInvariant() == "H")
            {
                if (arg is int)
                    return ToHexString((int)arg);
                throw new ArgumentException("Argument must be integer value");
            }
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, parent);
            return arg != null ? arg.ToString() : string.Empty;
        }

        private static string ToHexString(int number)
        {
            bool isNegative = false;
            const string digits = "0123456789ABCDEF";

            if (number == 0)
                return "0x0";
            if (number < 0)
            {
                isNegative = true;
                number = Math.Abs(number);
            }

            string hex = string.Empty;
            while (number > 0)
            {
                int digit = number % 16;
                hex = digits[digit] + hex;
                number = number / 16;
            }
            hex = "0x" + hex;
            if (isNegative)
                hex = "-" + hex;
            return hex;
        }
    }
}
