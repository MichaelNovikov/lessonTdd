using System;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public interface IRatioSource
    {
        Task<decimal> GetRatio(ECurrencyType from, ECurrencyType to);
    }
}
