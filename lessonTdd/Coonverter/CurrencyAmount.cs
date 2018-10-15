using System;
namespace lessonTdd.Coonverter
{
    public struct CurrencyAmount
    {
        public decimal Amount { get; }
        public ECurrencyType Currency { get; }

        public CurrencyAmount(decimal amount, ECurrencyType currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
