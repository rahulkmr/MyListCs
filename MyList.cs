using System;

namespace MyList
{
    public class List<T>
    {
        const int defaultCapacity = 4;

        T[] items;
        int count;
        public event EventHandler Changed;


        public List(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        public int Count => count;

        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < count) value = count;
                if (value != items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(items, 0, newItems, 0, count);
                    items = newItems;
                }
            }
        }

        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public T this[int index]
        {
            get { return items[index];  }
            set
            {
                items[index] = value;
                OnChanged();
            }
        }

        public void Add(T item)
        {
            if (count == Capacity) Capacity = count * 2;
            items[count] = item;
            count++;
            OnChanged();
        }

        static bool Equals(List<T> first, List<T> second)
        {
            if (Object.ReferenceEquals(first, null)) return Object.ReferenceEquals(second, null);
            if (Object.ReferenceEquals(second, null) || first.count != second.count) return false;

            for (int i = 0; i < first.count; i++) {
                if (!object.Equals(first[i], second[i])) return false;
            }
            return true;
        }

        public override bool Equals(object other) =>
            Equals(this, other as List<T>);


        public static bool operator ==(List<T> first, List<T> second) => Equals(first, second);

        public static bool operator !=(List<T> first, List<T> second) => Equals(first, second);


    }
}