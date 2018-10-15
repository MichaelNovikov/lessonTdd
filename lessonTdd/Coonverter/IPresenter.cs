using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lessonTdd.Coonverter
{
    public interface IPresenter
    {
        Task<string> GetAmount(string amount, string from, string to);
    }
}
