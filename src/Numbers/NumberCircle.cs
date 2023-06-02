using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumberCircle : NumberCollection
    {
        private Size _spaceSize;

        public Size SpaceSize
        {
            get
            {
                return _spaceSize;
            }
            set
            {
                _spaceSize = value;
            }
        }


        public NumberCircle(Size spaceSize)
        {
            _spaceSize = spaceSize;
        }
    }
}
