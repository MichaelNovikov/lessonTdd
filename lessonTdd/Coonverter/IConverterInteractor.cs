using System;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public interface IConverterInteractor
    {
        Task<CurrencyAmount> Convert(CurrencyAmount amount, ECurrencyType currency);
    }
}
