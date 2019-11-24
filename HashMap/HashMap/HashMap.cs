using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HashMap
{
    class HashMap<TKey, TValue> : IDictionary<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        private List<KeyValuePair<TKey, TValue>>[] hashMap;
        private int capacity;
        public HashMap(int capacity)
        {
            hashMap = new List<KeyValuePair<TKey, TValue>>[capacity];
            this.capacity = capacity;
        }
        public HashMap() //default constructor-assigned capacity of 10
        {
            hashMap = new List<KeyValuePair<TKey, TValue>>[10];
            this.capacity = 10;
        }

        public TValue this[TKey key]
        {
            get
            {
                if(getValue(key).CompareTo(default(TValue)) == 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return getValue(key);
            }
            set
            {
                int index = getIndexOfPair(key);
                if(index < 0)
                {
                    throw new IndexOutOfRangeException(); //pair doesn't exist
                }
                var hash = getHashIndex(key);
                //remove the keyvaluepair and re-add it with the new value?
                Remove(hashMap[hash][index]);
                Add(key, value);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keyList = new List<TKey>();
                for(int i = 0; i < hashMap.Length; i++)
                {
                    foreach(var pair in hashMap[i])
                    {
                        keyList.Add(pair.Key);
                    }
                }
                return keyList;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> valueList = new List<TValue>();
                for(int i = 0; i < hashMap.Length; i++)
                {
                    foreach(var pair in hashMap[i])
                    {
                        valueList.Add(pair.Value);
                    }
                }
                return valueList;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            int index = getHashIndex(key);
            KeyValuePair<TKey, TValue> newPair = new KeyValuePair<TKey, TValue>(key, value);
            if(hashMap[index] == null)
            {
                hashMap[index] = new List<KeyValuePair<TKey, TValue>>();
                hashMap[index].Add(newPair);
            }
            else
            {
                if(!hashMap[index].Contains(newPair))
                {
                    hashMap[index].Add(newPair);
                }
                else
                {
                    throw new Exception("Duplicate key; not allowed");
                }
            }
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            int index = getHashIndex(item);
            if(hashMap[index] == null)
            {
                hashMap[index] = new List<KeyValuePair<TKey, TValue>>();
                hashMap[index].Add(item);
            }
            else
            {
                if (!hashMap[index].Contains(item))
                {
                    hashMap[index].Add(item);
                }
                else
                {
                    throw new Exception("Duplicate Key; not allowed");
                }
            }
            Count++;
        }

        public void Clear()
        {
            for(int i = 0; i < hashMap.Length; i++)
            {
                hashMap[i].Clear();
            }
            Count = 0; 
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach(var list in hashMap)
            {
                if(list.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            for(int i = 0; i < hashMap.Length; i++)
            {
                for(int j = 0; j < hashMap[i].Count; j++)
                {
                    if(hashMap[i][j].Key.CompareTo(key) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            int index = getHashIndex(key);
            for(int i = 0; i < hashMap[index].Count; i++)
            {
                if(hashMap[index][i].Key.CompareTo(key) == 0)
                {
                    hashMap[index].RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int bucket = getHashIndex(item);
            foreach (var pair in hashMap[bucket])
            {
                if(pair.Equals(item))
                {
                    hashMap[bucket].Remove(item);
                    return true;
                }
            }
            return false;
        }

        public void ReHash()
        {
            List<KeyValuePair<TKey, TValue>>[] tempArray = new List<KeyValuePair<TKey, TValue>>[capacity * 2];
            int index;
            for(int i = 0; i < hashMap.Length; i++)
            {
                for(int j = 0; j < hashMap[i].Count; j++)
                {
                    index = hashMap[i][j].Key.GetHashCode() % (capacity * 2);
                    if(tempArray[index] == null)
                    {
                        tempArray[index] = new List<KeyValuePair<TKey, TValue>>();
                    }
                    tempArray[index].Add(hashMap[i][j]);
                }
            }
            hashMap = tempArray;
            capacity *= 2;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        private TValue getValue(TKey key)
        {
            int index = getHashIndex(key);
            for(int i = 0; i < hashMap[index].Count; i++)
            {
                if(hashMap[index][i].Key.CompareTo(key) == 0)
                {
                    return hashMap[index][i].Value;
                }
            }

            return default(TValue);
        }

        private int getHashIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % capacity);
        }
        private int getHashIndex(KeyValuePair<TKey, TValue> item)
        {
            return Math.Abs(item.Key.GetHashCode() % capacity);
        }

        private int getIndexOfPair(TKey key)
        {
            int index = getHashIndex(key);
            for(int i = 0; i < hashMap[index].Count; i++)
            {
                if(hashMap[index][i].Key.CompareTo(key) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
