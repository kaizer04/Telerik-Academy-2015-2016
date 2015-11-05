using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IteratorDP
{
    class ConcreteAggregate : Aggregate
    {
        private ArrayList items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return items[index]; }

            set { items.Insert(index, value); }
        }
    }
}
