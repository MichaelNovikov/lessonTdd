using System;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public class ConverterInteractor : IConverterInteractor
    {
        private readonly IRatioSource _ratioSource;

        public ConverterInteractor(IRatioSource ratioSource)
        {
            _ratioSource = ratioSource ?? throw new ArgumentNullException(nameof(ratioSource));
        }

        public async Task<CurrencyAmount> Convert(CurrencyAmount amount, ECurrencyType currencyTo)
        {
            decimal ratio = 0;
            try
            {
                ratio = await _ratioSource.GetRatio(amount.Currency, currencyTo);
            }
            catch(Exception ex)
            {
                throw new ConvertException(ex.Message);
            }

            return new CurrencyAmount(amount.Amount * ratio, currencyTo);
        }
    }
}
