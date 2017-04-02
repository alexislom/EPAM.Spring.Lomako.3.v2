using System;
using System.Globalization;
using System.Linq;
using System.Text;

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

            if (number < 0)
            {
                isNegative = true;
                number = Math.Abs(number);
            }

            var sb = new StringBuilder();

            do
            {
                sb.Append(digits[number % 16]);
                number /= 16;

            } while (number != 0);

            return (isNegative ? "-" : "") + "0x" + new string(sb.ToString().Reverse().ToArray());
        }
    }
}
