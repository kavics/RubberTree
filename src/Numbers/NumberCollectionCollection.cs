using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumberCollectionCollection : ICollection
    {
        private ArrayList _array = new ArrayList();

        public int Count
        {
            get { return _array.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public NumberCollection this[int index]
        {
            get { return (NumberCollection)_array[index]; }
        }


        public NumberCollectionCollection()
        {
        }


        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        public void CopyTo(Array a, int index)
        {
            _array.CopyTo(a, index);
        }


        public void Add(NumberCollection item)
        {
            _array.Add(item);
        }
        public void Remove(NumberCollection item)
        {
            _array.Remove(item);
        }

    }
}
