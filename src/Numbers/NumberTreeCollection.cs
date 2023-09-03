using System.Collections;

namespace Numbers
{
    public class NumberTreeCollection : ICollection
    {
        private ArrayList _array;
        public int Count => _array.Count;
        public object SyncRoot => this;
        public bool IsSynchronized => false;
        public NumberTree this[int index] => (NumberTree)_array[index];

        public NumberTreeCollection() { _array = new ArrayList(); }

        public void CopyTo(Array a, int index) { _array.CopyTo(a, index); }
        public IEnumerator GetEnumerator() { return _array.GetEnumerator(); }
        public void Add(NumberTree item) { _array.Add(item); }
        public void Remove(NumberTree item) { _array.Remove(item); }
        public void Clear() { _array.Clear(); }
        public int IndexOf(NumberTree item) { return _array.IndexOf(item); }

        public void Sort() { _array.Sort(); }
    }
}
