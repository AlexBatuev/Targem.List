using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Targem.List
{
    class MyList<T> : IList<T>
    {
        private T[] _items = new T[8];

        public MyList()
        {
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                ResizeItems();
            }

            _items[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Invalid target array length", nameof(array));
            }

            for (var i = 0; i < Count; i++)
            {
                array.SetValue(_items[i], arrayIndex++);
            }
        }

        public int Count { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Take(Count).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (item != null && item.Equals(_items[i]))
                {
                    return i;
                }

            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (Count == _items.Length)
                ResizeItems();
                    
            for (var i = Count - 1; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            Count++;
        }

        public bool IsReadOnly => false;

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (var i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            Count--;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _items[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                _items[index] = value;
            }
        }

        private void ResizeItems()
        {
            Array.Resize(ref _items, _items.Length * 2); // todo
        }
    }
}
