using System;
using lessonTdd.Coonverter;
using NUnit.Framework;

namespace LessonTddTest
{
    [TestFixture]
    public class CurrencyAmountTest
    {
        [Test]
        public void CtorTest()
        {
            //Given
            var amount = 2m;
            var currency = ECurrencyType.USD;

            //When
            var curAmount = new CurrencyAmount(amount, currency);

            //Then
            Assert.AreEqual(amount, curAmount.Amount);
            Assert.AreEqual(currency, curAmount.Currency);
        }
    }
}
