using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    /// <summary>
    /// Summary description for Numbers.
    /// </summary>
    public class NumberCollection : ICollection
    {
        private ArrayList _array;

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


        public Number this[int index]
        {
            get { return (Number)_array[index]; }
        }


        public NumberCollection()
        {
            _array = new ArrayList();
        }


        public void CopyTo(Array a, int index)
        {
            _array.CopyTo(a, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }


        public void Add(Number item)
        {
            _array.Add(item);
        }

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


        public void Remove(Number item)
        {
            _array.Remove(item);
        }

        public void Clear()
        {
            _array.Clear();
        }

    }
}
