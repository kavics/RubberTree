using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Numbers
{
    public class Manager
    {
        #region Singleton
        private static Manager _current;

        public static Manager Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new Manager();
                    _current.Initialize();
                }
                return _current;
            }
        }


        private Manager()
        {
        }
        #endregion

        string _fileName;
        NumberTreeCollection _forest;
        Size _defaultSpaceSize;
        Size _currentSpaceSize;

        public Size DefaultSpaceSize
        {
            get
            {
                return _defaultSpaceSize;
            }
            set
            {
                _defaultSpaceSize = value;
            }
        }

        public Size CurrentSpaceSize
        {
            get
            {
                return _currentSpaceSize;
            }
            set
            {
                _currentSpaceSize = value;
            }
        }

        public NumberTreeCollection Forest
        {
            get
            {
                return _forest;
            }
        }


        private void Initialize()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            string codeBase = a.CodeBase.Remove(0, 8).Replace("/", "\\");
            string appPath = Path.GetDirectoryName(codeBase);
            _forest = new NumberTreeCollection();
            _fileName = Path.ChangeExtension(codeBase, ".data.xml");
            Load();
            _defaultSpaceSize = new Size(600, 600);
            _currentSpaceSize = _defaultSpaceSize;
        }


        public NumberTree GetTree(int numberSystem, int digits, int pow, int add)
        {
            foreach (NumberTree tree in _forest)
                if (tree.NumberSystem == numberSystem && tree.Digits == digits && tree.Pow == pow && tree.Add == add)
                    return tree;
            Console.WriteLine("Not found: {0}-{1}-{2}-{3}", numberSystem, digits, pow, add);
            NumberTree newTree = new NumberTree(numberSystem, digits, pow, add);
            _forest.Add(newTree);
            return newTree;
        }

        public void SetTree(NumberTree tree)
        {
            if (_forest.IndexOf(tree) < 0)
                _forest.Add(tree);
        }


        private void Load()
        {
            if (File.Exists(_fileName))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(_fileName);
                foreach (XmlElement xeNumberTree in xd.DocumentElement.SelectNodes("NumberTree"))
                {
                    int numsys = Convert.ToInt32(xeNumberTree.Attributes["numberSystem"].Value);
                    int digits = Convert.ToInt32(xeNumberTree.Attributes["digits"].Value);
                    int pow = Convert.ToInt32(xeNumberTree.Attributes["pow"].Value);
                    int add = Convert.ToInt32(xeNumberTree.Attributes["add"].Value);
                    NumberTree tree = new NumberTree(numsys, digits, pow, add);
                    _forest.Add(tree);
                    tree.Build();

                    XmlNodeList xnlNumbers = xeNumberTree.SelectNodes("Number");
                    for (int i = 0; i < xnlNumbers.Count; i++)
                    {
                        XmlNode xnNumber = xnlNumbers[i];
                        int val = Convert.ToInt32(xnNumber.Attributes["value"].Value.Replace(",", "."));
                        //Single x = Convert.ToSingle(xnNumber.Attributes["x"].Value.Replace(",", "."));
                        //Single y = Convert.ToSingle(xnNumber.Attributes["y"].Value.Replace(",", "."));
                        var x = float.Parse(xnNumber.Attributes["x"].Value, NumberStyles.Any, CultureInfo.InvariantCulture);
                        var y = float.Parse(xnNumber.Attributes["y"].Value, NumberStyles.Any, CultureInfo.InvariantCulture);

                        Number number = tree.Numbers[i];
                        if (number.Value != val)
                        {
                            //-- kereses
                            number = null;
                            foreach (Number num in tree.Numbers)
                            {
                                if (num.Value == val)
                                {
                                    number = num;
                                    break;
                                }
                            }
                        }
                        if (number != null)
                        {
                            number.X = x;
                            number.Y = y;
                        }
                    }
                    XmlNodeList xnlCircles = xeNumberTree.SelectNodes("Circles/Circle");
                    for (int i = 0; i < xnlCircles.Count; i++)
                    {
                        XmlNode xnCircle = xnlCircles[i];
                        NumberCircle circle = (NumberCircle)tree.Circles[i];
                        int width = Convert.ToInt32(xnCircle.Attributes["width"].Value);
                        int height = Convert.ToInt32(xnCircle.Attributes["height"].Value);
                        circle.SpaceSize = new Size(width, height);
                    }
                    tree.NormalizeCircles();
                }
            }
        }

        public void Save()
        {
            _forest.Sort();
            XmlDocument xd = new XmlDocument();
            xd.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Numbers/>");
            foreach (NumberTree tree in _forest)
            {
                XmlElement xeNumberTree = xd.CreateElement("NumberTree");
                xd.DocumentElement.AppendChild(xeNumberTree);
                xeNumberTree.SetAttribute("numberSystem", tree.NumberSystem.ToString());
                xeNumberTree.SetAttribute("digits", tree.Digits.ToString());
                xeNumberTree.SetAttribute("pow", tree.Pow.ToString());
                xeNumberTree.SetAttribute("add", tree.Add.ToString());
                foreach (Number number in tree.Numbers)
                {
                    XmlElement xeNumber = xd.CreateElement("Number");
                    xeNumberTree.AppendChild(xeNumber);
                    xeNumber.SetAttribute("value", number.Value.ToString());
                    xeNumber.SetAttribute("x", number.X.ToString(CultureInfo.InvariantCulture));
                    xeNumber.SetAttribute("y", number.Y.ToString(CultureInfo.InvariantCulture));
                }
                XmlElement xeCircles = xd.CreateElement("Circles");
                xeNumberTree.AppendChild(xeCircles);
                foreach (NumberCircle circle in tree.Circles)
                {
                    XmlElement xeCircle = xd.CreateElement("Circle");
                    xeCircles.AppendChild(xeCircle);
                    xeCircle.SetAttribute("width", circle.SpaceSize.Width.ToString());
                    xeCircle.SetAttribute("height", circle.SpaceSize.Height.ToString());
                }
            }
            xd.Save(_fileName);
        }
    }
}
