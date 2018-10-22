using System;
using System.Collections.Generic;
using System.Text;

namespace QandA.Core.Builders
{
    public interface IBuilder<T>
    {
        List<T> Items { get; set; }

        int Count { get; }

        void Add(T item);

        void Add(List<T> items);

        void Remove(T item);

        void Remove(List<T> items);

        void Clear();

        T Fetch(Func<T, bool> criteria);
    }
}
