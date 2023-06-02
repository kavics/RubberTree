using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Number
    {
        private int _value;
        private Number _child;
        private NumberCollection _parents;
        private bool _isCircleMember;
        private NumberTree _rootObject;
        private float _x;
        private float _y;
        private double _aperture;
        private double _angle;
        private int _level;

        private PointF _f1;
        private PointF _f2;
        private PointF _nextPosition;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public Number Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child = value;
            }
        }

        public NumberCollection Parents
        {
            get
            {
                return _parents;
            }
            set
            {
                _parents = value;
            }
        }

        public bool IsCircleMember
        {
            get
            {
                return _isCircleMember;
            }
            set
            {
                _isCircleMember = value;
            }
        }

        public NumberTree RootObject
        {
            get
            {
                return _rootObject;
            }
            set
            {
                _rootObject = value;
            }
        }


        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public double Aperture
        {
            get
            {
                return _aperture;
            }
            set
            {
                _aperture = value;
            }
        }

        public double Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }



        public PointF F1
        {
            get
            {
                return _f1;
            }
            set
            {
                _f1 = value;
            }
        }

        public PointF F2
        {
            get
            {
                return _f2;
            }
            set
            {
                _f2 = value;
            }
        }

        public PointF NextPosition
        {
            get
            {
                return _nextPosition;
            }
            set
            {
                _nextPosition = value;
            }
        }


        public Number(NumberTree root) : this(root, 0)
        {
        }

        public Number(NumberTree root, int value)
        {
            _rootObject = root;
            _value = value;
            _parents = new NumberCollection();
            _isCircleMember = false;
            _f1 = PointF.Empty;
            _f2 = PointF.Empty;
            _nextPosition = PointF.Empty;
        }


        public override string ToString()
        {
            int a = _value;
            int m;
            string s = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            while (a > 0)
            {
                m = a % _rootObject.NumberSystem;
                a /= _rootObject.NumberSystem;
                s = (char)(m > 9 ? 'A' + m - 10 : '0' + m) + s;
            }
            s = "00000000000000000000000000000000000000000000000000" + s;
            return s.Substring(s.Length - _rootObject.Digits);
        }

    }
}
