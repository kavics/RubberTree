using System.Collections;

namespace Numbers;

public class NumberCollectionCollection : ICollection
{
    private readonly ArrayList _array = new();
    public int Count => _array.Count;
    public object SyncRoot => this;
    public bool IsSynchronized => false;
    public NumberCollection this[int index] => (NumberCollection)_array[index];

    public IEnumerator GetEnumerator() => _array.GetEnumerator();
    public void CopyTo(Array a, int index) { _array.CopyTo(a, index); }
    public void Add(NumberCollection item) { _array.Add(item); }
    public void Remove(NumberCollection item) { _array.Remove(item); }
}