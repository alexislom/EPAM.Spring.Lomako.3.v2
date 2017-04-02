using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;
using Task2Logic;


namespace Task2Tests
{
    [TestFixture]
    public class HexFormatterTests
    {
        [Test]
        [TestCase(0, Result = "0")]
        [TestCase(4, Result = "4")]
        [TestCase(27, Result = "1B")]
        [TestCase(int.MaxValue, Result = "7FFFFFFF")]
        [TestCase(int.MinValue, Result = "80000000")]
        public string ToHexStringTest(int number)
        {
            return string.Format(new HexFormatter(), "{0:X}", number);
        }

        [Test]
        [TestCase(-24, Result = "FFFFFFE8")]
        [TestCase(-240, Result = "FFFFFF10")]
        public string ToHexStringTest_Negative(int number)
        {
            return string.Format(new HexFormatter(), "{0:X}", number);
        }

        [Test]
        [TestCase(145, Result = "0x91")]
        [TestCase(-145, Result = "-0x91")]
        [TestCase(0, Result = "0x0")]
        [TestCase(41837, Result = "0xA36D")]
        [TestCase(47, Result = "0x2F")]
        [TestCase(47.2, ExpectedException = typeof(ArgumentException))]
        public string Format_Test(object number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IFormatProvider fp = new HexFormatter();

            return string.Format(fp, "{0:H}", number);
        }

        [Test]
        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        public string ParentFormat_Test(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IFormatProvider fp = new HexFormatter();

            return string.Format(fp, format, number);
        }
    }
}
