using System;
using System.Collections.Generic;
using System.Text;

namespace QandA.Core.Factories
{
    internal interface IFactory<T>
    {
        T Create();
    }
}
