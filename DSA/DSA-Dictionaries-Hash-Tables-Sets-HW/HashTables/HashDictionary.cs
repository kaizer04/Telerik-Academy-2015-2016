﻿namespace HashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
        where K : IComparable
    {
        const int InitialValuesSize = 16;

        LinkedList<KeyValuePair<K, V>>[] values;

        public HashDictionary()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[InitialValuesSize];
        }

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.Remove(key);
                this.Add(key, value);
            }
        }

        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);

            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.values[hash].Any(p => p.Key.Equals(key));
            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ResizeAndReadValues();
            }
        }

        public bool ContainsKey(K key)
		{
			var hash = HashKey(key);
			
			if (this.values[hash] == null) 
			{
				return false;	
			}
			
			var pairs = this.values[hash];
			
			return pairs.Any(pair => pair.Key.Equals(key));
		}

        public V Find(K key)
        {
            if (!ContainsKey(key))
            {
                throw new ArgumentException("Key does not exist.");
            }

            var index = key.GetHashCode() % this.Capacity;
            var foundValue = this.values[index].First(x => x.Key.CompareTo(key) == 0).Value;

            return foundValue;
        }

        public void Remove(K key)
        {
            if (!ContainsKey(key))
            {
                throw new ArgumentException("Key does not exist.");
            }

            var index = key.GetHashCode() % this.Capacity;
            var foundKVPair = this.values[index].First(x => x.Key.CompareTo(key) == 0);

            values[index].Remove(foundKVPair);
            this.Count--;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.values)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int HashKey(K key)
        {
            var hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);

            return hash;
        }

        private void ResizeAndReadValues()
        {
            //// CASH OLD VALUES
            var cachedValues = this.values;
            //// resize
            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            //// add values
            this.Count = 0;
            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }
    }
}
