using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origins);
    }
}
