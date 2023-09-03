using System.Collections;

namespace Numbers;

public class NumberCollection : ICollection
{
    private readonly ArrayList _array = new();
    public int Count => _array.Count;
    public object SyncRoot => this;
    public bool IsSynchronized => false;
    public Number this[int index] => (Number)_array[index];

    public void CopyTo(Array a, int index) { _array.CopyTo(a, index); }
    public IEnumerator GetEnumerator() { return _array.GetEnumerator(); }
    public void Add(Number item) { _array.Add(item); }
    public void Remove(Number item) { _array.Remove(item); }
    public void Clear() { _array.Clear(); }

    public void AddToCircle(Number item)
    {
        _array.Add(item);
        //---- special logic
        ArrayList del = new ArrayList();
        foreach (Number root in this)
        {
            del.Clear();
            foreach (Number n in root.Parents)
            {
                if (n.Value == item.Value)
                {
                    del.Add(n);
                }
            }
            for (int i = 0; i < del.Count; i++)
            {
                //root.Parents.Remove((Number)del[i]);
            }
        }
    }
}