using System;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public class RatioSourceStub : IRatioSource
    {
        public async Task<decimal> GetRatio(ECurrencyType from, ECurrencyType to)
        {
            return 2M;
        }
    }
}
