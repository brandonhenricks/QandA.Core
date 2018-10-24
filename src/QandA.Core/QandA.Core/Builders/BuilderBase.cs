using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QandA.Core.Builders
{
    public abstract class BuilderBase<T> : IBuilder<T>
    {
        private readonly ILogger Logger;

        public virtual List<T> Items { get; }

        public int Count => Items.Count;

        protected BuilderBase()
        {
            Items = new List<T>();
            Logger = new NullLogger<T>();
        }

        protected BuilderBase(ILogger<IBuilder<T>> logger)
        {
            Logger = logger;
        }

        protected BuilderBase(ILogger<IBuilder<T>> logger, IList<T> items)
        {
            Items = items.ToList();
            Logger = logger;
        }

        protected BuilderBase(IList<T> items)
        {
            Items = items.ToList();
            Logger = new NullLogger<T>();
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void Add(List<T> items)
        {
            items.AddRange(items);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public virtual T Fetch(Func<T, bool> criteria)
        {
            return Items.FirstOrDefault(criteria);
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

        public void Remove(List<T> items)
        {
            var itemSet = Items.Where(x => items.Contains(x));

            foreach (var item in itemSet)
            {
                Items.Remove(item);
            }
        }
    }
}