using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumberTree : IComparable
    {
        const float FORCELIMIT = 10.0f;

        Pen redpen = new Pen(Color.Red);
        Pen bluepen = new Pen(Color.Blue);
        Pen greenpen = new Pen(Color.Green);

        bool _built;
        private NumberCollection _numberVector;
        private NumberCollectionCollection _circles;
        private int _digits;
        private int _numberSystem;
        private int _modulo;
        private int _add;
        private int _pow;

        double _repulsionPow;
        double _repulsionMul;
        double _rubberPow;
        double _rubberMul;

        double _repulsionMax;
        double _rubberMax;
        double _forceMax;

        public int NumberSystem
        {
            get
            {
                return _numberSystem;
            }
            set
            {
                _numberSystem = value;
                Reset();
            }
        }

        public int Digits
        {
            get
            {
                return _digits;
            }
            set
            {
                _digits = value;
                Reset();
            }
        }

        public int Add
        {
            get
            {
                return _add;
            }
            set
            {
                _add = value;
                Reset();
            }
        }

        public int Pow
        {
            get
            {
                return _pow;
            }
            set
            {
                _pow = value;
                Reset();
            }
        }


        public NumberCollection Numbers
        {
            get
            {
                return _numberVector;
            }
        }

        public NumberCollectionCollection Circles
        {
            get
            {
                return _circles;
            }
        }


        public double RepulsionPow
        {
            get
            {
                return _repulsionPow;
            }
            set
            {
                _repulsionPow = value;
                Reset();
            }
        }

        public double RepulsionMul
        {
            get
            {
                return _repulsionMul;
            }
            set
            {
                _repulsionMul = value;
                Reset();
            }
        }

        public double RubberPow
        {
            get
            {
                return _rubberPow;
            }
            set
            {
                _rubberPow = value;
                Reset();
            }
        }

        public double RubberMul
        {
            get
            {
                return _rubberMul;
            }
            set
            {
                _rubberMul = value;
                Reset();
            }
        }


        public double RepulsionMax
        {
            get
            {
                return _repulsionMax;
            }
        }

        public double RubberMax
        {
            get
            {
                return _rubberMax;
            }
        }

        public double ForceMax
        {
            get
            {
                return _forceMax;
            }
        }


        public NumberTree() : this(2, 1, 2, 0)
        {
        }

        public NumberTree(int numberSystem, int digits, int pow, int add)
        {
            _numberSystem = numberSystem;
            _digits = digits;
            _pow = pow;
            _add = add;

            _numberVector = new NumberCollection();
            _circles = new NumberCollectionCollection();
            _built = false;

            _repulsionPow = -2;
            _repulsionMul = 500;
            _rubberPow = 2;
            _rubberMul = 1000;

            Reset();
        }


        #region Build
        public void Build()
        {
            if (_built)
                return;
            if (_digits < 1)
                throw new ApplicationException("Digits cannot be less than 1");
            if (_numberSystem < 2)
                throw new ApplicationException("NumberSystem cannot be less than 2");
            _modulo = (int)System.Math.Pow(_numberSystem, _digits);
            CalculateVectors();
            SearchCircles();
            CalculateApertures();
            CalculateAngles();
            CalculateLevels();
            CalculateCoords();
            NormalizeCircles();
            _built = true;
        }


        private void CalculateVectors()
        {
            int y;
            for (int x = 0; x < _modulo; x++)
            {
                _numberVector.Add(new Number(this, x));
            }
            for (int x = 0; x < _modulo; x++)
            {
                y = f(x);
                _numberVector[x].Child = _numberVector[y];
                _numberVector[y].Parents.Add(_numberVector[x]);
            }
        }

        private int f(int x)
        {
            for (int i = 1; i < _pow; i++)
                x *= x;
            x += _add;
            if (x < 0)
                x = -x;
            return x % _modulo;
        }


        private void SearchCircles()
        {
            int iFast, iSlow;
            for (int j = 0; j < _numberVector.Count; j++)
            {
                iFast = iSlow = j;
                do
                {
                    iFast = _numberVector[iFast].Child.Value;
                    iFast = _numberVector[iFast].Child.Value;
                    iSlow = _numberVector[iSlow].Child.Value;
                } while (iFast != iSlow);
                if (!_numberVector[iSlow].IsCircleMember)
                {
                    CreateCircle(iFast);
                }
            }
        }

        private void CreateCircle(int numberindex)
        {
            NumberCircle circle = new NumberCircle(Manager.Current.CurrentSpaceSize);
            _circles.Add(circle);
            int i = numberindex;
            do
            {
                _numberVector[i].IsCircleMember = true;
                circle.AddToCircle(_numberVector[i]);
                i = _numberVector[i].Child.Value;
            } while (i != numberindex);
        }


        private void CalculateApertures()
        {
            foreach (NumberCollection circle in _circles)
            {
                foreach (Number number in circle)
                {
                    number.Aperture = 360 / circle.Count;
                    CalculateAperture(number);
                }
            }
        }

        private void CalculateAperture(Number root)
        {
            foreach (Number parent in root.Parents)
            {
                if (!parent.IsCircleMember)
                {
                    parent.Aperture = root.Aperture / root.Parents.Count;
                    CalculateAperture(parent);
                }
            }
        }


        private void CalculateAngles()
        {
            foreach (NumberCollection circle in _circles)
            {
                for (int i = 0; i < circle.Count; i++)
                {
                    Number number = circle[i];
                    number.Angle = number.Aperture * i - number.Aperture / 2;
                    CalculateAngle(number, i);
                }
            }
        }

        private void CalculateAngle(Number root, int index)
        {
            for (int i = 0; i < root.Parents.Count; i++)
            {
                Number number = root.Parents[i];
                if (!number.IsCircleMember)
                {
                    number.Angle = root.Angle + root.Aperture / root.Parents.Count * i;
                    CalculateAngle(number, i);
                }
            }
        }


        private void CalculateLevels()
        {
            foreach (NumberCollection circle in _circles)
            {
                foreach (Number number in circle)
                {
                    number.Level = 0;
                    foreach (Number n in number.Parents)
                    {
                        CalculateLevels(n);
                    }
                }
            }
        }

        private void CalculateLevels(Number root)
        {
            foreach (Number number in root.Parents)
            {
                if (!number.IsCircleMember)
                {
                    number.Level = root.Level + 1;
                    CalculateLevels(number);
                }
            }
        }


        private void CalculateCoords()
        {
            foreach (Number number in _numberVector)
            {
                // Create the path.
                GraphicsPath myGraphicsPath = new GraphicsPath();
                myGraphicsPath.AddLine(0, 0, (number.Level + 1) * 50, 0);
                // Set the local transformation of the GraphicsPath object.
                Matrix myPathMatrix = new Matrix();
                myPathMatrix.Rotate((float)number.Angle, MatrixOrder.Append);
                myGraphicsPath.Transform(myPathMatrix);
                //
                PointF p = myGraphicsPath.GetLastPoint();
                number.X = p.X;
                number.Y = p.Y;
            }
        }
        #endregion

        public void NormalizeCircles()
        {
            foreach (NumberCollection circle in _circles)
            {
                float xmin = 0;
                float ymin = 0;
                float xmax = 0;
                float ymax = 0;
                float xoffset = 0;
                float yoffset = 0;
                NumberCollection allnumbers = CollectNumbersFromCircle(circle);
                foreach (Number number in allnumbers)
                {
                    if (number.X < xmin)
                        xmin = number.X;
                    if (number.Y < ymin)
                        ymin = number.Y;
                    if (number.X > xmax)
                        xmax = number.X;
                    if (number.Y > ymax)
                        ymax = number.Y;
                }
                xoffset = (xmax + xmin) / 2;
                yoffset = (ymax + ymin) / 2;
                foreach (Number number in allnumbers)
                {
                    number.X -= xoffset;
                    number.Y -= yoffset;
                }
            }
        }

        void Reset()
        {
            _repulsionMax = 0;
            _rubberMax = 0;
            _forceMax = 0;
        }


        public void Rubber(NumberCollection circle)
        {
            Reset();
            //---- Repulsion
            NumberCollection allnumbers = CollectNumbersFromCircle(circle);
            for (int i = 0; i < allnumbers.Count - 1; i++)
                for (int j = i + 1; j < allnumbers.Count; j++)
                    CalculateRepulsion(allnumbers[i], allnumbers[j]);
            //---- Rubber
            foreach (Number number in circle)
            {
                foreach (Number parent in number.Parents)
                {
                    CalculateRubber(number, parent);
                    if (!parent.IsCircleMember)
                        CalculateRubberBranch(parent);
                }
            }
            //---- next position = position + Repulsion + Rubber

            foreach (Number number in allnumbers)
            {
                float dx = number.F1.X + number.F2.X;
                float dy = number.F1.Y + number.F2.Y;
                if (Math.Abs(number.F1.X) > _repulsionMax)
                    _repulsionMax = number.F1.X;
                if (Math.Abs(number.F1.Y) > _repulsionMax)
                    _repulsionMax = number.F1.Y;
                if (Math.Abs(number.F2.X) > _rubberMax)
                    _rubberMax = number.F2.X;
                if (Math.Abs(number.F2.Y) > _rubberMax)
                    _rubberMax = number.F2.Y;
                if (Math.Abs(dx) > _forceMax)
                    _forceMax = dx;
                if (Math.Abs(dy) > _forceMax)
                    _forceMax = dy;
                if (dx > FORCELIMIT)
                    dx = FORCELIMIT;
                if (dy > FORCELIMIT)
                    dy = FORCELIMIT;
                if (dx < -FORCELIMIT)
                    dx = -FORCELIMIT;
                if (dy < -FORCELIMIT)
                    dy = -FORCELIMIT;
                number.NextPosition = new PointF(number.X + dx, number.Y + dy);
                number.X = number.NextPosition.X;
                number.Y = number.NextPosition.Y;
                number.F1 = PointF.Empty;
                number.F2 = PointF.Empty;
            }
        }

        void CalculateRubberBranch(Number root)
        {
            foreach (Number parent in root.Parents)
            {
                CalculateRubber(root, parent);
                if (!parent.IsCircleMember)
                    CalculateRubberBranch(parent);
            }
        }

        NumberCollection CollectNumbersFromCircle(NumberCollection circle)
        {
            NumberCollection targetCollection = new NumberCollection();
            foreach (Number number in circle)
            {
                targetCollection.Add(number);
                CollectNumbersFromBranch(number, targetCollection);
            }
            return targetCollection;
        }

        void CollectNumbersFromBranch(Number root, NumberCollection targetCollection)
        {
            foreach (Number number in root.Parents)
            {
                if (!number.IsCircleMember)
                {
                    targetCollection.Add(number);
                    CollectNumbersFromBranch(number, targetCollection);
                }
            }
        }


        void CalculateRepulsion(Number n1, Number n2)
        {
            if (n1 != n2)
            {
                double dx = n2.X - n1.X;
                double dy = n2.Y - n1.Y;
                double r = Math.Sqrt(dx * dx + dy * dy);
                if (r == 0.0)
                {
                    Random rnd = new Random();
                    dx += (rnd.NextDouble() - 0.5) / 1000000;
                    dy += (rnd.NextDouble() - 0.5) / 1000000;
                    r = Math.Sqrt(dx * dx + dy * dy);
                }
                double f = Math.Pow(r, _repulsionPow) * _repulsionMul;
                double df = f / r;
                PointF f1 = new PointF(Convert.ToSingle(-df * dx), Convert.ToSingle(-df * dy));
                PointF f2 = new PointF(Convert.ToSingle(df * dx), Convert.ToSingle(df * dy));
                n1.F1 = new PointF(Convert.ToSingle(n1.F1.X + f1.X), Convert.ToSingle(n1.F1.Y + f1.Y));
                n2.F1 = new PointF(Convert.ToSingle(n2.F1.X + f2.X), Convert.ToSingle(n2.F1.Y + f2.Y));
            }
        }

        void CalculateRubber(Number n1, Number n2)
        {
            if (n1 != n2)
            {
                double dx = n2.X - n1.X;
                double dy = n2.Y - n1.Y;
                double r = Math.Sqrt(dx * dx + dy * dy);
                double f = Math.Pow(r, _rubberPow) / _rubberMul;
                double df = f / r;
                PointF f1 = new PointF(Convert.ToSingle(df * dx), Convert.ToSingle(df * dy));
                PointF f2 = new PointF(Convert.ToSingle(-df * dx), Convert.ToSingle(-df * dy));
                n1.F2 = new PointF(Convert.ToSingle(n1.F2.X + f1.X), Convert.ToSingle(n1.F2.Y + f1.Y));
                n2.F2 = new PointF(Convert.ToSingle(n2.F2.X + f2.X), Convert.ToSingle(n2.F2.Y + f2.Y));
            }
        }


        #region IComparable Members

        public int CompareTo(object obj)
        {
            NumberTree tree = (NumberTree)obj;
            int result = this._numberSystem.CompareTo(tree._numberSystem);
            if (result == 0)
            {
                result = this._digits.CompareTo(tree._digits);
                if (result == 0)
                {
                    result = this._pow.CompareTo(tree._pow);
                    if (result == 0)
                    {
                        result = this._add.CompareTo(tree._add);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
