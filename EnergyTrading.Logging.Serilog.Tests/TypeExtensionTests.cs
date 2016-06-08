using System;
using System.Collections;
using NUnit.Framework;

namespace EnergyTrading.Logging.Serilog.Tests
{
    [TestFixture]
    public class TypeExtensionTests
    {
        public static IEnumerable ShouldDeconstructCases
        {
            get
            {
                yield return new TestCaseData(1).Returns(false).SetName("int");
                yield return new TestCaseData(new TestCaseData()).Returns(true).SetName("TestCaseData type");
            }
        }

        [Test]
        public void ShouldDeconstructNull()
        {
            Assert.That(TypeExtensions.ShouldDeconstruct(null), Is.False);
        }

        [Test]
        public void ShouldDeconstructNullables()
        {
            Assert.That(new int?().ShouldDeconstruct(), Is.False);
            int? nullable = 3;
            Assert.That(nullable.ShouldDeconstruct(), Is.False);
        }

        [Test]
        // ReSharper disable once UseNameofExpression
        [TestCaseSource("ShouldDeconstructCases")]
        public bool ShouldDeconstructItem<T>(T obj)
        {
            return obj.ShouldDeconstruct();
        }
    }
}