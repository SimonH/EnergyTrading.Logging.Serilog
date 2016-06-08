using System;
using System.Collections;
using NUnit.Framework;

namespace EnergyTrading.Logging.Serilog.Tests
{
    [TestFixture]
    public class StringFormatExtensionTests
    {
        public static IEnumerable StringFormatExtensionTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Returns(null).SetName("null input");
                yield return new TestCaseData(string.Empty, null).Returns(string.Empty).SetName("empty input");
                yield return new TestCaseData("nothing to replace", null).Returns("nothing to replace").SetName("string constant");
                yield return new TestCaseData("{Serilog} {format}", new object[] {0, 1}).Returns("{Serilog} {format}").SetName("Serilog named parameters");
                yield return new TestCaseData("{0} {1}", new object[] { 0, 1 }).Returns("{Int32} {Int32-1}").SetName("string.format formatted");
                yield return new TestCaseData("{0} {1} {3}", new object[] { new TestCaseData(), new ArgumentNullException(), new TestCaseData() }).Returns("{@TestCaseData} {@ArgumentNullException} {@TestCaseData-1}").SetName("string.format formatted using objects");
            }
        }

        [Test]
        // ReSharper disable once UseNameofExpression
        [TestCaseSource("StringFormatExtensionTestCases")]
        public string ToSerilogFormat(string format, object[] args)
        {
            return format.ToSerilogFormat(args);
        }
    }
}