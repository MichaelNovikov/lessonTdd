using System;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public class Presenter : IPresenter
    {
        private IConverterInteractor _converterInteractor;

        public Presenter(IConverterInteractor converter)
        {
            _converterInteractor = converter;
        }

        public async Task<string> GetAmount(string amountStr, string from, string to)
        {
            var fromCur = default(ECurrencyType);
            var toCur = default(ECurrencyType);
            var amount = default(decimal);

            try
            {
                amount = decimal.Parse(amountStr);
                fromCur = (ECurrencyType)Enum.Parse(typeof(ECurrencyType), from.ToUpper());
                toCur = (ECurrencyType)Enum.Parse(typeof(ECurrencyType), to.ToUpper());
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            return (await _converterInteractor.Convert(new CurrencyAmount(amount, fromCur), toCur)).ToString();
        }
    }
}
